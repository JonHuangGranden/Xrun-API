using MongoDB.Driver;
using 看課程.Repositories.Identity.Interface;
using 看課程.DataAccess.Identity.Entity;
using Microsoft.Extensions.Options;
using MongoD;


namespace 看課程.Repositories
{
    public class UserToDbRepository : IUserToDbRepository
    {
        private readonly IMongoCollection<UserAccountToDB> _usersCollection;
        //因為program.cs已經有註冊了
        //所以在這邊可以DI将 IMongoCollection<UserAccountToDB> 注入到 UserToDbRepository 类中

        public UserToDbRepository(IMongoCollection<UserAccountToDB> collection)
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
        //    var collection = mongoClient.GetDatabase(dbName).GetCollection<UserAccountToDB>("UsersWithSalt");

        //    _usersCollection = collection;
        //}
        //=================================================


        public async Task<UserAccountToDB> GetUserByEmailAsync(string email)
        {
            return await _usersCollection.Find(u => u.Email == email).FirstOrDefaultAsync();
        }
        public async Task<UserAccountToDB> GetUserByIdAsync(string userId)
        {
            return await _usersCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();
        }

        public async Task InsertUserAsync(UserAccountToDB user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        public async Task<bool> UpdateUserJtiAsync(string userId, string newJti)
        {
            var update = Builders<UserAccountToDB>.Update.Set(u => u.CurrJTI, newJti);
            var result = await _usersCollection.UpdateOneAsync(u => u.Id == userId, update);
            return result.ModifiedCount == 1;
        }
    }


}




