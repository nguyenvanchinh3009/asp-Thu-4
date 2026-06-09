<<<<<<< HEAD
﻿using CMS.Data;
using Microsoft.EntityFrameworkCore;
=======
using Microsoft.EntityFrameworkCore;
using CMS.Data;
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
// MVC
builder.Services.AddControllersWithViews();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =========================
// CORS
// =========================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Authentication
// Authentication (Sửa phần này)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        // Fix lỗi bảo mật Cookie trên localhost
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    });

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

=======
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
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
<<<<<<< HEAD

=======
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
app.UseStaticFiles();

app.UseRouting();

<<<<<<< HEAD
// =========================
// CORS
// =========================
app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();
=======
// 2. Kích hoạt xác thực và phân quyền (Thứ tự rất quan trọng)
app.UseAuthentication(); // BƯỚC A: Xác nhận "Anh là ai?" 
app.UseAuthorization();  // BƯỚC B: Xác nhận "Anh được làm gì?" [cite: 1747]
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();