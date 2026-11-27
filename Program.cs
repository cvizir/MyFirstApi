using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using MyFirstApi.Data;
using MyFirstApi.Middlewares; // 引入命名空間
using FluentValidation;
using MyFirstApi.Interfaces;
using MyFirstApi.Repositories;
using MyFirstApi.Services;
using MyFirstApi.Validators;


var builder = WebApplication.CreateBuilder(args);

// 1. 註冊 Repository 與 Service（每次 HTTP 請求建立一個實例）
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// 2. 自動掃描並註冊所有繼承 AbstractValidator 的驗證器
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();


// 註冊 Controller
builder.Services.AddControllers();

// 註冊 Swagger 服務
builder.Services.AddEndpointsApiExplorer();

// 設定 Swagger 支援 JWT 輸入介面
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "請直接貼上登入後取得的 JWT Token（不需要手動輸入 Bearer）"
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});

// 註冊 JWT 驗證規則
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});


// 註冊全域錯誤處理器與 ProblemDetails 服務
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// 3. 註冊 MySQL 資料庫連線
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionString!));

// 註冊 CORS 規則
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173", // Vite (Vue / React) 預設網址
                "http://localhost:5000",
                "http://localhost:3000"  // 其他常見前端開發網址
            )
            .AllowAnyHeader()  // 允許所有 Request Header（例如 Content-Type, Authorization）
            .AllowAnyMethod(); // 允許所有 HTTP 方法（GET, POST, PUT, DELETE, OPTIONS）
    });
});

var app = builder.Build();

// 啟用全域錯誤處理（建議放在最前面，確保能攔截後續所有中介軟體與 Controller 的錯誤）
app.UseExceptionHandler();

// 在開發環境啟用 Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 本機開發環境不強制轉址 HTTPS
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// 啟用 CORS（注意：必須放在 UseAuthorization 與 MapControllers 之前）
app.UseCors("AllowFrontend");

// 【新增步驟 C】啟用身分驗證（注意：必須放在 UseAuthorization 之前）
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();