using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Domain;

public interface ITutorialDomain
{
    List<Tutorial> GetAll();
    bool Create(string name);
    bool Update(int id,string name);
    bool Delete(int id);
}