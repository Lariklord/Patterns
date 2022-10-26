Pult pult = new Pult();
TV tv = new TV();
Volume volume = new Volume();
pult.SetCommand(new TVOnCommand(tv),0);
pult.SetCommand(new VolumeCommand(volume), 1);
pult.PressButton(0);
for (int i = 0; i < 20; i++)
    pult.PressButton(1);
while(pult.commands.TryPop(out var cmd))
    cmd.Undo();



interface ICommand
{
    void Execute();
    void Undo();
}
class NonCommand:ICommand
{
    public void Execute() { }
    public void Undo() { }
}
class TV
{
    public void On() => Console.WriteLine("TV On");
    public void Off() => Console.WriteLine("TV Off");
}
class TVOnCommand :ICommand
{
    TV tv;
    public TVOnCommand(TV tv)
    {
        this.tv = tv;
    }
    public void Execute()
    {
        tv.On();
    }
    public void Undo()
    {
        tv.Off();
    }
}
class Volume
{
    const int MAX = 20;
    const int MIN = 0;
    private int level;
    public Volume()
    {
        level = MIN;
    }
    public void More()
    {
        if (level < MAX) level++;
        Console.WriteLine($"Volume: {level}");
    }
    public void Less()
    {
        if(level > MIN) level--;
        Console.WriteLine($"Volume: {level}");
    }
}
class VolumeCommand:ICommand
{
    Volume volume;
    public VolumeCommand(Volume volume)
    {
        this.volume = volume;
    }
    public void Execute()
    {
        volume.More();
    }
    public void Undo()
    {
        volume.Less();
    }
}
class Pult
{
    ICommand[] buttons;
    public Stack<ICommand> commands;
    public Pult() 
    {
        buttons = new ICommand[2];
        for (int i = 0; i < buttons.Length; i++)
            buttons[i] = new NonCommand();
        commands = new Stack<ICommand>();
    }
    public void SetCommand(ICommand command,int num)
    {
        buttons[num] = command; 
    }
    public void PressButton(int num)
    {
        buttons[num].Execute();
        commands.Push(buttons[num]);
    }
    public void PressUndo()
    {
        if(commands.Count > 0)
        {
            ICommand command = commands.Pop();
            command.Undo();
        }
    }
}

