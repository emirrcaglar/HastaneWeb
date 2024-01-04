using HastaneRandevu.Models;
using HastaneRandevu.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix);
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR"),
        new CultureInfo("de-DE")
    };

    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("tr-TR");
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddDbContext<UygulamaDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UygulamaDbContext>().AddDefaultTokenProviders();
builder.Services.AddRazorPages();

// _doktorRepository obj icin Dependency Injection
builder.Services.AddScoped<IDoktorRepository, DoktorRepository>();
builder.Services.AddScoped<IBolumRepository, BolumRepository>();
builder.Services.AddScoped<IRandevuRepository, RandevuRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

var app = builder.Build();
app.UseRequestLocalization();

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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
