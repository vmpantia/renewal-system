using Microsoft.EntityFrameworkCore;
using RS.Api.Extensions;
using RS.BAL.Helpers;
using RS.BAL.Services;
using RS.DAL.Contractors;
using RS.DAL.DataAccess;
using RS.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RSDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MigrationDb")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<SubscriptionService>();

// Add elsa workflow services to the container
builder.Services.ConfigureElsaServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
