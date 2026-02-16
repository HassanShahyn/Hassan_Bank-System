using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HassanBank.Infrastructure.Persistence;       // ✅ مسار الـ DbContext
using HassanBank.Infrastructure.Services;   // ✅ مسار الخدمات
using HassanBank.Infrastructure.Repositories; // ✅ مسار الـ UnitOfWork
using HassanBank.Domain.Interfaces;         // ✅ مسار الـ Interfaces
using HassanBank.Domain.Entities;           // ✅ مسار الـ ApplicationUser

// 🛡️ شبكة الأمان (Try-Catch) عشان نمسك أي خطأ في التشغيل
try
{
    var builder = WebApplication.CreateBuilder(args);

    // ==========================================
    // 1. قاعدة البيانات
    // ==========================================
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                              ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));

    // ==========================================
    // 2. الهوية (Identity)
    // ==========================================
    builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

    // ==========================================
    // 3. المصادقة (JWT Authentication)
    // ==========================================
    // ✅ التأكد من قراءة المفتاح من ملف الإعدادات
    var jwtKey = builder.Configuration["JWT:Key"];
    if (string.IsNullOrEmpty(jwtKey))
    {
        throw new Exception("❌ كارثة: مفتاح JWT غير موجود في ملف appsettings.json!");
    }

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)) // استخدام المفتاح
        };
    });

    // ==========================================
    // 4. تسجيل الخدمات (DI)
    // ==========================================
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<IBuyoutService, BuyoutService>();

    // ==========================================
    // 5. إعدادات الـ API
    // ==========================================
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // ==========================================
    // 6. التشغيل (Pipeline)
    // ==========================================
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    Console.WriteLine("✅ System is starting... (المكنة بتدور)");
    app.Run();
}
catch (Exception ex)
{
    // 🚨 هنا المصيدة! لو حصل خطأ هيتطبع هنا والشاشة مش هتقفل
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n**************************************************");
    Console.WriteLine("🛑 خطأ قاتل أثناء التشغيل (Fatal Error):");
    Console.WriteLine($"رسالة الخطأ: {ex.Message}");
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine($"التفاصيل: {ex.StackTrace}");
    Console.WriteLine("**************************************************\n");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("اضغط Enter عشان تقفل الشاشة...");
    Console.ReadLine(); // يمنع الإغلاق الفوري
}