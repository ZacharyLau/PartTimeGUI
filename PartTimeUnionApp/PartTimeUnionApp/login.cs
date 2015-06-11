using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartTimeUnionApp
{
    public partial class login : Form
    {
        private LoginAdapter loginAdapter;
        public login()
        {
            InitializeComponent();
            passwordBox.KeyDown += new KeyEventHandler(tb_KeyDown);
            loginAdapter = new LoginAdapter();
        }

        private void login_Load(object sender, EventArgs e){}
        private void label1_Click(object sender, EventArgs e){}

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
           passwordBox.PasswordChar = '*';
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to quit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
            {
                new login().Show();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender is TextBox)
                {
                    if (String.IsNullOrEmpty(usernameBox.Text) || String.IsNullOrEmpty(passwordBox.Text))
                    {
                        label3.Visible = true;
                        return;
                    }

                    try
                    {
                        loginAdapter.Login(usernameBox.Text, passwordBox.Text);
                        Visible = false;
                    }
                    catch
                    {
                        label3.Visible = true;
                    }
                }
            }
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(usernameBox.Text) || String.IsNullOrEmpty(passwordBox.Text))
            {
                label3.Visible = true;
                return;
            }

            try
            {
                loginAdapter.Login(usernameBox.Text, passwordBox.Text);
                Visible = false;
            }
            catch
            {
                label3.Visible = true;
            }


        }   
    }
}
