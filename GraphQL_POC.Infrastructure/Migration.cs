using System.Reflection;
using Microsoft.Data.Sqlite;

namespace GraphQL_POC.Infrastructure;

public static class Migration
{
    public static void Migrate()
    {
        var currentLocation = Assembly.GetExecutingAssembly().Location;
        var currentDirectory = Path.GetDirectoryName(currentLocation);
        using var connection = new SqliteConnection($"Data Source={currentDirectory}/poc.db");
        
        connection.Open();
        
        const string sql = "CREATE TABLE IF NOT EXISTS patients (id TEXT PRIMARY KEY, first_name TEXT NOT NULL)";
        
        var command = connection.CreateCommand();
        command.CommandText = sql;
        
        command.ExecuteNonQuery();
        
        connection.Close();
    }
}