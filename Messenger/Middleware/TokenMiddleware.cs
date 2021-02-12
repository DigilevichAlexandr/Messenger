using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Threading.Tasks;
 
public class TokenMiddleware
{
    private readonly RequestDelegate _next;
 
    public TokenMiddleware(RequestDelegate next)
    {
        this._next = next;
    }
 
    public async Task InvokeAsync(HttpContext context)
    {
        //var token = context.Request.Query["token"];
        //if (token!= "12345678")
        //{
        //    context.Response.StatusCode = 403;
        //    await context.Response.WriteAsync("Token is invalid");
        //}
        //else
        //{
        //    await _next.Invoke(context);
        //}

        var url1 = context.Request.GetDisplayUrl();
        var url2 = context.Request.GetEncodedUrl();

        await _next.Invoke(context);
    }
}