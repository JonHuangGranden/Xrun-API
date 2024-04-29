using System;
using 看課程.DataAccess.UserInfo.Entity;
using 看課程.Repositories;
using 看課程.Repositories.UserInfo.Interface;
using 看課程.DataAccess.UserInfo.Interface;

namespace 看課程.DataAccess.UserInfo
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



        public async Task<UserInfoToDB> GetUserInfoByIdAsync(string userId)
        {
            return await _userInfoRepository.GetUserInfoByIdAsync(userId);
        }


        public async Task InsertUserInfoAsync(UserInfoToDB userInfoToDB)
        {
         await   _userInfoRepository.InsertUserInfoAsync(userInfoToDB);
        }

    }
}


