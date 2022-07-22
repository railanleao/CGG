using BVS.Models.Entity.ContextBVS;
using BVS.Models.Entity.ModelBind;
using BVS.Models.Interface;
using BVS.Models.Interface.IServiceBase;
using BVS.Models.Repositories;
using BVS.Models.Service;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddApiVersioning();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<BVSContext>(opt => opt.UseNpgsql
(builder.Configuration.GetConnectionString("BVS")));
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(RepositoryBase<>));

builder.Services.AddScoped<IServiceComprador, ServiceComprador>();
builder.Services.AddScoped<IRepositoryComprador, RepositoryComprador>();

builder.Services.AddScoped<IServiceAssociado, ServiceAssociado>();
builder.Services.AddScoped<IRepositoryAssociado, RepositoryAssociado>();

builder.Services.AddScoped<IServiceInicioParceria, ServiceInicioParceria>();
builder.Services.AddScoped<IRepositoryInicioParceria, RepositoryInicioParceria>();

builder.Services.AddScoped<IServiceAlteracaoSaida, ServiceAlteracaoSaida>();
builder.Services.AddScoped<IRepositoryAlteracaoSaida, RepositoryAlteracaoSaida>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Comprador}/{action=ObterTodos}/{id?}");

app.Run();


