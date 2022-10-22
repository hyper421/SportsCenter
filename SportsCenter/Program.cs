using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.Table;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Google登入
builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    //未登入時會自動導到這個網址
    option.LoginPath = new PathString("/Register/NoLogin");
    //沒權限
    option.AccessDeniedPath = new PathString("/Register/NoAccess");
    //登入時間設置
    option.ExpireTimeSpan = TimeSpan.FromSeconds(100);
}).AddGoogle(option =>
{
    option.ClientId = builder.Configuration.GetSection("Auth:Google:ClientId").Value;
    option.ClientSecret = builder.Configuration.GetSection("Auth:Google:ClientSecret").Value;
});

builder.Services.AddDbContext<SportsCenterDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
//{
//    //未登入時會自動導到這個網址
//    option.LoginPath = new PathString("/Register/NoLogin");
//    //沒權限
//    option.AccessDeniedPath = new PathString("/Register/NoAccess");
//    //登入時間設置
//    option.ExpireTimeSpan = TimeSpan.FromSeconds(100);
//});


var app = builder.Build();

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

//登入驗證
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
