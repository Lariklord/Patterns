Driver driver = new Driver();
Auto auto = new Auto();

driver.Travel(auto);

Camel camel1 = new Camel();
ITransport camelTo = new CamelToTransportAdapter(camel1);
driver.Travel(camelTo);
interface ITransport
{
    void Drive();
}

class Auto:ITransport
{
    public void Drive()
    {
        Console.WriteLine("Машина едет по дороге");
    }
}
class Driver
{
    public void Travel(ITransport transport)
    {
        transport.Drive();
    }
}
interface IAnimal
{
    public void Move();
}
class Camel:IAnimal
{
    public void Move()
    {
        Console.WriteLine("Верблюд идет по пустыне");
    }
}
class CamelToTransportAdapter:ITransport
{
    Camel camel;
    public CamelToTransportAdapter(Camel camel)
    {
        this.camel = camel;
    }
    public void Drive()
    {
        camel.Move();
    }
}
