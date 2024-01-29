using Microsoft.EntityFrameworkCore;
using PersonnelSystem.Application.Abstract;
using PersonnelSystem.Application.Services;
using PersonnelSystem.Core.Abstract;
using PersonnelSystem.Infrastructure.Data;
using PersonnelSystem.Infrastructure.Repository;
using System.Runtime.CompilerServices;

namespace PersonnelSystem.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IDepartmentService), typeof(DepartmentService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
        }
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersonnelSystemContext>(builder2 => { builder2.UseNpgsql(configuration.GetConnectionString("Postgres")); });
        }
        public static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Default", policyBuilder =>
                {
                    policyBuilder.AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .WithOrigins()
                                 .AllowCredentials();
                });
            });
        }
    }
}
