using LearningCenter.Infraestructure;
using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Domain;

public class UserDomain : IUserDomain
{

    private IUserInfraestructure _userInfraestructure;

    public UserDomain(IUserInfraestructure userInfraestructure)
    {
        _userInfraestructure = userInfraestructure;
    }
    
    public async Task<bool> Login(User user)
    {
        return await _userInfraestructure.Login(user);
    }

    public async Task<int> Signup(User user)
    {
        return await _userInfraestructure.Signup(user);
    }
}