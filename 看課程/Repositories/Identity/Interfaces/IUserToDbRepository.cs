
using 看課程.DataAccess.Identity.Entity;
namespace 看課程.Repositories.Identity.Interfaces
{
    public interface IUserToDbRepository
    {
        Task<UserAccountToDB> GetUserByEmailAsync(string email);
        Task<UserAccountToDB> GetUserByIdAsync(string userId);
        Task InsertUserAsync(UserAccountToDB user);
        Task<bool> UpdateUserJtiAsync(string userId, string newJti);
    }
}
