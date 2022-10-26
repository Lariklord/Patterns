VisualStudio vs = new VisualStudio(
    new TextEditor(),
    new Compiler(),
    new CLR()
    );
vs.Start();
vs.Stop();

class TextEditor
{
    public void CreateCode()
    {
        Console.WriteLine("Написание кода");
    }
    public void Save()
    {
        Console.WriteLine("Сохранение кода");
    }
}
class Compiler
{
    public void Compile()
    {
        Console.WriteLine("Компиляция приложения");
    }
}
class CLR
{ 
    public void Execute()
    {
        Console.WriteLine("Выполнение программы");
    }
    public void Finish()
    {
        Console.WriteLine("Завершение программы приложения");
    }
}

class VisualStudio
{
    TextEditor editor;
    Compiler compiler;
    CLR clr;
    public VisualStudio(TextEditor editor, Compiler compiler, CLR clr)
    {
        this.editor = editor;
        this.compiler = compiler;
        this.clr = clr;
    }
    public void Start()
    {
        editor.CreateCode();
        editor.Save();
        compiler.Compile();
        clr.Execute();
    }
    public void Stop()
    {
        clr.Finish();
    }
}
