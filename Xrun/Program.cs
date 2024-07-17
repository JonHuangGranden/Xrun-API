using MongoD;
using Xrun.Extensions;


using Xrun.Repositories;
//===
using Xrun.Services.Identity;
using Service.Identity.Interface;
using Xrun.DataAccess.Identity;
using Xrun.DataAccess.Identity.Interface;
using Xrun.DataAccess.Identity.Entity;
using Xrun.Repositories.Identity.Interface;
//===
using Xrun.Services.UserInfo;
using Xrun.Service.UserInfo.Interface;
using Xrun.DataAccess.UserInfo;
using Xrun.DataAccess.UserInfo.Interface;
using Xrun.DataAccess.UserInfo.Entity;
using Xrun.Repositories.UserInfo.Interface;
using Xrun.Repositories.UserInfo;
//===
//using Xrun.Services.UserInformation;
using Xrun.Service.UserInformation.Interface;
using Xrun.DataAccess.UserInformation;


using Xrun.Service.UserInformation;

using Xrun.DataAccess.UserInformation.Interface;
using Xrun.DataAccess.UserInformation.Entity;
using Xrun.Repositories.UserInformation;
using Xrun.Repositories.UserInformation.Interface;




var builder = WebApplication.CreateBuilder(args);




//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//使用.GetSection("MongoDbSettings") 是从应用的配置系统（如 appsettings.json、环境变量等）中获取特定部分的配置。
var mongoDbSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();


//===寫法3     (透過extensions)
builder.Services.AddMongoDBCollections(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName);
builder.Services.AddDBCollection<UserAccountEntity>("UsersAccount");
builder.Services.AddDBCollection<UserInfoEntity>("UserInfo");

builder.Services.AddDBCollection<UserInformationEntity>("UserInformation");

//==


//=====寫法2    (不在倉庫層處理db，並且有封裝)
//builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
//    new MongoClient(mongoDbSettings.ConnectionString)
//);
//void AddDBCollection<TDocument>(string collectionName)
//{
//    builder.Services.AddSingleton(serviceProvider =>
//    {
//        var mongoClient = serviceProvider.GetRequiredService<IMongoClient>();
//        var database = mongoClient.GetDatabase(mongoDbSettings.DatabaseName);
//        return database.GetCollection<TDocument>(collectionName);
//    });
//}
//AddDBCollection<UserAccountEntity>("UsersAccount");
//AddDBCollection<UserInformationEntity>("UserInfo");


//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//=====寫法1     (不在倉庫層處理db)
//builder.Services.AddSingleton(serviceProvider =>
//{
//    var mongoClient = serviceProvider.GetRequiredService<IMongoClient>();
//    var database = mongoClient.GetDatabase(mongoDbSettings.DatabaseName);
//    var collection = database.GetCollection<UserAccountEntity>("UsersWithSalt");
//    return collection;
//});
//builder.Services.AddSingleton(serviceProvider =>
//{
//    var mongoClient = serviceProvider.GetRequiredService<IMongoClient>();
//    var database = mongoClient.GetDatabase(mongoDbSettings.DatabaseName);
//    var collection = database.GetCollection<UserInformationEntity>("UserInfo");
//    return collection;
//});
//=====
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝


//== ▼cors▼ ===
//您所展示的两段代码中都使用了“options”这一术语
//，这实际上是ASP.NET Core框架中一个常见的配置模式。
//这种模式通常用于在服务注册（ConfigureServices 方法中）
//和中间件配置（Configure 方法中）时设置各种选项。
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowLocalhost5500",
//        policy => policy.WithOrigins("http://127.0.0.1:5500")  
//                        .AllowAnyMethod()  // 允許任何 HTTP 方法
//                        .AllowAnyHeader());  // 允許任何標頭
//});
builder.Services.AddCorsConfiguration();
//== ▲cors▲ ===


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = false,  
//        ValidateAudience = false, 
//        ValidateLifetime = true,  
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("refreshToken_secretKey_testtesttest_22222222222222222")),
//        ClockSkew = TimeSpan.Zero

//    };
//});
builder.Services.AddJwtAuthentication("refreshToken_secretKey_testtesttest_22222222222222222");



//builder.Services.Configure<MongoDbSettings>(
//    builder.Configuration.GetSection("MongoDbSettings")
//);
//这行代码将 MongoDbSettings 配置节注册到依赖注入（DI）系统中。它使配置数据可以通过 IOptions<MongoDbSettings> 或 IOptionsSnapshot<MongoDbSettings> 在需要时解析，通常在服务的构造函数中使用。



    // 配置授权
    //-----------------------------------------
    //builder.Services.AddAuthorization(options =>
    //{
    //    options.AddPolicy("ReqRole",
    //        policy => policy.RequireRole("Administrator"));
    //});

builder.Services.AddCustomAuthorization();

//--------------------

builder.Services.AddSingleton<IUserToDbRepository, UserToDbRepository>();
builder.Services.AddSingleton<IIdentityDataAccess, IdentityDataAccess>();

builder.Services.AddSingleton<IIdentityService, IdentityService>();





builder.Services.AddSingleton<IUserInfoRepository, UserInfoRepository>();
builder.Services.AddSingleton<IUserInfoDataAccess, UserInfoDataAccess>();

builder.Services.AddSingleton<IUserInfoService, UserInfoService>();



builder.Services.AddSingleton<IUserInformationRepository, UserInformationRepository>();
builder.Services.AddSingleton<IUserInformationDataAccess, UserInformationDataAccess>();

builder.Services.AddSingleton<IUserInformationService, UserInformationService>();





//==================

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//===============================



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage(); // ?
}
app.UseRouting();
app.UseCors("AllowLocalhost5500");
app.UseHttpsRedirection();

//---
app.UseAuthentication(); // jwt
app.UseAuthorization();
//驗證 (Authentication)就是讓系統認得你是誰
//授權 (Authorization)讓系統判斷你是否有權限
//---

app.MapControllers();

app.Run();
