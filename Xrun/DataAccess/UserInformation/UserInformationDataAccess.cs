
using System;
using Xrun.DataAccess.UserInformation.Entity;
using Xrun.Repositories.UserInformation.Interface;
using Xrun.DataAccess.UserInformation.Interface;



namespace Xrun.DataAccess.UserInformation
{
    public class UserInformationDataAccess : IUserInformationDataAccess
    {
        private readonly IUserInformationRepository _userInformationRepository;
        public UserInformationDataAccess(IUserInformationRepository userInformationRepository)
        {
            _userInformationRepository = userInformationRepository;

        }

        public async Task<UserInformationEntity> GetUserByNHINumberAsync(string nhiNumber)
        {
            return await _userInformationRepository.GetUserByNHINumberAsync(nhiNumber);
        }


        public async Task InsertUserInformationAsync(UserInformationEntity userInformationEntity)
        {
            await _userInformationRepository.InsertUserAsync(userInformationEntity);
        }


    }
}




