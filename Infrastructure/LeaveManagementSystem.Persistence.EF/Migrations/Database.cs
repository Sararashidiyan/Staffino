using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace LeaveManagementSystem.Persistence.EF.Migrations
{
    public static class Database
    {
        public static void EnsureDatabase()
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", DatabaseConstants.DatabaseName);
            using var connection = new SqlConnection(DatabaseConstants.MasterConnectionString);
            var records = connection.Query("SELECT * FROM sys.Databases WHERE name = @name", parameters);
            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE {DatabaseConstants.DatabaseName}");
            }
        }

        public static class DatabaseConstants
        {
            public static string MasterConnectionString=> "Data Source=192.168.39.45;Initial Catalog=master;User ID=sa;Password=King1167";
            public static string DatabaseName=>"Demo";
        }

    }
}