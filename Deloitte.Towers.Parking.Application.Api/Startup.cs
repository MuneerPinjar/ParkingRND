using Owin;

namespace Deloitte.Towers.Parking.Application.Api
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
