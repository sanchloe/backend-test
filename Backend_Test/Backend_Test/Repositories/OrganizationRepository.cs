using System;
using Dapper;
using Backend_Test.Context;
using Backend_Test.Models;

namespace Backend_Test.Repositories

{   public class OrganizationRepository{
        private readonly DatabaseContext _databaseContext;

        public OrganizationRepository(DatabaseContext context){
            _databaseContext = context;
        }

        // Retrieve a list of organization
        public async Task<IEnumerable<Organization>> GetAll(){
            using var connection = _databaseContext.CreateConnection();

            var sql = @"SELECT name, businessregistrationnumber, address, postcode, contactnumber, createdtimestamp
                        FROM organization;";
            var result = await connection.QueryAsync<Organization>(sql);

            return result;
        }

        // Retrieve organization by Business Registraion Number
        public async Task<Organization> GetById(int BusinessRegistrationNumber){
            using var connection = _databaseContext.CreateConnection();

            var sql = @"SELECT name, businessregistrationnumber, address, postcode, contactnumber, createdtimestamp
                        FROM organization
                        WHERE businessregistrationnumber = @BusinessRegistrationNumber;;";
            var result = await connection.QueryFirstOrDefaultAsync<Organization>(sql, new { BusinessRegistrationNumber = BusinessRegistrationNumber.ToString() });

            return result;
        }

        // Create a new organization
        public async Task<int> CreateOrganization(Organization organization){
            using var connection = _databaseContext.CreateConnection();

            var sql = @"INSERT INTO organization (name, businessregistrationnumber, address, postcode, contactnumber)
            VALUES (@name, @businessregistrationnumber, @address, @postcode, @contactnumber);";
            var result = await connection.ExecuteAsync(sql, new { name = organization.Name,
            businessregistrationnumber = organization.BusinessRegistrationNumber,
            address = organization.Address,
            postcode = organization.PostCode,
            contactnumber = organization.ContactNumber });

            return result;
        }
    }
}