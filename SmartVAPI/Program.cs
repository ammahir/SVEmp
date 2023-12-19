using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Identity;
using SmartVision.Data;
using SmartVision.Entities;
using SmartVision.BLL;
using SmartVData;
using Microsoft.AspNetCore.Cors;
using SmartVAPI.BLL.Contracts;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:7082");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployee, EmployeeBLL>();
builder.Services.AddScoped<ITimesheet, TimesheetBLL>();
// Web API configuration and services

//builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();
//.AddApiEndPoints();

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
app.UseCors(MyAllowSpecificOrigins);

//app.MapIdentityApi<ApplicationUser>();

app.Run();
