using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace GestorDeTurnos.Application.Extensions
{
    public static class HttpContextExtension
    {
        public static string GetUserName(this HttpContext? httpContext)
        {
            return httpContext?.User.Claims.FirstOrDefault(c => c.ValueType.Equals(ClaimTypes.NameIdentifier))?.Value ?? "System";
        }
    }
}