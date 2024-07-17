using MongoDB.Driver;
using Xrun.Repositories.Identity.Interface;
using Xrun.DataAccess.Identity.Entity;
using Microsoft.Extensions.Options;
using MongoD;


namespace Xrun.Repositories
{
    public class UserToDbRepository : IUserToDbRepository
    {
        private readonly IMongoCollection<UserAccountEntity> _usersCollection;
        //因為program.cs已經有註冊了
        //所以在這邊可以DI把 IMongoCollection<UserAccountEntity> 注入到 UserToDbRepository 类中

        public UserToDbRepository(IMongoCollection<UserAccountEntity> collection)
        {
            _usersCollection = collection;
        }

        //=================================================
        //public UserToDbRepository(IOptions<MongoDbSettings> mongoDbSettings)
        ////当您通过 IOptions<MongoDbSettings> 访问配置时，
        ////ASP.NET Core 的配置系统会负责从appsettings.json（或其他配置源）加载配置，
        ////IOptions<T>要用.Value訪問
        //{
        //    var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        //    //IOptions<T>要用.Value訪問
        //    var dbName = mongoDbSettings.Value.DatabaseName;
        //    var collection = mongoClient.GetDatabase(dbName).GetCollection<UserAccountEntity>("UsersWithSalt");

        //    _usersCollection = collection;
        //}
        //=================================================


        public async Task<UserAccountEntity> GetUserByEmailAsync(string email)
        {
            return await _usersCollection.Find(u => u.Email == email).FirstOrDefaultAsync();
        }
        public async Task<UserAccountEntity> GetUserByIdAsync(string userId)
        {
            return await _usersCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();
        }

        public async Task InsertUserAsync(UserAccountEntity user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        public async Task<bool> UpdateUserJtiAsync(string userId, string newJti)
        {
            var update = Builders<UserAccountEntity>.Update.Set(u => u.CurrJTI, newJti);
            var result = await _usersCollection.UpdateOneAsync(u => u.Id == userId, update);
            return result.ModifiedCount == 1;
        }
    }


}




