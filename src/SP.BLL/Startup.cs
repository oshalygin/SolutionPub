using Microsoft.Extensions.DependencyInjection;
using SP.DAL;

namespace SP.BLL
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPostDataAccess, PostDataAccess>();
        }
    }
}
