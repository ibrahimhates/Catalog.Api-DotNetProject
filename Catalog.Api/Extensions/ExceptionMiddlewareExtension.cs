using Layer.Entity.ErrorModels;
using Layer.Entity.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Catalog.Api.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };
                    }

                    await context.Response.WriteAsync(new ErrorDetail()
                    {
                        ErrorMessage = contextFeature.Error.Message,
                        StatusCode = context.Response.StatusCode
                    }.ToString());
                });
            });
        }
    }
}
