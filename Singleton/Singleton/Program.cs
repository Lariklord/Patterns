Computer comp = new Computer();
comp.Launch("Windows 10");
Console.WriteLine(comp.Os.Name);

comp.Os = OS.getInstance("Windows 11");
Console.WriteLine(comp.Os.Name);

class OS
{
    private static OS instance;
    public string Name { get;private set;}
    private static object syncRoot = new object();
    private OS(string name)
    {
        Name = name;
    }
    public static OS getInstance(string name)
    {
        if (instance == null)
            lock (syncRoot)
            {
                if(instance == null)
                    instance = new OS(name);
            }
        return instance;
    }
}
class Computer
{
    public OS Os { get; set; }
    public void Launch(string name)
    {
        Os = OS.getInstance(name);
    }
}


