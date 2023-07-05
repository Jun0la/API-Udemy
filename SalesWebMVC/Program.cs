using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using SalesWebMVC.Data;
using SalesWebMVC.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SalesWebMVC.Data.SalesWebMVCContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMVCContext"),
    new MySqlServerVersion(new Version(8, 0, 27)), mysqlOptions =>
    {
        mysqlOptions.MigrationsAssembly("SalesWebMVC");
    }));

builder.Services.AddControllersWithViews();

//
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
//


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

/*app.Use(async (context, next) =>
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var seedingService = services.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }

    await next();
});*/


app.Run();