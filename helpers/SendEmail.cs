using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;

namespace GECP_Front_End_Static.helpers
{
    public static class Email
    {
       
        public static bool SendEmail(string EmailTo, string subject, string Body, string EmailFrom,string EmailName = "GECP")
        {
            
        // Plug in your email service here to send an email.
        var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress(EmailName, EmailFrom));
            msg.To.Add(new MailboxAddress(EmailTo));
            //msg.Bcc.Add(new MailboxAddress(template.EmailBcc));
            msg.Subject = subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = Body;
            msg.Body = bodyBuilder.ToMessageBody();


            using (var smtp = new SmtpClient())
            {

                smtp.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                //smtp.Authenticate(credentials: new NetworkCredential("gecpatcse.common@gmail.com", "Admin@123"));
                smtp.Authenticate("gecpatcse.common@gmail.com", "vfog owli eiek cqfq"); //

                //MILES WEB HOSTING
                //smtp.Connect("beyond.herosite.pro", 587, SecureSocketOptions.None);
                //smtp.Authenticate(credentials: new NetworkCredential("contact@gecpatan.ac.in", "vP841q$q"));


                //sendinblue
                //smtp.Connect("smtp-relay.brevo.com", 587, SecureSocketOptions.None);
                //smtp.Authenticate(credentials: new NetworkCredential("87b654002@smtp-brevo.com", "fzGB6kwcpC42PqKD"));
                smtp.Send(msg, CancellationToken.None);
                smtp.Disconnect(true, CancellationToken.None);
            }

            return true;
        }
    }
}