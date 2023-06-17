using System;
using Microsoft.Extensions.Options;
using Dapper;
using Npgsql;
using System.Data;

namespace Backend_Test.Context
{
    public class DatabaseContext
    {
        private DatabaseSettings _databaseSettings;

        public DatabaseContext(IOptions<DatabaseSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings.Value;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = $"Server={_databaseSettings.Server}; Database={_databaseSettings.Database}; User Id={_databaseSettings.UserId}; Password={_databaseSettings.Password}; Ssl Mode=VerifyCA;";
            return new NpgsqlConnection(connectionString);
        }
    }
}

