using GoEat.Infrastructure.Settings;
using GoEat.Logic.Order;
using GoEat.Logic.Order.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GoEat.Infrastructure.Context;
//TODO:map quantity, items, private backend fields
public class OrderContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Category> Categ { get; set; }

    private SqlServerSettings SqlServerSettings { get; }

    public OrderContext(SqlServerSettings sqlServerSettings )
    {
        SqlServerSettings = sqlServerSettings;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(SqlServerSettings.ConnectionString);
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        // ORDER
        // Table
        modelBuilder.Entity<Order>()
            .ToTable("Order");

        // Id
        modelBuilder.Entity<Order>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Order>()
            .Property(x => x.Id)
            .HasConversion(id => id.Value, value => new Id(value));

        // Ignore Properties

        modelBuilder.Entity<Order>()
            .Ignore(x => x.SubTotal);
        
        modelBuilder.Entity<Order>()
            .Ignore(x => x.Count);

        modelBuilder.Entity<Order>()
            .Ignore(x => x.GetAllOrderItems);

        // Map Properties

        // Add relationships
        modelBuilder.Entity<Order>()
            .HasMany(x => x.Items)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId);

        //Order Item
        modelBuilder.Entity<OrderItem>()
           .ToTable("OrderItem");

        // Id
        modelBuilder.Entity<OrderItem>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<OrderItem>()
            .Property(x => x.Id)
            .HasConversion(id => id.Value, value => new Id(value));

        modelBuilder.Entity<OrderItem>()
            .Ignore(x => x.Quantity);

        modelBuilder.Entity<OrderItem>()
            .Property(x => x.ItemQuantity)
            .HasConversion(quantity => quantity.Value, value => new Quantity(value));

        modelBuilder.Entity<OrderItem>()
            .Property(x => x.Price)
            .HasConversion(price => price.Value, value => new Price(value));

        modelBuilder.Entity<OrderItem>()
            .Property(x => x.Description);

        modelBuilder.Entity<OrderItem>()
            .Property(x => x.Name);

        // Seed Data
        var orderId = Guid.NewGuid();

        modelBuilder.Entity<Order>()
            .HasData(new Order()
            {
                Id = new Id(orderId)
            });

        modelBuilder.Entity<OrderItem>()
            .HasData(new OrderItem(
                new Id(Guid.NewGuid()),
                "King Burger" , 
                new Price(2.99M), 
                "Delicious cheese burger", 
                new Quantity())
            {
                OrderId = new Id(orderId)        
            });
    }
}
