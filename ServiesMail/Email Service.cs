using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class EmailService
{
    private readonly IConfiguration _config;
    private readonly ILogger<EmailService> _logger;

    public EmailService(IConfiguration config, ILogger<EmailService> logger)
    {
        _config = config;
        _logger = logger;
    }

    public async Task SendEmailAsync(string to, string subject, string body, string replyTo = null)
    {
        // Read SMTP settings with safe defaults (keeps current appsettings working)
        var host = _config["Smtp:Host"] ?? "smtp.gmail.com";
        var portRaw = _config["Smtp:Port"];
        var enableSslRaw = _config["Smtp:EnableSsl"];
        var from = _config["Smtp:From"];
        var fromName = _config["Smtp:FromName"] ?? "Law Firm Website";
        var username = _config["Smtp:Username"] ?? from;
        var password = _config["Smtp:Password"];

        if (string.IsNullOrWhiteSpace(from))
            throw new System.InvalidOperationException("SMTP 'From' address is not configured (Smtp:From).");
        if (string.IsNullOrWhiteSpace(password))
            _logger.LogWarning("SMTP password is empty. Email sending will likely fail. Configure Smtp:Password or use Secret Manager.");

        int port = 587;
        if (!string.IsNullOrWhiteSpace(portRaw) && int.TryParse(portRaw, out var parsedPort))
            port = parsedPort;

        bool enableSsl = true;
        if (!string.IsNullOrWhiteSpace(enableSslRaw) && bool.TryParse(enableSslRaw, out var parsedSsl))
            enableSsl = parsedSsl;

        using var smtpClient = new SmtpClient(host, port)
        {
            EnableSsl = enableSsl,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(username, password),
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Timeout = 1000 * 30 // 30s
        };

        using var mailMessage = new MailMessage
        {
            From = new MailAddress(from, fromName, Encoding.UTF8),
            Subject = subject,
            SubjectEncoding = Encoding.UTF8,
            Body = body,
            BodyEncoding = Encoding.UTF8,
            IsBodyHtml = true
        };

        // Support comma/semicolon-separated recipients
        foreach (var addr in (to ?? string.Empty).Split(new[] { ',', ';' }, System.StringSplitOptions.RemoveEmptyEntries))
        {
            mailMessage.To.Add(addr.Trim());
        }

        if (mailMessage.To.Count == 0)
            throw new System.ArgumentException("No valid recipient address provided.", nameof(to));

        if (!string.IsNullOrWhiteSpace(replyTo))
        {
            try { mailMessage.ReplyToList.Add(new MailAddress(replyTo)); }
            catch { /* ignore invalid reply-to */ }
        }

        try
        {
            _logger.LogInformation("Sending email to {To} via {Host}:{Port} (SSL={Ssl})", string.Join(",", mailMessage.To), host, port, enableSsl);
            await smtpClient.SendMailAsync(mailMessage);
            _logger.LogInformation("Email sent successfully.");
        }
        catch (SmtpException ex)
        {
            _logger.LogError(ex, "SMTP error while sending email to {To}", string.Join(",", mailMessage.To));
            throw;
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Unexpected error while sending email to {To}", string.Join(",", mailMessage.To));
            throw;
        }
    }
}
