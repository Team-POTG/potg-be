using Microsoft.Extensions.Options;
using MongoDB.Driver;
using potg.Database.Interfaces;

namespace potg.Database;

public class MongoContext : IMongoContext
{
    public MongoContext(IOptions<MongoConfiguration> options)
    {
        Configuration = options.Value;
        Client = new MongoClient(Configuration.ConnectionString);
        Database = Client.GetDatabase(Configuration.Database);
    }

    private MongoConfiguration Configuration { get; }

    private MongoClient Client { get; }

    private IMongoDatabase Database { get; }

    /// <summary>
    ///     콜렉션을 가져옵니다.
    /// </summary>
    public IMongoCollection<T> GetCollection<T>(string collection) => Database.GetCollection<T>(collection);
}