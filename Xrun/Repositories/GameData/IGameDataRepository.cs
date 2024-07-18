
using System;
using Xrun.DataAccess.GameData.Entity;

namespace Xrun.Repositories.UserGameData.Interface
{
    public interface IUserGameDataRepository
    {
        //Task InsertBeetleGameDataAsync(BeetleGameData beetleGameData);
        //Task InsertCardGameDataAsync(CardGameData cardGameData);
        //Task InsertMarbleGameDataAsync(MarbleGameData marbleGameData);
        //Task InsertFruitGameDataAsync(FruitGameData fruitGameData);

        //Task InsertGameDataAsync<T>(T gameData) where T : class;

        Task<UserAllGameDataList> GetByNHINumberAsync(int nhiNumber);
        Task InsertUserGameDataAsync(UserAllGameDataList userGameData);
        Task InsertGameDataAsync(object gameData);

    }
}


