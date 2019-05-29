using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ParentsEyesKidsTracking.Web.Models;
using ParentsEyesKidsTracking.Web.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParentsEyesKidsTracking.Web
{
	public partial class Startup
	{
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }

        public static void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(KidsTrackingContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
        }
	}
}