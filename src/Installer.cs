namespace Responser;

using Microsoft.AspNetCore.Builder;
using Middlewares;
public static class Installer
{
    public static WebApplication UseMalfurionException(this WebApplication app)
    {
        app.UseMiddleware<ExceptionResponseMiddleware>();
        return app;
    }
}