using BlazorApp6.Repository;
using BlazorApp6.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp6.UnitOfWork;


    public interface IUnitOfWork : IDisposable
    {
        IService<Member> Members { get; }
        IService<Category> Categories { get; }
        IService<Property> Properties { get; }
        IService<TaskCard> TaskCards { get; }
        Task<int> SaveChangesAsync();
    }
