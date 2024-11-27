using Clinica.Application.Interface.Interfaces;
using Clinical.Infraestructure.Context;
using Dapper;
using Microsoft.Identity.Client;
using System.Data;

namespace Clinica.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
           _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync(string storeProcedure)
        {
            using var connection = _context.CreateConnection;
            return await connection.QueryAsync<T>(storeProcedure, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(string storeProcedure, object parameter)
        {
            
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await connection
                .QuerySingleOrDefaultAsync<T>(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> ExecAsync(string storeProcedure, object parameters)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameters);
            var recordAffected = await connection
                .ExecuteAsync(storeProcedure, param:objParam, commandType:CommandType.StoredProcedure);
            return recordAffected > 0;
        }
    }
}
