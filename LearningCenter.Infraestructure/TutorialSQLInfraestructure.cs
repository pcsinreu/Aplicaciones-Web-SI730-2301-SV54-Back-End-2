namespace LearningCenter.Infraestructure;

public class TutorialSQLInfraestructure : ITutorialInfraestructure
{
    public List<string> GetAll()
    {
        //Conecta BBDD
        List<string> list = new List<string>();
        list.Add("Value SQL 1");
        list.Add("Value SQL 2");
        list.Add("Value SQL 3");

        return list;
    }
}