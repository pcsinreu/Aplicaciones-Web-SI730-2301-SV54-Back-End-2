using LearningCenter.Infraestructure.Context;
using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure;


public class TutorialOracleInfraestructure: ITutorialInfraestructure
{
    private LearningCenterDBContext _learningCenterDbContext;

    public TutorialOracleInfraestructure(LearningCenterDBContext learningCenterDbContext)
    {
        _learningCenterDbContext = learningCenterDbContext;
    }
    
    public List<Tutorial> GetAll()
    {
        //Conecta BBDD
        List<string> list = new List<string>();
        list.Add("Value Oracle 1");
        list.Add("Value Oracle 2");
        list.Add("Value Oracle 3");
        //LearningCenterDBContext;
        //SecurityDB;

        return _learningCenterDbContext.Tutorials.ToList();

    }

    public bool Create(string name)
    {
        try
        {
            Tutorial tutorial = new Tutorial();
            tutorial.Name = name;
            tutorial.IsActive = true;

            _learningCenterDbContext.Tutorials.Add(tutorial);
            _learningCenterDbContext.SaveChanges();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public bool Update(int id, string name)
    {
        try
        {
            var tutorial = _learningCenterDbContext.Tutorials.Find(id); //obtengo

            tutorial.Name = name; //Modifico

            _learningCenterDbContext.Tutorials.Update(tutorial); //modifco


            _learningCenterDbContext.SaveChanges();

            return true;
        }
        catch (Exception exception)
        {
            return false;
        }

    }

    public bool Delete(int id)
    {

        //_learningCenterDbContext.Tutorials.Remove(tutorial);
        
        
        var tutorial = _learningCenterDbContext.Tutorials.Find(id); //obtengo

        tutorial.IsActive = false; //Modifico

        _learningCenterDbContext.Tutorials.Update(tutorial); //modifco
        
        _learningCenterDbContext.SaveChanges();

        return true;
    }
}