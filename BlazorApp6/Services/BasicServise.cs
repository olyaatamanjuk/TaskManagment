using BlazorApp6.Repository;

namespace BlazorApp6.Services;

public class BasicService<T> : IService<T> where T : class
{
    private readonly IRepository<T> _repository;

    public BasicService(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _repository.Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null)
        {
            _repository.Delete(entity);
        }
    }
}
