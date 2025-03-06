#region

using System.Diagnostics;

#endregion

namespace QuizWhizAPI.Logging;

public class LoggingMiddleware
{
    private readonly ILoggerManager _logger;
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next, ILoggerManager logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        _logger.LogInfo($"Request: {context.Request.Method} {context.Request.Path}");

        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unhandled Exception: {ex.Message}");
            throw;
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInfo(
                $"Response: {context.Response.StatusCode} - Processed in {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}