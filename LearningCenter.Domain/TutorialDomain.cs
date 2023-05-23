using System.Diagnostics.CodeAnalysis;
using LearningCenter.Infraestructure;
using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Domain;

public class TutorialDomain : ITutorialDomain
{
    private ITutorialInfraestructure _tutorialInfraestructure;

    public TutorialDomain(ITutorialInfraestructure tutorialInfraestructure)
    {
        _tutorialInfraestructure = tutorialInfraestructure;
    }
    
    
    public List<Tutorial> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Create(string name)
    {
        if (name.Length < 3) throw new Exception("less than 3 char");
        if (name.Length > 10) throw new Exception("more than 10 char");
        
        return _tutorialInfraestructure.Create(name);
    }

    public bool Update(int id,string name)
    {
        return _tutorialInfraestructure.Update(id, name);
    }

    public bool Delete(int id)
    {
        return _tutorialInfraestructure.Delete(id);
    }
}