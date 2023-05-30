using MongoDB.Bson;

namespace potg.Database.Interfaces;

public interface IMongoEntity
{
    ObjectId Id { get; init; }
}