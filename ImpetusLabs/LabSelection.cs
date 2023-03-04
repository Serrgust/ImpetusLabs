using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpetusLabs.LabsScreen
{
    public partial class LabSelection : UserControl
    {
        Lab01Screen Lab01Scre;
        public LabSelection()
        {
            InitializeComponent();
            Lab01Scre = new Lab01Screen();
        }

        public void GoToLab(object UserControl)
        {
            flowLayoutPanel1.Enabled = false;
            flowLayoutPanel1.Visible = false;
            if (this.LabSelectPanel.Controls.Count > 0)
                this.LabSelectPanel.Controls.RemoveAt(0);
            UserControl f = UserControl as UserControl;
            f.Dock = DockStyle.Fill;
            this.LabSelectPanel.Controls.Add(f);
            this.LabSelectPanel.Tag = f;
            f.Show();

        }
        private void BtnLab01Screen_Click(object sender, EventArgs e)
        {
            GoToLab(new Lab01Screen());
        }

        private void BtnLab02Screen_Click(object sender, EventArgs e)
        {
            GoToLab(new Lab02Screen());
        }
    }
}
