using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ToDoWebApp.Utilities
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustumExeption
    {
        private readonly RequestDelegate _next;

        public  CustumExeption(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
             await    _next(httpContext);
            }
            catch (Exception ex)
            {
                //log
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustumExeption(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustumExeption>();
        }
    }
}
