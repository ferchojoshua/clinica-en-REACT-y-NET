using Clinica.Application.Interface.Interfaces;
using Clinica.Domain.Entities;

namespace Clinica.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Analysis> Analysis { get; }

        public UnitOfWork(IGenericRepository<Analysis> analysis)
        {
            Analysis = analysis;
        }
       
        public void Dispose() 
        {
            GC.SuppressFinalize(this);
        }
    }
}
