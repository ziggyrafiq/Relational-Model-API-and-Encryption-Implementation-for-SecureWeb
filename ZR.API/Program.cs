/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 01 - Book Api
*  Date     :  	25/09/2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*
************************************************************************************************************/


using ZR.Business.Security;
using ZR.Business.Security.Interfaces;
using ZR.API.Extensions.ApiServiceExtensions;
using Microsoft.AspNetCore.DataProtection;
using NLog;
using Microsoft.EntityFrameworkCore.Design;
using ZR.Infrastructure.Entities;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddDataProtection();
builder.Services.AddDataProtection().PersistKeysToFileSystem(new System.IO.DirectoryInfo("@E:\\_ZR-DPAPI"));
//the default Key lifetime is set to 30 days instead of 90 days
builder.Services.AddDataProtection().SetDefaultKeyLifetime(TimeSpan.FromDays(30));


//ZR Add services to the container.
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/zr-api.nlog.config"));

//setting up DI and telling it to use the db setup
IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

builder.Services.AddScoped<IRsaCryptograper,RsaCryptograper>();


builder.Services.ConfigureLoggerService();
builder.Services.ConfigureCors();
builder.Services.ConfigureSqlDbEntitiesContext(configuration);
builder.Services.ConfigureJson();
builder.Services.ConfigureSwagger();
builder.Services.AddControllers();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
 

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication? app = builder.Build();

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
