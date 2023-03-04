using ImpetusLabs.LabsScreen;
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
        LabSelection LabSel;
        public MainWindow()
        {
            LabSel = new LabSelection();
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

        private void BtnLabSelection_Click(object sender, EventArgs e)
        {
            LoadUserControl(new LabSelection());
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
