using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using PickMyCropBackend.Models;
using Microsoft.Owin.Security;
using System.Web.SessionState;

namespace PickMyCropBackend
{
    public class ApplicationOAuthProvider: OAuthAuthorizationServerProvider
    {
        private string publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            this.publicClientId = publicClientId;
        }

        public ApplicationOAuthProvider()
        {
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = await manager.FindAsync(context.UserName, context.Password);
            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("UserName", user.UserName));
                identity.AddClaim(new Claim("Email", user.Email));
                identity.AddClaim(new Claim("FirstName", user.FirstName));
                identity.AddClaim(new Claim("LastName", user.LastName));
                identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                identity.AddClaim(new Claim("UserId", user.Id));
                context.Validated(identity);
            }
            else
                return;
        }

        internal static AuthenticationProperties CreateProperties(string userName)
        {
            throw new NotImplementedException();
        }
    }
}