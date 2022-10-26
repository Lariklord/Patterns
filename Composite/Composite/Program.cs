Component system = new Directory("Файловая система");

Component dyskC = new Directory("Диск с");

dyskC.Add(new File("12345.png"));
dyskC.Add(new File("rocketLeague.exe"));

system.Add(dyskC);

system.Print();

abstract class Component
{
    protected string name;
    public Component(string name)
    {
        this.name = name;
    }
    public virtual void Add(Component component) { }
    public virtual void Remove(Component component) { }
    public virtual void Print()
    {
        Console.WriteLine(name);
    }
}
class Directory:Component
{
    private List<Component> components = new List<Component>();
    public Directory(string n) : base(n) { }
    public override void Add(Component component)
    {
        components.Add(component);
    }
    public override void Remove(Component component)
    {
        components.Remove(component);
    }
    public override void Print()
    {
        Console.WriteLine("Узел "+name);
        Console.WriteLine("Подузлы:");
        foreach (var item in components)
        {
            item.Print();
        }
    }
}
class File:Component
{
    public File(string s) : base(s) { }
}
