using LearningCenter.Infraestructure;
using LearningCenter.Infraestructure.Models;
using Moq;

namespace LearningCenter.Domain.Test;

public class TutorialDomainUnitTest
{
    [Fact]
    public void Create_ValidTutorial_ReturnSuccess()
    {
        //Arrage
        Tutorial tutorial = new Tutorial()
        {
            Name = "Tutorual 1"
        };
        var mockTutorialInfraestructure = new Mock<ITutorialInfraestructure>();
        mockTutorialInfraestructure.Setup(t => t.CreateAsync(tutorial)).ReturnsAsync(true);
        TutorialDomain tutorialDomain = new TutorialDomain(mockTutorialInfraestructure.Object);
        
        
        //Act
       var returnValue = tutorialDomain.CreateAsync(tutorial);

       //Assert
       Assert.True(returnValue.Result);
    }
    
    [Fact]
    public void Create_InvalidTutorial_ReturnError()
    {
        //Arrage
        Tutorial tutorial = new Tutorial()
        {
            Name = "Tutorual 1"
        };
        var mockTutorialInfraestructure = new Mock<ITutorialInfraestructure>();
        mockTutorialInfraestructure.Setup(t => t.CreateAsync(tutorial)).ReturnsAsync(false);
        TutorialDomain tutorialDomain = new TutorialDomain(mockTutorialInfraestructure.Object);
        
        
        //Act
        var returnValue = tutorialDomain.CreateAsync(tutorial);

        //Assert
        Assert.False(returnValue.Result);
    }
    
    
    [Fact]
    public void Create_InvalidTutorial_ReturnEXception()
    {
        //Arrage
        Tutorial tutorial = new Tutorial()
        {
            Name = "Te"
        };
        var mockTutorialInfraestructure = new Mock<ITutorialInfraestructure>();
        mockTutorialInfraestructure.Setup(t => t.CreateAsync(tutorial)).ReturnsAsync(false);
        TutorialDomain tutorialDomain = new TutorialDomain(mockTutorialInfraestructure.Object);
        
        
        //Act
        //var returnValue = tutorialDomain.Create(tutorial);
        var ex = Assert.ThrowsAsync<Exception>(() => tutorialDomain.CreateAsync(tutorial) );

        //Assert
        Assert.Equal("less than 3 char",ex.Result.Message);
    }
    
}