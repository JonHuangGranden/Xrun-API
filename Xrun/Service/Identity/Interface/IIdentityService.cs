
using Xrun.Service.Identity.Requests;
using Xrun.Service.Identity.Response;

namespace Service.Identity.Interface
{
    public interface IIdentityService
    {

        Task<RegisterRes> Register(RegisterReq registerReq);
     
        Task<LoginRes> Login(LoginReq loginRequest);
        Task<RefreshTokenRes> verifyAccessToken(string token);
        Task<RefreshTokenRes> verifyRefreshToken(string token);
    }
}
