
using 看課程.DataAccess.Identity.Entity;
namespace 看課程.Repositories.Interfaces
{
    public interface IUserToDbRepository
    {
        Task<UserDataToDB> GetUserByEmailAsync(string email);
        Task InsertUserAsync(UserDataToDB user);
        Task<UserDataToDB> FindUserByIdAsync(string userId);
        Task<bool> UpdateUserJtiAsync(string userId, string newJti);
    }
}
