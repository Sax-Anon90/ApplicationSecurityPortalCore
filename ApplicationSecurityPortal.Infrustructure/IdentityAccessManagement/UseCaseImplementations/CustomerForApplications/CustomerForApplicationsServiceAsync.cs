using ApplicationSecurityPortal.Application.Common;
using ApplicationSecurityPortal.Application.IdentityAccessManagement.UseCaseRepositories.CustomerForApplications;
using ApplicationSecurityPortal.Domain.IdentityAccessManagement.Models.CustomerForApplications;
using ApplicationSecurityPortal.Infrustructure.BaseApiService;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Infrustructure.IdentityAccessManagement.UseCaseImplementations.CustomerForApplications
{
    public class CustomerForApplicationsServiceAsync : ICustomerForApplicationServiceAsync
    {
        private readonly ApiService _apiService;
        public CustomerForApplicationsServiceAsync(ApiService _apiService)
        {
            this._apiService = _apiService;
        }
        public async Task<Response<CustomerForApplicationsViewModel>> CreateCustomerForApplicationAsync(CustomerForApplicationsInputModel customerForApplicationsInputModel)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.CustomerForApplicationEndpoint}")
                                                                   .AllowAnyHttpStatus()
                                                                   .PostJsonAsync(new
                                                                   {
                                                                       customerForApplicationToCreate = customerForApplicationsInputModel
                                                                   })
                                                                   .ReceiveJson<Response<CustomerForApplicationsViewModel>>();
                return response;

            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<CustomerForApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<CustomerForApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<CustomerForApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<CustomerForApplicationsViewModel>> DeleteCustomerForApplicationAsync(int CustomerForApplicationId)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.CustomerForApplicationEndpoint}{CustomerForApplicationId}")
                                                                   .AllowAnyHttpStatus()
                                                                  .DeleteAsync()
                                                                  .ReceiveJson<Response<CustomerForApplicationsViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<CustomerForApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<CustomerForApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<CustomerForApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<IEnumerable<CustomerForApplicationsViewModel>>> GetAllCustomerForApplicationsAsync()
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.CustomerForApplicationEndpoint}")
                                                                  .AllowAnyHttpStatus()
                                                                  .GetJsonAsync<Response<IEnumerable<CustomerForApplicationsViewModel>>>();
                return response;

            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<IEnumerable<CustomerForApplicationsViewModel>>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<IEnumerable<CustomerForApplicationsViewModel>>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<CustomerForApplicationsViewModel>>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Response<CustomerForApplicationsViewModel>> UpdateCustomerForApplicationAsync(CustomerForApplicationsUpdateModel customerForApplicationsUpdateModel)
        {
            try
            {
                var response = await $"{_apiService.BaseApiUrl}".AppendPathSegment($"{_apiService.CustomerForApplicationEndpoint}")
                                                                   .AllowAnyHttpStatus()
                                                                  .PutJsonAsync(new
                                                                  {
                                                                      customerForApplicationToUpdate = customerForApplicationsUpdateModel
                                                                  })
                                                                  .ReceiveJson<Response<CustomerForApplicationsViewModel>>();
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {

                return new Response<CustomerForApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection Timed out. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (FlurlHttpException ex)
            {
                return new Response<CustomerForApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = "Connection error occured. Cannot establish connection",
                    ExceptionMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Response<CustomerForApplicationsViewModel>()
                {
                    Succeeded = false,
                    Message = $"Something went wrong. Result: {ex.Message.ToString()}",
                    ExceptionMessage = ex.Message
                };
            }
        }
    }
}
