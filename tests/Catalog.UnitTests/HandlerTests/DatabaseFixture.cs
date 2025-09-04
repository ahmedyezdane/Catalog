using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Respawn;
using System.Data.Common;

namespace Catalog.UnitTests.HandlerTests;

public class DatabaseFixture : IAsyncLifetime
{
    private Respawner _respawner;
    private DbConnection _connection;

    public ApplicationDbContext Context { get; private set; }

    public DatabaseFixture()
    {
        string connectionString = "Server=localhost,1433;Database=Catalog;User ID=sa;Password=Ahmad@12101382;TrustServerCertificate=True;";

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                              .UseSqlServer(connectionString)
                              .Options;

        Context = new ApplicationDbContext(options);
    }

    public async Task InitializeAsync()
    {
        var respawnerOptions = new RespawnerOptions
        {
            TablesToIgnore =
            [
                new Respawn.Graph.Table("__EFMigrationsHistory")
            ]
        };

        _connection = Context.Database.GetDbConnection();
        await _connection.OpenAsync();

        _respawner = await Respawner.CreateAsync(_connection, respawnerOptions);
    }

    public async Task DisposeAsync()
    {
        await _respawner.ResetAsync(_connection);
        await _connection.CloseAsync();
    }
}

[CollectionDefinition("QueryHandlerCollection", DisableParallelization = true)]
public class QueryHandlerCollection : ICollectionFixture<DatabaseFixture>
{
    // Class used only for Collection Definition
}