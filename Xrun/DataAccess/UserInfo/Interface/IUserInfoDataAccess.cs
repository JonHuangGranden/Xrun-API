using System;
using Xrun.DataAccess.UserInfo.Entity;

namespace Xrun.DataAccess.UserInfo.Interface
{
	public interface IUserInfoDataAccess
	{
        Task<UserInfoEntity> GetUserInfoByIdAsync(string userId);
        Task InsertUserInfoAsync(UserInfoEntity userInfoEntity);
        //Task<bool> UpdateUserInfoAsync(string userId, string field, string value);


    }
}

