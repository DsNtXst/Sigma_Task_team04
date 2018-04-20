using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace DistanceLearning.BusinessLayer
{
    public static class Mail
    {
        public static void SendMail(string TO, string Text)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("maxbadenko@yandex.ua", "Denis");
            // кому отправляем
            MailAddress to = new MailAddress(TO);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Привет";
            // текст письма
            m.Body = "<h2>Курс " + Text + " был создан</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("distancelearning80@gmail.com", "dooge1488");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
