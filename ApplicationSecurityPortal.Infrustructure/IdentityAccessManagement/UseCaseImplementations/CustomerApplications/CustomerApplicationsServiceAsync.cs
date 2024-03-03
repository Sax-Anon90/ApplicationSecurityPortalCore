using ApplicationSecurityPortal.Application.Common;
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.CustomerApplications;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.CustomerApplications;
using ApplicationSecurityPortal.Infrustructure.BaseApiService;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Infrustructure.IdentityAccessManagement.UseCaseImplementations.CustomerApplications
{
    public class CustomerApplicationsServiceAsync : ICustomerApplicationsServiceAsync
    {
        private readonly ApiService _apiService;
        public CustomerApplicationsServiceAsync(ApiService _apiService)
        {
            this._apiService = _apiService;
        }
        public async Task<Response<CustomerApplicationsViewModel>> CreateCustomerApplicationAsync(CustomerApplicationsInputModel customerApplicationsInputModel)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.CustomerApplicationEndpoint}")
                                                                   .AllowAnyHttpStatus()
                                                                   .PostJsonAsync(new
                                                                   {
                                                                       customerApplicationToCreate = customerApplicationsInputModel
                                                                   })
                                                                   .ReceiveJson<Response<CustomerApplicationsViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {
                return new Response<CustomerApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<CustomerApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<CustomerApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<CustomerApplicationsViewModel>> DeleteCustomerApplicationAsync(int customerApplicationId)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.CustomerApplicationEndpoint}{customerApplicationId}")
                                                                  .AllowAnyHttpStatus()
                                                                  .DeleteAsync()
                                                                  .ReceiveJson<Response<CustomerApplicationsViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<CustomerApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<CustomerApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<CustomerApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<IEnumerable<CustomerApplicationsViewModel>>> GetAllCustomerApplicationsAsync()
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.CustomerApplicationEndpoint}")
                                                                  .AllowAnyHttpStatus()
                                                                  .GetJsonAsync<Response<IEnumerable<CustomerApplicationsViewModel>>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<IEnumerable<CustomerApplicationsViewModel>>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<IEnumerable<CustomerApplicationsViewModel>>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<CustomerApplicationsViewModel>>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<CustomerApplicationRoleGroupRoles>> GetCustomerApplicationsRoleGroupsWithRoles(int customerApplicationId)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.CustomerApplicationEndpoint}")
                                                                    .AllowAnyHttpStatus()
                                                                    .GetJsonAsync<Response<CustomerApplicationRoleGroupRoles>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<CustomerApplicationRoleGroupRoles>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<CustomerApplicationRoleGroupRoles>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<CustomerApplicationRoleGroupRoles>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<CustomerApplicationsViewModel>> UpdateCustomerApplicationAsync(CustomerApplicationsUpdateModel customerApplicationsUpdateModel)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.CustomerApplicationEndpoint}")
                                                                   .AllowAnyHttpStatus()
                                                                   .PutJsonAsync(new
                                                                   {
                                                                       customerApplicationToUpdate = customerApplicationsUpdateModel
                                                                   })
                                                                   .ReceiveJson<Response<CustomerApplicationsViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<CustomerApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<CustomerApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<CustomerApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }
    }
}
