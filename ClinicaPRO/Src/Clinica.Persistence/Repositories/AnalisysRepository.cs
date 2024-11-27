using Clinica.Application.Interface.Interfaces;
using Clinica.Domain.Entities;
using Clinical.Infraestructure.Context;
using Dapper;
using System.Data;

namespace Clinica.Persistence.Repositories
{
    public class AnalisysRepository : IAnalisysRepository
    {
        private readonly ApplicationDbContext _context;

        public AnalisysRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Analysis>> ListAnalisys()
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisList";

            var analysis = await connection.QueryAsync<Analysis>(query, commandType: CommandType.StoredProcedure);

            return analysis;
        }

        public async Task<Analysis> AnalysisByid(int analysisId)
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisByid";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysisId);

            var analysis = await connection.QuerySingleOrDefaultAsync<Analysis>(query,param: parameters,commandType: CommandType.StoredProcedure);

            return analysis;
        }


        public async Task<bool> AnalysisRegister(Analysis analysis)
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisRegister";

            var parameters = new DynamicParameters();
            parameters.Add("Name", analysis.Name);
            parameters.Add("State", 1);
            parameters.Add("AuditCreateDate", DateTime.Now);

            var recordsAffected = await connection
                .ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;
        }

        public async Task<bool> AnalysisUpdate(Analysis analysis)
        {
            using var connection = _context.CreateConnection;

                var query = "uspAnalysisUpdate";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysis.AnalysisId);
            parameters.Add("Name", analysis.Name);

            var recordsAffected = await connection
                .ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;


        }

        public async Task<bool> AnalysisDelete(int analysisId)
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisDelete";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysisId);

            var recordsAffected = await connection
                .ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;
        }
    }
}

