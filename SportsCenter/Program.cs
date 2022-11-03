using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using SportsCenter.DataAccess;
using SportsCenter.Services;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<UploadService>();

//Google�n�J
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    //���n�J�ɷ|�۰ʾɨ�o�Ӻ��}
    option.LoginPath = new PathString("/Register/NoLogin");
    //�S�v��
    option.AccessDeniedPath = new PathString("/Register/NoAccess");
    //�n�J�ɶ��]�m
    option.ExpireTimeSpan = TimeSpan.FromSeconds(100);
}).AddGoogle(options =>
{
    options.ClientId = builder.Configuration.GetSection("OAuth:Google:ClientId").Value;
    options.ClientSecret = builder.Configuration.GetSection("OAuth:Google:ClientSecret").Value;
    options.Events.OnCreatingTicket = ctx =>
    {
        ctx.Identity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Role, "1"));
        return Task.CompletedTask;
    };
});//����


builder.Services.AddDbContext<SportsCenterDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));



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

//�n�J����
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
