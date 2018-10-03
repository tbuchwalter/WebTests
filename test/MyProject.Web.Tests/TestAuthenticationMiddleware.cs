using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace MyProject.Web.Tests
{
    public class TestAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public TestAuthenticationMiddleware(RequestDelegate next, IAuthenticationSchemeProvider schemas)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.Keys.Contains("my-name"))
            {
                if (context.Request.Headers["my-name"].First().Equals("admin"))
                {
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, "admin"),
                            new Claim(ClaimTypes.NameIdentifier, context.Request.Headers["my-id"].First()),
                            new Claim(ClaimTypes.Role, "Admin"),
                            new Claim("http://www.aspnetboilerplate.com/identity/claims/tenantId", "1", "int"),
                            new Claim("AspNet.Identity.SecurityStamp", Guid.NewGuid().ToString())

                        }
                       , "Identity.Application");
                   ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
                    context.User = principal;
                    await context.SignInAsync("Identity.Application", principal);

                }
            }

            await _next(context);
        }
       
    }
}
