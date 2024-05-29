using ImpetusLabs.Forms;
using ImpetusLabs.LabsScreen;
using MaterialSkin2Framework;
using MaterialSkin2Framework.Controls;
using System;
using System.Windows.Forms;

namespace ImpetusLabs
{
    public partial class MainWindow : MaterialForm
    {
        public MainWindow()
        {
            InitializeComponent();
            OpcClientManager.ConnectionStatusChanged += UpdateConnectionStatus;
            UpdateConnectionStatus();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // Set the interval to 1 second
            timer1.Start(); // Start the timer
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TopDate.Text = $"{DateTime.Now.ToLongDateString()}";
            TopTime.Text = $"{DateTime.Now.ToLongTimeString()}";
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            ClearMainPanel();
        }

        private void BtnLabSelection_Click(object sender, EventArgs e)
        {
            LoadUserControl(new LabSelection());
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            using (LoginForm loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
            }
        }

        private void BtnX_Click(object sender, EventArgs e)
        {
            // Define behavior for BtnX click event
        }

        private void BtnSelectServer_Click(object sender, EventArgs e)
        {
            using (SelectServerForm selectServerForm = new SelectServerForm())
            {
                selectServerForm.ShowDialog();
            }
        }

        public void LoadUserControl(UserControl userControl)
        {
            ClearMainPanel();
            userControl.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(userControl);
            this.MainPanel.Tag = userControl;
            userControl.Show();
        }

        private void UpdateConnectionStatus()
        {
            lblConnectionStatus.Text = $"Connected: {(OpcClientManager.IsConnected ? "Yes" : "No")}";
        }

        private void ClearMainPanel()
        {
            if (this.MainPanel.Controls.Count > 0)
            {
                this.MainPanel.Controls.Clear();
            }
        }
    }
}
