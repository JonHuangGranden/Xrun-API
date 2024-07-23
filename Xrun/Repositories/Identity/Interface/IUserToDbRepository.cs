
using Xrun.DataAccess.Identity.Entity;
namespace Xrun.Repositories.Identity.Interface
{
    public interface IUserToDbRepository
    {
        Task<UserAccountEntity> GetUserByEmailAsync(string email);
        Task<UserAccountEntity> GetUserByIdAsync(string userId);
        Task InsertUserAsync(UserAccountEntity user);
        Task<bool> UpdateUserJtiAsync(string userId, string newJti);
    }
}
