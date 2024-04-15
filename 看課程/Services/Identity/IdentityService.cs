using Microsoft.AspNetCore.Identity.Data;
using Service.Identity.Interface;
using 看課程.Service.Identity.Requests;
using Common.Helper;
//using 看課程.Models;
using Microsoft.Extensions.Options;
using MongoD;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using 看課程.Service.Identity.Response;


namespace 看課程.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IMongoCollection<UserDataToDB> _usersCollection;
        //IMongoCollection是MongoDB 的官方.NET 驱动程序（MongoDB.NET Driver）提供的接口。
        //User 是一个类，表示 MongoDB 中的一个文档，通常用于表示用户的数据。
        //    这意味着 _usersCollection 是一个包含用户文档的集合
        public IdentityService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<UserDataToDB>("UsersWithSalt");
        }

        public async Task Register(RegisterReq userRequestToRegister)

        {
            var salt = PasswordWithSaltHashHelper.GenerateSalt();
            var passwordHash = PasswordWithSaltHashHelper.GenerateHash(userRequestToRegister.Password, salt);
            var user = new UserDataToDB()
            {
                Id = userRequestToRegister.Id,
                Email = userRequestToRegister.Email,
                Name = userRequestToRegister.Name,
                PasswordToHash = passwordHash,
                Salt = salt
            };
            await _usersCollection.InsertOneAsync(user);
        }


        public async Task<LoginResult> Login(LoginReq loginReq)
        {
            var user = await _usersCollection.Find(u => u.Email == loginReq.UserEmail).FirstOrDefaultAsync();

            if (user == null)
            {
                return new LoginResult { Success = false, ErrorMessage = "帳號不存在" };
            }
            if (user != null)
            {
                if (PasswordWithSaltHashHelper.ValidatePassword(loginReq.UserPassword, user.PasswordToHash, user.Salt)) {
                    var token = JWTHelper.GenerateToken(
                       "testtesttesttesttesttesttest123123123123123123",  // 從配置或安全源取得
                        user.Id,
                        DateTime.UtcNow.AddDays(7)  // Token有效期
                    );
                    return new LoginResult
                    {
                        Success = true,
                        Token = token,
                        UserName = user.Name
                    };
                }
                return new LoginResult { Success = false, ErrorMessage = "密碼錯誤" };
            }
            return new LoginResult { Success = false, ErrorMessage = "錯誤" };

        }
    }
}
