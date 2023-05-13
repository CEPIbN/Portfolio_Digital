var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// добавляем поддержку контроллеров

var app = builder.Build();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "UserPage",
    pattern: "user",
    defaults: new {controller = "User", action="Index"});

app.Run();