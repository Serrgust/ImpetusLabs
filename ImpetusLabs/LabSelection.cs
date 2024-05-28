using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ImpetusLabs.LabsScreen
{
    public partial class LabSelection : UserControl
    {
        public LabSelection()
        {
            InitializeComponent();
        }

        public void GoToLab<T>() where T : UserControl, new()
        {
            try
            {
                flowLayoutPanel1.Enabled = false;
                flowLayoutPanel1.Visible = false;

                // Check if the control of the same type is already loaded
                if (LabSelectPanel.Controls.Count > 0 && LabSelectPanel.Controls[0] is T)
                    return;

                // Clear the existing control
                LabSelectPanel.Controls.Clear();

                // Create the new control and add it to the panel
                T labScreen = new T
                {
                    Dock = DockStyle.Fill
                };

                LabSelectPanel.Controls.Add(labScreen);
                labScreen.Show();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the control loading
                MessageBox.Show($"An error occurred while loading the lab screen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Re-enable the flowLayoutPanel if an error occurs
                flowLayoutPanel1.Enabled = true;
                flowLayoutPanel1.Visible = true;
            }
        }

        private void BtnLab01Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab01Screen>();
        }

        private void BtnLab02Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab02Screen>();
        }

        private void BtnLab03Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab03Screen>();
        }

        private void BtnLab04Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab04Screen>();
        }

        private void BtnLab05Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab05Screen>();
        }

        private void BtnLab06Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab06Screen>();
        }

        private void BtnLab07Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab07Screen>();
        }

        private void BtnLab08Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab08Screen>();
        }

        private void BtnLab09Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab09Screen>();
        }

        private void BtnLab10Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab10Screen>();
        }

        private void BtnLab11Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab11Screen>();
        }

        private void BtnLab12Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab12Screen>();
        }

        private void BtnLab13Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab13Screen>();
        }

        private void BtnLab14Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab14Screen>();
        }

        private void BtnLab15Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab15Screen>();
        }

        private void BtnLab16Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab16Screen>();
        }

        private void BtnLab17Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab17Screen>();
        }

        private void BtnLab18Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab18Screen>();
        }

        private void BtnLab19Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab19Screen>();
        }

        private void BtnLab20Screen_Click(object sender, EventArgs e)
        {
            GoToLab<Lab20Screen>();
        }
    }
}
