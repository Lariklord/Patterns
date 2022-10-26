
Creater vlad = new WoodCreater("Vlad");
House house1 = vlad.CreateHouse();

Creater vova = new PanelCreater("Vova");
House house2 = vova.CreateHouse();




abstract class House{}

class WoodHouse:House
{ }

class PanelHouse:House
{ }

abstract class Creater 
{
    protected string name;
    public Creater(string name)
    {
        this.name = name;
    }

    public abstract House CreateHouse();
}

class WoodCreater : Creater
{
    public WoodCreater(string name) : base(name)
    {
        Console.WriteLine();
    }

    public override House CreateHouse()
    {
        Console.WriteLine($"{name} - Строитель по дереву строит деревянный дом");
        return new WoodHouse();
    }
}

class PanelCreater : Creater
{
    public PanelCreater(string name) : base(name)
    {
        Console.WriteLine();
    }

    public override House CreateHouse()
    {
        Console.WriteLine($"{name} - Строитель по камню строит каменный дом");
        return new PanelHouse();
    }
}