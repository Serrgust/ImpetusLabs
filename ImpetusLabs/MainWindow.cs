using ImpetusLabs.Forms;
using ImpetusLabs.LabsScreen;
using Opc.UaFx.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpetusLabs
{
    public partial class MainWindow : Form
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        public void LoadUserControl(object UserControl)
        {
            if (this.MainPanel.Controls.Count > 0)
                this.MainPanel.Controls.RemoveAt(0);
            UserControl f = UserControl as UserControl;
            f.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(f);
            this.MainPanel.Tag = f;
            f.Show();
        }

        public void LoadForm(object Form)
        {
            Form f = Form as Form;
            f.Show();
        }

        private void BtnLabSelection_Click(object sender, EventArgs e)
        {
            LoadUserControl(new LabSelection());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TopTime.Text = DateTime.Now.ToLongTimeString();
            TopDate.Text = DateTime.Now.ToLongDateString();
        }

        private void materialBtnLabSelection_Click(object sender, EventArgs e)
        {
            LoadUserControl(new LabSelection());
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoadForm(new LoginForm());
        }

        private void materialBtnLabSelection_Click_1(object sender, EventArgs e)
        {
            LoadUserControl(new LabSelection());
        }

        private void materialBtnLogin_Click(object sender, EventArgs e)
        {
            LoadForm(new LoginForm());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadForm(new SelectServerForm());
        }
    }
}
