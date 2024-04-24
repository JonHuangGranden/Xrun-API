//using 看課程.Service.Identity.Requests;
using 看課程.DataAccess.Identity.Entity;


namespace 看課程.DataAccess.Identity.Interface
{
    public interface IIdentityDataAccess
    {
        Task<UserDataToDB> GetUserByEmailAsync(string email);
        Task InsertUserAsync(UserDataToDB user);
        Task<UserDataToDB> FindUserByIdAsync(string userId);
        Task<bool> UpdateUserJtiAsync(string userId, string newJti);

    }
}
