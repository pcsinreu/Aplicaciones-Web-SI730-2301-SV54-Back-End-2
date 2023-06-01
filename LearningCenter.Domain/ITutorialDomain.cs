using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Domain;

public interface ITutorialDomain
{
    Task<bool> CreateAsync(Tutorial input);
    bool Update(int id,Tutorial input);
    bool Delete(int id);
}