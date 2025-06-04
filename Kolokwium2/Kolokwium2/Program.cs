using System.Text.Json.Serialization;
using Kolokwium2.Data;
using Kolokwium2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IgnoreNullValues = true;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});


builder.Services.AddDbContext<ApbdContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// add scoped
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();