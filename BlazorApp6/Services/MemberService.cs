using BlazorApp6.Repository;
using BlazorApp6.UnitOfWork;

namespace BlazorApp6.Services;

public class MemberService {
    
    private readonly IUnitOfWork _unitOfWork;

    public MemberService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Member> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Member>().GetByIdAsync(id);
    }

    public async Task<IEnumerable<Member>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Member>().GetAllAsync();
    }

    public async Task AddAsync(Member entity)
    {
        await _unitOfWork.Repository<Member>().AddAsync(entity);
    }

    public async Task UpdateAsync(Member entity)
    {
        _unitOfWork.Repository<Member>().Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Member>().GetByIdAsync(id);
        if (entity != null)
        {
            _unitOfWork.Repository<Member>().Delete(entity);
        }
    }
}