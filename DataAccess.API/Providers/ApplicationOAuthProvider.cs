using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.API;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace ResourceMetadata.API.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = "*";


            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {allowedOrigin});

            var repo = new AuthRepository();

            ClaimsIdentity identity;
            bool result = repo.Validate(context.UserName, context.Password, out identity);
            if (!result)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            AuthenticationProperties properties = CreateProperties(context.UserName, identity.Claims.Where(c=>c.Type==ClaimTypes.Role).Select(c=>c.Value).SingleOrDefault());
            var ticket = new AuthenticationTicket(identity, properties);
            context.Validated(ticket);
        }

        public static AuthenticationProperties CreateProperties(string userName, string role)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName },
                {"group", role}
            };
            return new AuthenticationProperties(data);
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}