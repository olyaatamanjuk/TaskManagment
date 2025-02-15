using BlazorApp6.Repository;
using BlazorApp6.UnitOfWork;

namespace BlazorApp6.Services;

public class PropertyService {
    
    private readonly IUnitOfWork _unitOfWork;

    public PropertyService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Property> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Property>().GetByIdAsync(id);
    }

    public async Task<IEnumerable<Property>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Property>().GetAllAsync();
    }

    public async Task AddAsync(Property entity)
    {
        await _unitOfWork.Repository<Property>().AddAsync(entity);
    }

    public async Task UpdateAsync(Property entity)
    {
        _unitOfWork.Repository<Property>().Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await  _unitOfWork.Repository<Property>().GetByIdAsync(id);
        if (entity != null)
        {
            _unitOfWork.Repository<Property>().Delete(entity);
        }
    }
}