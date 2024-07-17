using System;
using Xrun.DataAccess.UserInfo.Entity;

namespace Xrun.Repositories.UserInfo.Interface
{
	public interface IUserInfoRepository
    {
        Task<UserInfoEntity> GetUserInfoByIdAsync(string userId);
        Task InsertUserInfoAsync(UserInfoEntity UserInfoEntity);
        //Task<bool> UpdateUserInfoAsync(string userId, string field, string value);
    }
}

