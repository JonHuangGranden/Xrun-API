
using System;
using MongoDB.Driver;
using Xrun.Repositories.UserInformation.Interface;
using Xrun.DataAccess.UserInformation.Entity;




namespace Xrun.Repositories.UserInformation
{
	public class UserInformationRepository : IUserInformationRepository
    {
        private readonly IMongoCollection<UserInformationEntity> _usersCollection;
        //因為program.cs已經有註冊了
        //所以在這邊可以DI将 IMongoCollection<XX>注入到 XX類中

        public UserInformationRepository(IMongoCollection<UserInformationEntity> collection)
        {
            _usersCollection = collection;
        }


        public async Task<UserInformationEntity> GetUserByNHINumberAsync(string nhiNumber)
        {
            return await _usersCollection.Find(u => u.NHINumber == nhiNumber).FirstOrDefaultAsync();
        }


        public async Task<List<UserInformationEntity>> GetAllUserInformationAsync()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }

        public async Task InsertUserAsync(UserInformationEntity userInformationEntity)
        {
            await _usersCollection.InsertOneAsync(userInformationEntity);
        }




    }
}





