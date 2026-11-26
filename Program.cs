using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Middlewares; // 引入命名空間

var builder = WebApplication.CreateBuilder(args);

// 註冊 Controller
builder.Services.AddControllers();

// 註冊 Swagger 服務
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

app.UseAuthorization();
app.MapControllers();

app.Run();