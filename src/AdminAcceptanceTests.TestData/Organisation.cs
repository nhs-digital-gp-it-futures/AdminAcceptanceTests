using AdminAcceptanceTests.TestData.Utils;
using System;
using System.Linq;

namespace AdminAcceptanceTests.TestData
{
    public sealed class Organisation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OdsCode { get; set; }
        public string PrimaryRoleId { get; set; }
        public int CatalogueAgreementSigned { get; set; }
        public DateTime LastUpdated { get; set; }

        public Organisation RetrieveByODSCode(string connectionString, string ODSCode)
        {
            var query = @"SELECT * FROM [dbo].[Organisations] WHERE OdsCode=@ODSCode";
            return SqlExecutor.Execute<Organisation>(connectionString, query, new { ODSCode }).Single();
        }
    }
}
