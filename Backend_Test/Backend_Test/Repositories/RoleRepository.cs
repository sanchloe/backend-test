using System;
using Dapper;
using Backend_Test.Context;
using Backend_Test.Models;

namespace Backend_Test.Repositories
{
    public class RoleRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RoleRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            using var connection = _databaseContext.CreateConnection();

            var sql = @"SELECT Id, Name, Description FROM public.role;";
            var result = await connection.QueryAsync<Role>(sql);

            return result;
        }

        public async Task<Role> GetById(int Id)
        {
            using var connection = _databaseContext.CreateConnection();

            var sql = @"SELECT Id, Name, Description FROM public.role
                        WHERE Id = @Id;";
            var result = await connection.QueryFirstOrDefaultAsync<Role>(sql, new { Id = Id });

            return result;
        }
    }
}

