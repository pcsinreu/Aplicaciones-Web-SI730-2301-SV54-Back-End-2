namespace LearningCenter.Infraestructure;

public class TutorialOracleInfraestructure: ITutorialInfraestructure
{
    public List<string> GetAll()
    {
        //Conecta BBDD
        List<string> list = new List<string>();
        list.Add("Value Oracle 1");
        list.Add("Value Oracle 2");
        list.Add("Value Oracle 3");

        return list;

    }
}