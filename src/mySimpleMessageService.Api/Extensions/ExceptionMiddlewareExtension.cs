using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using mySimpleMessageService.Api.Helpers;
using mySimpleMessageService.Application.Exceptions;
using mySimpleMessageService.Domain.Exceptions;
using Sieve.Exceptions;

namespace mySimpleMessageService.Api.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = (int)MapExceptionsToHttpCode(contextFeature.Error);
                        var message = "";
                        if (contextFeature.Error is AggregateException aggregate)
                        {
                            message = string.Join(",", aggregate.InnerExceptions);
                        }
                        else
                        {
                            message = contextFeature.Error.Message;
                        }
                        await context.Response.WriteAsync(
                            new ErrorDetails
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = message
                            }.ToString());
                    }
                });
            });
        }

        private static HttpStatusCode MapExceptionsToHttpCode(Exception exception)
        {
            switch (exception)
            {
                case MessageNoFoundException _:
                case ContactNotFoundException _:
                    return HttpStatusCode.NotFound;
                case InvalidOperationException _:
                case SieveException _:
                case ContactValidationException _:
                    return HttpStatusCode.BadRequest;
                case ContactExistException _:
                    return HttpStatusCode.Conflict;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
