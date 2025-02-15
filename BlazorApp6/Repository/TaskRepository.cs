using Microsoft.EntityFrameworkCore;

namespace BlazorApp6.Repository;

public class TaskRepository : Repository<TaskCard>, ITaskRepository
{
    public TaskRepository(DataContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<TaskCard>> GetAllAsync()
    {
        return await DbSet
            .Include(x => x.Category)
            .ToListAsync();
    }
}