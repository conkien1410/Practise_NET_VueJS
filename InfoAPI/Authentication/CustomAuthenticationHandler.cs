using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;




namespace InfoAPI.Authentication {
    public class CustomAuthenticationHandler:  AuthenticationHandler<AuthenticationSchemeOptions>
    {
         private readonly ClaimsPrincipal _id;

        public CustomAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _id = new ClaimsPrincipal(new ClaimsIdentity("Api"));
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync() {
            IHeaderDictionary currRequest = this.Request.Headers;
            StringValues username;
            bool result = currRequest.TryGetValue("username", out username);
            // if (!result || !username.First().Equals("Test")) {
            //     return Task.FromResult(AuthenticateResult.Fail(new Exception("Invalid")));
            // }

            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(_id, "Api")));
        }
    }
}