Car car = new Car(5, "Peugeot 206", new PetrolMove());
car.Move();
car.Movable = new ElectricMove();
car.Move();

interface IMovable
{
    public void Move();
}
class PetrolMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Бензиновая машина");
    }
}
class ElectricMove:IMovable
{
    public void Move()
    {
        Console.WriteLine("Електричесая машина");
    }
}

class Car
{
    public int pasagers;
    public string model;
    public IMovable Movable { get; set; }

    public Car(int pasagers, string model, IMovable movable)
    {
        this.pasagers = pasagers;
        this.model = model;
        this.Movable = movable;
    }
    
    public void Move()
    {
        Movable.Move();
    }
}


