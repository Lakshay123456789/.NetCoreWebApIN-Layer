using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelDTO
{
     public  class EmailHelper
    {
        public bool SendEmail(string userEmail, string confirmationLink)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("lakshayk.aspirefox@gmail.com");
                mailMessage.To.Add(new MailAddress(userEmail));

                mailMessage.Subject = "Confirm your email";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = confirmationLink;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("lakshayk.aspirefox@gmail.com", "zxtnznreiyawvzlq");

                client.Send(mailMessage);
                return true;
            }
            catch (SmtpException ex)
            {
                // Log or handle the exception accordingly
                return false;
            }
        }
    }
}
