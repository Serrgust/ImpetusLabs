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

namespace ImpetusLabs.LabsScreen
{
    public partial class Lab02Screen : UserControl
    {
        OpcValue[] LabTests = new OpcValue[2];
        Label[] Lbl2Lab02 = new Label[2];
        OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        public Lab02Screen()
        {
            InitializeComponent();
            Lbl2Lab02[0] = Lbl2Lab02Test1;
            Lbl2Lab02[1] = Lbl2Lab02Test2;
        }

        private void TimerLab02_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void RefreshLabs()
        {
            client.Connect();
            LabTests[0] = client.ReadNode("ns=2;s=[GustavoDevice]LAB02.VAR[0]");
            LabTests[1] = client.ReadNode("ns=2;s=[GustavoDevice]LAB02.VAR[1]");

            for (int i = 0; i < LabTests.Length; i++)
            {
                if (LabTests[i].ToString().Equals("0"))
                {
                    Lbl2Lab02[i].BackColor = Color.Silver;
                    Lbl2Lab02[i].Text = "NOT RUN";
                }
                if (LabTests[i].ToString().Equals("1"))
                {
                    Lbl2Lab02[i].BackColor = Color.LightGreen;
                    Lbl2Lab02[i].Text = "PASSED";
                }
                if (LabTests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab02[i].BackColor = Color.Red;
                    Lbl2Lab02[i].Text = "FAILED";
                }
                client.Disconnect();
            }
        }

        private void BtnLab02Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT2";
            client.Connect();
            client.WriteNode(tagName, false);
            BtnLab02Start.Visible = true;
            BtnLab02Stop.Visible = false;
            client.Disconnect();
        }

        private void BtnLab02Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT2";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab02Start.Visible = false;
            BtnLab02Stop.Visible = true;
            client.Disconnect();
        }
    }
}
