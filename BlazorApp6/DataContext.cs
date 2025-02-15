using Microsoft.EntityFrameworkCore;
namespace BlazorApp6;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    protected DbSet<TaskCard> TaskCards { get; set; }
    protected DbSet<Member> Members { get; set; }
    protected DbSet<Category> Categories { get; set; }
    protected DbSet<Property> Properties { get; set; }
}