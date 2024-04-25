using System;
using 看課程.DataAccess.UserInfo.Entity;

namespace 看課程.Repositories.UserInfo.Interfaces
{
	public interface IUserInfoRepository
    {
        Task<UserInfoToDB> GetUserByIdAsync(string userId);
        Task InsertUserInfoAsync(UserInfoToDB userInfoToDB);
        Task<bool> UpdateUserInfoAsync(string userId, string field, string value);
    }
}

