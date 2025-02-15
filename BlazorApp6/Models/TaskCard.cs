namespace BlazorApp6;

public class TaskCard
{
    public int Id { get; set; } // Унікальний ідентифікатор
    public string Name { get; set; }
    public string Status { get; set; }
    public Category Category { get; set; }
    public List<Member> Members { get; set; } = new List<Member>();
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
    public DateTime? EndedAt { get; set; }
    
}