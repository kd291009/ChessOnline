using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ChessOnline.Data;
using ChessOnline.Models;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ChessOnlineContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChessOnlineContext")));
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityContext")));
builder.Services.AddIdentity<UserInfo, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
