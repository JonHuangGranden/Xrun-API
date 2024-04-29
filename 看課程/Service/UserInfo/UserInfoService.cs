using 看課程.DataAccess.UserInfo.Interface;

using 看課程.Service.UserInfo.Interface;

using 看課程.Service.UserInfo.Response;
using 看課程.Service.UserInfo.Requests;

namespace 看課程.Services.UserInfo
{
    public class UserInfoService : IUserInfoService
    {

        private readonly IUserInfoDataAccess _dataAccess;

        public UserInfoService(IUserInfoDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        //public async Task<RegisterRes> Register(RegisterReq registerReq)
        //{
           
        //}
        //=========================================================================

        public async  Task<UserInfoCheckRes> verifyUserInfo(IdReq idReq)
           //=========== 登入成功 就更新db refresh token   ==============
        {
            try
            {
                //   var user = await _usersCollection.Find(u => u.Email == loginReq.UserEmail).FirstOrDefaultAsync();
                var userInfoexists = await _dataAccess.GetUserInfoByIdAsync(idReq.Id);//改用dal的


                if (userInfoexists == null)
                {
                    return new UserInfoCheckRes { Success = false, Msg = "尚未填寫資料" };
                }
                if (userInfoexists != null)
                {
                     return new UserInfoCheckRes { Success = true, Msg = "確認已填寫資料" };
                 }

                throw new InvalidOperationException("未預期錯誤");

            }
            catch (Exception ex)
            {
                return new UserInfoCheckRes { Success = false, Msg = ex.Message };
            }
        }
        //==============================================================


















    }
}
