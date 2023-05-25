using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure;

public interface ITutorialInfraestructure
{
    List<Tutorial> GetAll();
    List<Tutorial> GetByName(string name);

    Tutorial GetById(int id);
    bool Create(Tutorial input);
    bool Update(int id, Tutorial input);
    bool Delete(int id);
}