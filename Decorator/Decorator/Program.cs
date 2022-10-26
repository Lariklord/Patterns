Pizza pizza1 = new ItalianPizza();
pizza1 = new TomatoPizza(pizza1);
Console.WriteLine($"Название: {pizza1.Name}");
Console.WriteLine($"Цена: {pizza1.GetCost()}");

Pizza pizza2 = new BulgerianPizza();
pizza2 = new CheesePizza(pizza2);
Console.WriteLine($"Название: {pizza2.Name}");
Console.WriteLine($"Цена: {pizza2.GetCost()}");

Pizza pizza3 = new BulgerianPizza();
pizza3 = new CheesePizza(pizza3);
pizza3 = new TomatoPizza(pizza3);
Console.WriteLine($"Название: {pizza3.Name}");
Console.WriteLine($"Цена: {pizza3.GetCost()}");

abstract class Pizza
{
    public string Name { get;set; }
    public Pizza(string name)
    {
        Name = name;
    }
    public abstract int GetCost();
}
class ItalianPizza:Pizza
{
    public ItalianPizza():base("Итальянская пицца") { }
    public override int GetCost()
    {
        return 10;
    }
}

class BulgerianPizza : Pizza
{
    public BulgerianPizza() : base("Болгарская пицца") { }
    public override int GetCost()
    {
        return 8;
    }
}
abstract class PizzaDecorator:Pizza
{
    protected Pizza pizza;
    public PizzaDecorator(string n,Pizza pizza):base(n)
    {
        this.pizza = pizza;
    }
}
class TomatoPizza : PizzaDecorator
{
    public TomatoPizza(Pizza p) : base(p.Name + ", с томатами", p) { }
    public override int GetCost()
    {
        return pizza.GetCost() + 3;
    }
}
class CheesePizza:PizzaDecorator
{
    public CheesePizza(Pizza p) : base(p.Name + ", с сыром", p) { }
    public override int GetCost()
    {
        return pizza.GetCost() + 5;
    }
}