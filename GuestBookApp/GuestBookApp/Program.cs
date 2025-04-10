using GuestBookApp.Services;

var builder = WebApplication.CreateBuilder(args);

// ��������� ��������� ������������ � ���������������
builder.Services.AddControllersWithViews();

// ����������� DI: ��������� IFeedbackService
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

// ������������� ������� �� ���������. ���������� Guest � �������� Recent
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Guest}/{action=Recent}/{id?}");

app.Run();
