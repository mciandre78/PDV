using System;
using System.Threading.Tasks;

namespace pdv.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}
