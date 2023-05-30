using System.Linq.Expressions;
using MongoDB.Driver;
using potg.Database.Interfaces;

namespace potg.Database;

public class MongoRepository<T> : IMongoRepository<T> where T : IMongoEntity
{
    public MongoRepository(IMongoCollection<T> collection) => Collection = collection;

    protected IMongoCollection<T> Collection { get; }

    /// <summary>
    ///     Deletes a single document.
    /// </summary>
    public async Task DeleteOneAsync(T entity)
    {
        await Collection.DeleteOneAsync(x => x.Id == entity.Id);
    }

    /// <summary>
    ///     The result of the delete operation.
    /// </summary>
    public async Task DeleteOneAsync(Expression<Func<T, bool>> expression)
    {
        await Collection.DeleteOneAsync(expression);
    }

    /// <summary>
    ///     Find the document matching the filter and returns the first document of the cursor, or a default value if the
    ///     cursos contains no documents.
    /// </summary>
    public async Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        return await Collection.Find(expression).FirstOrDefaultAsync();
    }

    /// <summary>
    ///     Find the document matching the filter and returns the first document of the cursor, or a default value if the
    ///     cursos contains no documents.
    /// </summary>
    public T FirstOrDefault(Expression<Func<T, bool>> expression)
    {
        return Collection.FindSync(expression).FirstOrDefault();
    }

    /// <summary>
    ///     Find the document matching the filter and determines whether the cursor returned  by a cursor source contains any
    ///     documents.
    /// </summary>
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await Collection.Find(expression).AnyAsync();
    }

    /// <summary>
    ///     Inserts a single document.
    /// </summary>
    public async Task InsertOneAsync(T entity)
    {
        await Collection.InsertOneAsync(entity);
    }

    /// <summary>
    ///     Replaces a single document.
    /// </summary>
    public async Task ReplaceOneAsync(T entity)
    {
        await Collection.ReplaceOneAsync(doc => doc.Id == entity.Id, entity);
    }

    /// <summary>
    ///     Deletes multiple documents.
    /// </summary>
    public async Task DeleteManyAsync(Expression<Func<T, bool>> expression)
    {
        await Collection.DeleteManyAsync(expression);
    }

    /// <summary>
    ///     Counts the number of documents in the collection.
    /// </summary>
    public async Task<long> CountDocuments(Expression<Func<T, bool>> expression)
    {
        return await Collection.CountDocumentsAsync(expression);
    }

    /// <summary>
    /// Finds the documents matching the filter.
    /// </summary>
    public async Task<IAsyncCursor<T>> FindAsync(Expression<Func<T, bool>> expression)
    {
        return await Collection.FindAsync(expression);
    }
}