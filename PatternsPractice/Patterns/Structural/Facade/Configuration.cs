namespace PatternsPractice.Patterns.Structural.Facade;

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
    private const string _server = "127.0.0.1";
    private const string _port = "8888";
    private const string _exchangeData = "exchange-specific-data";

    public static INotificateConfiguration? Load<T>(string path) where T : INotificateConfiguration
        => typeof(T).Name switch
        {
            nameof(IMailNotificateConfiguration) => new DefaultMailNotificateConfiguration()
            {
                Server = $"MAIL-{_server}",
                Port = _port,
                ExchangeData = _exchangeData
            },
            nameof(ITelegramNotificateConfiguration) => new DefaultTelegramNotificateConfiguration()
            {
                Server = $"TELEGRAM-{_server}",
                Port = _port
            },
            _ => null
        };
}