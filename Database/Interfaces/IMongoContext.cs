using MongoDB.Driver;

namespace potg.Database.Interfaces;

public interface IMongoContext
{
    public IMongoCollection<T> GetCollection<T>(string collection);
}