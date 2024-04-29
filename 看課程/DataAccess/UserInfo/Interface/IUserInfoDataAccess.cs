using System;
using 看課程.DataAccess.UserInfo.Entity;

namespace 看課程.DataAccess.UserInfo.Interface
{
	public interface IUserInfoDataAccess
	{
        Task<UserInfoToDB> GetUserInfoByIdAsync(string userId);
        Task InsertUserInfoAsync(UserInfoToDB userInfoToDB);
        //Task<bool> UpdateUserInfoAsync(string userId, string field, string value);


    }
}

