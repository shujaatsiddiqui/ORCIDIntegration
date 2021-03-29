using CapstoneProject.Models;
using CapstoneProject.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject
{
    public static class Helper
    {
        public static void InjectMongoDbCollection(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<OrcidIobmIntDatabaseSettings>(
                Configuration.GetSection(nameof(OrcidIobmIntDatabaseSettings)));

            services.AddSingleton<IOrcidIobmIntDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<OrcidIobmIntDatabaseSettings>>().Value);

            ////services.AddSingleton<EmployeesService>();
        }
    }
}
