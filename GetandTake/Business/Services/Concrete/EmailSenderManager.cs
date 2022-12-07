using GetandTake.Configuration.Settings;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace GetandTake.Business.Services.Concrete;

public class EmailSenderManager : IEmailSender
{
    private readonly AppSettings _appSettings;

    public EmailSenderManager(AppSettings appSettings) => _appSettings = appSettings;

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        try
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(
                _appSettings.EmailSettings.UserName,
                _appSettings.EmailSettings.From));

            mimeMessage.To.Add(new MailboxAddress(_appSettings.EmailSettings.UserName, email));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                
                await client.ConnectAsync(
                        _appSettings.EmailSettings.SmtpServer, 
                        _appSettings.EmailSettings.Port,
                        useSsl: true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(
                    _appSettings.EmailSettings.From,
                    _appSettings.EmailSettings.Password);

                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(quit: true);
            }

        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message);
        }
    }
}