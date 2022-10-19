using System.Net.Mail;

namespace SportsCenter.Models.Service
{
    public class Mail
    {
        public bool SendMail(string reciever, string msg, string title)
        {
            try
            {
                SmtpClient client = new("smtp.gmail.com", 587)
                {
                    Credentials = new System.Net.NetworkCredential("david8740lie@gmail.com", "gpamvnafmryqnmqj"),
                    EnableSsl = true
                };
                MailAddress from = new("david8740lie@gmail.com", "開約Go");
                MailAddress to = new(reciever);
                MailMessage message = new(from, to)
                {
                    Body = msg,
                    IsBodyHtml = true,
                    BodyEncoding = System.Text.Encoding.UTF8,
                    Subject = title,
                    SubjectEncoding = System.Text.Encoding.UTF8
                };
                client.Send(message);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
