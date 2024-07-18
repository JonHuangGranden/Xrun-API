using System;

using Xrun.Service.GameData;
using Xrun.Service.GameData.Interface;
using Xrun.DataAccess.GameData;
using Xrun.Service.UserInformation.Interface;
using Xrun.Service.UserInformation.Request;
using Xrun.DataAccess.GameDataDataAccess;
using Xrun.DataAccess.GameData.Interface;
using Xrun.DataAccess.GameData.Entity;

namespace Xrun.Service.GameData
{
	public class GameDataService : IGameDataService
    {	

        private readonly IGameDataDataAccess _gameDataDataAccess;

        public GameDataService(IGameDataDataAccess gameDataDataAccess)
        {
            _gameDataDataAccess = gameDataDataAccess;
        }


        public async Task CreateOrUpdateGameDataAsync(object gameData)
        {
            int nhiNumber = (int)gameData.GetType().GetProperty("NHINumber").GetValue(gameData);

            var existingUserGameData = await _gameDataDataAccess.GetByNHINumberAsync(nhiNumber);
            if (existingUserGameData == null)
            {
                // 创建新的用户游戏数据
                existingUserGameData = new UserAllGameDataList
                {
                    NHINumber = nhiNumber
                };

                // 插入新的用户游戏数据到数据库
                await _gameDataDataAccess.InsertUserGameDataAsync(existingUserGameData);
            }

            // 插入或更新游戏数据
            await _gameDataDataAccess.InsertGameDataAsync(gameData);
        }


       


    }
}






