using System;
using System.Threading.Tasks;
using HassanBank.Domain.Entities;


namespace HassanBank.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;

        // التصحيح: CompleteAsync (كانت مكتوبة غلط)
        Task<int> CompleteAsync();
    }
}