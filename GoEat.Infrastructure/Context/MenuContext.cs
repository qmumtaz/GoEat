using GoEat.Infrastructure.Settings;
using GoEat.Logic.Menu;
using GoEat.Logic.Order.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEat.Infrastructure.Context;

public  class MenuContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }

    private SqlServerSettings SqlServerSettings { get; }
    public MenuContext(SqlServerSettings sqlServerSettings)
    {
        SqlServerSettings = sqlServerSettings;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(SqlServerSettings.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        // Table
        modelBuilder.Entity<MenuItem>()
            .ToTable("Menu");

        // Id
        modelBuilder.Entity<MenuItem>()
            .HasKey(c => c.Id);        
        
        modelBuilder.Entity<MenuItem>()
            .Property(x => x.Id)
            .HasConversion(id => id.Value, value => new Id(value));

        modelBuilder.Entity<MenuItem>()
            .Property(x => x.CategoryId)
            .HasConversion(id => id.Value, value => new Id(value));

        // Properties
        modelBuilder.Entity<MenuItem>()
            .Property(x => x.Name);

        modelBuilder.Entity<MenuItem>()
            .Property(x => x.Description);

        modelBuilder.Entity<MenuItem>()
            .Property(x =>x.Price)
            .HasConversion(price => price.Value, value => new Price(value));

        // Relationships
        modelBuilder.Entity<MenuItem>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Menus)
            .HasForeignKey(x => x.CategoryId);


        /////////////////////
        ///

        // Table
        modelBuilder.Entity<Category>()
            .ToTable("Category");

        // Id
        modelBuilder.Entity<Category>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Category>()
            .Property(x => x.Id)
            .HasConversion(id => id.Value, value => new Id(value));

        // Properties
        modelBuilder.Entity<Category>()
            .Property(x => x.Name);
    }
 }
