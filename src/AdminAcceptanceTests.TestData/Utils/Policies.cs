using Polly;
using System;
using System.Data.SqlClient;

namespace AdminAcceptanceTests.TestData.Utils
{
    internal static class Policies
    {
        internal static ISyncPolicy RetryPolicy()
        {
            return Policy.Handle<SqlException>()
                .Or<TimeoutException>()
                .WaitAndRetry(3, retryAttempt => TimeSpan.FromMilliseconds(500));
        }
    }
}
