using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieApp.Arch.MediatR;
using MovieApp.Database;
using MovieApp.Handlers;
using MovieApp.Infrastucture.Controller;
using MovieApp.Services;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options => options.Filters.Add<CustomExceptionFilter>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add MovieAppDbContext
builder.Services.AddDbContext<MovieAppDbContext>(options =>
{
    var connection = builder.Configuration.GetConnectionString("DefaultConnection");
   
    options.UseSqlServer(connection);
});


//Add MediatR
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
    builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

//Add my services
builder.Services.AddMyServices();

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
