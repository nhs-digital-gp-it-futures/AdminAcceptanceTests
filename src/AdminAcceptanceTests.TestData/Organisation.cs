namespace AdminAcceptanceTests.TestData
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AdminAcceptanceTests.TestData.Utils;
    using Bogus;

    public sealed class Organisation
    {
        public Guid OrganisationId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string OdsCode { get; set; }

        public string PrimaryRoleId { get; set; }

        public int CatalogueAgreementSigned { get; set; } = 0;

        public DateTime LastUpdated { get; set; }

        public static async Task<Organisation> RetrieveByODSCode(string connectionString, string odsCode)
        {
            var query = @"SELECT * FROM [dbo].[Organisations] WHERE OdsCode=@ODSCode";
            var result = await SqlExecutor.ExecuteAsync<Organisation>(connectionString, query, new { odsCode });
            return result.Single();
        }

        public static async Task<Organisation> RetrieveById(string connectionString, Guid id)
        {
            var query = @"SELECT * FROM [dbo].[Organisations] WHERE OrganisationId=@id";
            var results = await SqlExecutor.ExecuteAsync<Organisation>(connectionString, query, new { id });
            return results.Single();
        }

        public async Task Create(string connectionString)
        {
            var query = @"INSERT INTO [dbo].[Organisations] (
                            OrganisationId
                            ,Name
                            ,Address
                            ,OdsCode
                            ,PrimaryRoleId
                            ,CatalogueAgreementSigned
                            ,LastUpdated
                        )
                        VALUES (
                            @organisationId
                            ,@name
                            ,@address
                            ,@odsCode
                            ,@primaryRoleId
                            ,@catalogueAgreementSigned
                            ,@lastUpdated
                        )";

            await SqlExecutor.ExecuteAsync<User>(connectionString, query, this);
        }

        public async Task<Organisation> RetrieveRandomOrganisation(string connectionString)
        {
            var query = @"SELECT * FROM [dbo].[Organisations]";
            var listOfItems = await SqlExecutor.ExecuteAsync<Organisation>(connectionString, query, this);
            return listOfItems.ElementAt(new Faker().Random.Number(listOfItems.Count() - 1));
        }

        public async Task Delete(string connectionString)
        {
            var query = @"DELETE FROM  [dbo].[Organisations] WHERE OrganisationId=@organisationId OR OdsCode=@odsCode";
            await SqlExecutor.ExecuteAsync<Organisation>(connectionString, query, this);
        }
    }
}
