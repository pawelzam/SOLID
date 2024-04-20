namespace SOLID.Application.DependencyInversionPrinciple.Antipattern;

public class SmsSender
{
    public void SendSms(string message)
    {
        Console.WriteLine(message);
    }
}

public class EmailSender
{
    public void SendEmail(string message)
    {
        Console.WriteLine(message);
    }
}


// Here high-level class depends on low-level classes
public class AlertingSystem
{
    private readonly SmsSender _smsSender;
    private readonly EmailSender _emailSender;

    public AlertingSystem()
    {
        _smsSender = new SmsSender();
        _emailSender = new EmailSender();
    }

    public void SendAlert(string message)
    {
        _smsSender.SendSms(message);
        _emailSender.SendEmail(message);
    }
}
