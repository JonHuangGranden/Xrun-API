
using System;
using Xrun.DataAccess.GameData.Entity;

namespace Xrun.Repositories.UserGameData.Interface
{
    public interface IUserGameDataRepository
    {

        Task<UserAllGameDataList> GetByNHINumberAsync(string nhiNumber);
        Task InsertUserGameDataListAsync(UserAllGameDataList userGameData);
        Task InsertGameDataAsync(object gameData);

    }
}


