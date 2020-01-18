using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Medicine.Common
{
    public static class CustomEmail
    {
        public static bool SendFeedbackEmail(string toEmail, string fromName, string toName, string feedbackMessage)
        {
            try
            {
                string subject = "";
                string body = "";

                subject = "Medicine Report Feedback";
                body = "Hi, "+ toName + "<br/><br/>" + feedbackMessage + "<br/><br/>";

                var message = new MailMessage();
                message.To.Add(new MailAddress(toEmail));
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                    return true;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
