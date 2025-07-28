using KullaniciListe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(Options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("database");
    Options.UseSqlite(connectionString);
});
//DataContext sınıfı, Entity Framework Core kullanarak veritabanı ile etkileşimde bulunmak için kullanılır.

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Kullanici}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
