using AdminAcceptanceTests.TestData.Utils;
using Bogus;
using System;
using System.Linq;

namespace AdminAcceptanceTests.TestData
{
    public sealed class Organisation
    {
        public Guid OrganisationId { get; set; }
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

        public Organisation RetrieveById(string connectionString, Guid id)
        {
            var query = @"SELECT * FROM [dbo].[Organisations] WHERE OrganisationId=@id";
            return SqlExecutor.Execute<Organisation>(connectionString, query, new { id }).Single();
        }

        public Organisation RetrieveRandomOrganisation(string connectionString)
        {
            var query = @"SELECT * FROM [dbo].[Organisations]";
            var listOfItems = SqlExecutor.Execute<Organisation>(connectionString, query, this);
            return listOfItems.ElementAt(new Faker().Random.Number(listOfItems.Count() - 1));
        }
    }
}
