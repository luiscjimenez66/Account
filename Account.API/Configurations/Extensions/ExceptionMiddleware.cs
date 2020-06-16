using Account.BusinessLayer.Exception;
using API.Helper.Exception;
using API.Helper.LoggerService;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Account.API.Configurations.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager loggerManager)
        {
            _next = next;
            _logger = loggerManager;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case BusinessException businessException:
                    context.Response.StatusCode = businessException.ExceptionCode;
                    return BuildExceptionDetail(context, exception, businessException.ExceptionCode);

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return BuildExceptionDetail(context, exception, (int)HttpStatusCode.InternalServerError);
            }
        }

        private Task BuildExceptionDetail(HttpContext context, Exception exception, int codeException)
        {
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDetail { 
                StatusCode = codeException,
                Message = exception.Message
            }));
        }
    }
}
