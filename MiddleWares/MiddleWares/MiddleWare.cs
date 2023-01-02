using System.Diagnostics;

namespace MiddleWares
{
    public class MiddleWare {
    private readonly RequestDelegate _next;
    private IQueryCollection cultureQuery;

    public MiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public MiddleWare(HttpContext context)
    {
        Context = context;
    }

    public MiddleWare(IQueryCollection cultureQuery)
    {
        this.cultureQuery = cultureQuery;
    }

    public HttpContext Context { get; }

    public async Task Invoke(HttpContext httpContext)
    {
        Debug.WriteLine(httpContext.Request.Method);

        Debug.WriteLine(httpContext.Request.Host);

        Debug.WriteLine(DateTime.Now);

        await _next(httpContext);
    }
}

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MiddleWare>();
    }
}
}
