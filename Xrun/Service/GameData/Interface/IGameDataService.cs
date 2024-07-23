using System;
using Xrun.Service.UserInformation.Request;
using Xrun.Service.UserInformation.Response;
using Xrun.Service.GameData;
using Xrun.Service.GameData;
using Xrun.DataAccess.GameData.Entity;

namespace Xrun.Service.GameData.Interface
{
	public interface IGameDataService
	{
    
        //Task CreateOrUpdateGameDataAsync<T>(T gameData) where T : class;

        //Task<List<UserAllGameDataList>> GetAllUserGameDataAsync();

        Task<InsertGameDataResponse>CreateOrUpdateGameDataAsync(object gameData);

    }
}

