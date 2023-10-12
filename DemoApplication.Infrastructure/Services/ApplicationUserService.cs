using DemoApplication.Core.Abstraction.Repository;
using DemoApplication.Core.Abstraction.Services;
using DemoApplication.Core.Models;

namespace DemoApplication.Infrastructure.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }
        public async Task<ApplicationUserResponseOutput> GetApplicationUserListAsync(ApplicationUserListRequest applicationUserListRequest)
        {
            return await _applicationUserRepository.GetApplicationUserListAsync(applicationUserListRequest);
        }

        public async Task<ApplicationUserDetailResponse> InsertUpdateApplicationUserDetailAsync(AddUpdateUserRequest addUpdateUserRequest)
        {
            ApplicationUserDetailResponse results = new ApplicationUserDetailResponse();
            results = await _applicationUserRepository.InsertUpdateApplicationUserDetailAsync(addUpdateUserRequest);
            if (results != null)
            {
                if (results.Id != -11)
                {
                    if (addUpdateUserRequest.Id == 0)
                    {
                        addUpdateUserRequest.Id = results.Id;
                    }
                }
            }
            return results;
        }

    }
}