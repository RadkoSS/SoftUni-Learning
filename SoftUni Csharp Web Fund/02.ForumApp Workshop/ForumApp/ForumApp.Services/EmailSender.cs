namespace ForumApp.Services;

using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

using static HiddenCredentials;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var senderEmail = OutlookEmail;
        var password = Password;

        var client = new SmtpClient("smtp.office365.com", 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(senderEmail, password)
        };

        return client.SendMailAsync(
            new MailMessage(from: senderEmail,
                to: email,
                subject,
                htmlMessage));
    }
}