
using Xrun.Service.UserInformation.Response;
using Xrun.Service.UserInformation.Request;





namespace Xrun.Service.UserInformation.Interface
{
    public interface IUserInformationService
    {

        Task<LoginResponse> Login(NHINumberRequest NHINumberRequest);
        Task<RegisterResponse> Register(UserInformationRequest userInformationRequest);

       
    }
}













