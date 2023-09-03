namespace PatternsPractice.Patterns.Structural.Decorator;

public static class Runner
{
    private const string _notifyEmail = "test@geomix.ru";
    private const string _notifyBody = "Работа выполнена!";

    public static void EmulateSystem(IEmbeddedNotification notification)
    {
        Thread.Sleep(2000);
        notification.Notify();
    }

    public static void NormalStyleRun()
    {
        TelegramNotificationFacadeAdapterWrapper telega = new(_notifyEmail, _notifyBody);
        EmailNotificationFacadeAdapterWrapper email = new(_notifyEmail, _notifyBody, telega);

        EmulateSystem(email);
    }

    public static void InlineStyleRun()
    {
        IEmbeddedNotification notification =
            new EmailNotificationFacadeAdapterWrapper(
                _notifyEmail,
                _notifyBody,
                new TelegramNotificationFacadeAdapterWrapper(
                    _notifyEmail,
                    _notifyBody));

        EmulateSystem(notification);
    }

    public static void Run()
    {
        NormalStyleRun();
        //InlineStyleRun();
    }
}
