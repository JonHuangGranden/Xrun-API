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

        public async Task<RegisterRes> Register(RegisterReq userRequestToRegister)
        {
            var existingUser = await _usersCollection.Find(u => u.Email == userRequestToRegister.Email).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                return new RegisterRes
                {
                    Success = false,
                    Msg = "-此帳號已被註冊-"
                };
            }

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

            return new RegisterRes
            {
                Success = true,
                UserName = user.Name,
                Msg = "註冊成功"
            };
        }


        public async Task<LoginRes> Login(LoginReq loginReq)
        {

            try
            {
                var user = await _usersCollection.Find(u => u.Email == loginReq.UserEmail).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new LoginRes { Success = false, Msg = "帳號不存在" };
                }
                if (user != null)
                {
                    if (PasswordWithSaltHashHelper.ValidatePassword(loginReq.UserPassword, user.PasswordToHash, user.Salt))
                    {
                        var token = JWTHelper.GenerateToken(
                           "testtesttesttesttesttesttest111111111111111",  // 從配置或安全源取得
                            user.Id,
                            DateTime.UtcNow.AddDays(7)  // Token有效期
                        );
                        return new LoginRes
                        {
                            Success = true,
                            Token = token,
                            UserName = user.Name,
                            Msg = "登入成功"
                        };
                    }
                    return new LoginRes { Success = false, Msg = "密碼錯誤" };
                }
                return new LoginRes { Success = false, Msg = "錯誤" };
            } catch (Exception ex)
            {
                return new LoginRes { Success = false, Msg = ex.Message };
            }
        }
    }
}
