namespace AdminAcceptanceTests.Steps.Utils
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AdminAcceptanceTests.TestData;
    using Newtonsoft.Json.Linq;

    internal static class EnvironmentVariables
    {
        internal static (string Url, string HubUrl, string Browser, string ServerUrl, string DatabaseName, string DbUser, string DbPassword) Get()
        {
            var url = Url();
            var hubUrl = HubUrl();
            var browser = Browser();

            var (serverUrl, databaseName, dbUser, dbPassword) = DbConnectionDetails();

            return (url, hubUrl, browser, serverUrl, databaseName, dbUser, dbPassword);
        }

        internal static string HubUrl()
        {
            return Environment.GetEnvironmentVariable("HUBURL") ?? "http://localhost:4444/wd/hub";
        }

        internal static string Url()
        {
            var uri = Environment.GetEnvironmentVariable("PBURL") ?? DefaultUri();
            return uri.TrimEnd('/');
        }

        internal static string Browser()
        {
            return Environment.GetEnvironmentVariable("BROWSER") ?? "ChromeLocal";
        }

        internal static (string ServerUrl, string DatabaseName, string DbUser, string DbPassword) DbConnectionDetails()
        {
            var serverUrl = Environment.GetEnvironmentVariable("SERVERURL") ?? "127.0.0.1,1450";
            var databaseName = Environment.GetEnvironmentVariable("DATABASENAME") ?? "CatalogueUsers";
            var dbUser = JsonConfigValues("user", "NHSD-ISAPI");
            var dbPassword = JsonConfigValues("password", "DisruptTheMarket1!");

            return (ServerUrl: serverUrl, DatabaseName: databaseName, DbUser: dbUser, DbPassword: dbPassword);
        }

        internal static string DbConnectionString()
        {
            var (serverUrl, databaseName, dbUser, dbPassword) = DbConnectionDetails();

            return string.Format(ConnectionString.GPitFutures, serverUrl, databaseName, dbUser, dbPassword);
        }

        internal static User AdminUser()
        {
            var path = Path.Combine(
                Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory),
                "Utils",
                "tokens.json");
            var jsonSection = JObject.Parse(File.ReadAllText(path))["adminUser"];
            var user = jsonSection.ToObject<User>();

            if (user.UserName.Contains("#{") || user.PasswordHash.Contains("#{"))
            {
                user = new User { UserName = "BobSmith@email.com", PasswordHash = "Pass123$" };
            }

            return user;
        }

        private static string JsonConfigValues(string section, string defaultValue)
        {
            var path = Path.Combine(
                Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory),
                "Utils",
                "tokens.json");
            var jsonSection = JObject.Parse(File.ReadAllText(path))[section];

            var dbValues = jsonSection.ToObject<Dictionary<string, string>>();

            var result = dbValues.Values
                .FirstOrDefault(s => !s.Contains("#{"));

            return string.IsNullOrEmpty(result) ? defaultValue : result;
        }

        private static string DefaultUri()
        {
            var uri = "https://host.docker.internal";

            return uri;
        }
    }
}
