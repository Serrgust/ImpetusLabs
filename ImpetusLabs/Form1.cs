using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.UaFx.Client;

namespace ImpetusLabs
{
    public partial class Form1 : Form
    {
        OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        
        public Form1()
        {
            InitializeComponent();
            BtnLab01Stop.Visible = false;
            Lbl2Lab01Test1.BackColor = Color.Silver;
        }

        private void btnOpcWrite_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fuck The Police");

            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";

            client.Connect();

            string temperature;
            
            //temperature = Convert.ToString(txtOpcDataWrite.Text);

            //client.WriteNode(tagName, temperature);
            client.Disconnect();
            
        }

        private void btnOpcRead_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fuck The Police");
            //string opcUrl = "opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1";
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            //var client = new OpcClient(opcUrl);
            client.Connect();
            var temperature = client.ReadNode(tagName);

            //txtOpcDataRead.Text = temperature.ToString();
        }

        private void BtnLab01Start_Click_1(object sender, EventArgs e)
        {
            //string opcUrl = "opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1";
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            //var client = new OpcClient(opcUrl);
            client.Connect();

            client.WriteNode(tagName, true);
            BtnLab01Start.Visible = false;
            BtnLab01Stop.Visible = true;

            client.Disconnect();
        }

        private void BtnLab01Stop_Click(object sender, EventArgs e)
        {
            //string opcUrl = "opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1";
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            //var client = new OpcClient(opcUrl);
            client.Connect();

            client.WriteNode(tagName, false);
            BtnLab01Start.Visible = true;
            BtnLab01Stop.Visible = false;
            client.Disconnect();
        }

        public void Lbl2Lab01Test1_Click(object sender, EventArgs e)
        {

            //string opcUrl = "opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1";
            var tagName = "ns=2;s=[GustavoDevice]LAB01.VAR[1]";
            //var client = new OpcClient(opcUrl);
            client.Connect();
            var Lab01Test1 = client.ReadNode(tagName);
            if (Lab01Test1.Equals(1))
            {
                LblLab01Test1.BackColor = Color.Green;
            }
            if (Lab01Test1.Equals(-1))
            {
                LblLab01Test1.BackColor = Color.Red;
            }
            client.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string opcUrl = "opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1";
            var tagName = "ns=2;s=[GustavoDevice]LAB01.VAR[2]";
            //var client = new OpcClient(opcUrl);
            client.Connect();
            var Lab01Test1 = client.ReadNode(tagName);
            if (Lab01Test1.ToString().Equals("1"))
            {
                Lbl2Lab01Test1.BackColor = Color.Green;
                Lbl2Lab01Test1.Text = "PASSED";
            }
            if (Lab01Test1.ToString().Equals("-1"))
            {
                Lbl2Lab01Test1.BackColor = Color.Red;
                Lbl2Lab01Test1.Text = "FAILED";
            }
            client.Disconnect();
        }
    }
}
