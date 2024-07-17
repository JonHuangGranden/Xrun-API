using System;
using Xrun.DataAccess.UserInformation.Entity;


namespace Xrun.Repositories.UserInformation.Interface
{
    public interface IUserInformationRepository
    {
        Task<UserInformationEntity> GetUserByNHINumberAsync(string nhiNumber);
        Task InsertUserAsync(UserInformationEntity userInformationEntity);
    }
}

