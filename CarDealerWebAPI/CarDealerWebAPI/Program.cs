using Core.CarDealer;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Infrastructure.CarDealer;
using Infrastructure.CarDealer.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<AnnouncesContext>();
builder.Services.AddScoped<IRepository<Car>,CarRepository>();
builder.Services.AddScoped<IRepository<Message>,MessageRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
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
