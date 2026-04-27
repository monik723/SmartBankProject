var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/");
});

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();
