using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MVCExample
{
    public static class DependencyInjection
    {
        public static void AddContexts(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<MainContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            services.AddScoped<IContext>(provider => provider.GetService<MainContext>());
        }
    }
}
