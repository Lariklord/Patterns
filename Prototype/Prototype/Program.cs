IFigure figure = new Rectangle(30, 40);
IFigure clonedFigure = figure.Clone();
figure.GetInfo();
clonedFigure.GetInfo();

figure = new Circle(30);
clonedFigure = figure.Clone();
figure.GetInfo();
clonedFigure.GetInfo();

interface IFigure
{
    IFigure Clone();
    void GetInfo();
}
class Rectangle : IFigure
{
    int width;
    int height;
    public Rectangle(int w,int h)
    {
        width = w;
        height = h;
    }
    public IFigure Clone()
    {
        return new Rectangle(width, height);
    }

    public void GetInfo()
    {
        Console.WriteLine($"Прямоугольник с размерами {width}/{height}");
    }
}
class Circle:IFigure
{
    int radius;
    public Circle(int radius)
    {
        this.radius = radius;
    }
    public IFigure Clone()
    {
        return new Circle(radius);
    }
    public void GetInfo()
    {
        Console.WriteLine($"Круг с радиусом {radius}");
    }
}