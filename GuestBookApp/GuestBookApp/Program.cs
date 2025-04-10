using GuestBookApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку контроллеров с представлениями
builder.Services.AddControllersWithViews();

// Регистрация DI: внедрение IFeedbackService
builder.Services.AddSingleton<IFeedbackService, FeedbackService>();

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

// Устанавливаем маршрут по умолчанию. Контроллер Guest и действие Recent
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Guest}/{action=Recent}/{id?}");

app.Run();
