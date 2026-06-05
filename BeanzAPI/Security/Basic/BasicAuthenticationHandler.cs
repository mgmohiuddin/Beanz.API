using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Beanz.WebAPI.Security.Basic
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
       private readonly IBeanzAuthentication IBeanzAuthentication;

	  public BasicAuthenticationHandler(
                                    IOptionsMonitor<AuthenticationSchemeOptions> options
                                   ,ILoggerFactory logger
                                   ,UrlEncoder encoder
                                   ,ISystemClock clock
                                   ,IBeanzAuthentication iBeanzAuthentication)
                          : base(options, logger, encoder, clock)
        {
            IBeanzAuthentication = iBeanzAuthentication;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
           //if (!Request.Headers.ContainsKey("Authorization")) return AuthenticateResult.Fail("Missing Authorization Header"); 
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1]; 
               var authK =  await Task.Run(()=>IBeanzAuthentication.Authenticate(username, password));
                if (!authK)
                    return AuthenticateResult.Fail("Invalid Authorization Header");
                else
                {
                    var claims = new[] {
                        new Claim(ClaimTypes.NameIdentifier, "TestNameIdentifier"),
                        new Claim(ClaimTypes.Name, "TestName"),
                        };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            } 
            
        }

    }
}