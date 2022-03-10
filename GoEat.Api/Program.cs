using FluentValidation.AspNetCore;
using GoEat.Application;
using GoEat.Application.Order.AddOrderItem;
using GoEat.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// add services
builder.Services.AddControllers();
    //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddOrderItemValidator>());

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSwaggerGen();

//builder.Services.AddMediatR(typeof(AddOrderItem));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    
}

//Run middleware
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();