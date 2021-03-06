﻿namespace AdminAcceptanceTests.TestData
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AdminAcceptanceTests.TestData.Utils;
    using Bogus;
    using Microsoft.AspNetCore.Identity;

    public sealed class User
    {
        public Guid Id { get; set; } = default;

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public int EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public Guid ConcurrencyStamp { get; set; } = default;

        public string PhoneNumber { get; set; }

        public int PhoneNumberConfirmed { get; set; }

        public int TwoFactorEnabled { get; set; }

        public string LockoutEnd { get; set; }

        public int LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public Guid PrimaryOrganisationId { get; set; } = default;

        public string OrganisationFunction { get; set; }

        public int Disabled { get; set; }

        public int CatalogueAgreementSigned { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public static string ConcatDisplayName(User user)
        {
            return string.Join(" ", user.FirstName, user.LastName);
        }

        public static string GenericTestPassword() => "BuyingC@t4logue";

        public User GenerateRandomUser(bool buyingUser = true, Guid primaryOrganisationId = default)
        {
            Faker faker = new();
            var generatedEmail = faker.Internet.Email();
            return new User
            {
                Id = faker.Random.Guid(),
                Email = generatedEmail,
                UserName = generatedEmail,
                NormalizedUserName = generatedEmail.ToUpper(),
                NormalizedEmail = generatedEmail.ToUpper(),
                EmailConfirmed = 1,
                PasswordHash = new PasswordHasher<User>().HashPassword(this, GenericTestPassword()),
                SecurityStamp = faker.Random.Hash(),
                ConcurrencyStamp = faker.Random.Guid(),
                PhoneNumber = faker.Phone.PhoneNumber(),
                PhoneNumberConfirmed = 0,
                TwoFactorEnabled = 0,
                LockoutEnd = null,
                LockoutEnabled = 1,
                AccessFailedCount = 0,
                PrimaryOrganisationId = primaryOrganisationId,
                OrganisationFunction = buyingUser ? "Buyer" : "Authority",
                Disabled = 0,
                CatalogueAgreementSigned = 0,
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
            };
        }

        public async Task Create(string connectionString)
        {
            var query = @"INSERT INTO AspNetUsers (
                            Id,
                            UserName,
                            NormalizedUserName,
                            Email,
                            NormalizedEmail,
                            EmailConfirmed,
                            PasswordHash,
                            SecurityStamp,
                            ConcurrencyStamp,
                            PhoneNumber,
                            PhoneNumberConfirmed,
                            TwoFactorEnabled,
                            LockoutEnd,
                            LockoutEnabled,
                            AccessFailedCount,
                            PrimaryOrganisationId,
                            OrganisationFunction,
                            Disabled,
                            CatalogueAgreementSigned,
                            FirstName,
                            LastName
                        )
                        VALUES (
                            @id,
                            @userName,
                            @normalizedUserName,
                            @email,
                            @normalizedEmail,
                            @emailConfirmed,
                            @passwordHash,
                            @securityStamp,
                            @concurrencyStamp,
                            @phoneNumber,
                            @phoneNumberConfirmed,
                            @twoFactorEnabled,
                            @lockoutEnd,
                            @lockoutEnabled,
                            @accessFailedCount,
                            @primaryOrganisationId,
                            @organisationFunction,
                            @disabled,
                            @catalogueAgreementSigned,
                            @firstName,
                            @lastName
                        )";

            await SqlExecutor.ExecuteAsync<User>(connectionString, query, this);
        }

        public async Task<User> Retrieve(string connectionString)
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
            var users = await SqlExecutor.ExecuteAsync<User>(connectionString, query, this);
            return users.Single();
        }

        public async Task<User> RetrieveRandomBuyerUser(string connectionString)
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
                    FROM [dbo].[AspNetUsers] WHERE OrganisationFunction='Buyer'";
            var listOfItems = await SqlExecutor.ExecuteAsync<User>(connectionString, query, this);
            return listOfItems.ElementAt(new Faker().Random.Number(listOfItems.Count() - 1));
        }

        public async Task Update(string connectionString)
        {
            var query = @"UPDATE AspNetUsers 
                        SET 
                            UserName=@userName,
                            NormalizedUserName=@normalizedUserName,
                            Email=@email,
                            NormalizedEmail=@normalizedEmail,
                            EmailConfirmed=@emailConfirmed,
                            PasswordHash=@passwordHash,
                            SecurityStamp=@securityStamp,
                            ConcurrencyStamp=@concurrencyStamp,
                            PhoneNumber=@phoneNumber,
                            PhoneNumberConfirmed=@phoneNumberConfirmed,
                            TwoFactorEnabled=@twoFactorEnabled,
                            LockoutEnd=@lockoutEnd,
                            LockoutEnabled=@lockoutEnabled,
                            AccessFailedCount=@accessFailedCount,
                            PrimaryOrganisationId=@primaryOrganisationId,
                            OrganisationFunction=@organisationFunction,
                            Disabled=@disabled,
                            CatalogueAgreementSigned=@catalogueAgreementSigned,
                            FirstName=@firstName,
                            LastName=@lastName
                        WHERE Id=@id";

            await SqlExecutor.ExecuteAsync<User>(connectionString, query, this);
        }

        public async Task Delete(string connectionString)
        {
            var query = @"DELETE FROM AspNetUsers WHERE UserName=@userName";

            await SqlExecutor.ExecuteAsync<User>(connectionString, query, this);
        }
    }
}
