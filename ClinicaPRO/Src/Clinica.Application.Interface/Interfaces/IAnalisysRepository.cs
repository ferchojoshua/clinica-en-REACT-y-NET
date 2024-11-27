using Clinica.Domain.Entities;

namespace Clinica.Application.Interface.Interfaces
{
    public interface IAnalisysRepository
    {
        Task<IEnumerable<Analysis>> ListAnalisys();
        Task<Analysis> AnalysisByid(int analysisId);
        Task<bool> AnalysisRegister(Analysis analysis);

        Task<bool> AnalysisUpdate(Analysis analysis);

        Task<bool> AnalysisDelete(int analysisId);
    }
}
