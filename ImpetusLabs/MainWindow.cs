using ImpetusLabs.Forms;
using ImpetusLabs.LabsScreen;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;


namespace ImpetusLabs
{
    public partial class MainWindow : MaterialForm
    {
        private OpcConnectionManager opcConnectionManager;

        public MainWindow()
        {
            InitializeComponent();
            opcConnectionManager = new OpcConnectionManager();
            // Initialize MaterialSkinManager
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Initialize the timer to update time and date
            timer1.Interval = 1000; // Set the interval to 1 second
            timer1.Start(); // Start the timer
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TopTime.Text = DateTime.Now.ToLongTimeString();
            TopDate.Text = DateTime.Now.ToLongDateString();
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
            using (LoginForm LoginForm = new LoginForm())
            {
                LoginForm.ShowDialog();
            }
        }
        private void BtnX_Click(object sender, EventArgs e)
        {

        }

        private void BtnSelectServer_Click(object sender, EventArgs e)
        {
            using (SelectServerForm selectServerForm = new SelectServerForm(opcConnectionManager))
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

        public void LoadForm(Form form)
        {
            form.Show();
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
