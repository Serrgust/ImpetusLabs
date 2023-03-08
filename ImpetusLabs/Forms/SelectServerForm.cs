using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.UaFx;
using Opc.UaFx.Client;

namespace ImpetusLabs.Forms
{
    public partial class SelectServerForm : Form
    {

        public SelectServerForm()
        {
            InitializeComponent();
        }

        public static class SelectServer
        {
            public static String SERVERID;
        }

        private void ServerTxtBox_TextChanged(object sender, EventArgs e)
        {
            SelectServer.SERVERID = ServerTxtBox.Text.ToString();
        }

        private void ServerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServerTxtBox.Text.ToString().Length == 0 | !Uri.IsWellFormedUriString(ServerTxtBox.Text.ToString(), UriKind.Absolute))
                {
                    MessageBox.Show("Enter URI", "ERROR");
                }
                else
                {
                    OpcClient client = new OpcClient(SelectServer.SERVERID);
                    client.Connect();
                    MessageBox.Show("Successful Connection", "Success");
                    ServerTxtBox.Text = "";
                    this.Close();
                }
            }
            catch (Opc.UaFx.OpcException)
            {
                MessageBox.Show("Connection to OPC UA Server failed", "Connection ERROR");
            }
        }
    }
}
