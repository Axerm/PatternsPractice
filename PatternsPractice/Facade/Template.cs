namespace PatternsPractice.Patterns.Facade;

public static class TemplateLoader
{
    public static string Load(string _) => "{0} template ({1})";
}

public interface ITemplateInfo
{
    string TemplatePath { get; }
}

public class MailTemplateInfo : ITemplateInfo
{
    public string TemplatePath { get; set; } = null!;
    public string ToEmail { get; set; } = null!;
}

public class TelegramTemplateInfo : ITemplateInfo
{
    public string TemplatePath { get; set; } = null!;
    public string ToTelephone { get; set; } = null!;
}

public interface ITemplateFormatter<T> where T : ITemplateInfo
{
    string Process(Action<T> templateInfoSetup);
}

public class MailTemplate : ITemplateFormatter<MailTemplateInfo>
{
    public virtual string Process(Action<MailTemplateInfo> templateInfoSetup)
    {
        if (templateInfoSetup is null)
            throw new ArgumentNullException(nameof(templateInfoSetup));

        MailTemplateInfo templateInfo = new();
        templateInfoSetup(templateInfo);

        if (String.IsNullOrWhiteSpace(templateInfo.TemplatePath) || String.IsNullOrWhiteSpace(templateInfo.ToEmail))
            throw new ArgumentException(nameof(templateInfo));

        string template = TemplateLoader.Load(templateInfo.TemplatePath);
        return String.Format(template, "processed MAIL", $"mail: {templateInfo.ToEmail}");
    }
}

public class TelegramTemplate : ITemplateFormatter<TelegramTemplateInfo>
{
    public virtual string Process(Action<TelegramTemplateInfo> templateInfoSetup)
    {
        if (templateInfoSetup is null)
            throw new ArgumentNullException(nameof(templateInfoSetup));

        TelegramTemplateInfo templateInfo = new();
        templateInfoSetup(templateInfo);

        if (String.IsNullOrWhiteSpace(templateInfo.TemplatePath) || String.IsNullOrWhiteSpace(templateInfo.ToTelephone))
            throw new ArgumentException(nameof(templateInfo));

        string template = TemplateLoader.Load(templateInfo.TemplatePath);
        return String.Format(template, "processed TELEGRAM", $"telephone: {templateInfo.ToTelephone}");
    }
}