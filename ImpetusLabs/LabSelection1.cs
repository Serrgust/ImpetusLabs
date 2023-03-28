using ImpetusLabs.LabsScreen;
using ImpetusLabs;
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
    public partial class LabSelection1 : Form
    {
        public LabSelection1()
        {
            InitializeComponent();
        }



        public void GoToLab(object UserControl)
        {
            this.Controls.Clear();
            UserControl f = UserControl as UserControl;
            f.Dock = DockStyle.Fill;
            this.Controls.Add(f);
            this.Tag = f;
            f.Show();
        }

        private void BtnLab01Screen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fuck Pierlusi");
            GoToLab(new Lab01Screen());
        }

        private void BtnLab02Screen_Click(object sender, EventArgs e)
        {
            GoToLab(new Lab02Screen());
        }
    }
}