Stock stock = new Stock();

Broker broker = new Broker("ООО КУРС",stock);
Bank bank = new Bank("ООО АльфаБанк", stock);

for (int i = 0; i < 10; i++)
{
    stock.Market();
    Console.WriteLine();
}

broker.StopTrade();
interface IObserver
{
    void Update(object obj);
}
interface IObservable
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

class StockInfo
{
    public int USD { get; set; }
    public int EURO { get; set; }
}
class Stock:IObservable
{
    StockInfo sInfo;
    List<IObserver> observers;
    public Stock()
    {
        observers = new List<IObserver>();
        sInfo = new StockInfo();
    }
    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
    public void NotifyObservers()
    {
        foreach (var item in observers)
        {
            item.Update(sInfo);
        }
    }
    public void Market()
    {
        Random rand = new Random();
        sInfo.USD = rand.Next(50, 70);
        sInfo.EURO = rand.Next(70, 90);
        NotifyObservers();
    }
}

class Broker : IObserver
{
    public string Name { get; set; }
    IObservable? stock;
    public Broker(string name, IObservable stock)
    {
        Name = name;
        this.stock = stock;
        stock.RegisterObserver(this);
    }
    public void Update(object obj)
    {
        StockInfo sInfo = (StockInfo)obj;
        if (sInfo.USD > 60)
            Console.WriteLine($"Брокер {Name} продает доллары; Курс долара: {sInfo.USD}");
        else
            Console.WriteLine($"Брокер {Name} покупает доллары; Курс долара: {sInfo.USD}");
        Console.WriteLine();
    }
    public void StopTrade()
    {
        stock?.RemoveObserver(this);
        stock = null;
        Console.WriteLine($"Брокер {Name} прекращает торги");
        Console.WriteLine();
    }
}
class Bank : IObserver
{
     public string Name { get; set; }
     IObservable? stock;
     public Bank(string name, IObservable stock)
     {
        Name = name;
        this.stock = stock;
        stock.RegisterObserver(this);
     }
     public void Update(object obj)
     {
         StockInfo sInfo = (StockInfo)obj;
         if (sInfo.EURO > 80)
             Console.WriteLine($"Банк {Name} продает евро; Курс евро: {sInfo.EURO}");
         else
             Console.WriteLine($"Банк {Name} покупает евро; Курс евро: {sInfo.EURO}");
        Console.WriteLine();
     }
}


