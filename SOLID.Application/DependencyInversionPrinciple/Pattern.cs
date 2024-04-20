namespace SOLID.Application.DependencyInversionPrinciple;

public interface IMessageSender
{
    void SendMessage(string message); 
}

public class SmsSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine(message);
    }
}

public class EmailSender : IMessageSender
{
    public void SendEmail(string message)
    {
        Console.WriteLine(message);
    }

    public void SendMessage(string message)
    {
        Console.WriteLine(message);
    }
}


// Here high-level class not depends on low-level classes. Implementation of send message is abstraction for it.
public class AlertingSystem
{
    private readonly IMessageSender[] _senders;    

    public AlertingSystem(IMessageSender[] senders)
    {
        _senders = senders;
    }

    public void SendAlert(string message)
    {
        foreach (var sender in _senders)
        {
            sender.SendMessage(message);
        }
    }
}