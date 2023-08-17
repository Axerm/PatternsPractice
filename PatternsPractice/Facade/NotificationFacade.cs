namespace PatternsPractice.Patterns.Facade;

public static class Sender
{
    public static void Send(INotificateConfiguration configuration, string info, string body)
        => Console.WriteLine($"Sending on \"{configuration.Server}:{configuration.Port}\". Info: {info}. BodySection: {body}");
}

public class NotificationFacade
{
    public void StandardMailNotification(string email, string body)
    {
        MailNotificationFactory factory = new();

        var configuration = (IMailNotificateConfiguration)factory.GetConfiguration();
        var template = (MailTemplate)factory.GetTemplateFormatter();
        string processedMessage = template.Process(templateInfo =>
        {
            templateInfo.TemplatePath = "./templates/mail/standard";
            templateInfo.ToEmail = email;
        });

        Sender.Send(configuration, processedMessage, body);
    }

    public void StandardMailNotificationWithExtendConfiguration(string email, string body, Action<IMailNotificateConfiguration>? configurationSetup)
    {
        MailNotificationFactory factory = new();

        var configuration = (IMailNotificateConfiguration)factory.GetConfiguration();
        configurationSetup?.Invoke(configuration);

        var template = (MailTemplate)factory.GetTemplateFormatter();
        string processedMessage = template.Process(templateInfo =>
        {
            templateInfo.TemplatePath = "./templates/mail/standard";
            templateInfo.ToEmail = email;
        });

        Sender.Send(configuration, processedMessage, body);
    }

    public void StandardTelegramNotification(string telephone, string body)
    {
        TelegramNotificationFactory factory = new();

        var configuration = (ITelegramNotificateConfiguration)factory.GetConfiguration();
        var template = (TelegramTemplate)factory.GetTemplateFormatter();
        string processedMessage = template.Process(templateInfo =>
        {
            templateInfo.TemplatePath = "./templates/telegram/standard";
            templateInfo.ToTelephone = telephone;
        });

        Sender.Send(configuration, processedMessage, body);
    }
}
