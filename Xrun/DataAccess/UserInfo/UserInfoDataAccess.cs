using System;
using Xrun.DataAccess.UserInfo.Entity;
using Xrun.Repositories;
using Xrun.Repositories.UserInfo.Interface;
using Xrun.DataAccess.UserInfo.Interface;

namespace Xrun.DataAccess.UserInfo
{
	public class UserInfoDataAccess : IUserInfoDataAccess
    {
		  //　　　↓↓↓↓注入repositoy
        private readonly IUserInfoRepository _userInfoRepository;
        public UserInfoDataAccess(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }
        //　　　↑↑↑↑注入repositoy



        public async Task<UserInfoEntity> GetUserInfoByIdAsync(string userId)
        {
            return await _userInfoRepository.GetUserInfoByIdAsync(userId);
        }


        public async Task InsertUserInfoAsync(UserInfoEntity userInfoEntity)
        {
         await   _userInfoRepository.InsertUserInfoAsync(userInfoEntity);
        }

    }
}


