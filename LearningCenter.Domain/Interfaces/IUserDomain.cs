using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Domain;

public interface IUserDomain
{
     Task<string> Login(User user);
     Task<int> Signup(User user);
}