﻿//using 看課程.Service.Identity.Requests;
using 看課程.DataAccess.Identity.Entity;


namespace 看課程.DataAccess.Identity.Interface
{
    public interface IIdentityDataAccess
    {
        Task<UserAccountToDB> GetUserByEmailAsync(string email);
        Task InsertUserAsync(UserAccountToDB user);
        Task<UserAccountToDB> FindUserByIdAsync(string userId);
        Task<bool> UpdateUserJtiAsync(string userId, string newJti);

    }
}
