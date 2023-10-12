using System.Net;
using DemoApplication.Core.Abstraction.Services;
using DemoApplication.Core.Constants;
using DemoApplication.Core.Models;
using DemoApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers
{
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        /// <summary>
        /// private readonly abstract ApplicationUserService.
        /// </summary>
        private readonly IApplicationUserService _applicationUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserController"/> class.
        /// Define a constructor for initialize a service method and properties.
        /// </summary>
        /// <param name="applicationUserService">pass applicationuserservice</param>
        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            this._applicationUserService = applicationUserService;
        }

        /// <summary>
        /// get application user list
        /// </summary>
        /// <param name="ApplicationUserListRequest">pass request params of applicationuser</param>
        /// <returns></returns>
        [Route("applicationuser/list")]
        [HttpPost]
        public async Task<ServiceResponse<ApplicationUserResponseOutput>> GetApplicationUserList([FromBody] ApplicationUserListRequest demoUserListRequest)
        {
            ServiceResponse<ApplicationUserResponseOutput> response = new ServiceResponse<ApplicationUserResponseOutput>();
            ApplicationUserResponseOutput demoUserResponseOutput = null;
            demoUserResponseOutput = await _applicationUserService.GetApplicationUserListAsync(demoUserListRequest);
            if (demoUserResponseOutput != null)
            {
                response = new ServiceResponse<ApplicationUserResponseOutput>() { Status = 1, StatusCode = HttpStatusCode.OK, Message = StatusMessages.AppUserSuccess, Result = demoUserResponseOutput };
            }
            else
            {
                response = new ServiceResponse<ApplicationUserResponseOutput>() { Status = 0, StatusCode = HttpStatusCode.NotFound, Message = StatusMessages.AppUserNotFound, Result = null };
            }
            return response;
        }

        /// <summary>
        /// add update application user detail
        /// </summary>
        /// <param name="addUpdateUserRequest">pass request params of application user</param>
        /// <returns></returns>
        [Route("applicationuser/insertupdate")]
        [HttpPost]
        public async Task<ServiceResponse<ApplicationUserDetailResponse>> InsertUpdateApplicationUserDetail([FromBody] AddUpdateUserRequest addUpdateUserRequest)
        {
            ServiceResponse<ApplicationUserDetailResponse> response = new ServiceResponse<ApplicationUserDetailResponse>();
            ApplicationUserDetailResponse addUpdateUserResponse = null;
            if (ModelState.IsValid)
            {
                addUpdateUserResponse = await _applicationUserService.InsertUpdateApplicationUserDetailAsync(addUpdateUserRequest);
                if (addUpdateUserResponse != null)
                {
                    if (addUpdateUserResponse.Id == -11)
                    {
                        response = new ServiceResponse<ApplicationUserDetailResponse>() { Status = 0, StatusCode = HttpStatusCode.BadRequest, Message = StatusMessages.AppUserEmailExist, Result = null };
                    }
                    else
                    {
                        response = new ServiceResponse<ApplicationUserDetailResponse>() { Status = 1, StatusCode = HttpStatusCode.OK, Message = StatusMessages.AppUserInsertSuccess, Result = addUpdateUserResponse };
                    }
                }
                else
                {
                    response = new ServiceResponse<ApplicationUserDetailResponse>() { Status = 0, StatusCode = HttpStatusCode.NotFound, Message = StatusMessages.AppUserNotFound, Result = null };
                }
            }
            else
            {
                response = new ServiceResponse<ApplicationUserDetailResponse>() { Status = 0, StatusCode = HttpStatusCode.BadRequest, Message = StatusMessages.AppUserfailed, Result = null };
            }
            return response;
        }
    }
}