using LearningCenter.Infraestructure.Context;
using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure;

public class TutorialOracleInfraestructure: ITutorialInfraestructure
{
    public List<string> GetAll()
    {
        //Conecta BBDD
        List<string> list = new List<string>();
        list.Add("Value Oracle 1");
        list.Add("Value Oracle 2");
        list.Add("Value Oracle 3");
        //LearningCenterDBContext;
        //SecurityDB;


        LearningCenterDBContext learningCenterDbContext = new LearningCenterDBContext();
        learningCenterDbContext.Tutorials.Add(new Tutorial()
        {
            Name = "Test1"
        });
        
        learningCenterDbContext.Tutorials.Update(new Tutorial()
        {
            Id = 1,
            Name = "Test1"
        });


        learningCenterDbContext.Tutorials.Remove(new Tutorial()
        {
            Id = 1,
            Name = "Test1"
        });


        learningCenterDbContext.Categories.ToList();

        learningCenterDbContext.SaveChanges();

        return list;

    }
}