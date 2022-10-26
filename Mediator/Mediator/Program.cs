Manager manager = new Manager();

Colleague customer = new Customer(manager);
Colleague programmer = new Programmer(manager);
Colleague tester = new Tester(manager);

manager.Programmer = programmer;
manager.Customer = customer;
manager.Tester = tester;

customer.Send("Есть заказ, надо сделать программу");
programmer.Send("Программа готова, нужно протестировать");
tester.Send("Программа готова, можно продавать");
abstract class Mediator
{
    public abstract void Send(string mes, Colleague colleague);
}
abstract class Colleague
{
    protected Mediator mediator;
    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }
    public virtual void Send(string mes)
    {
        mediator.Send(mes, this);
    }
    public abstract void Notify(string mes);
}
class Customer : Colleague
{
    public Customer(Mediator mediator) : base(mediator) { } 
    public override void Notify(string mes)
    {
        Console.WriteLine("Сообщение заказчику: "+mes);
    }
}

class Programmer : Colleague
{
    public Programmer(Mediator mediator) : base(mediator) { }
    public override void Notify(string mes)
    {
        Console.WriteLine("Сообщение программисту: " + mes);
    }
}

class Tester : Colleague
{
    public Tester(Mediator mediator) : base(mediator) { }
    public override void Notify(string mes)
    {
        Console.WriteLine("Сообщение тестировщику: " + mes);
    }
}

class Manager:Mediator
{
    public Colleague Customer { get; set; }
    public Colleague Programmer { get; set; }
    public Colleague Tester { get; set; }

    public override void Send(string mes, Colleague colleague)
    {
        if (Customer == colleague)
            Programmer.Notify(mes);
        else if(Programmer== colleague)
            Tester.Notify(mes);
        else if(Tester== colleague)
            Customer.Notify(mes);

    }
}
