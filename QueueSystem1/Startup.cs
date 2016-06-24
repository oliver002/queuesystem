using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QueueSystem1.Startup))]
namespace QueueSystem1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
