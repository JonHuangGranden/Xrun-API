using Service.Identity.Interface;
using 看課程.Service.Identity.Requests;

using Common.Helper;
using Microsoft.Extensions.Options;
using MongoD;
using MongoDB.Driver;
using 看課程.Service.Identity.Response;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Diagnostics;
using System.Linq;
using 看課程.DataAccess.Identity.Interface;
using 看課程.DataAccess.Identity.Entity;


namespace 看課程.Services.Identity
{
    public class IdentityService : IIdentityService
    {
       // private readonly IMongoCollection<UserDataToDB> _usersCollection;
                            //IMongoCollection是MongoDB 的官方.NET 驱动程序（MongoDB.NET Driver）提供的接口。
                            //User 是一个类，表示 MongoDB 中的一个文档，通常用于表示用户的数据。
                            //    这意味着 _usersCollection 是一个包含用户文档的集合
        //public IdentityService(IOptions<MongoDbSettings> mongoDbSettings)
                            //IOptions<MongoDbSettings> 不是直接等同于 appsettings.json 文件，
                            //而是一个用于访问配置数据的接口，这些配置数据通常来源于 appsettings.json。
                            //IOptions<T> 是 ASP.NET Core 提供的一个机制，用于方便地访问强类型配置数据。
                            //这里的 T 是一个用户定义的类，用来表示配置信息。在你的例子中，T 是 MongoDbSettings 类。
        //{
        //    var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        //var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
        //_usersCollection = mongoDatabase.GetCollection<UserDataToDB>("UsersWithSalt");
        //}



    private readonly IIdentityDataAccess _dataAccess;

        public IdentityService(IIdentityDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }



        public async Task<RegisterRes> Register(RegisterReq registerReq)
        {
            //var existingUser = await _usersCollection.Find(u => u.Email == userRequestToRegister.Email).FirstOrDefaultAsync();
            var existingUser = await _dataAccess.GetUserByEmailAsync(registerReq.Email);//改用dal的

            if (existingUser != null)
            {
                return new RegisterRes
                {
                    Success = false,
                    Msg = "此帳號已被註冊"
                };
            }
            var salt = PasswordWithSaltHashHelper.GenerateSalt();
            var passwordHash = PasswordWithSaltHashHelper.GenerateHash(registerReq.Password, salt);
            var user = new UserAccountToDB()
            {
            //    Id = registerReq.Id,
                Email = registerReq.Email,
                Name = registerReq.Name,
                PasswordToHash = passwordHash,
                Salt = salt
            };
           // await _usersCollection.InsertOneAsync(user);
            await _dataAccess.InsertUserAsync(user);//改用dal的


            return new RegisterRes
            {
                Success = true,
                UserName = user.Name,
                Msg = "註冊成功"
            };
        }
        //=========================================================================
     
        public async Task<LoginRes> Login(LoginReq loginReq)
        //=========== 登入成功 就更新db refresh token   ==============

        {
            try
            {
             //   var user = await _usersCollection.Find(u => u.Email == loginReq.UserEmail).FirstOrDefaultAsync();
                var user = await _dataAccess.GetUserByEmailAsync(loginReq.UserEmail);//改用dal的


                if (user == null)
                {
                    return new LoginRes { Success = false, Msg = "帳號不存在" };
                }
                if (user != null)
                {
                    if (PasswordWithSaltHashHelper.ValidatePassword(loginReq.UserPassword, user.PasswordToHash, user.Salt))
                    {

                        string jtiString = Guid.NewGuid().ToString();

                        //var update = Builders<UserDataToDB>.Update.Set(u => u.CurrJTI, jtiString);
                        //await _usersCollection.UpdateOneAsync(u => u.Id == user.Id, update);
                        bool updateSuccess = await _dataAccess.UpdateUserJtiAsync(user.Id, jtiString);//dal取代上面兩行
                        //登入覆蓋舊的jti

                        var accessToken = JWTHelper.GenerateToken(
                            "AccessToken_Key_test_000000000000000000", 
                            user.Id,
                            DateTime.UtcNow.AddSeconds(10)  
                            , jtiString
                        );
                        var refreshToken = JWTHelper.GenerateToken(
                           "refreshToken_secretKey_testtesttest_22222222222222222",  
                            user.Id,
                            DateTime.UtcNow.AddMinutes(30)  
                            , jtiString
                        );
                        Debug.WriteLine($"jtiString字串為~{jtiString}");

                        return new LoginRes
                        {
                            Success = true,
                            AccessToken = accessToken,
                            RefreshToken = refreshToken,
                            UserName = user.Name,
                            Msg = "登入成功,已更新DB中refresh token",
                        };
                    }
                    return new LoginRes { Success = false, Msg = "密碼錯誤" };
                }
                return new LoginRes { Success = false, Msg = "錯誤" };
            }
            catch (Exception ex)
            {
                return new LoginRes { Success = false, Msg = ex.Message };
            }
        }
        //==============================================================

