namespace LearningCenter.Infraestructure.Models;

public class BaseModel
{
    //Campo d eauditoria
    public int Id { get; set; }
    public bool IsActive { get; set; }
    
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}