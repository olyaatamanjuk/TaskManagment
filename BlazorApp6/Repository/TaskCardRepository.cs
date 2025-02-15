using Microsoft.EntityFrameworkCore;

namespace BlazorApp6.Repository;

public class TaskCardRepository : Repository<TaskCard>, ITaskCardRepository
{
    
    public TaskCardRepository(DataContext context) : base(context)
    
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    

    public override async Task<IEnumerable<TaskCard>> GetAllAsync()
    {
        return await DbSet
            .Include(x => x.Category)
            .ToListAsync();
    }
}