using BlazorApp6.Repository;
using BlazorApp6.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp6.UnitOfWork;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
    
        public ITaskCardRepository  TaskCards { get; }

        // Загальний репозиторій для всіх інших моделей
        public IRepository<T> Repository<T>() where T : class => new Repository<T>(_context);
        
        public UnitOfWork(DataContext context, ITaskCardRepository taskCardRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            TaskCards = taskCardRepository ?? throw new ArgumentNullException(nameof(taskCardRepository));
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
    
