double longitude = 37.61;
double latitude = 55.74;

HouseFactory houseFactory = new HouseFactory();

for (int i = 0; i<5;i++)
{
    House house = houseFactory.GetHouse("Panel");
    if(house is not null)
    {
        house.Build(longitude, latitude);
        longitude += 0.1;
        latitude += 0.1;
    }
}
Console.WriteLine();
for (int i = 0; i < 5; i++)
{
    House house = houseFactory.GetHouse("Brick");
    if (house is not null)
    {
        house.Build(longitude, latitude);
        longitude += 0.1;
        latitude += 0.1;
    }
}
abstract class House
{
    protected int stages;
    public abstract void Build(double longitude, double latitude);
}
class PanelHouse:House
{
    public PanelHouse()
    {
        stages = 16;
    }
    public override void Build(double longitude, double latitude)
    {
        Console.WriteLine($"Построен панельный дом из 16 этажей;\nКоординаты: {latitude} широты {longitude} долготы\n");
    }
}
class BrickHouse:House
{
    public BrickHouse()
    {
        stages = 5;
    }
    public override void Build(double longitude, double latitude)
    {
        Console.WriteLine($"Построен кирпичный дом из 5 этажей;\nКоординаты: {latitude} широты {longitude} долготы\n");
    }
}
class HouseFactory
{
    Dictionary<string, House> houses = new Dictionary<string, House>();
    public HouseFactory()
    {
        houses.Add("Panel", new PanelHouse());
        houses.Add("Brick", new BrickHouse());
    }
    public House GetHouse(string key)
    {
        if (houses.ContainsKey(key))
            return houses[key];
        else
            return null;
    }
}
