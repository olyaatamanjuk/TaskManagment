using BlazorApp6.Repository;
using BlazorApp6.UnitOfWork;

namespace BlazorApp6.Services;

public class CategoryService {
    
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Category> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Category>().GetByIdAsync(id);
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Category>().GetAllAsync();
    }

    public async Task AddAsync(Category entity)
    {
        await _unitOfWork.Repository<Category>().AddAsync(entity);
    }

    public async Task UpdateAsync(Category entity)
    { 
        _unitOfWork.Repository<Category>().Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Category>().GetByIdAsync(id);
        if (entity != null)
        {
            _unitOfWork.Repository<Category>().Delete(entity);
        }
    }
}