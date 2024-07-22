

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


        public async Task<LoginResponse> Login(UserInformationRequest userInformationRequest)
        {
            //string nhiNumber = (string)userInformationRequest.GetType().GetProperty("NHINumber").GetValue(userInformationRequest);
            //可以不用反射 因為已經指定UserInformationRequest類別了
            string nhiNumber = userInformationRequest.NHINumber;
            Console.WriteLine(nhiNumber);

            var userInformationEntity = await _userInformationDataAccess.GetUserByNHINumberAsync(nhiNumber);
            Console.WriteLine(userInformationEntity);
            if (userInformationEntity == null)
            {
                var newUserEntity = new UserInformationEntity
                {
                    NHINumber = userInformationRequest.NHINumber,
                    Name = userInformationRequest.Name,
                    Gender = userInformationRequest.Gender,
                    Birthday = userInformationRequest.Birthday,
                };
                await _userInformationDataAccess.InsertUserInformationAsync(newUserEntity);

                return new LoginResponse
                {
                    IsSuccess = true,
                    Message = "無此用戶，已成功註冊並登入"
                };
            }
            return new LoginResponse
            {
                IsSuccess = true,
                Message = "登入成功"
            };
        }



    }


}
