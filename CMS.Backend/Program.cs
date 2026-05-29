using Microsoft.EntityFrameworkCore;
using CMS.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Cấu hình dịch vụ xác thực Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        [cite_start] options.LoginPath = "/Account/Login"; // Đường dẫn đến trang đăng nhập [cite: 1741]
        options.AccessDeniedPath = "/Account/AccessDenied"; // Đường dẫn nếu không có quyền [cite: 1742]
    });

// Đăng ký ApplicationDbContext với DI Container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 2. Kích hoạt xác thực và phân quyền (Thứ tự rất quan trọng)
app.UseAuthentication(); // BƯỚC A: Xác nhận "Anh là ai?" 
app.UseAuthorization();  // BƯỚC B: Xác nhận "Anh được làm gì?" [cite: 1747]

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();