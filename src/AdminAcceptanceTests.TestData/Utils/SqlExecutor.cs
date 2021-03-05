namespace AdminAcceptanceTests.TestData.Utils
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Dapper;

    internal static class SqlExecutor
    {
        internal static async Task<IEnumerable<T>> ExecuteAsync<T>(string connectionString, string query, object param)
        {
            IEnumerable<T> returnValue = null;
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            await Policies.RetryPolicyAsync().ExecuteAsync(async () => { returnValue = await connection.QueryAsync<T>(query, param); });
            return returnValue;
        }
    }
}
