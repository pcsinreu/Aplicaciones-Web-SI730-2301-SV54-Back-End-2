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

    public async Task<bool> CreateAsync(Tutorial input)
    {
        if (input.Name.Length < 3) throw new Exception("less than 3 char");
        if (input.Name.Length > 10) throw new Exception("more than 10 char");
        
        return await _tutorialInfraestructure.CreateAsync(input);
    }

    public bool Update(int id,Tutorial tutorial)
    {
        return _tutorialInfraestructure.Update(id, tutorial);
    }

    public bool Delete(int id)
    {
        return _tutorialInfraestructure.Delete(id);
    }
}