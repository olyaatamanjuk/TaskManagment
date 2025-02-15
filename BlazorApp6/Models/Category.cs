namespace BlazorApp6;

public class Category
{
    public int Id { get; set; } // Унікальний ідентифікатор
    public string Name { get; set; }
    public List<Property> Properties { get; set; } = new List<Property>();
}