using MongoDB.Driver;
using 看課程.Repositories.UserInfo.Interfaces;
using 看課程.DataAccess.UserInfo.Entity;
using Microsoft.Extensions.Options;
using MongoD;


namespace 看課程.Repositories.UserInfo
{
    public class UserInfoRepository : IUserInfoRepository
    {

         private readonly IMongoCollection<UserInfoToDB> _usersCollection;
        //因為program.cs已經有註冊了
        //所以在這邊可以DI将 IMongoCollection<UserAccountToDB> 注入到 UserToDbRepository 类中

        public UserInfoRepository(IMongoCollection<UserInfoToDB> collection)
        {
            _usersCollection = collection;
        }


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


    }


}




