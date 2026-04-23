using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DataAccess;

public class MongoDbConnectionFactory : IMongoDbConnectionFactory, IDisposable
{
    private readonly IConfiguration configuration;
    private bool disposedValue;

    public MongoDbConnectionFactory(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string ConnectionString => configuration["MongoDb:ConneX"] ?? throw new InvalidOperationException("MongoDB connection string is not configured.");

    public string DatabaseName => configuration["MongoDb:Database"] ?? throw new InvalidOperationException("MongoDB database is not set.");

    public IMongoDatabase? Database { get; private set; }

    public IMongoDatabase GetDatabase()
    {
        if (Database == null)
        {
            var client = new MongoClient(ConnectionString);
            Database = client.GetDatabase(DatabaseName);
        }

        return Database;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}