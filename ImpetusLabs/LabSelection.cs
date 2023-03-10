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
        public LabSelection()
        {
            InitializeComponent();
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

        private void BtnLab03Screen_Click(object sender, EventArgs e)
        {
            GoToLab(new Lab03Screen());
        }

        private void BtnLab04Screen_Click(object sender, EventArgs e)
        {
            GoToLab(new Lab04Screen());
        }

        private void BtnLab05Screen_Click(object sender, EventArgs e)
        {
            GoToLab(new Lab05Screen());
        }

        private void BtnLab06Screen_Click(object sender, EventArgs e)
        {
            GoToLab(new Lab06Screen());

        }

        private void BtnLab07Screen_Click(object sender, EventArgs e)
        {
            GoToLab(new Lab07Screen());
        }

        private void BtnLab08Screen_Click(object sender, EventArgs e)
        {
            GoToLab(new Lab08Screen());
        }

        private void BtnLab09Screen_Click(object sender, EventArgs e)
        {
            GoToLab(new Lab09Screen());
        }

        private void BtnLab10Screen_Click(object sender, EventArgs e)
        {
            GoToLab(new Lab10Screen());
        }

        private void BtnLab11Screen_Click(object sender, EventArgs e)
        {
            GoToLab(new Lab11Screen());
        }
    }
}
