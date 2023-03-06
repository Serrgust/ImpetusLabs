using Opc.Ua;
using Opc.UaFx;
using Opc.UaFx.Client;
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
    public partial class Lab01Screen : UserControl
    {
        OpcValue[] LabTests = new OpcValue[6];
        Label[] Lbl2Lab01 = new Label[6];
        OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");

        public Lab01Screen()
        {
            InitializeComponent();
            Lbl2Lab01[0] = Lbl2Lab01Test1;
            Lbl2Lab01[1] = Lbl2Lab01Test2;
            Lbl2Lab01[2] = Lbl2Lab01Test3;
            Lbl2Lab01[3] = Lbl2Lab01Test4;
            Lbl2Lab01[4] = Lbl2Lab01Test5;
            Lbl2Lab01[5] = Lbl2Lab01Test6;
        }

        private void TimerLab01_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void RefreshLabs()
        {
            client.Connect();
            LabTests[0] = client.ReadNode("ns=2;s=[GustavoDevice]LAB01.VAR[0]");
            LabTests[1] = client.ReadNode("ns=2;s=[GustavoDevice]LAB01.VAR[1]"); 
            LabTests[2] = client.ReadNode("ns=2;s=[GustavoDevice]LAB01.VAR[2]");
            LabTests[3] = client.ReadNode("ns=2;s=[GustavoDevice]LAB01.VAR[3]");
            LabTests[4] = client.ReadNode("ns=2;s=[GustavoDevice]LAB01.VAR[4]");
            LabTests[5] = client.ReadNode("ns=2;s=[GustavoDevice]LAB01.VAR[5]");

            for (int i = 0; i < LabTests.Length; i++)
            {
                if (LabTests[i].ToString().Equals("0"))
                {
                    Lbl2Lab01[i].BackColor = Color.Silver;
                    Lbl2Lab01[i].Text = "NOT RUN";
                }
                if (LabTests[i].ToString().Equals("1"))
                {
                    Lbl2Lab01[i].BackColor = Color.LightGreen;
                    Lbl2Lab01[i].Text = "PASSED";
                }
                if (LabTests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab01[i].BackColor = Color.Red;
                    Lbl2Lab01[i].Text = "FAILED";
                }
            client.Disconnect();
            }
        }

        private void BtnLab01Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab01Start.Visible = false;
            BtnLab01Stop.Visible = true;
            client.Disconnect();
        }

        private void BtnLab01Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            client.Connect();
            client.WriteNode(tagName, false);
            BtnLab01Start.Visible = true;
            BtnLab01Stop.Visible = false;
            client.Disconnect();
        }
    }
}

