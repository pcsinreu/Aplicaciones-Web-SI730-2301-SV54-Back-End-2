using LearningCenter.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.Infraestructure.Context;

public class LearningCenterDBContext : DbContext
{
    
    public DbSet<Tutorial> Tutorials { get; set; }
    public DbSet<Category> Categories { get; set; }

}