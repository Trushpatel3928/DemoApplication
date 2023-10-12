using DemoApplication.Core.Models;
using System.Threading.Tasks;

namespace DemoApplication.Core.Abstraction.Repository
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUserResponseOutput> GetApplicationUserListAsync(ApplicationUserListRequest ApplicationUserListRequest);
        Task<ApplicationUserDetailResponse> InsertUpdateApplicationUserDetailAsync(AddUpdateUserRequest addUpdateUserRequest);
    }
}
