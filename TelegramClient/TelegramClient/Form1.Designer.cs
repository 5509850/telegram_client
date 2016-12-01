namespace Telegram_Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_send = new System.Windows.Forms.Button();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.recipientPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAuth = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_userlist = new System.Windows.Forms.ComboBox();
            this.recipientName = new System.Windows.Forms.TextBox();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_send
            // 
            this.button_send.Enabled = false;
            this.button_send.Location = new System.Drawing.Point(293, 145);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(126, 23);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textBox_message
            // 
            this.textBox_message.Location = new System.Drawing.Point(12, 26);
            this.textBox_message.Multiline = true;
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(265, 223);
            this.textBox_message.TabIndex = 1;
            this.textBox_message.Text = "hi";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(3, 35);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(101, 20);
            this.textBoxPhone.TabIndex = 2;
            this.textBoxPhone.Text = "375296852724";
            this.textBoxPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPhone_KeyPress);
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(3, 85);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(100, 20);
            this.textBoxCode.TabIndex = 3;
            this.textBoxCode.Tag = "code";
            this.textBoxCode.TextChanged += new System.EventHandler(this.textBoxCode_TextChanged);
            this.textBoxCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCode_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "your phone number";
            // 
            // recipientPhone
            // 
            this.recipientPhone.Enabled = false;
            this.recipientPhone.Location = new System.Drawing.Point(498, 229);
            this.recipientPhone.Name = "recipientPhone";
            this.recipientPhone.Size = new System.Drawing.Size(121, 20);
            this.recipientPhone.TabIndex = 6;
            this.recipientPhone.TextChanged += new System.EventHandler(this.textBoxPhoneTo_TextChanged);
            this.recipientPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPhoneTo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "to";
            // 
            // buttonAuth
            // 
            this.buttonAuth.Location = new System.Drawing.Point(110, 32);
            this.buttonAuth.Name = "buttonAuth";
            this.buttonAuth.Size = new System.Drawing.Size(83, 23);
            this.buttonAuth.TabIndex = 8;
            this.buttonAuth.Text = "Authentificate";
            this.buttonAuth.UseVisualStyleBackColor = true;
            this.buttonAuth.Click += new System.EventHandler(this.buttonAuth_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSignIn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonAuth);
            this.groupBox1.Controls.Add(this.textBoxPhone);
            this.groupBox1.Controls.Add(this.textBoxCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(293, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 113);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authentificate";
            // 
            // comboBox_userlist
            // 
            this.comboBox_userlist.FormattingEnabled = true;
            this.comboBox_userlist.Location = new System.Drawing.Point(498, 143);
            this.comboBox_userlist.Name = "comboBox_userlist";
            this.comboBox_userlist.Size = new System.Drawing.Size(121, 21);
            this.comboBox_userlist.TabIndex = 10;
            this.comboBox_userlist.SelectedIndexChanged += new System.EventHandler(this.comboBox_userlist_SelectedIndexChanged);
            // 
            // recipientName
            // 
            this.recipientName.Enabled = false;
            this.recipientName.Location = new System.Drawing.Point(498, 203);
            this.recipientName.Name = "recipientName";
            this.recipientName.Size = new System.Drawing.Size(121, 20);
            this.recipientName.TabIndex = 12;
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Enabled = false;
            this.buttonSignIn.Location = new System.Drawing.Point(110, 81);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(83, 23);
            this.buttonSignIn.TabIndex = 9;
            this.buttonSignIn.Text = "Sign In";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 261);
            this.Controls.Add(this.recipientName);
            this.Controls.Add(this.comboBox_userlist);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.recipientPhone);
            this.Controls.Add(this.textBox_message);
            this.Controls.Add(this.button_send);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telegram Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox recipientPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAuth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_userlist;
        private System.Windows.Forms.TextBox recipientName;
        private System.Windows.Forms.Button buttonSignIn;
    }
}

