using System;
using MongoDB.Driver;
using Xrun.DataAccess.GameData.Entity;
using Xrun.Repositories.UserGameData.Interface;

namespace Xrun.Repositories.UserGameDataRepository
{
    public class UserGameDataRepository : IUserGameDataRepository
    {
        private readonly IMongoCollection<UserAllGameDataList> _userGameDataCollection;
        //因為program.cs已經有註冊了
        //所以在這邊可以DI将 IMongoCollection<UserAccountEntity> 注入到 UserToDbRepository 类中

        public UserGameDataRepository(IMongoCollection<UserAllGameDataList> userGameDataCollection)
        {
            _userGameDataCollection = userGameDataCollection;
        }


        //public async Task<List<UserAllGameDataList>> GetAllUserGameDataAsync()
        //{
        //    return await _userGameDataCollection.Find(_ => true).ToListAsync();
        //}
     

        public async Task<UserAllGameDataList> GetByNHINumberAsync(string nhiNumber)
        {
            return await _userGameDataCollection.Find(x => x.NHINumber == nhiNumber).FirstOrDefaultAsync();
        }


        public async Task InsertUserGameDataListAsync(UserAllGameDataList userGameData)
        {
            await _userGameDataCollection.InsertOneAsync(userGameData);
        }


        public async Task InsertGameDataAsync(object gameData)
        {
            string nhiNumber = (string)gameData.GetType().GetProperty("NHINumber").GetValue(gameData);
            //string nhiNumber = gameData.NHINumber; 要寫上面那樣，才能動態存取資料value，因為是object，不確定會進來什麼東西

            var filter = Builders<UserAllGameDataList>.Filter.Eq(x => x.NHINumber, nhiNumber);

            UpdateDefinition<UserAllGameDataList> update;
            if (gameData.GetType() == typeof(BeetleGameData))
            {
                update = Builders<UserAllGameDataList>.Update.Push(x => x.BeetleGameDatas, (BeetleGameData)gameData);
            }
            else if (gameData.GetType() == typeof(CardGameData))
            {
                update = Builders<UserAllGameDataList>.Update.Push(x => x.CardGameDatas, (CardGameData)gameData);
            }
            else if (gameData.GetType() == typeof(MarbleGameData))
            {
                update = Builders<UserAllGameDataList>.Update.Push(x => x.MarbleGameDatas, (MarbleGameData)gameData);
            }
            else if (gameData.GetType() == typeof(FruitGameData))
            {
                update = Builders<UserAllGameDataList>.Update.Push(x => x.FruitGameDatas, (FruitGameData)gameData);
            }
            else
            {
                throw new ArgumentException("");
            }

            await _userGameDataCollection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
        }
    }
}







