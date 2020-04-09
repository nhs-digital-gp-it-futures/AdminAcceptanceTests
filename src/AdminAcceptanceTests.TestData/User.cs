using AdminAcceptanceTests.TestData.Utils;
using Bogus;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

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

        public static string ConcatDisplayName(User user)
        {
            return string.Join(" ", user.FirstName, user.LastName);
        }

        public User GenerateRandomUser(bool BuyingUser = true, Guid PrimaryOrganisationId = new Guid())
        {
            var genericTestPassword = "BuyingC@t4logue";
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
                PasswordHash = GenerateHash(genericTestPassword),
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

        public User RetrieveRandomBuyerUser(string connectionString)
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
            var listOfItems = SqlExecutor.Execute<User>(connectionString, query, this);
            return listOfItems.ElementAt(new Faker().Random.Number(listOfItems.Count() -1));
        }

        public void Create(string connectionString)
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

            SqlExecutor.Execute<User>(connectionString, query, this);
        }

        public void Update(string connectionString)
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

            SqlExecutor.Execute<User>(connectionString, query, this);
        }
        public void Delete(string connectionString)
        {
            var query = @"DELETE FROM AspNetUsers WHERE Id=@id";
            SqlExecutor.Execute<User>(connectionString, query, this);
        }

        private static string GenerateHash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return password;
            }

            const int identityVersion = 1; // 1 = Identity V3
            const int iterationCount = 10000;
            const int passwordHashLength = 32;
            const KeyDerivationPrf hashAlgorithm = KeyDerivationPrf.HMACSHA256;
            const int saltLength = 16;

            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[saltLength];
            rng.GetBytes(salt);

            var pbkdf2Hash = KeyDerivation.Pbkdf2(
                password,
                salt,
                hashAlgorithm,
                iterationCount,
                passwordHashLength);

            var identityVersionData = new byte[] { identityVersion };
            var prfData = BitConverter.GetBytes((uint)hashAlgorithm).Reverse().ToArray();
            var iterationCountData = BitConverter.GetBytes((uint)iterationCount).Reverse().ToArray();
            var saltSizeData = BitConverter.GetBytes((uint)saltLength).Reverse().ToArray();

            var hashElements = new[]
            {
                identityVersionData,
                prfData,
                iterationCountData,
                saltSizeData,
                salt,
                pbkdf2Hash
            };

            var identityV3Hash = new List<byte>();
            foreach (var data in hashElements)
            {
                identityV3Hash.AddRange(data);
            }

            if (!identityV3Hash.Count.Equals(61))
            {
                throw new ArithmeticException();
            }
            return Convert.ToBase64String(identityV3Hash.ToArray());
        }
    }
}
