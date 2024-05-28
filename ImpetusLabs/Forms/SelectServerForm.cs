using System;
using System.Windows.Forms;
using Opc.UaFx;
using Opc.UaFx.Client;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ImpetusLabs.Forms
{
    public partial class SelectServerForm : MaterialForm
    {
        private OpcConnectionManager opcConnectionManager;

        public SelectServerForm(OpcConnectionManager opcConnectionManager)
        {
            InitializeComponent();
            this.opcConnectionManager = opcConnectionManager;
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

        public static class SelectServer
        {
            public static string SERVERID = "";
        }

        private void ServerTxtBox_TextChanged(object sender, EventArgs e)
        {
            SelectServer.SERVERID = ServerTxtBox.Text.ToString();
        }

        private void ServerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServerTxtBox.Text.ToString().Length == 0 || !Uri.IsWellFormedUriString(ServerTxtBox.Text.ToString(), UriKind.Absolute))
                {
                    MessageBox.Show("Enter a valid URI", "ERROR");
                }
                else
                {
                    opcConnectionManager.Connect(SelectServer.SERVERID);
                    if (opcConnectionManager.IsConnected())
                    {
                        MessageBox.Show("Successful Connection", "Success");
                        ServerTxtBox.Text = "";
                        this.Close();
                    }
                }
            }
            catch (OpcException)
            {
                MessageBox.Show("Connection to OPC UA Server failed", "Connection ERROR");
            }
        }

        private void SelectServerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
