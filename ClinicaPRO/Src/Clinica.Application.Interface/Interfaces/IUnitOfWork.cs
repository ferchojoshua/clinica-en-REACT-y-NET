using Clinica.Domain.Entities;

namespace Clinica.Application.Interface.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Analysis> Analysis { get;}

    }
}
