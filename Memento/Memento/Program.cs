Hero hero = new Hero();
hero.Shoot();

GameHistory gameHistory = new GameHistory();

gameHistory.History.Push(hero.SaveState());

hero.Shoot();

hero.RestorState(gameHistory.History.Pop());

hero.Shoot();

class Hero
{
    private int patrons = 10;
    private int lives = 5;
    public void Shoot()
    {
        if (patrons > 0)
        {
            patrons--;
            Console.WriteLine("Производим выстрел. Остало {0} патронов", patrons);
        }
        else
            Console.WriteLine("Патронов больше нет.");
    }
    public HeroMemento SaveState()
    {
        Console.WriteLine("Сохранение игры. Параметры: {0} патронов, {1} жизней", patrons, lives);
        return new HeroMemento(patrons, lives);
    }
    public void RestorState(HeroMemento heroMemento)
    {
        this.patrons = heroMemento.Patrons;
        this.lives = heroMemento.Lives;
        Console.WriteLine("Восстановление игры. Параметры: {0} патронов, {1} жизней",patrons,lives);
    }
}
class HeroMemento
{
    public int Patrons { get;private set; }
    public int Lives { get;private set; }
    public HeroMemento(int patrons,int lives)
    {
        Patrons = patrons;
        Lives = lives;
    }
}
class GameHistory
{
    public Stack<HeroMemento> History { get; private set; }
    public GameHistory()
    {
        History = new Stack<HeroMemento>();
    }
}
