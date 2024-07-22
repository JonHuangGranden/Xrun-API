using System;

using Xrun.Service.GameData;
using Xrun.Service.GameData.Interface;
using Xrun.DataAccess.GameData;
using Xrun.Service.UserInformation.Interface;
using Xrun.Service.UserInformation.Request;
using Xrun.DataAccess.GameDataDataAccess;
using Xrun.DataAccess.GameData.Interface;
using Xrun.DataAccess.GameData.Entity;
using Xrun.Service.GameData;

namespace Xrun.Service.GameData
{
	public class GameDataService : IGameDataService
    {	

        private readonly IGameDataDataAccess _gameDataDataAccess;

        public GameDataService(IGameDataDataAccess gameDataDataAccess)
        {
            _gameDataDataAccess = gameDataDataAccess;
        }



        public async Task<InsertGameDataResponse> CreateOrUpdateGameDataAsync(object gameData)
        {

            try {
                string nhiNumber = (string)gameData.GetType().GetProperty("NHINumber").GetValue(gameData);

                var existingUserGameData = await _gameDataDataAccess.GetByNHINumberAsync(nhiNumber);
                if (existingUserGameData == null)
                {
                    existingUserGameData = new UserAllGameDataList
                    {
                        NHINumber = nhiNumber
                    };
                    await _gameDataDataAccess.InsertUserGameDataListAsync(existingUserGameData);
                    //創一筆用戶的遊戲存放List
                }

                await _gameDataDataAccess.InsertGameDataAsync(gameData);
                // 插入新遊戲紀錄

                return new InsertGameDataResponse { IsSuccess = true };                 
            }
            catch 
            {
                return new InsertGameDataResponse { IsSuccess = false }; 
            }

        }


       


    }
}


