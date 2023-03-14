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
    public partial class Lab04Screen : UserControl
    {
        private OpcValue[] Lab04Tests = new OpcValue[8];
        private Label[] Lbl2Lab04 = new Label[8];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        public Lab04Screen()
        {
            InitializeComponent();
            Lbl2Lab04[0] = Lbl2Lab04Test1;
            Lbl2Lab04[1] = Lbl2Lab04Test2;
            Lbl2Lab04[2] = Lbl2Lab04Test3;
            Lbl2Lab04[3] = Lbl2Lab04Test4;
            Lbl2Lab04[4] = Lbl2Lab04Test5;
            Lbl2Lab04[5] = Lbl2Lab04Test6;
            Lbl2Lab04[6] = Lbl2Lab04Test7;

            //Lab Display Label
            string currentlab = "Lab #4";
            LblCurrentLab.Text = currentlab;

        }

        private void RefreshLabs()
        {
            Lab04Tests[0] = client.ReadNode("ns=2;s=[GustavoDevice]LAB04.VAR[0]");
            Lab04Tests[1] = client.ReadNode("ns=2;s=[GustavoDevice]LAB04.VAR[1]");
            Lab04Tests[2] = client.ReadNode("ns=2;s=[GustavoDevice]LAB04.VAR[2]");
            Lab04Tests[3] = client.ReadNode("ns=2;s=[GustavoDevice]LAB04.VAR[3]");
            Lab04Tests[4] = client.ReadNode("ns=2;s=[GustavoDevice]LAB04.VAR[4]");
            Lab04Tests[5] = client.ReadNode("ns=2;s=[GustavoDevice]LAB04.VAR[5]");
            Lab04Tests[6] = client.ReadNode("ns=2;s=[GustavoDevice]LAB04.VAR[6]");
            Lab04Tests[7] = client.ReadNode("ns=2;s=[GustavoDevice]LAB04.VAR[7]");

            for (int i = 0; i < Lab04Tests.Length; i++)
            {
                if (Lab04Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab04[i].BackColor = Color.Silver;
                    Lbl2Lab04[i].Text = "NOT RUN";
                }
                if (Lab04Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab04[i].BackColor = Color.LightGreen;
                    Lbl2Lab04[i].Text = "PASSED";
                }
                if (Lab04Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab04[i].BackColor = Color.Red;
                    Lbl2Lab04[i].Text = "FAILED";
                }
            }

        }

        private void BtnLab04Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT4";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab04Start.Visible = false;
            BtnLab04Stop.Visible = true;
            TimerLab04.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void BtnLab04Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT4";
            client.WriteNode(tagName, false);
            BtnLab04Start.Visible = true;
            BtnLab04Stop.Visible = false;
            TimerLab04.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab04_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}
