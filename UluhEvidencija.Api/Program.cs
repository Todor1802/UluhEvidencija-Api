﻿using Microsoft.EntityFrameworkCore;
using UluhEvidencija.Contract.IRepository;
using UluhEvidencija.Contract.IService;
using UluhEvidencija.Controller;
using UluhEvidencija.Migration;
using UluhEvidencija.Repository;
using UluhEvidencija.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IPaintingRepository, PaintingRepository>();
builder.Services.AddScoped<IPaintingService, PaintingService>();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<UluhEvidencijaProfile>();
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
