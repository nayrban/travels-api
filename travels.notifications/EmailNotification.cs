using MailKit.Net.Smtp;
using MimeKit;

using System.Threading.Tasks;

namespace travels.notifications
{
    public class EmailNotification : CloudNotification
    {

        private const string HOST = "Smtp.Host";
        private const string PORT = "Smtp.Port";
        private const string USE_SSL = "Smtp.EnableSsl";
        private const string EMAIL_PASSWORD = "fromPassword";
        private const string EMAIL_USER = "fromAddress";
        private const string EMAIL_NAME = "fromName";
        private const string FIXED_EMAIL = "fixedAddress";
      

        private int _port;
        private string _host;
        private bool _ssl;
        private string _pwd;
        private string _email;
        private string _name;
        private string _fixedEmail;

        public EmailNotification()
        {
            _port = int.Parse(System.Configuration.ConfigurationManager.AppSettings[PORT]);
            _host = System.Configuration.ConfigurationManager.AppSettings[HOST];
            _ssl = bool.Parse(System.Configuration.ConfigurationManager.AppSettings[USE_SSL]);
            _pwd = System.Configuration.ConfigurationManager.AppSettings[EMAIL_PASSWORD];
            _email = System.Configuration.ConfigurationManager.AppSettings[EMAIL_USER];
            _name = System.Configuration.ConfigurationManager.AppSettings[EMAIL_NAME];
            _fixedEmail = System.Configuration.ConfigurationManager.AppSettings[FIXED_EMAIL];
        }


        public async Task sendNotification(NotificationMessage notMessage)
        {      
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_name, _email));
            message.To.Add(new MailboxAddress(_name, _fixedEmail));            
            message.Subject = notMessage.Title;

            message.Body = new TextPart("html")
            {
                
                Text = notMessage.Message
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(_host, 25, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
              //  client.Authenticate(_email, _pwd);

                await client.SendAsync(message);
                client.Disconnect(true);
            }
        }
    }
}
