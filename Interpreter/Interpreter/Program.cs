Context context1 = new Context();

int x = 5;
int y = 8;
int z = 2;

context1.SetVariable("x", x);
context1.SetVariable("y", y);
context1.SetVariable("z", z);

IExpression expression = new SubExpression(
    new AddExpression(new NumberExpression("x"), new NumberExpression("y")),
    new NumberExpression("z"));
int res = expression.Interpret(context1);
Console.WriteLine($"Результат: {res}");

class Context
{
    Dictionary<string, int> variables;
    public Context()
    {
        variables = new Dictionary<string, int>();
    }
    public int GetVariable(string name)
    {
        return variables[name];
    }
    public void SetVariable(string name,int value)
    {
        if(variables.ContainsKey(name))
            variables[name] = value;
        else
            variables.Add(name, value);
    }
}
interface IExpression
{
    int Interpret(Context context);
}
class NumberExpression:IExpression
{
    string name;
    public NumberExpression(string name)
    {
        this.name = name;
    }
    public int Interpret(Context context)
    {
        return context.GetVariable(name);
    }
}
class AddExpression:IExpression
{
    IExpression leftExpression;
    IExpression rightExpression;

    public AddExpression(IExpression leftExpression, IExpression rightExpression)
    {
        this.leftExpression = leftExpression;
        this.rightExpression = rightExpression;
    }
    public int Interpret(Context context)
    {
        return leftExpression.Interpret(context) + rightExpression.Interpret(context);
    }
}
class SubExpression : IExpression
{
    IExpression leftExpression;
    IExpression rightExpression;

    public SubExpression(IExpression leftExpression, IExpression rightExpression)
    {
        this.leftExpression = leftExpression;
        this.rightExpression = rightExpression;
    }
    public int Interpret(Context context)
    {
        return leftExpression.Interpret(context) - rightExpression.Interpret(context);
    }
}