using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstNetCore.Contexts
{
    /// <summary>
    /// 邮件帮助类
    /// </summary>
    public class MailHelperContext
    {
        public void Send(string address,string subject, string content)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("王亮", "764747364@qq.com"));
            message.To.Add(new MailboxAddress("王亮", address));
            message.Subject = subject;

            message.Body = new TextPart(TextFormat.Plain) { Text = content };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.qq.com", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("joey", "password");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
