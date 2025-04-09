// Program.cs
var builder = WebApplication.CreateBuilder(args);

// ���������� ��������� MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ��������� ����������� ������
app.UseStaticFiles();

// ��������� ���������
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Guest}/{action=Recent}/{id?}");
});

app.Run();