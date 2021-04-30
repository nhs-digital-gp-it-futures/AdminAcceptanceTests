using AdminAcceptanceTests.TestData.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminAcceptanceTests.TestData
{
    public sealed class RelatedOrganisations
    {
        public Guid OrganisationId { get; set; }

        public Guid RelatedOrganisationId { get; set; }

        public static async Task<IEnumerable<RelatedOrganisations>> GetRelatedOrganisations(string connectionString, Guid orgId)
        {
            var query = "SELECT OrganisationId, RelatedOrganisationId FROM dbo.RelatedOrganisations WHERE OrganisationId = @organisationId";

            return await SqlExecutor.ExecuteAsync<RelatedOrganisations>(connectionString, query, new { organisationId = orgId });
        }
    }
}
