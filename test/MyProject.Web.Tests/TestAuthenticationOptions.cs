using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace MyProject.Web.Tests
{
    public class TestAuthenticationOptions:AuthenticationSchemeOptions
    {
        public virtual ClaimsIdentity Identity { get; } = new ClaimsIdentity(new Claim[]
        {
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", Guid.NewGuid().ToString()),
            new Claim("http://schemas.microsoft.com/identity/claims/tenantid", "test"),
            new Claim("http://schemas.microsoft.com/identity/claims/objectidentifier", Guid.NewGuid().ToString()),
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname", "test"),
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname", "test"),
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn", "test"),
        }, "test");

//        public TestAuthenticationOptions(ILoggerFactory loggerFactory) : base(loggerFactory, UrlEncoder.Default)
//            : base(next, options, loggerFactory, )
//        {
//            this.DefaultAuthenticateScheme = "TestAuthenticationMiddleware";
//        }
    }
}