        //public async Task<LoginRes> RefreshToken(RefreshTokenReq refreshTokenReq)
        public async Task<RefreshTokenRes> verifyRefreshToken(string token)
        //===== 【只有當access過期】才要驗證refresh，就要來打這個api 。  ====
        //=========== 有成功 就更新db refresh token   ==============
        {
            try
            {
                var principal = JWTHelper.GetPrincipalFromToken(token, "refreshToken_secretKey_testtesttest_22222222222222222",true);
                //principal是ClaimsPrincipal 对象
                if (principal == null)
                {               
                     return new RefreshTokenRes { Success = false, Msg = "無效的token" };
                }
                //principal是ClaimsPrincipal 对象

                string? userId = principal.Claims.FirstOrDefault(r => r.Type.Equals(ClaimTypes.NameIdentifier)).Value;
                var jtiFromToken = principal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value;
                if (userId == null || jtiFromToken == null)
                {
                    return new RefreshTokenRes { Success = false, Msg = "token提取後查無此用戶" };
                }
                Debug.WriteLine($"token解析後提取的用戶jti為{jtiFromToken}");
                Debug.WriteLine($"token解析後提取的用戶id: {userId}");


               // var user = await _usersCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();
                var user = await _dataAccess.FindUserByIdAsync(userId);//改用dal的


                Debug.WriteLine($"從資料庫提取的: {user}");
                              //解碼後得到id然後去資料庫找
                if (user == null)
                {
                    return new RefreshTokenRes { Success = false, Msg = "-無效Refresh Token-" };
                }
                if (user.CurrJTI != jtiFromToken)
                {
                    return new RefreshTokenRes { Success = false, Msg = "jti不符，Refresh Token失效!" };
                }
                //====　↓　驗證通過　↓　====
                string jtiString = Guid.NewGuid().ToString();
                var update = Builders<UserAccountToDB>.Update.Set(u => u.CurrJTI, jtiString);

             
          //     await _usersCollection.UpdateOneAsync(u => u.Id == user.Id, update);
                bool updateSuccess = await _dataAccess.UpdateUserJtiAsync(user.Id, jtiString);//dal取代上面一行

            




                //更新db中的refresh token
                var newAccessToken = JWTHelper.GenerateToken(
                "AccessToken_Key_test_000000000000000000",
                    user.Id,
                    DateTime.UtcNow.AddSeconds(10),
                    jtiString);
                var NewRefreshToken = JWTHelper.GenerateToken(
                    "refreshToken_secretKey_testtesttest_22222222222222222",
                    user.Id,
                    DateTime.UtcNow.AddMinutes(30)  // Refresh token有效期
                    , jtiString
                );

                return new RefreshTokenRes
                {
                    Success = true,
                    AccessToken = newAccessToken,
                    RefreshToken = NewRefreshToken,
                    Msg = "已更新db中的refresh token,"
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during token refresh: {ex.Message}");
                return new RefreshTokenRes { Success = false, Msg = "catch-刷新token發生錯誤" };
            }
        }


        // ===================================================================================

        public async Task<RefreshTokenRes> verifyAccessToken(string token)
        //===== 存取resuource才驗證access ====
        //access token只驗證期限 不去資料庫(我認為)
        //access token claim裡面可以包含用戶資料(我認為)

          //伺服器取得 JWT 時只驗證是否有被竄改以及過期，
        {
            try { 
                 var principal = JWTHelper.GetPrincipalFromToken(token, "AccessToken_Key_test_000000000000000000", true);
                if (principal == null)
                {
                     return new RefreshTokenRes { Success = false, Msg = "access token過期" };
                }
                string? userId = principal.Claims.FirstOrDefault(r => r.Type.Equals(ClaimTypes.NameIdentifier)).Value;
                //var jtiClaim = principal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);
                //我覺得access不驗證jti
                Debug.WriteLine($"access token解析後提取的用戶id: {userId}");
                return new RefreshTokenRes
                {
                    Success = true,          
                    Msg = "access Token驗證成功"
                };
            }
             catch (Exception ex)
            {
                Debug.WriteLine($"Error during token refresh: {ex.Message}");
                return new RefreshTokenRes { Success = false, Msg = "catch-刷新token發生錯誤" };
            }
        }




















        //public async Task<LoginRes> Login(LoginReq loginReq)
        //{
        //    try
        //    {
        //        var user = await _usersCollection.Find(u => u.Email == loginReq.UserEmail).FirstOrDefaultAsync();
        //        if (user == null)
        //        {
        //            return new LoginRes { Success = false, Msg = "帳號不存在" };
        //        }
        //        if (user != null)
        //        {
        //            if (PasswordWithSaltHashHelper.ValidatePassword(loginReq.UserPassword, user.PasswordToHash, user.Salt))
        //            {
        //                var token = JWTHelper.GenerateToken(
        //                   "testtesttesttesttesttesttest111111111111111",  // 從配置或安全源取得
        //                    user.Id,
        //                    DateTime.UtcNow.AddDays(7)  // Token有效期
        //                );
        //                return new LoginRes
        //                {
        //                    Success = true,
        //                    Token = token,
        //                    UserName = user.Name,
        //                    Msg = "登入成功"
        //                };
        //            }
        //            return new LoginRes { Success = false, Msg = "密碼錯誤" };
        //        }
        //        return new LoginRes { Success = false, Msg = "錯誤" };
        //    } catch (Exception ex)
        //    {
        //        return new LoginRes { Success = false, Msg = ex.Message };
        //    }
        //}



        //=========================================================================



    }
}
