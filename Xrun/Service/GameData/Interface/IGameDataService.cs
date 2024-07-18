using System;
using Xrun.Service.UserInformation.Request;
using Xrun.Service.UserInformation.Response;
using Xrun.Service.GameData;
namespace Xrun.Service.GameData.Interface
{
	public interface IGameDataService
	{
        //Task<CreateGameDataResponse> CreateBeetleGameData(BeetleGameDataRequest beetleGameDataRequest);
        //Task<CreateGameDataResponse> CreateCardGameData(CardGameDataRequest cardGameDataRequest);
        //Task<CreateGameDataResponse> CreateMarbleGameData(MarbleGameDataRequest marbleGameDataRequest);
        //Task<CreateGameDataResponse> CreateFruitGameData(FruitGameDataRequest fruitGameDataRequest);

        //Task CreateOrUpdateGameDataAsync<T>(T gameData) where T : class;

        Task CreateOrUpdateGameDataAsync(object gameData);

    }
}

