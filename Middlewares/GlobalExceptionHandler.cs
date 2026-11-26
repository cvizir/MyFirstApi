using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    private readonly IHostEnvironment _env;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        // 1. 在後端終端機記錄完整的錯誤細節（含堆疊追蹤），方便除錯
        _logger.LogError(exception, "發生未預期的伺服器錯誤：{Message}", exception.Message);

        // 2. 組合統一的 JSON 錯誤格式
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "伺服器內部錯誤",
            // 開發環境顯示實際錯誤訊息；正式環境則隱藏細節，避免洩漏資料庫或程式結構
            Detail = _env.IsDevelopment() ? exception.Message : "系統發生未預期錯誤，請稍後再試。",
            Instance = httpContext.Request.Path
        };

        // 3. 設定 HTTP 狀態碼為 500 並回傳 JSON
        httpContext.Response.StatusCode = problemDetails.Status.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        // 回傳 true 代表錯誤已攔截並處理完畢
        return true;
    }
}