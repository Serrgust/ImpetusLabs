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
    public partial class Lab06Screen : UserControl
    {
        private OpcValue[] Lab06Tests = new OpcValue[11];
        private Label[] Lbl2Lab06 = new Label[12];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private OpcValue OutTimerLab06;
        public Lab06Screen()
        {
            InitializeComponent();
            Lbl2Lab06[0] = Lbl2Lab06Test1;
            Lbl2Lab06[1] = Lbl2Lab06Test2;
            Lbl2Lab06[2] = Lbl2Lab06Test3;
            Lbl2Lab06[3] = Lbl2Lab06Test4;
            Lbl2Lab06[4] = Lbl2Lab06Test5;
            Lbl2Lab06[5] = Lbl2Lab06Test6;
            Lbl2Lab06[6] = Lbl2Lab06Test7;
            Lbl2Lab06[7] = Lbl2Lab06Test8;
            Lbl2Lab06[8] = Lbl2Lab06Test9;
            Lbl2Lab06[9] = Lbl2Lab06Test10;
        }
        private void RefreshLabs()
        {
            Lab06Tests[0] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR[0]");
            Lab06Tests[1] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR[1]");
            Lab06Tests[2] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR[2]");
            Lab06Tests[3] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR[3]");
            Lab06Tests[4] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR[4]");
            Lab06Tests[5] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR[5]");
            Lab06Tests[6] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR[6]");
            Lab06Tests[7] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR[7]");
            Lab06Tests[8] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR[8]");
            Lab06Tests[9] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR[9]");
            Lab06Tests[10] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR[10]");
            OutTimerLab06 = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.TIMER1.ACC");

            for (int i = 0; i < Lab06Tests.Length; i++)
            {
                if (Lab06Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab06[i].BackColor = Color.Silver;
                    Lbl2Lab06[i].Text = "NOT RUN";
                }
                if (Lab06Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab06[i].BackColor = Color.LightGreen;
                    Lbl2Lab06[i].Text = "PASSED";
                }
                if (Lab06Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab06[i].BackColor = Color.Red;
                    Lbl2Lab06[i].Text = "FAILED";
                }
            }
            LblTimerAccLab06.Text = OutTimerLab06.ToString();
        }

        private void BtnLab06Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT6";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab06Start.Visible = false;
            BtnLab06Stop.Visible = true;
            TimerLab06.Enabled = true;
        }

        private void BtnLab06Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT6";
            client.WriteNode(tagName, false);
            BtnLab06Start.Visible = true;
            BtnLab06Stop.Visible = false;
            TimerLab06.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab06_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}
