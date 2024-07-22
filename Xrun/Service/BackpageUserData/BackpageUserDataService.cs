using System;
using System.Numerics;
using Xrun.DataAccess.GameData.Interface;
using Xrun.DataAccess.GameDataDataAccess;
using Xrun.Repositories.BackpageUserData;
using Xrun.Service.BackpageUserData.Interface;
using Xrun.Service.GameData.Interface;
using Xrun.Service.BackpageUserData;
using Xrun.DataAccess.GameData.Entity;
using Xrun.Service.UserInformation.Request;

namespace Xrun.Service.BackpageUserData
{
	public class BackpageUserDataService : IBackpageUserDataService
    {
        private readonly IBackpageUserDataRepository _backpageUserDataRepository;

        public BackpageUserDataService(IBackpageUserDataRepository backpageUserDataRepository)
        {
            _backpageUserDataRepository = backpageUserDataRepository;
        }
       
        public async Task<UserAllGameDataList> GetBackpageUserAllGameDataListAsync(NHINumberRequest nhiNumberRequest)
        {
            var result = await _backpageUserDataRepository.GetByNHINumberAsync(nhiNumberRequest);

            return result;      
        }


        public async Task<List<UserAllGameDataList>> GetAllUserGameDataAsync()
        {
            var result = await _backpageUserDataRepository.GetAllUserGameDataAsync();
            return result;
        }


        //public async Task<BackpageAllUserInformation> GetBackpageAllUserInformationAsync(string nhiNumber)
        //{
        //    await _backpageUserDataRepository.GetByNHINumberAsync(nhiNumber);

        //    return new BackpageAllUserInformation();
        //}


    }
}





