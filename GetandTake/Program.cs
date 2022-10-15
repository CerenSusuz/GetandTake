using AutoMapper;
using GetandTake.DataAccess.Repositories;
using GetandTake.DataAccessLayer.EF;
using GetandTake.Services.Abstracts;
using GetandTake.Services.AutoMapper;
using GetandTake.Services.Concretes;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NorthwindDbContext>(
    options =>  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IProductService, ProductManager>();
builder.Services.AddTransient<ICategoryService, CategoryManager>();
builder.Services.AddTransient(typeof(IEntityRepository<>), typeof(EFEntityRepository<>));
builder.Services.AddSingleton(new MapperConfiguration(x => x.AddProfile(new AutoMapperProfile())).CreateMapper());

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
