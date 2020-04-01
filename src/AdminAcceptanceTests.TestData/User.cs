﻿using AdminAcceptanceTests.TestData.Utils;
using Bogus;
using System;
using System.Linq;

namespace AdminAcceptanceTests.TestData
{
    public sealed class User
    {
        public Guid Id { get; set; } = new Guid();
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public int EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public Guid ConcurrencyStamp { get; set; } = new Guid();
        public string PhoneNumber { get; set; }
        public int PhoneNumberConfirmed { get; set; }
        public int TwoFactorEnabled { get; set; }
        public string LockoutEnd { get; set; }
        public int LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public Guid PrimaryOrganisationId { get; set; } = new Guid();
        public string OrganisationFunction { get; set; }
        public int Disabled { get; set; }
        public int CatalogueAgreementSigned { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User GenerateRandomUser(bool BuyingUser = true, Guid PrimaryOrganisationId = new Guid())
        {
            Faker faker = new Faker();
            var generatedEmail = faker.Internet.Email();
            return new User
            {
                Id = faker.Random.Guid(),
                Email = generatedEmail,
                UserName = generatedEmail,
                NormalizedUserName = generatedEmail.ToUpper(),
                NormalizedEmail = generatedEmail.ToUpper(),
                EmailConfirmed = 1,
                PasswordHash = faker.Random.Hash(),
                SecurityStamp = faker.Random.Hash(),
                ConcurrencyStamp = faker.Random.Guid(),
                PhoneNumber = faker.Phone.PhoneNumber(),
                PhoneNumberConfirmed = 0,
                TwoFactorEnabled = 0,
                LockoutEnd = null,
                LockoutEnabled = 1,
                AccessFailedCount = 0,
                PrimaryOrganisationId = PrimaryOrganisationId,
                OrganisationFunction = BuyingUser ? "Buyer" : "Authority",
                Disabled = 0,
                CatalogueAgreementSigned = 0,
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName()               
            };
        }    

        public User Retrieve(string connectionString)
        {
            var query = @"SELECT 
                    Convert(UniqueIdentifier, Id) as Id
                    ,[UserName]
                      ,[NormalizedUserName]
                      ,[Email]
                      ,[NormalizedEmail]
                      ,[EmailConfirmed]
                      ,[PasswordHash]
                      ,[SecurityStamp]
                      ,Convert(UniqueIdentifier, ConcurrencyStamp) as ConcurrencyStamp
                      ,[PhoneNumber]
                      ,[PhoneNumberConfirmed]
                      ,[TwoFactorEnabled]
                      ,[LockoutEnd]
                      ,[LockoutEnabled]
                      ,[AccessFailedCount]
                      ,Convert(UniqueIdentifier, PrimaryOrganisationId) as PrimaryOrganisationId
                      ,[OrganisationFunction]
                      ,[Disabled]
                      ,[CatalogueAgreementSigned]
                      ,[FirstName]
                      ,[LastName]
                    FROM [dbo].[AspNetUsers] WHERE Email=@email";
            return SqlExecutor.Execute<User>(connectionString, query, this).Single();
        }
    }
}
