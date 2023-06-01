using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure;

public interface ITutorialInfraestructure
{
    Task<List<Tutorial>> GetAll();
    List<Tutorial> GetByName(string name);

    Tutorial GetById(int id);
    Task<bool> CreateAsync(Tutorial input);
    bool Update(int id, Tutorial input);
    bool Delete(int id);
}