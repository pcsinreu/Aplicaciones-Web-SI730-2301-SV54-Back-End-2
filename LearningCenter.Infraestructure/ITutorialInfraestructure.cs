using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure;

public interface ITutorialInfraestructure
{
    List<Tutorial> GetAll();
    bool Create(string name);
    bool Update(int id, string name);
    bool Delete(int id);
}