
using 看課程.Service.Identity.Requests;
using 看課程.Service.Identity.Response;

namespace Service.Identity.Interface
{
    public interface IIdentityService
    {

        Task<RegisterRes> Register(RegisterReq registerRequest);
        
        Task<LoginRes> Login(LoginReq loginRequest);

        Task<RefreshTokenRes> verifyAccessToken(string token);
        Task<RefreshTokenRes> verifyRefreshToken(string token);


    }
}
