using ImpetusLabs.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ImpetusLabs.Forms.SelectServerForm;

namespace ImpetusLabs
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void materialLoginEnter_Click(object sender, EventArgs e)
        {
            if (UsernameField.Text == "" && PasswordField.Text == "")
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("The username or password entered is incorrect, please try again.");
            }
        }

        private void materialMultiLineTextBox21_Click(object sender, EventArgs e)
        {

        }

        /*        private void button1_Click(object sender, EventArgs e)
                {
                    if (UsernameField.Text == "" && PasswordField.Text == "")
                    {
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("The username or password entered is incorrect, please try again.");
                    }
                }*/

    }
}
