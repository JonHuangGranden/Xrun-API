//using MongoDB.Driver;
//using 看課程.Repositories.UserInfo.Interfaces;
//using 看課程.DataAccess.UserInfo.Entity;
//using Microsoft.Extensions.Options;
//using MongoD;


//namespace 看課程.Repositories.UserInfo
//{
//    public class UserInfoRepository : IUserInfoRepository
//    {

//        private readonly IMongoCollection<UserInfoToDB> _usersCollection;

//        public UserInfoRepository(IMongoCollection<UserInfoToDB> collection)
//        {
//            _usersCollection = collection;
//        }



                            //private readonly IMongoCollection<  > _usersCollection;
                            //public UserInfoRepository(IOptions<MongoDbSettings> mongoDbSettings)     
                            //{
                            //    var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
                            //    var dbName = mongoDbSettings.Value.DatabaseName;
                            //    var collection = mongoClient.GetDatabase(dbName).GetCollection<   >("UsersWithSalt");

                            //    _usersCollection = collection;
                            //}





        //public async Task<UserInfoToDB> GetUserByIdAsync(string userId)
        //{
        //    return await _usersCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();
        //}

    
        //public async Task InsertUserInfoAsync(UserInfoToDB userInfoToDB)
        //{
        //    return await _usersCollection.Find(u => u.Email == email).FirstOrDefaultAsync();
        //}
        //public async Task<bool> UpdateUserInfoAsync(string userId, string field, string value)
        //{
        //    return await _usersCollection.Find(u => u.Email == email).FirstOrDefaultAsync();
        //}


//    }


//}




