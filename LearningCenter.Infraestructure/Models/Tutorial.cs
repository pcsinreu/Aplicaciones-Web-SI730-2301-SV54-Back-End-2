namespace LearningCenter.Infraestructure.Models;

public class Tutorial
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public  bool IsActive { get; set; }
}