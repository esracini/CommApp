using CommAppAPI.Application.Interfaces;
using CommAppAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IContactService, ContactService>();
        }
    }
}
