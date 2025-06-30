using Microsoft.Extensions.DependencyInjection;
using qtec.domain.Interfaces;
using qtec.infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.infrastructure.RegisterServices
{
    public static class ExtractRegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IJournalRepository, JournalRepository>();
            return services;
        }
    }
}
