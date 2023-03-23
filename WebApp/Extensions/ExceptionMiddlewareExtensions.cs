using log4net;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApp.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            var logger = LogManager.GetLogger(typeof(ExceptionMiddlewareExtensions));
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null) {
                        logger.Error($"{contextFeature.Error}");
                    }
                });
            });
        }
    }
}
