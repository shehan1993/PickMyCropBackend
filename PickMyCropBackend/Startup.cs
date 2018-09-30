using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(PickMyCropBackend.Startup))]

namespace PickMyCropBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            app.UseCors(CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                AllowInsecureHttp = true
            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new Microsoft.Owin.Security.OAuth.OAuthBearerAuthenticationOptions());

        }
    }
}
