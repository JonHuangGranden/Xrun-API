//using Xrun.Service.Identity.Requests;
using Xrun.DataAccess.Identity.Entity;


namespace Xrun.DataAccess.Identity.Interface
{
    public interface IIdentityDataAccess
    {
        Task<UserAccountEntity> GetUserByEmailAsync(string email);
        Task InsertUserAsync(UserAccountEntity user);
        Task<UserAccountEntity> FindUserByIdAsync(string userId);
        Task<bool> UpdateUserJtiAsync(string userId, string newJti);

    }
}
