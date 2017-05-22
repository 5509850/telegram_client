using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeleSharp.TL;
using TLSharp.Core;

namespace Telegram_Client
{
    public partial class Form1 : Form
    {
        string apiHash = "<Your API hash>";
        int apiId = <Your api ID>;
       
        private TLUser user = null;
        private TLUser user2 = null;
        bool resultConnect = false;
        TelegramClient client = null;
        List<TLUser> recipientUserlist = null;

        public Form1()
        {
            InitializeComponent();
            InitClient();
        }

        #region Property
        string SessionHash { get; set; }
                
        string MyPhoneNumber
        {
            get
            {
                return textBoxPhone.Text;
            }
            set
            {
                textBoxPhone.Text = value;
            }
        }

        int RecipientID { get; set; }       

        // code sms drom telegram
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

        string RecipientPhone
        {
            get
            {
                return recipientPhone.Text;
            }
            set
            {
                recipientPhone.Text = value;
            }
        }

        #endregion

        #region control Events

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MyPhoneNumber))
            {
                textBoxPhone.BackColor = Color.White;
                RequestCode();
            }
            else
            {
                MessageBox.Show("Enter you Phone!");
                textBoxPhone.Focus();
                textBoxPhone.BackColor = Color.Red;
            }
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            SignIn();
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(SessionHash))
            {
                RequestCode();
            }
            else
            {
                if (string.IsNullOrEmpty(RecipientPhone))
                {
                    MessageBox.Show("Choice recipient by phone or Name");             
                    recipientPhone.BackColor = Color.Red;
                }
                else
                {
                    SendMessageByPhone();
                }
            }
        }

        //fix textBox text only digit
        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxPhoneTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            buttonSignIn.Enabled = !string.IsNullOrEmpty(Code) && !string.IsNullOrEmpty(MyPhoneNumber);
            textBoxCode.BackColor = (string.IsNullOrEmpty(Code)) ? Color.Red : Color.White;            
        }
       
        private void textBoxPhoneTo_TextChanged(object sender, EventArgs e)
        {
            recipientPhone.BackColor = (string.IsNullOrEmpty(recipientPhone.Text)) ? Color.Red : Color.White;
        }

        private void comboBox_userlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_userlist.SelectedValue == null)
            {
                return;
            }
            // получаем весь выделенный объект
            Recipient recipient = (Recipient)comboBox_userlist.SelectedItem;
            recipientName.Text = string.Format("{0} {1}", recipient.FirstName, recipient.LastName) ;
            RecipientPhone = recipient.Phone;
            RecipientID = recipient.Id;
        }

        #endregion
        
        private async void InitClient()
        {                 
            client = new TelegramClient(apiId, apiHash);
            resultConnect = await client.ConnectAsync(true);
        }
            
        private async void SendMessageByPhone()
        {
            if (string.IsNullOrEmpty(Message))
            {
                MessageBox.Show("Enter your message");
                textBox_message.Focus();
                return;
            }
            if (RecipientID == 0)
            {                
                MessageBox.Show("Choice recipient by phone or Name");
                recipientPhone.Focus();
                recipientPhone.BackColor = Color.Red;
                return;
            }

            if (client != null)
            {
                try
                {
                    if (user == null)
                    {
                        //var hash = await client.SendCodeRequestAsync(PhoneNumber); //отсылаем запрос на создании сессии 
                        user = await client.MakeAuthAsync(MyPhoneNumber, SessionHash, Code);
                    }
                    if (user == null)
                    {
                        Thread.Sleep(1000);
                        if (user == null)
                        {
                            MessageBox.Show("user == null");
                            return;
                        }
                    }               
                    //send message
                    await client.SendMessageAsync(new TLInputPeerUser() { user_id = RecipientID }, Message);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! " + ex.Message);
                }
            }          
        }

        private async Task FillRecipienstList()
        {
            recipientUserlist = null;
            if (client != null)
            {
                try
                {
                    if (user == null)
                    {
                        //var hash = await client.SendCodeRequestAsync(PhoneNumber); //отсылаем запрос на создании сессии 
                         user = await client.MakeAuthAsync(MyPhoneNumber, SessionHash, Code);
                        /*var password = await client.GetPasswordSetting();
                        *     PasswordToAuthenticate = ConfigurationManager.AppSettings[nameof(PasswordToAuthenticate)];
                        var password_str = PasswordToAuthenticate;

                        user = await client.MakeAuthWithPasswordAsync(password, password_str);
                        */
                        //user2 = await client.MakeAuthWithPasswordAsync(new TeleSharp.TL.Account.TLPassword(), "4028");
                    }
                    if (user == null)
                    {
                        Thread.Sleep(1000);
                        if (user == null)
                        {
                            MessageBox.Show("user2 == null");
                            return;
                        }
                    }
                    //get available contacts
                    var result = await client.GetContactsAsync();

                    if (result != null)
                    {
                        TLVector<TLAbsUser> userS = result.users;
                        List<TLAbsUser> usersList = userS.lists;
                        recipientUserlist = new List<TLUser>();
                        List<Recipient> recipientList = new List<Recipient>();
                        foreach (TLUser userTLU in usersList)
                        {
                            TLUser u = userTLU as TLUser;
                            if (u != null)
                            {                               
                                recipientUserlist.Add(u);
                                recipientList.Add(new Recipient {
                                    Id = u.id,
                                    Name = string.Format("{0} {1} ({2})", u.first_name, u.last_name, u.phone),
                                    Phone = u.phone, FirstName = u.first_name, LastName = u.last_name});
                            }
                        }

                        comboBox_userlist.DataSource = recipientList;
                        comboBox_userlist.DisplayMember = "Name";
                        comboBox_userlist.ValueMember = "Id";                      
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! " + ex.Message);
                }
            }
        }

        private async void RequestCode()
        {
            Code = string.Empty;       
            if (resultConnect)
            {   //textBox_message.Text
                try
                {
                    SessionHash = await client.SendCodeRequestAsync(MyPhoneNumber); //отсылаем запрос на создании сессии  
                    MessageBox.Show("Enter Code from SMS");                    
                    textBoxCode.BackColor = Color.Red;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Not connected");
            }
        }

        private async void SignIn()
        {
            await FillRecipienstList();
            button_send.Enabled = (RecipientID != 0) && !string.IsNullOrEmpty(Code) && !string.IsNullOrEmpty(MyPhoneNumber) && !string.IsNullOrEmpty(SessionHash);            
        }     
    }

    class Recipient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
