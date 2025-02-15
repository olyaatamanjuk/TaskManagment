using Microsoft.EntityFrameworkCore;
namespace BlazorApp6;

public class DataContext: DbContext
{
   public DataContext(DbContextOptions<DataContext> options) : base(options)
   {
      
   }
   public DbSet<TaskCard> TaskCards  => Set<TaskCard>();
   public DbSet<Member> Members { get; set; }
   public DbSet<Category> Categories { get; set; }
   public DbSet<Property> Properties { get; set; }
}