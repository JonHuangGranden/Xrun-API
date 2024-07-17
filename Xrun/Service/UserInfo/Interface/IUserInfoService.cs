
using Xrun.Service.UserInfo.Response;
using Xrun.Service.UserInfo.Requests;


namespace Xrun.Service.UserInfo.Interface
{
	public interface IUserInfoService
	{

        Task<UserInfoCheckRes> verifyUserInfo(IdReq idReq);
    }
}














