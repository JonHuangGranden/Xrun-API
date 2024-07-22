
using Xrun.Repositories.UserGameDataRepository;
using Xrun.Repositories.UserGameData.Interface;

using System;
using Xrun.DataAccess.GameData.Interface;
using Xrun.DataAccess.GameData.Interface;
using Xrun.DataAccess.GameData.Entity;



namespace Xrun.DataAccess.GameDataDataAccess
{
    public class GameDataDataAccess : IGameDataDataAccess

    {
        private readonly IUserGameDataRepository _userGameDataRepository;

        public GameDataDataAccess(IUserGameDataRepository userGameDataRepository)
        {
            _userGameDataRepository = userGameDataRepository;

        }


        public async Task<UserAllGameDataList> GetByNHINumberAsync(string nhiNumber)
        {
            return await _userGameDataRepository.GetByNHINumberAsync(nhiNumber);
        }
     
        public async Task InsertGameDataAsync(object gameData)
        {
            await _userGameDataRepository.InsertGameDataAsync(gameData);
        }

        public async Task InsertUserGameDataListAsync(UserAllGameDataList userGameData)
        {
            await _userGameDataRepository.InsertUserGameDataListAsync(userGameData);
        }




    }
}














