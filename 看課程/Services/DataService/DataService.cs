using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoD;
using 看課程.Services.DataService.Interface;
using 看課程.Models;
using Common.Helper;
//using MongoDB.Bson;

public class DataService : IDataService
{
    private readonly IMongoCollection<User> _usersCollection;
    //IMongoCollection是MongoDB 的官方.NET 驱动程序（MongoDB.NET Driver）提供的接口。
    //User 是一个类，表示 MongoDB 中的一个文档，通常用于表示用户的数据。
    //    这意味着 _usersCollection 是一个包含用户文档的集合
    public DataService(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _usersCollection = mongoDatabase.GetCollection<User>("UsersWithSalt");
    }

    //===============================
    public async Task CreateAsync(UserRequest userRequest)
    {
        var salt = PasswordWithSaltHashHelper.GenerateSalt();
        var passwordHash = PasswordWithSaltHashHelper.GenerateHash(userRequest.Password, salt);

        // 生成salt
        //var salt = PasswordWithSaltHashHelper.GenerateSalt();
        //密碼+salt=哈希


        //user.PasswordToHash = passwordHash;
        //user.Salt = salt;
        var user = new User()
        {
            Id = userRequest.Id,
            Email = userRequest.Email,
            Name = userRequest.Name,
            Password= userRequest.Password,
            PasswordToHash = passwordHash,
            Salt = salt
            
        };
        // 資料庫加鹽（此处假设数据库操作能够处理额外字段）
        await _usersCollection.InsertOneAsync(user);
        //使用 _usersCollection.InsertOneAsync(user) 将新创建的 User 对象插入到MongoDB的集合中。这是一个异步操作，await 关键字用于等待这个操作完成。
        //当你看到这行代码 await _usersCollection.InsertOneAsync(user);
        //，它是在使用 MongoDB 的官方.NET 驱动程序
        //异步地向 MongoDB 数据库中插入一个文档（在这个上下文中，是一个 User 对象）

        //InsertOneAsync 方法是 MongoDB 驱动提供的一个异步方法，
        //用于将单个文档插入到数据库的集合中。
        //这个方法接收一个要插入的文档作为参数，在这个例子中是 user 对象。
    }

    //=======登入========================
    public async Task<bool> ValidateCredentialsAsync(LoginRequest loginRequest)
    {
        var user = await _usersCollection.Find(u => u.Email == loginRequest.UserEmail).FirstOrDefaultAsync();
        if (user != null)
        {
            // 使用保存的盐值和输入的密码生成哈希值，并与存储的哈希值进行比较
            return PasswordWithSaltHashHelper.ValidatePassword(loginRequest.UserPassword, user.PasswordToHash, user.Salt);
        }
        return false;
    }


}