using Microsoft.AspNetCore.Identity.Data;
using Service.Identity.Interface;
using 看課程.Service.Identity.Requests;
using Common.Helper;
using 看課程.Models;
using Microsoft.Extensions.Options;
using MongoD;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;


namespace 看課程.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IMongoCollection<User> _usersCollection;
        //IMongoCollection是MongoDB 的官方.NET 驱动程序（MongoDB.NET Driver）提供的接口。
        //User 是一个类，表示 MongoDB 中的一个文档，通常用于表示用户的数据。
        //    这意味着 _usersCollection 是一个包含用户文档的集合
        public IdentityService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<User>("UsersWithSalt");
        }

        //public async Task<object> Register(RegisterRequest registerRequest)
        //{

        //}

        public async Task Register(UserRequestToRegister userRequestToRegister)

        {
            var salt = PasswordWithSaltHashHelper.GenerateSalt();
            var passwordHash = PasswordWithSaltHashHelper.GenerateHash(userRequestToRegister.Password, salt);
            var user = new User()
            {
                Id = userRequestToRegister.Id,
                Email = userRequestToRegister.Email,
                Name = userRequestToRegister.Name,
                PasswordToHash = passwordHash,
                Salt = salt
            };
            await _usersCollection.InsertOneAsync(user);
        }


        public async Task<object> Login(LoginReq loginReq)
        {
            var user = await _usersCollection.Find(u => u.Email == loginReq.UserEmail).FirstOrDefaultAsync();

            if (user != null)
            {


                if (PasswordWithSaltHashHelper.ValidatePassword(loginReq.UserPassword, user.PasswordToHash, user.Salt)) {

                    //return "成功";
                    var token = JWTHelper.GenerateToken(
                       "testtesttesttesttesttesttest",  // 应从配置或安全源获取
                          "id",
                      // user.Id,  // 使用用户ID生成Token
                       DateTime.UtcNow.AddDays(7)  // Token有效期
                    );

                    return token;
                }
                return "密碼錯誤";
            }

            return "null";

        }





    }
}
