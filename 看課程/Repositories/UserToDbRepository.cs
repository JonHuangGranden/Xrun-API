using MongoDB.Driver;
using 看課程.Repositories.Interfaces;
//using 看課程.Service.Identity.Requests;

using 看課程.DataAccess.Identity.Entity;
using Microsoft.Extensions.Options;
using MongoD;




namespace 看課程.Repositories
{
    public class UserToDbRepository : IUserToDbRepository
    {
        private readonly IMongoCollection<UserDataToDB> _usersCollection;

        public UserToDbRepository(IOptions<MongoDbSettings> mongoDbSettings)
            //当您通过 IOptions<MongoDbSettings> 访问配置时，
            //ASP.NET Core 的配置系统会负责从appsettings.json（或其他配置源）加载配置，
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<UserDataToDB>("UsersWithSalt");
        }
        //=================================================
        //public UserRepository(IMongoCollection<UserDataToDB> usersCollection)
        //{
        //    _usersCollection = usersCollection;
        //}


        public async Task<UserDataToDB> GetUserByEmailAsync(string email)
        {
            return await _usersCollection.Find(u => u.Email == email).FirstOrDefaultAsync();
        }
        public async Task<UserDataToDB> FindUserByIdAsync(string userId)
        {
            return await _usersCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();
        }

        public async Task InsertUserAsync(UserDataToDB user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

 
        public async Task<bool> UpdateUserJtiAsync(string userId, string newJti)
        {
            var update = Builders<UserDataToDB>.Update.Set(u => u.CurrJTI, newJti);
            var result = await _usersCollection.UpdateOneAsync(u => u.Id == userId, update);
            return result.ModifiedCount == 1;
        }

    }


}




