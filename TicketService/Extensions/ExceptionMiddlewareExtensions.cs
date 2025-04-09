using System.Net;

using Microsoft.AspNetCore.Diagnostics;

namespace TicketService.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                                    {
                                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                        context.Response.ContentType = "application/json";
                                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                                        if (contextFeature != null)
                                        {
                                           
                                        }
                                    });
            });
        }
    }
}