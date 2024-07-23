using System;
using MongoDB.Driver;
using SharpCompress.Common;
//using Xrun.DataAccess.GameData.Entity;
using Xrun.Repositories.UserGameData.Interface;
using Xrun.Repositories.BackpageUserData;
using System.Numerics;
using Xrun.Service.BackpageUserData;
using Xrun.DataAccess.GameData.Entity;

namespace Xrun.Repositories.BackpageUserData
{
    public class BackpageUserDataRepository : IBackpageUserDataRepository
    {

        private readonly IMongoCollection<UserAllGameDataList> _userGameDataCollection;

        public BackpageUserDataRepository(IMongoCollection<UserAllGameDataList> userGameDataCollection)
        {
            _userGameDataCollection = userGameDataCollection;
        }



        public async Task<UserAllGameDataList> GetByNHINumberAsync(NHINumberRequest nhiNumberRequest)
        {
            string nhiNumber = nhiNumberRequest.NHINumber;
            Console.WriteLine(nhiNumber);
            return await _userGameDataCollection.Find(x => x.NHINumber == nhiNumber).FirstOrDefaultAsync();
        }
    

    }
}




