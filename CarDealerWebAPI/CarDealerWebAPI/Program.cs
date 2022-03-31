using Core.CarDealer;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Infrastructure.CarDealer;
using Infrastructure.CarDealer.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("CarDealer");
builder.Services.AddDbContext<AnnouncesContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<IRepositoryCar,CarRepository>();
builder.Services.AddScoped<IRepositoryUser,UserRepository>();
builder.Services.AddScoped<IRepositoryMessage, MessageRepository>();
builder.Services.AddMediatR((typeof(AssemblyMarker)));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
