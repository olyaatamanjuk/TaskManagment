using BlazorApp6.Repository;
using BlazorApp6.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp6.UnitOfWork;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        
        public IService<Member> Members { get; }
        public IService<Category> Categories { get; }
        public IService<Property> Properties { get; }
        public IService<TaskCard> TaskCards { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Members = new BasicService<Member>(new Repository<Member>(_context));
            Categories = new BasicService<Category>(new Repository<Category>(_context));
            Properties = new BasicService<Property>(new Repository<Property>(_context));
            TaskCards = new BasicService<TaskCard>(new Repository<TaskCard>(_context)); 
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
    
