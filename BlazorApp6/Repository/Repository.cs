using Microsoft.EntityFrameworkCore;

namespace BlazorApp6.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbSet<T> DbSet;

    public Repository(DataContext context)
    {
        DbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id); // Повертає будь-яку сутність за ID
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync(); // Повертає всі записи будь-якої сутності
    }

    public virtual async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity); // Додає будь-який об'єкт
    }

    public virtual void Update(T entity)
    {
        DbSet.Update(entity); // Оновлює будь-який об'єкт
    }

    public virtual void Delete(T entity)
    {
        DbSet.Remove(entity); // Видаляє будь-який об'єкт
    }
}