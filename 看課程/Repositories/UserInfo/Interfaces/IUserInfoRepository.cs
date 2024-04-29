using System;
using 看課程.DataAccess.UserInfo.Entity;

namespace 看課程.Repositories.UserInfo.Interface
{
	public interface IUserInfoRepository
    {
        Task<UserInfoToDB> GetUserInfoByIdAsync(string userId);
        Task InsertUserInfoAsync(UserInfoToDB userInfoToDB);
        //Task<bool> UpdateUserInfoAsync(string userId, string field, string value);
    }
}

