using AutoMapper;
using LearningCenter.API.Input;
using LearningCenter.API.Response;
using LearningCenter.Infraestructure;
using LearningCenter.Infraestructure.Models;

namespace LearningCenter.API.Mapper;


public class InputToModel: Profile
{
    public InputToModel()
    {
        CreateMap<TutorialInput, Tutorial>();
        CreateMap<CategoryInput, Category>();
        
        
        CreateMap<UserLoginInput, User>();
        CreateMap<UserInput, User>();
        CreateMap<PostInput, Post>();
        //CreateMap<Category, CategoryReponse>();
    }

}