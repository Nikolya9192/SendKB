using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SendKB
{
    public partial class Login : Form
    {        
        private string TypeUser = "nemo";
        public static string login;
        public static string baza;
        

        public Login()
        {
            InitializeComponent();

            tb_Login.Text = Options.login_;
            tb_Baza.Text = Options.baza_;
            

        }
        
        private void button2_Click(object sender, System.EventArgs e)
		{
			TypeUser="nemo";
			Close();
		}

		private void btn_ClickOK(object sender, System.EventArgs e)
		{
			
//			if (comboBox1.Text=="")
//			{
//				MessageBox.Show("Введіть путь до бази даних");
//				comboBox1.Focus();
//				return;
//			}
			
			if (tb_Login.Text=="")
			{
				MessageBox.Show("Введіть користувача");
				tb_Login.Focus();
				return;
			}

			if (tb_Passwd.Text=="")
			{
				MessageBox.Show("Введіть пароль");
				tb_Passwd.Focus();
				return;
			}
			if (tb_Baza.Text=="")
			{
				MessageBox.Show("Введіть назву бази");
				tb_Baza.Focus();
				return;
			}

            
			
			TypeUser="user";

			if (!AccessDB.SetOraLoginPass(tb_Login.Text, tb_Passwd.Text, tb_Baza.Text))
				TypeUser="nemo";

            login = tb_Login.Text;
            baza = tb_Baza.Text;
			
			Close();
		}

		public string ShowLogin()
		{
			this.ShowDialog();
			return TypeUser;
		}

		
		private void Login_Activated(object sender, System.EventArgs e)
		{
            if (tb_Login.Text == "")
                tb_Login.Focus();
            else
                tb_Passwd.Focus();
		}

				
		private void Login_Load(object sender, System.EventArgs e)
		{
            //if (tb_Login.Text == "")
            //    tb_Login.Focus();
            //else
            //    tb_Passwd.Focus();
            
		}

		
        private void tb_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                tb_Passwd.Focus();
                //tb_Login.Focus();                
        }

        private void tb_Passwd_KeyDown(object sender, KeyEventArgs e)
        
        {
            if (e.KeyData == Keys.Enter)
                if (tb_Baza.Text == "")
                    tb_Baza.Focus();
                else 
                    btn_ClickOK(sender, e);
                //tb_Passwd.Focus();
        }

        private void tb_Baza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btn_Ok.Focus();
            
        }

        private void tb_Login_Leave(object sender, EventArgs e)
        {
            tb_Login.Text = tb_Login.Text.ToUpper();
        }

       
	}

}

