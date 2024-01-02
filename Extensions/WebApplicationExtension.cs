using ApiPagamentos.Context;
using EvolveDb;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ApiPagamentos.Extensions;

public static class WebApplicationExtension 
{
    public static void AddMigration(this WebApplication app, string connectionString)
    {
        try {
            var connection = new SqliteConnection(connectionString);

            var evolve = new Evolve(connection)
            {
                Locations = new List<string>() {"Database/Migrations", "Database/DataSet"},
                IsEraseDisabled = true,
            };

            evolve.Migrate();
        }
        catch 
        {
            throw;
        }
    }

    public static WebApplicationBuilder AddApiDbContext(this WebApplicationBuilder builder)
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        dbContextOptionsBuilder.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));

        var appDbContext = new AppDbContext(dbContextOptionsBuilder.Options);

        builder.Services.AddSingleton(appDbContext);

        return builder;
    }
}