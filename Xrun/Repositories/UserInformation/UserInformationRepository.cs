
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
        //所以在這邊可以DI将 IMongoCollection<UserAccountEntity> 注入到 UserToDbRepository 类中

        public UserInformationRepository(IMongoCollection<UserInformationEntity> collection)
        {
            _usersCollection = collection;
        }



        //Task<UserInformationEntity> GetUserByNHINumberAsync(string nhiNumber);
        //Task InsertUserAsync(UserInformationEntity userInformationEntity);


        public async Task<UserInformationEntity> GetUserByNHINumberAsync(string nhiNumber)
        {
            return await _usersCollection.Find(u => u.Id == nhiNumber).FirstOrDefaultAsync();
        }


        public async Task InsertUserAsync(UserInformationEntity userInformationEntity)
        {
            await _usersCollection.InsertOneAsync(userInformationEntity);
        }
    }
}





