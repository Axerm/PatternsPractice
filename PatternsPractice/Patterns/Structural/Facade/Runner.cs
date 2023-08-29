#define NotificationMode

namespace PatternsPractice.Patterns.Structural.Facade;

public static class Runner
{
    private static void RunNotificationFacadeTest()
    {
        NotificationFacade notificationFacade = new();

        notificationFacade.StandardMailNotification("test@geomix.ru", "hello by mail");
        notificationFacade.StandardTelegramNotification("+7(xxx)xxx-xx-xx", "hello by telegram");

        notificationFacade.StandardMailNotificationWithExtendConfiguration(
            "test@geomix.ru",
            "hello by extend mail",
            configurationSetup =>
            {
                configurationSetup.Server = "EXTENDED-MAIL-localhost";
            }
        );
    }

    private static void RunFacadeToMediatorComparision()
    {
        #region mediator

        Console.WriteLine("mediator section");

        Patterns.Facade.AsMediator.Sub1 sub1 = new();
        Patterns.Facade.AsMediator.Mediator mediator = new(sub1);
        Console.WriteLine(mediator.GetInfo());
        sub1.Number = 5;
        Console.WriteLine($"{mediator.GetInfo()}{Environment.NewLine}");

        #endregion

        #region facade

        Console.WriteLine("facade section");

        Patterns.Facade.AsFacade.Facade facade = new();
        Console.WriteLine(facade.GetInfo());
        facade.SetNumber(5);
        Console.WriteLine($"{mediator.GetInfo()}{Environment.NewLine}");

        #endregion
    }

    public static void Run()
    {
#if NotificationMode
        RunNotificationFacadeTest();
#else
        RunFacadeToMediatorComparision();
#endif
    }
}
