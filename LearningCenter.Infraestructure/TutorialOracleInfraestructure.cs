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

        return _learningCenterDbContext.Tutorials.Where(tutorial => tutorial.IsActive).ToList();

    }

    public List<Tutorial> GetByName(string name)
    {
        //return _learningCenterDbContext.Tutorials.Where(tutorial => tutorial.IsActive && tutorial.Name == name).ToList(); //Nombre exacto
        return _learningCenterDbContext.Tutorials.Where(tutorial => tutorial.IsActive && tutorial.Name.Contains(name)).ToList(); //Contiene parte
    }

    public Tutorial GetById(int id)
    {
        return _learningCenterDbContext.Tutorials.Single(tutorial => tutorial.IsActive && tutorial.Id == id);
    }

    public bool Create(Tutorial tutorial)
    {
        try
        {
            /*Tutorial tutorial = new Tutorial();
            tutorial.Name = name;
            tutorial.IsActive = true;*/

            _learningCenterDbContext.Tutorials.Add(tutorial);
            _learningCenterDbContext.SaveChanges();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public bool Update(int id, Tutorial input)
    {
        try
        {
            using (var transaction = _learningCenterDbContext.Database.BeginTransaction())
            {
                try
                {
                    var tutorial = _learningCenterDbContext.Tutorials.Find(id); //obtengo

                   tutorial.Name = input.Name; //Modifico
                   tutorial.Description = input.Description; //Modifico
                    _learningCenterDbContext.Tutorials.Update(tutorial); //modifco

                    _learningCenterDbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
            

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