using BlazorApp6.Repository;
using BlazorApp6.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp6.UnitOfWork;


public interface IUnitOfWork : IDisposable
{
    ITaskCardRepository TaskCards { get; }

    IRepository<T> Repository<T>() where T : class;

    Task<int> SaveChangesAsync();
}

