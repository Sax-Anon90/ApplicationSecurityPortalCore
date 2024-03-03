using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.CustomerApplications;
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.CustomerForApplications;
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.RoleGroups;
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.Roles;
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.UserRoles;
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.Users;
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.UserTypes;
using ApplicationSecurityPortal.Infrustructure.BaseApiService;
using ApplicationSecurityPortal.Infrustructure.IdentityAccessManagement.UseCaseImplementations.CustomerApplications;
using ApplicationSecurityPortal.Infrustructure.IdentityAccessManagement.UseCaseImplementations.CustomerForApplications;
using ApplicationSecurityPortal.Infrustructure.IdentityAccessManagement.UseCaseImplementations.RoleGroups;
using ApplicationSecurityPortal.Infrustructure.IdentityAccessManagement.UseCaseImplementations.Roles;
using ApplicationSecurityPortal.Infrustructure.IdentityAccessManagement.UseCaseImplementations.UserRoles;
using ApplicationSecurityPortal.Infrustructure.IdentityAccessManagement.UseCaseImplementations.Users;
using ApplicationSecurityPortal.Infrustructure.IdentityAccessManagement.UseCaseImplementations.UserTypes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Infrustructure
{
    public static class InfrustructureServiceRegistration
    {
        public static IServiceCollection AddInfrustructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICustomerForApplicationServiceAsync, CustomerForApplicationsServiceAsync>();
            services.AddTransient<ICustomerApplicationsServiceAsync, CustomerApplicationsServiceAsync>();
            services.AddTransient<IRoleGroupsServiceAsync, RoleGroupsServiceAsync>();
            services.AddTransient<IRolesServiceAsync, RolesServiceAsync>();
            services.AddTransient<IUserTypesServiceAsync, UserTypesServiceAsync>();
            services.AddTransient<IUsersServiceAsync, UsersServiceAsync>();
            services.AddTransient<IUserTypesServiceAsync, UserTypesServiceAsync>();
            services.AddTransient<IUserRoleServiceAsync, UserRolesServiceAsync>();
            services.AddTransient<ApiService>();

            return services;
        }
    }
}
