using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure;

public interface IUserInfraestructure
{
    Task<User> GetByUsername(string username);
    Task<int> Signup(User user);
}