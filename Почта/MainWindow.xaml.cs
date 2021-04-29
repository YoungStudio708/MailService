using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Почта
{
    public partial class MainWindow : Window

    {

        public int vov;

        public MainWindow()

        {

            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
       {
            Random random = new Random();
            vov = random.Next();
            string login = log.Text;
            string pasword = pas.Password;
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress(login, "Сервис почты праграмистов");
                // кому отправляем
                MailAddress to = new MailAddress(login);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Вход в вашу почту";
                // текст письма
                m.Body = $"<h2>ВНИМАНИЕ</h2>";
                m.Body += "В вашу почту кто-то вошёл, убедитесь, что всё хорошо";
               // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                string str = "";
                if (login.Contains("@gmail.com")) str = "smtp.gmail.com";
                else if (login.Contains("@mail.ru")) str = "smtp.mail.ru";
                SmtpClient smtp = new SmtpClient(str, 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential(login, pasword);
                smtp.EnableSsl = true;
                smtp.Send(m);
                //открытие ввода кода

                this.Hide();
                Potchta a = new Potchta(pasword, login);
                a.Show();
            }
           catch
            {
                MessageBox.Show("Вы ввели логин или пароль не правильно!");
            }

        }

    }
}
