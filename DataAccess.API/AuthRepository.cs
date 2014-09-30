using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ResourceMetadata.API;

namespace DataAccess.API
{
    public class AuthRepository
    {
        private const string DomainName = "quadservices";

        public bool Validate(string userName, string password, out ClaimsIdentity identity)
        {
            using (var ctx = new PrincipalContext(ContextType.Domain, DomainName))
            {
                bool isValid = ctx.ValidateCredentials(userName, password);
                if (isValid)
                {
                    identity = new ClaimsIdentity(Startup.OAuthBearerOptions.AuthenticationType);
                    var groups=GetUserGroups(userName);
                    identity.AddClaim(new Claim(ClaimTypes.Name, userName));
                    identity.AddClaim(new Claim(ClaimTypes.Role, string.Join(",",groups)));
                }
                else
                {
                    identity = null;
                }

                return isValid;
            }
        }

        private IEnumerable<string> GetUserGroups(string username)
        {
            var groups=new List<string>();
            UserPrincipal user = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain, DomainName), IdentityType.SamAccountName, username);
            if (user != null) groups=user.GetGroups().AsQueryable().Select(l => l.ToString()).ToList();
            return groups;
        }
    }
}