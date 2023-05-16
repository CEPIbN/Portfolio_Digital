using Microsoft.EntityFrameworkCore;
using MVP.Controllers;
using MVP.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// добавляем поддержку контроллеров
builder.Services.AddSingleton<IPersonRepository, FakePersonRepository>();
var app = builder.Build();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(
	name: "user",
	pattern: "users/{login}",
    defaults: new { Controller = "Content", Action = "Account" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller = Home}/{action = Index}/{id?}",
    defaults: new { Controller = "Home", Action = "Index" });



app.Run();