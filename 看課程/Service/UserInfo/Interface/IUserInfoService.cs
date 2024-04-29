
using 看課程.Service.UserInfo.Response;
using 看課程.Service.UserInfo.Requests;


namespace 看課程.Service.UserInfo.Interface
{
	public interface IUserInfoService
	{

        Task<UserInfoCheckRes> verifyUserInfo(IdReq idReq);
    }
}














