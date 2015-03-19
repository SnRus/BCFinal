using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace parcerHTML_bastchange
{
    public partial class Massage : Form
    {
        public Massage()
        {
            InitializeComponent();
        }

        private void Massage_Load(object sender, EventArgs e)
        {

        }

        private void SendMsg_Click(object sender, EventArgs e)
        {
            if (FromMail.Text.Trim() == String.Empty || SubjectMail.Text.Trim() == String.Empty || BodyMail.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Пожалуйста введите все поля");
            }
            else
            {
                try
                {

                    SmtpClient client = new SmtpClient("smtp.mail.ru", 587);
                    client.Credentials = new NetworkCredential("clientBCFinder@mail.ru", "clientbcfinder007");
                    string from = "clientBCFinder@mail.ru";
                    string to = "sbcfinder@mail.ru";
                    string subject = "От: " + Convert.ToString(FromMail.Text) + "." + TypeOfMail.SelectedItem.ToString() + "  |  " + "ask: " + Convert.ToString(SubjectMail.Text);
                    string text = Convert.ToString(BodyMail.Text);
                    client.EnableSsl = true;

                    client.Send(from, to, subject, text);
                    this.Close();
                    MessageBox.Show("Ваше сообщение отправлено, спасибо за ваше обращение");

                }
                catch { MessageBox.Show("Что-то пошло не так:( Проверте коректность введеных вами данных, если при повторном вводе проблема не решена - обратитесь к системному администратору "); }
            }
        }
    }
}
