using CommAppAPI.Application.Repositories;
using CommAppAPI.Domain.Entities;
using CommAppAPI.Persistence.Contexts;
using CommAppAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommAppAPIDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // PERSON
            services.AddScoped<IReadRepository<Person>, PersonReadRepository>();
            services.AddScoped<IWriteRepository<Person>, PersonWriteRepository>();
            services.AddScoped<IPersonReadRepository, PersonReadRepository>();
            services.AddScoped<IPersonWriteRepository, PersonWriteRepository>();

            // COMPANY
            services.AddScoped<IReadRepository<Company>, CompanyReadRepository>();
            services.AddScoped<IWriteRepository<Company>, CompanyWriteRepository>();
            services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();

            // CONTACT
            services.AddScoped<IReadRepository<Contact>, ContactReadRepository>();
            services.AddScoped<IWriteRepository<Contact>, ContactWriteRepository>();
            services.AddScoped<IContactReadRepository, ContactReadRepository>();
            services.AddScoped<IContactWriteRepository, ContactWriteRepository>();

            // USER
            services.AddScoped<IReadRepository<User>, UserReadRepository>();
            services.AddScoped<IWriteRepository<User>, UserWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();



        }
    }
}
