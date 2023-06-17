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

            var sql = @"SELECT Id, OrganizationId, FirstName, LastName, EmailAddress, ContactNumber,
                        IsActive, IsDelete, CreateTimestamp, DeleteTimestamp FROM public.user;";
            var result = await connection.QueryAsync<User>(sql);

            return result;
        }

        public async Task<User> GetById(int Id)
        {
            using var connection = _databaseContext.CreateConnection();

            var sql = @"SELECT Id, OrganizationId, FirstName, LastName, EmailAddress, ContactNumber,
                        IsActive, IsDelete, CreateTimestamp, DeleteTimestamp FROM public.user
                        WHERE Id = @Id;";
            var result = await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = Id });

            return result;
        }
    }
}

