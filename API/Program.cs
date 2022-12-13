using CompanyManagementSystem.Repository;
using CompanyManagementSystem.Core.Repositories;
using CompanyManagementSystem.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CompanyManagementSystem.Repository.UnitOfWorks;
using System.Net.Sockets;
using CompanyManagementSystem.Core;
using CompanyManagementSystem.Service.Services;
using CompanyManagementSystem.Service.Mapping;
using CompanyManagementSystem.Core.Services;
using FluentValidation;
using CompanyManagementSystem.Core.DTOs;
using FluentValidation.AspNetCore;
using CompanyManagementSystem.Service.Validations;
using CompanyManagementSystem.API.Filters;
using Microsoft.AspNetCore.Mvc;
using CompanyManagementSystem.API.Middlewares;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using CompanyManagementSystem.API.Modules;
using System;
using CompanyManagementSystem.Repository.AppDbContexts.AppDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepositoryServicesModules()));

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CompanyDtoValidator>());
builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfiles));


// Biz yazýyoruz
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnetion"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

// Ýsme göre deðil tipe göre çekiyoruz



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomException();


app.MapControllers();

app.Run();
