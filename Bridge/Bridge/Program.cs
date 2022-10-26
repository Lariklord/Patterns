Programmer programmer = new FreelanceProgrammer(new CPPLanguage());
programmer.DoWork();
Console.WriteLine();

programmer.Language = new CSharpLanguage();
programmer.DoWork();
Console.WriteLine();

programmer.EarnMoney();
Console.WriteLine();

Programmer programmer1 = new FreelanceProgrammer(new CPPLanguage());
programmer1.DoWork();
Console.WriteLine();

programmer1.Language = new CSharpLanguage();
programmer1.DoWork();
Console.WriteLine();

programmer1.EarnMoney();
Console.WriteLine();


interface ILanguage
{
    void Build();
    void Execute();
}
class CPPLanguage:ILanguage
{
    public void Build()
    {
        Console.WriteLine("С помощью компилятора с++ компилируем программу в бинарный код");
    }
    public void Execute()
    {
        Console.WriteLine("Запускаем исполняемый файл программы");
    }
}
class CSharpLanguage : ILanguage
{
    public void Build()
    {
        Console.WriteLine("С помощью компилятора Roslyn компилируем исходный код в файл exe");
    }

    public void Execute()
    {
        Console.WriteLine("JIT компилирует программу в бинарный код");
        Console.WriteLine("CLR выполняет скомпилированный бинарный код");
    }
}
abstract class Programmer
{
    protected ILanguage language;
    public ILanguage Language
    {
        set { language = value; }
    }

    public Programmer(ILanguage lang)
    {
        language = lang;
    }
    public virtual void DoWork()
    {
        language.Build();
        language.Execute();
    }
    public abstract void EarnMoney();
}

class FreelanceProgrammer:Programmer
{
    public FreelanceProgrammer(ILanguage language) : base(language) { }
    public override void EarnMoney()
    {
        Console.WriteLine("Получаем оплату за выполненный заказ");
    }
}
class CorporateProgrammer : Programmer
{
    public CorporateProgrammer(ILanguage language) : base(language) { }
    public override void EarnMoney()
    {
        Console.WriteLine("Получаем зарплату в конце месяца");
    }
}