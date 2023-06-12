using AutoMapper;
using LearningCenter.API.Response;
using LearningCenter.Infraestructure.Models;

namespace LearningCenter.API.Mapper;

public class ModelToResponse : Profile
{

    public ModelToResponse()
    {
        CreateMap<Tutorial, TutorialResponse>();
        CreateMap<User, UserResponse>();
        CreateMap<Post, PostResponse>();
        
        
        //CreateMap<Category, CategoryReponse>();
    }
    
}