using System;
using Xrun.DataAccess.GameData.Entity;
using Xrun.Service.BackpageUserData;

namespace Xrun.Service.BackpageUserData.Interface
{
	public interface IBackpageUserDataService
	{

        //Task<BackpageAllUserInformation> GetBackpageAllUserInformationAsync();

        Task<UserAllGameDataList> GetBackpageUserAllGameDataListAsync(NHINumberRequest nhiNumberRequest);
        Task<List<UserAllGameDataList>> GetAllUserGameDataAsync();



    }
}

