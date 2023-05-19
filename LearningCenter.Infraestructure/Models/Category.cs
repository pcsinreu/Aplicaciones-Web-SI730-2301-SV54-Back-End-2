namespace LearningCenter.Infraestructure.Models;

public class Category
{
    public int Id { get; set; }
    public string Description { get; set; }
    
    public List<Tutorial> Tutorials { get; set; }
    
    //EJm. relacion Uno a muchos
    //public Tutorial Tutorial { get; set; }

}