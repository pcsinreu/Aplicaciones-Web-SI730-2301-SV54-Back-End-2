using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure;

public class TutorialSQLInfraestructure : ITutorialInfraestructure
{
    public List<Tutorial> GetAll()
    {
        //Conecta BBDD
        List<string> list = new List<string>();
        list.Add("Value SQL 1");
        list.Add("Value SQL 2");
        list.Add("Value SQL 3");

        return null;
    }

    public Tutorial GetById(int id)
    {
        throw new NotImplementedException();
    }

    public bool Create(string name)
    {
        throw new NotImplementedException();
    }

    public bool Update(int id, string name)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public bool Update()
    {
        throw new NotImplementedException();
    }

    public bool Delete()
    {
        throw new NotImplementedException();
    }
}