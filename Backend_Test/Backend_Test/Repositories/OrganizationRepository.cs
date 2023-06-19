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
    }
}