using LearningCenter.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.Infraestructure.Context;

public class LearningCenterDBContext : DbContext
{
    public LearningCenterDBContext()
    {
        
    }
    
    public LearningCenterDBContext(DbContextOptions<LearningCenterDBContext> options) : base(options)
    {
    }
    public DbSet<Tutorial> Tutorials { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=LaUpc123*;Database=LearningCenterDB;", serverVersion);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Description).IsRequired().HasMaxLength(60);


        builder.Entity<Tutorial>().ToTable("Tutorials");
        builder.Entity<Tutorial>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

    }
}