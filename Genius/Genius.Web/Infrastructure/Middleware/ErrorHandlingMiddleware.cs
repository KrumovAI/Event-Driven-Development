namespace Genius.Web.Infrastructure.Middleware
{
    using Genius.Common.Exceptions;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this.next(httpContext);
            }
            catch (EntityNotFoundException)
            {
                httpContext.Response.Redirect(httpContext.Request.PathBase + "/Error/NotFound");
            }
        }
    }
}
