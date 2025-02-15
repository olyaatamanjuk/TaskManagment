using BlazorApp6;
using BlazorApp6.UnitOfWork;

public class TaskCardService {
    
    private readonly IUnitOfWork _unitOfWork;

    public TaskCardService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    
    public async Task<TaskCard> GetByIdAsync(int id)
    {
        if (_unitOfWork == null) throw new NullReferenceException("_unitOfWork is null");
        var repo = _unitOfWork.Repository<TaskCard>();
        if (repo == null) throw new NullReferenceException("Repository<TaskCard> is null");

        return await repo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<TaskCard>> GetAllAsync()
    {
        if (_unitOfWork == null) throw new NullReferenceException("_unitOfWork is null");
        var repo = _unitOfWork.TaskCards;
        if (repo == null) throw new NullReferenceException("Repository<TaskCard> is null");

        return await repo.GetAllAsync();
    }

    public async Task AddAsync(TaskCard entity)
    {
        if (_unitOfWork == null) throw new NullReferenceException("_unitOfWork is null");
        var repo = _unitOfWork.Repository<TaskCard>();
        if (repo == null) throw new NullReferenceException("Repository<TaskCard> is null");

        await repo.AddAsync(entity);
    }

    public async Task UpdateAsync(TaskCard entity)
    {
        if (_unitOfWork == null) throw new NullReferenceException("_unitOfWork is null");
        var repo = _unitOfWork.Repository<TaskCard>();
        if (repo == null) throw new NullReferenceException("Repository<TaskCard> is null");

        repo.Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        if (_unitOfWork == null) throw new NullReferenceException("_unitOfWork is null");
        var repo = _unitOfWork.Repository<TaskCard>();
        if (repo == null) throw new NullReferenceException("Repository<TaskCard> is null");

        var entity = await repo.GetByIdAsync(id);
        if (entity != null)
        {
            repo.Delete(entity);
        }
    }
}
