using Microsoft.EntityFrameworkCore;

namespace BlazorApp6.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected DataContext _context;
    protected readonly DbSet<T> DbSet;

    public Repository(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        DbSet = _context.Set<T>() ?? throw new ArgumentNullException($"DbSet<{typeof(T).Name}> is null");

        Console.WriteLine($"Repository<{typeof(T).Name}> initialized.");
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public virtual void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        DbSet.Remove(entity);
    }
}