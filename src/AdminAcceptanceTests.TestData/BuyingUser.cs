using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.TestData
{
    public sealed class BuyingUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String EmailAddress { get; set; }
        public String ContactDetail { get; set; }
        public String OrganisationIdentifyier { get; set; }

        public BuyingUser GenerateRandomUser(String OrganisationIdentifyier = null)
        {
            Faker faker = new Faker();
            return new BuyingUser
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                EmailAddress = faker.Internet.Email(),
                ContactDetail = faker.Phone.PhoneNumber(),
                OrganisationIdentifyier = OrganisationIdentifyier ?? faker.Random.Number(999).ToString()
            };
        }
    }
}
