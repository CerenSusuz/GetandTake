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
                _appSettings.EmailConfiguration.UserName,
                _appSettings.EmailConfiguration.From));

            mimeMessage.To.Add(new MailboxAddress(_appSettings.EmailConfiguration.UserName, email));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                
                await client.ConnectAsync(
                        _appSettings.EmailConfiguration.SmtpServer, 
                        _appSettings.EmailConfiguration.Port,
                        true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(
                    _appSettings.EmailConfiguration.From,
                    _appSettings.EmailConfiguration.Password);

                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }

        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message);
        }
    }
}