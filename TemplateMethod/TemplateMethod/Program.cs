School school = new School();
University university = new University();

school.Learn();
Console.WriteLine();
university.Learn();
abstract class Education
{
    public void Learn()
    {
        Enter();
        Study();
        PassExams();
        GetDocument();
    }

    public abstract void Enter();

    public abstract void Study();


    public virtual void PassExams()
    {
        Console.WriteLine("Сдаём выпускные экзамены");
    }

    public abstract void GetDocument();
}
class School : Education
{
    public override void Enter()
    {
        Console.WriteLine("Идем в 1 класс");
    }
    public override void Study()
    {
        Console.WriteLine("Ходим на уроки");
    }
    public override void GetDocument()
    {
        Console.WriteLine("Получаем аттестат");
    } 
}
class University : Education
{
    public override void Enter()
    {
        Console.WriteLine("Идем в 1 класс");
    }
    public override void Study()
    {
        Console.WriteLine("Ходим на пары");
    }
    public override void PassExams()
    {
        Console.WriteLine("Сдаем экзамен по специальности");
    }
    public override void GetDocument()
    {
        Console.WriteLine("Получаем диплом");
    }
}
