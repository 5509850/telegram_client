using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TeleSharp.TL;
using TLSharp.Core;

namespace Telegram_Client
{
    public partial class Form1 : Form
    {
        string apiHash = "<Your API HASH>";
        int apiId = 1;

        public Form1()
        {
            InitializeComponent();
            InitClient();
        }

        string PhoneNumber {
            get
            {
                return textBoxPhone.Text;
            }
            set
            {
                textBoxPhone.Text = value;
            }
        }

        // код который придет от Telegram 
        string Code
        {
            get
            {
                return textBoxCode.Text;
            }
            set
            {
                textBoxCode.Text = value;
            }
        }

        string Message
        {
            get
            {
                return textBox_message.Text;
            }
            set
            {
                textBox_message.Text = value;
            }
        }

        string recipientPhone
        {
            get
            {
                return textBoxPhoneTo.Text;
            }
            set
            {
                textBoxPhoneTo.Text = value;
            }
        }

        bool resultConnect = false;
        TelegramClient client;       

        private async void InitClient()
        {                 
            client = new TelegramClient(apiId, apiHash);
            resultConnect = await client.ConnectAsync(true);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxCode.Text))
            {
                RequestCode();
            }
            else
            {
                SendMessageByPhone();
            }
        }

        private async void SendMessageByPhone()
        {
            //get available contacts
            var result = await client.GetContactsAsync();

            //find recipient in contacts
            var user = result.users.lists
                .Where(x => x.GetType() == typeof(TLUser))
                .Cast<TLUser>()
                .FirstOrDefault(x => x.phone == recipientPhone);

            //send message
            await client.SendMessageAsync(new TLInputPeerUser() { user_id = user.id }, Message);
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }      

        private void textBoxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void RequestCode()
        {
            if (resultConnect)
            {   //textBox_message.Text
                var hash = await client.SendCodeRequestAsync(PhoneNumber); //отсылаем запрос на создании сессии 
                while (string.IsNullOrEmpty(Code))
                {
                    Thread.Sleep(500);
                }
                var user = await client.MakeAuthAsync(PhoneNumber, hash, Code); // создаем сессию
            }
            else
            {
                MessageBox.Show("Not connected");
            }
        }
    }
}
