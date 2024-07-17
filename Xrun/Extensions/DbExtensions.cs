
using MongoDB.Driver;

namespace Xrun.Extensions
{
    public static class DbExtensions
    {
        public static IServiceCollection AddMongoDBCollections(this IServiceCollection services, string connectionString, string databaseName)
        {
            services.AddSingleton<IMongoClient>(serviceProvider =>
                new MongoClient(connectionString));

            services.AddSingleton(serviceProvider =>
            {
                var mongoClient = serviceProvider.GetRequiredService<IMongoClient>();
                var database = mongoClient.GetDatabase(databaseName);
                return database;
            });

            return services;
        }

        //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        public static IServiceCollection AddDBCollection<TDocument>(this IServiceCollection services, string collectionName)
        {
            services.AddSingleton(serviceProvider =>
            {
                var database = serviceProvider.GetRequiredService<IMongoDatabase>();
                return database.GetCollection<TDocument>(collectionName);
            });

            return services;
        }
    }
}
