using HastaneRandevu.Models;
using HastaneRandevu.Utility;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UygulamaDbContext>(options=>options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// _doktorRepository obj icin Dependency Injection
builder.Services.AddScoped<IDoktorRepository, DoktorRepository>();
builder.Services.AddScoped<IBolumRepository, BolumRepository>();
builder.Services.AddScoped<IRandevuRepository, RandevuRepository>();



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
