namespace LearningCenter.Infraestructure.Models;

public class Tutorial : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }

    public int  MaxLenght  { get; set; }
}