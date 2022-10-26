Receiver receiver1 = new Receiver(false, true, false);

PaymentHandler handler = new BankPaymentHandler();
PaymentHandler handler1 = new MoneyHandlel();
PaymentHandler handler2 = new PayPallHandler();
handler.Successor = handler1;
handler1.Successor= handler2;

handler.Handle(receiver1);
class Receiver
{
    public bool BankTransfer { get; set; }
    public bool MoneyTransfer { get; set; }
    public bool PayPallTransfer { get; set; }
    public Receiver(bool bankTransfer, bool moneyTransfer, bool payPallTransfer)
    {
        BankTransfer = bankTransfer;
        MoneyTransfer = moneyTransfer;
        PayPallTransfer = payPallTransfer;
    }
}
abstract class PaymentHandler
{
    public PaymentHandler Successor { get; set; }
    public abstract void Handle(Receiver receiver);
}

class BankPaymentHandler:PaymentHandler
{
    public override void Handle(Receiver receiver)
    {
        if(receiver.BankTransfer==true)
            Console.WriteLine("Выполняем банковский перевод");
        else if(Successor!= null)
            Successor.Handle(receiver);
    }
}
class PayPallHandler:PaymentHandler
{
    public override void Handle(Receiver receiver)
    {
        if (receiver.PayPallTransfer == true)
            Console.WriteLine("Выполняем перевод через PayPall");
        else if (Successor != null)
            Successor.Handle(receiver);
    }
}
class MoneyHandlel:PaymentHandler
{
    public override void Handle(Receiver receiver)
    {
        if (receiver.MoneyTransfer == true)
            Console.WriteLine("Выполняем перевод через системы денежных переводов");
        else if (Successor != null)
            Successor.Handle(receiver);
    }
}
