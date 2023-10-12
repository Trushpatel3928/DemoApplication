using DemoApplication.Core.Models;
using System.Threading.Tasks;

namespace DemoApplication.Core.Abstraction.Services
{
   public interface IApplicationUserService
    {
        Task<ApplicationUserResponseOutput> GetApplicationUserListAsync(ApplicationUserListRequest applicationUserListRequest);
        Task<ApplicationUserDetailResponse> InsertUpdateApplicationUserDetailAsync(AddUpdateUserRequest addUpdateUserRequest);
    }
}
