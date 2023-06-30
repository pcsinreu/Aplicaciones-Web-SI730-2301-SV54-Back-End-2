using System.ComponentModel.DataAnnotations;
using LearningCenter.Infraestructure.Models;

namespace LearningCenter.API.Input;

public class TutorialInput
{
    [Required]
    [MaxLength(10)]
    [MinLength(3)]
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public  int MaxLenght { get; set; }
    
    public CategoryInput Category { get; set; }
}