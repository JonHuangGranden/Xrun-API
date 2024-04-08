using MongoDB.Driver;
using SimplePostApi.Models;
using Microsoft.Extensions.Options;
using 看課程;

public class DataService
{
    private readonly IMongoCollection<User> _usersCollection;
    //IMongoCollection是MongoDB 的官方.NET 驱动程序（MongoDB.NET Driver）提供的接口。
    //User 是一个类，表示 MongoDB 中的一个文档，通常用于表示用户的数据。
    //    这意味着 _usersCollection 是一个包含用户文档的集合
    public DataService(IOptions<MongoDbSettings> mongoDbSettings)
    //IOptions<MongoDbSettings>
    {
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<User>("Users");
        
    }

    public async Task CreateAsync(User user)
    {
        await _usersCollection.InsertOneAsync(user);
    }
}
