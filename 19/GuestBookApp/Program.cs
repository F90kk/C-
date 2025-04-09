// Program.cs
var builder = WebApplication.CreateBuilder(args);

// Добавление поддержки MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Включение статических файлов
app.UseStaticFiles();

// Настройка маршрутов
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Guest}/{action=Recent}/{id?}");
});

app.Run();