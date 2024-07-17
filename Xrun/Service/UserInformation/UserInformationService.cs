

using Xrun.DataAccess.UserInformation.Interface;

using Xrun.Service.UserInformation.Interface;

using Xrun.Service.UserInformation.Response;
using Xrun.Service.UserInformation.Request;
using Xrun.DataAccess.UserInformation.Entity;


namespace Xrun.Service.UserInformation
{
    public class UserInformationService : IUserInformationService
    {

        private readonly IUserInformationDataAccess _userInformationDataAccess;

        public UserInformationService(IUserInformationDataAccess userInformationDataAccess)
        {
            _userInformationDataAccess = userInformationDataAccess;
        }


        public async Task<LoginResponse> Login(NHINumberRequest NHINumberRequest)
        {
            var userInformationEntity = await _userInformationDataAccess.GetUserByNHINumberAsync(NHINumberRequest.NHINumber);

            if (userInformationEntity == null)
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = "無此用戶"
                };
            }

            return new LoginResponse
            {
                IsSuccess = true,
                Message = "登入成功"
            };

        }


        //= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        public async Task<RegisterResponse> Register(UserInformationRequest userInformationRequest)
        {

            var userInformationEntity = new UserInformationEntity
            {
                NHINumber = userInformationRequest.NHINumber,
                Name = userInformationRequest.Name,
                Gender = userInformationRequest.Gender,
                Birthday = userInformationRequest.Birthday,
            };

            await _userInformationDataAccess.InsertUserInformationAsync(userInformationEntity);

            return new RegisterResponse
            {
                IsSuccess = true,
                Message = "註冊成功"
            };


        }       


    }


}
