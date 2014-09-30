using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using ResourceMetadata.API;

[assembly: OwinStartup(typeof (Startup))]

namespace ResourceMetadata.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseCors(CorsOptions.AllowAll);
            
        }
    }
}