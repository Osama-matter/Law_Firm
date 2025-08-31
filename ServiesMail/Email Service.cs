using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class EmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(string to, string subject, string body, string replyTo = null)
    {
        var from = _config["Smtp:From"];
        var password = _config["Smtp:Password"];

        using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
        {
            smtpClient.Credentials = new NetworkCredential(from, password);
            smtpClient.EnableSsl = true;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(from, "Law Firm Website"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(to);

            if (!string.IsNullOrEmpty(replyTo))
                mailMessage.ReplyToList.Add(new MailAddress(replyTo));

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
