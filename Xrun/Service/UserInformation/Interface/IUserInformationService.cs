
using Xrun.Service.UserInformation.Response;
using Xrun.Service.UserInformation.Request;


using Xrun.DataAccess.UserInformation.Entity;



namespace Xrun.Service.UserInformation.Interface
{
    public interface IUserInformationService
    {

        Task<LoginResponse> Login(UserInformationRequest userInformationRequest);

        Task<List<UserInformationEntity>> GetAllUserInformation();

    }
}













