using MongoDB.Driver;
using Xrun.Repositories.UserInfo.Interface;
using Xrun.DataAccess.UserInfo.Entity;
using Microsoft.Extensions.Options;
using MongoD;


namespace Xrun.Repositories.UserInfo
{
    public class UserInfoRepository : IUserInfoRepository
    {

        private readonly IMongoCollection<UserInfoEntity> _usersCollection;
        //因為program.cs已經有註冊了
        //所以在這邊可以DI将 IMongoCollection<UserAccountEntity> 注入到 UserToDbRepository 类中

        public UserInfoRepository(IMongoCollection<UserInfoEntity> collection)
        {
            _usersCollection = collection;
        }

        //======

        public async Task<UserInfoEntity> GetUserInfoByIdAsync(string userId)
        {
            return await _usersCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();
        }


        public async Task InsertUserInfoAsync(UserInfoEntity UserInfoEntity)
        {
            await _usersCollection.InsertOneAsync(UserInfoEntity);
        }

        //public async Task<bool> UpdateUserInfoAsync(string userId, string field, string value)
        //{
        //}


    }


}




