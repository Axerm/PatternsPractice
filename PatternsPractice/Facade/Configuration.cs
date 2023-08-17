namespace PatternsPractice.Patterns.Facade;

public interface INotificateConfiguration
{
    string Server { get; set; }
    string Port { get; set; }
}

public interface IMailNotificateConfiguration : INotificateConfiguration
{
    string ExchangeData { get; }
}
public interface ITelegramNotificateConfiguration : INotificateConfiguration { }

internal class DefaultMailNotificateConfiguration : IMailNotificateConfiguration
{
    public string Server { get; set; } = null!;
    public string Port { set; get; } = null!;
    public string ExchangeData { get; set; } = null!;
}

internal class DefaultTelegramNotificateConfiguration : ITelegramNotificateConfiguration
{
    public string Server { get; set; } = null!;
    public string Port { set; get; } = null!;
}

public static class ConfigurationLoader
{
    private const string s_server = "127.0.0.1";
    private const string s_port = "8888";
    private const string s_exchangeData = "8888";

    public static INotificateConfiguration? Load<T>(string path) where T : INotificateConfiguration
        => typeof(T).Name switch
        {
            "IMailNotificateConfiguration" => new DefaultMailNotificateConfiguration()
                {
                    Server = $"MAIL-{s_server}",
                    Port = s_port,
                    ExchangeData = s_exchangeData
                },
            "ITelegramNotificateConfiguration" => new DefaultTelegramNotificateConfiguration()
                {
                    Server = $"TELEGRAM-{s_server}",
                    Port = s_port
                },
            _ => null
        };
}