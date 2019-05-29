using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(ParentsEyesKidsTracking.Web.Startup))]
namespace ParentsEyesKidsTracking.Web
{
    public partial class Startup
    {
        public  void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}