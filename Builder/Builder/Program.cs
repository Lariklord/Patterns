using System.Text;

Baker baker = new Baker();
Bread first = baker.Bake(new ReyBreadBuilder());
Bread second = baker.Bake(new WheatBreadBuilder());
Console.WriteLine(first);
Console.WriteLine(second);
class Flour
{
    public string Sort { get; set; }
}
class Salt { }

class Additives
{ 
    public string Name { get; set; }
}
class Bread
{
    public Flour Flour { get; set; }
    public Salt Salt { get; set; }
    public Additives Additives { get; set; }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        if (Flour != null) sb.Append(Flour.Sort + "\n");
        if (Salt != null) sb.Append("Соль\n");
        if (Additives != null) sb.Append("Добавки " + Additives.Name + "\n");
        return sb.ToString();
    }
}
abstract class BreadBuilder
{
    public Bread Bread { get; private set; }
    public void CreateBread() => Bread = new Bread();
    public abstract void SetFlour();
    public abstract void SetSalt();
    public abstract void SetAdditivies();
}
class Baker
{
    public Bread Bake(BreadBuilder breadBuilder)
    {
        breadBuilder.CreateBread();
        breadBuilder.SetFlour();
        breadBuilder.SetSalt();
        breadBuilder.SetAdditivies();
        return breadBuilder.Bread;
    }
}

class ReyBreadBuilder:BreadBuilder
{
    public override void SetFlour()
    {
        Bread.Flour = new Flour{ Sort="Ржаная мука 1 сорт"};
    }
    public override void SetSalt()
    {
        Bread.Salt = new Salt();
    }
    public override void SetAdditivies()
    {
       
    }
}

class WheatBreadBuilder : BreadBuilder
{
    public override void SetFlour()
    {
        Bread.Flour = new Flour { Sort = "Пшеничная мука высший сорт" };
    }
    public override void SetSalt()
    {
        Bread.Salt = new Salt();
    }
    public override void SetAdditivies()
    {
        Bread.Additives = new Additives { Name = "улучшитель хлебопекарный" };
    }
}

