using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using CodeComb.Yuuko;

[assembly: OwinStartup(typeof(Qqhru.Startup))]

namespace Qqhru
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapYuuko();
        }
    }
}
