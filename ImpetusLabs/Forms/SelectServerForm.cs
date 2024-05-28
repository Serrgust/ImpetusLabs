using System;
using System.Windows.Forms;
using MaterialSkin2Framework;
using MaterialSkin2Framework.Controls;
using Opc.UaFx;
using Opc.UaFx.Client;

namespace ImpetusLabs.Forms
{
    public partial class SelectServerForm : MaterialForm
    {

        public SelectServerForm()
        {
            InitializeComponent();
        }

        private void ServerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string serverUrl = ServerTxtBox.Text.ToString();

                if (string.IsNullOrWhiteSpace(serverUrl) || !Uri.IsWellFormedUriString(serverUrl, UriKind.Absolute))
                {
                    MessageBox.Show("Enter a valid URI", "ERROR");
                }
                else
                {
                    OpcClientManager.Connect(serverUrl);
                    if (OpcClientManager.IsConnected)
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
            // Any initialization code if needed
        }
    }
}
