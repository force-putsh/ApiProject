using ApiProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var ConnectionString= builder.Configuration.GetConnectionString("DemoDbConnectionString");



builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DemoDbContext>(item => item.UseSqlServer(ConnectionString));
builder.Services.AddScoped<IUserRepository,UserRepository>();
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
