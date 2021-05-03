using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CountriesChallenge.Middleware
{
    public class BasicAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string authHeader = httpContext.Request.Headers["Authorization"];

            if(authHeader != null && authHeader.StartsWith("Basic"))
            {
                string ecodeUsernameAndPassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                string usernameAndPassword = encoding.GetString(Convert.FromBase64String(ecodeUsernameAndPassword));
                int index = usernameAndPassword.IndexOf(":");
                string username = usernameAndPassword.Substring(0, index);
                string password = usernameAndPassword.Substring(index + 1);

                if (username.Equals("admin") && password.Equals("admin"))
                {
                    await _next.Invoke(httpContext);
                } else
                {
                    httpContext.Response.StatusCode = 401;
                }
            } else
            {
                httpContext.Response.StatusCode = 401;
            }
        }
    }

    public static class BasicAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthenticationMiddleware>();
        }
    }
}
