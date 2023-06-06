using LearningCenter.Infraestructure.Context;
using LearningCenter.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.Infraestructure;

public class UserInfraestructure : IUserInfraestructure
{
    private LearningCenterDBContext _learningCenterDbContext;

    public UserInfraestructure(LearningCenterDBContext learningCenterDbContext)
    {
        _learningCenterDbContext = learningCenterDbContext;
    }
    
    public async Task<bool> Login(User user)
    {
        try
        {
           var foundUser = await  _learningCenterDbContext.Users.Where(u =>
                u.Username == user.Username && u.Password == user.Password).ToListAsync();
            return foundUser.Count() == 1 ? true : false;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<int> Signup(User user)
    {
        user.DateCreated = DateTime.Now;
        _learningCenterDbContext.Users.Add(user);
        await _learningCenterDbContext.SaveChangesAsync();
        return user.Id;
    }
}