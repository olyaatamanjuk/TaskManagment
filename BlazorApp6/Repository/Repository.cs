using Microsoft.EntityFrameworkCore;

namespace BlazorApp6.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id); // Повертає будь-яку сутність за ID
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync(); // Повертає всі записи будь-якої сутності
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity); // Додає будь-який об'єкт
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity); // Оновлює будь-який об'єкт
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity); // Видаляє будь-який об'єкт
    }
}