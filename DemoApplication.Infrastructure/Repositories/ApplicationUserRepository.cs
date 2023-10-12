using Dapper;
using DemoApplication.Core.Abstraction.Factory;
using DemoApplication.Core.Abstraction.Repository;
using DemoApplication.Core.Models;
using Medusa.Setup.Core.Constants;
using System.Data;


namespace DemoApplication.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        /// <summary>
        /// The db connection factory
        /// </summary>
        protected IDbConnectionFactory _dbConnectionFactory;

        public ApplicationUserRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this._dbConnectionFactory = dbConnectionFactory;
        }

        /// <summary>
        /// get application user list
        /// </summary>
        /// <param name="demoUserListRequest"></param>
        /// <returns></returns>
        public async Task<ApplicationUserResponseOutput> GetApplicationUserListAsync(ApplicationUserListRequest demoUserListRequest)
        {
            List<ApplicationUserListDetails> results = new List<ApplicationUserListDetails>();
            using (var db = _dbConnectionFactory.GetConnection())
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", demoUserListRequest.Id);
                queryParameters.Add("@userName", demoUserListRequest.UserName);
                queryParameters.Add("@date", demoUserListRequest.Date);
                queryParameters.Add("@startDate", demoUserListRequest.StartDate);
                queryParameters.Add("@endDate", demoUserListRequest.EndDate);
                queryParameters.Add("@description", demoUserListRequest.Description);
                queryParameters.Add("@subject", demoUserListRequest.Subject);
                results = (await db.QueryAsync<ApplicationUserListDetails>(StoredProcedure.APPLICATIONUSER_LIST,
                   queryParameters, commandType: CommandType.StoredProcedure)).ToList();
            }
            ApplicationUserResponseOutput nmodel = new ApplicationUserResponseOutput();
            if (results.Count > 0)
            {
                nmodel = new ApplicationUserResponseOutput()
                {
                    TotalCount = results[0].TotalRecord,
                    applicationUserDetailResponses = results.Select(notiList => new ApplicationUserDetailResponse
                    {
                        Id = notiList.Id,
                        UserName = notiList.UserName,
                        Date = notiList.Date,
                        StartDate = notiList.StartDate,
                        EndDate = notiList.EndDate,
                        Subject = notiList.Subject,
                        Description = notiList.Description,
                    }).ToList()
                };
            }
            else
            {
                nmodel = new ApplicationUserResponseOutput()
                {
                    TotalCount = 0
                };
            }
            return nmodel;
        }

        /// <summary>
        /// insert update application user detail
        /// </summary>
        /// <param name="addUpdateUserRequest"></param>
        /// <returns></returns>
        public async Task<ApplicationUserDetailResponse> InsertUpdateApplicationUserDetailAsync(AddUpdateUserRequest addUpdateUserRequest)
        {
            using (var conn = _dbConnectionFactory.GetConnection())
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", addUpdateUserRequest.Id);
                queryParameters.Add("@userName", addUpdateUserRequest.UserName);
                queryParameters.Add("@date", addUpdateUserRequest.Date);
                queryParameters.Add("@startDate", addUpdateUserRequest.StartDate);
                queryParameters.Add("@endDate", addUpdateUserRequest.EndDate);
                queryParameters.Add("@description", addUpdateUserRequest.Description);
                queryParameters.Add("@subject", addUpdateUserRequest.Subject);
                return (await conn.QueryAsync<ApplicationUserDetailResponse>(StoredProcedure.INSERTUPDATE_APPLICATIONUSER, queryParameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            }
        }
    }
}
