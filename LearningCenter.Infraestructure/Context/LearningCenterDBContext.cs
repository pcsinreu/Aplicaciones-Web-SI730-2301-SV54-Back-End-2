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
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10623948;Pwd=KKhtn5C7sy;Database=sql10623948;", serverVersion);
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
        
        
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(c => c.Username).IsRequired().HasMaxLength(60);
        builder.Entity<User>().Property(c => c.Password).IsRequired().HasMaxLength(120);
        builder.Entity<User>().Property(c => c.IsActive).IsRequired().HasDefaultValue(true);

    }
}