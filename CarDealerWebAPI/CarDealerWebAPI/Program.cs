using AutoMapper;
using Core.CarDealer;
using Core.CarDealer.Configurations;
using Core.CarDealer.Interfaces;
using Infrastructure.CarDealer;
using Infrastructure.CarDealer.Repositories;
using Infrastructure.CarDealer.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
builder.Services.AddScoped<IRepositoryMessage,MessageRepository>();
builder.Services.AddScoped<IRepositoryMessageTo,MessageToRepository>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWorkMessages>();
builder.Services.AddScoped<IServiceBlob,BlobService>();
builder.Services.AddScoped<IRepositoryImage,ImageRepository>();
builder.Services.AddScoped<IRepositoryUserCar,UserCarRepository>();
builder.Services.AddScoped<IRepositoryBrand,BrandRepository>();
builder.Services.AddScoped<IRepositoryCarType,CarTypeRepository>();
builder.Services.AddScoped<IRepositoryFuelType,FuelTypeRepository>();
builder.Services.AddScoped<IRepositoryRole,RoleRepository>();
builder.Services.AddScoped<IServiceAuth,AuthService>();
builder.Services.AddAutoMapper(ConfigureMapper.Configure);
builder.Services.AddScoped<BlobService>();
builder.Services.AddMediatR((typeof(AssemblyMarker)));
builder.Services.AddCors(options => options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials()));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

app.Run();
