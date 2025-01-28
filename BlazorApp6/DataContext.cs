using Microsoft.EntityFrameworkCore;
namespace BlazorApp6;

public class DataContext: DbContext
{
   public DataContext(DbContextOptions<DataContext> options) : base(options)
   {
      
   }
   public DbSet<TaskCard> TaskCards  => Set<TaskCard>();
}