using System;
using Dapper;
using Backend_Test.Context;
using Backend_Test.Models;

namespace Backend_Test.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using var connection = _databaseContext.CreateConnection();

            var sql = @"SELECT name, businessregistrationnumber, address, postcode, contactnumber, createdtimestamp FROM organization;";
            var result = await connection.QueryAsync<User>(sql);

            return result;
        }

        public async Task<User> GetById(int Id)
        {
            using var connection = _databaseContext.CreateConnection();

            var sql = @"SELECT name, businessregistrationnumber, address, postcode, contactnumber, createdtimestamp
                        FROM public.organization
                        WHERE businessregistrationnumber = @businessregistrationnumber;";
            var result = await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = Id });

            return result;
        }
    }
}

