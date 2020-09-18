using AdminAcceptanceTests.TestData;
using Microsoft.Extensions.Configuration;

namespace AdminAcceptanceTests.Steps.Utils
{
    public sealed class Settings
    {
        public string HubUrl { get; set; }

        public string PBUrl { get; set; }

        public string Browser { get; set; }

        public DatabaseSettings DatabaseSettings { get; set; }
        public User AdminUser { get; set; }


        public Settings(IConfiguration config)
        {
            HubUrl = config.GetValue<string>("hubUrl");
            PBUrl = config.GetValue<string>("pbUrl");
            Browser = config.GetValue<string>("browser");
            DatabaseSettings = SetUpDatabaseSettings(config);
            AdminUser = GetAdminUser(config);
        }

        private DatabaseSettings SetUpDatabaseSettings(IConfiguration config)
        {
            var databaseSettings = config.GetSection("db").Get<DatabaseSettings>();
            databaseSettings.ConnectionString = ConstructDatabaseConnectionString(
                databaseSettings.ServerUrl,
                databaseSettings.DatabaseName,
                databaseSettings.User,
                databaseSettings.Password);
            return databaseSettings;
        }

        private User GetAdminUser(IConfiguration config)
        {
            return config.GetSection("adminUser").Get<User>();
        }

        private static string ConstructDatabaseConnectionString(string serverUrl, string databaseName, string user, string password) =>
            string.Format(ConnectionStringTemplate, serverUrl, databaseName, user, password);

        private static string ConnectionStringTemplate => @"Server={0};Initial Catalog={1};Persist Security Info=false;User Id={2};Password={3}";
    }
}
