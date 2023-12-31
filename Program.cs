using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrganizationCrudWithMediatr.Behaviour;
using OrganizationCrudWithMediatr.Commands;
using OrganizationCrudWithMediatr.DbContext;
using OrganizationCrudWithMediatr.Models;
using OrganizationCrudWithMediatr.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<IValidator<CreateProductCommand>, CreateOrderValidation>();
builder.Services.AddScoped<IPipelineBehavior<CreateProductCommand, ProductModel>, CreateOrderBehaviour>();
builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseNpgsql("Server=localhost; Port=2005; Database=order_db; User Id=postgres; Password=postgres;");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();