using PatternsPractice.Patterns.Structural.Facade;
namespace PatternsPractice.Patterns.Structural.Decorator;

public interface IEmbeddedNotification { void Notify(); }

public class NotificationFacadeAdapterWrapper22 : IEmbeddedNotification
{
    protected IEmbeddedNotification? DecoratedNotification { get; set; }

    public NotificationFacadeAdapterWrapper22(IEmbeddedNotification? nextNotification = null)
        => (DecoratedNotification) = (nextNotification);

    public virtual void Notify()
    {
        Console.WriteLine("decorate");
        DecoratedNotification?.Notify();
    }
}

public abstract class NotificationFacadeAdapterWrapper : IEmbeddedNotification
{
    protected NotificationFacade NotificationFacade { get; init; }
    protected string Email { get; init; }
    protected string Body { get; init; }
    protected IEmbeddedNotification? DecoratedNotification { get; set; }

    public NotificationFacadeAdapterWrapper(string email, string body, IEmbeddedNotification? nextNotification = null)
        => (NotificationFacade, Email, Body, DecoratedNotification) = (new(), email, body, nextNotification);

    public virtual void Notify()
        => DecoratedNotification?.Notify();
}

public sealed class EmailNotificationFacadeAdapterWrapper : NotificationFacadeAdapterWrapper
{
    public EmailNotificationFacadeAdapterWrapper(string email, string body, IEmbeddedNotification? nextNotification = null)
        : base(email, body, nextNotification)
    {
    }

    public override void Notify()
    {
        NotificationFacade.StandardMailNotification(Email, Body);
        base.Notify();
    }
}

public sealed class TelegramNotificationFacadeAdapterWrapper : NotificationFacadeAdapterWrapper
{
    public TelegramNotificationFacadeAdapterWrapper(string email, string body, IEmbeddedNotification? nextNotification = null)
        : base(email, body, nextNotification)
    {
    }

    public override void Notify()
    {
        // Дополнительная логика: полуить номер телефона по электронному адресу.
        string telNumber = "+7(xxx)xxx-xx-xx";

        NotificationFacade.StandardTelegramNotification(telNumber, Body);
        base.Notify();
    }
}