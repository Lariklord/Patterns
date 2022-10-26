var structure = new Bank();
structure.Add(new Person { Name = "Vlad", Number = "80296307745" });
structure.Add(new Company { Name = "Microsoft", RegNumber = "ewuir32141324", Number = "342431445" });
structure.Accept(new HtmlVisitor());
structure.Accept(new XmlVisitor());
interface IVisitor
{
    void VisitPersonAcc(Person acc);
    void VisitCompanyAcc(Company acc);
}
class HtmlVisitor:IVisitor
{
    public void VisitPersonAcc(Person acc)
    {
        string res = "<table>\n<tr><td>Свойство</td><td>Значение</td></tr>\n" +
            "<tr><td>Name</td><td>" + acc.Name + "</td></tr>\n" +
            "<tr><td>Number</td><td>" + acc.Number + "</td></tr>\n" +
            "</table>";
        Console.WriteLine(res);
        Console.WriteLine();
    }
    public void VisitCompanyAcc(Company acc)
    {
        string res = "<table>\n<tr><td>Свойство</td><td>Значение</td></tr>\n" +
            "<tr><td>Name</td><td>" + acc.Name + "</td></tr>\n" +
             "<tr><td>RegNumber</td><td>" + acc.RegNumber + "</td></tr>\n" +
            "<tr><td>Number</td><td>" + acc.Number + "</td></tr>\n" +
            "</table>";
        Console.WriteLine(res);
        Console.WriteLine();
    }
}
class XmlVisitor:IVisitor
{
    public void VisitPersonAcc(Person acc)
    {
        string res = "<Person>\n<Name>" + acc.Name + "</Name>\n" +
            "<Number>" + acc.Number + "</Number>\n</Person>";
        Console.WriteLine(res);
        Console.WriteLine();
    }
    public void VisitCompanyAcc(Company acc)
    {
        string res = "<Company>\n<Name>" + acc.Name + "</Name>\n" +
            "<RegNumber>"+acc.RegNumber+"</RegNumber>\n"+
            "<Number>" + acc.Number + "</Number>\n</Company>";
        Console.WriteLine(res);
        Console.WriteLine();
    }
}
interface IAccount
{
    void Accept(IVisitor visitor);
}
class Bank
{
    List<IAccount> accounts = new List<IAccount>();
    public void Add(IAccount account)
    {
        accounts.Add(account);
    }
    public void Remove(IAccount account)
    {
        accounts.Remove(account);
    }
    public void Accept(IVisitor visitor)
    {
        foreach (var item in accounts)
        {
            item.Accept(visitor);
        }
    }
}

class Person:IAccount
{
    public string Name { get; set; }
    public string Number { get; set; }
    public void Accept(IVisitor visitor)
    {
        visitor.VisitPersonAcc(this);
    }
}
class Company:IAccount
{
    public string Name { get; set; }
    public string RegNumber { get; set; }
    public string Number { get; set; }
    public void Accept(IVisitor visitor)
    {
        visitor.VisitCompanyAcc(this);
    }
}
