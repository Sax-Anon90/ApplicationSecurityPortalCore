using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerApplications;
using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.CustomerForApplications;
using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.RoleGroups;
using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Roles;
using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserRoles;
using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.Users;
using ApplicationSecurity.Application.IdentityAccessManagement.UseCaseRepositories.UserTypes;
using ApplicationSecurity.Domain.IdentityAccessManagementDbContext;
using ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.CustomerApplications;
using ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.CustomerForApplications;
using ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.RoleGroups;
using ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.Roles;
using ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.UserRoles;
using ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.Users;
using ApplicationSecurity.Persistence.IdentityAccessManagement.UseCaseImplementations.UserTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDevelopmentSecuritydbContext>(options =>
            options.UseSqlServer(
                    configuration["ConnectionStrings:IdentityAccessManagementDbConnString"]), ServiceLifetime.Transient);


            #region UseCaseRepositories
            //Identity Access Management
            services.AddTransient<ICustomerForApplicationRepositoryAsync, CustomerForApplicationRepositoryAsync>();
            services.AddTransient<ICustomerApplicationRepositoryAsync, CustomerApplicationRepositoryAsync>();
            services.AddTransient<IRoleGroupRepositoryAsync, RoleGroupRepositoryAsync>();
            services.AddTransient<IRoleRepositoryAsync, RoleRepositoryAsync>();
            services.AddTransient<IUserRoleRepositoryAsync, UserRoleRepositoryAsync>();
            services.AddTransient<IUsersRepositoryAsync, UsersRepositoryAsync>();
            services.AddTransient<IUserTypesRepositoryAsync, UserTypeRepositoryAsync>();

            #endregion

            return services;
        }
    }
}
