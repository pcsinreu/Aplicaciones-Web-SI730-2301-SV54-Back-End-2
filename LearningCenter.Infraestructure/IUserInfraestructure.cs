using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure;

public interface IUserInfraestructure
{
    Task<bool> Login(User user);
    Task<int> Signup(User user);
}