using System;
using Xrun.DataAccess.GameData.Entity;
using Xrun.Service.BackpageUserData;
using Xrun.DataAccess.UserInformation.Entity;

namespace Xrun.Repositories.BackpageUserData
{
    public interface IBackpageUserDataRepository
    {

        Task<UserAllGameDataList> GetByNHINumberAsync(NHINumberRequest nhiNumberRequest);

    }
}

