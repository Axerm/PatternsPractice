namespace PatternsPractice.Patterns.Facade;

public interface INotificationFactory<TFormatterType> where TFormatterType : ITemplateInfo
{
    INotificateConfiguration GetConfiguration();
    ITemplateFormatter<TFormatterType> GetTemplateFormatter();
}

public class MailNotificationFactory: INotificationFactory<MailTemplateInfo>
{
    public INotificateConfiguration GetConfiguration()
        => ConfigurationLoader.Load<IMailNotificateConfiguration>(String.Empty)!;

    public ITemplateFormatter<MailTemplateInfo> GetTemplateFormatter()
        => new MailTemplate();
}

public class TelegramNotificationFactory : INotificationFactory<TelegramTemplateInfo>
{
    public INotificateConfiguration GetConfiguration()
        => ConfigurationLoader.Load<ITelegramNotificateConfiguration>(String.Empty)!;

    public ITemplateFormatter<TelegramTemplateInfo> GetTemplateFormatter()
        => new TelegramTemplate();
}