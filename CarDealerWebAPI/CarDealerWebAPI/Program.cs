using Core.CarDealer;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries;
using Core.CarDealer.QueriesHandler;
using Infrastructure.CarDealer;
using Infrastructure.CarDealer.Repositories;
using Infrastructure.CarDealer.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions
        .ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);

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
builder.Services.AddScoped<IRepositoryMessageTo, MessageToRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkMessages>();
builder.Services.AddScoped<IConfiguration>();
builder.Services.AddScoped<BlobService>();
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
