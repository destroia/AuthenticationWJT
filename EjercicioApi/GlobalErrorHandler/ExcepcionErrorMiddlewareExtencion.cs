using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EjercicioApi.GlobalErrorHandler
{
    public  static class ExcepcionErrorMiddlewareExtencion
    {
        public  static void ConfigExceptionHandler( this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contexFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contexFeature != null)
                    {

                        await context.Response.WriteAsync(new ErrorDetail()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal server error"
                        }.ToString());
                    }
                });
            });
        }
    }
}
