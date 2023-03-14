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
    public partial class Lab03Screen : UserControl
    {
        private OpcValue[] Lab03Tests = new OpcValue[3];
        private Label[] Lbl2Lab03 = new Label[3];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private OpcValue Lab03Timer;
        private OpcValue Lab03OutLight;

        public Lab03Screen()
        {
            InitializeComponent();
            Lbl2Lab03[0] = Lbl2Lab03Test1;
            Lbl2Lab03[1] = Lbl2Lab03Test2;
            Lbl2Lab03[2] = Lbl2Lab03Test3;

            //Lab Display Label
            string currentlab = "Lab #3";
            LblCurrentLab.Text = currentlab;
        }

        private void RefreshLabs()
        {
            Lab03Tests[0] = client.ReadNode("ns=2;s=[GustavoDevice]LAB03.VAR[0]");
            Lab03Tests[1] = client.ReadNode("ns=2;s=[GustavoDevice]LAB03.VAR[1]");
            Lab03Tests[2] = client.ReadNode("ns=2;s=[GustavoDevice]LAB03.VAR[2]");
            Lab03Timer = client.ReadNode("ns=2;s=[GustavoDevice]LAB03.TIMER1.ACC");
            Lab03OutLight = client.ReadNode("ns=2;s=[GustavoDevice]LAB03.LIGHT");

            for (int i = 0; i < Lab03Tests.Length; i++)
            {
                if (Lab03Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab03[i].BackColor = Color.Silver;
                    Lbl2Lab03[i].Text = "NOT RUN";
                }
                if (Lab03Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab03[i].BackColor = Color.LightGreen;
                    Lbl2Lab03[i].Text = "PASSED";
                }
                if (Lab03Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab03[i].BackColor = Color.Red;
                    Lbl2Lab03[i].Text = "FAILED";
                }
            }
            OutTimerTxtLab04.Text = Lab03Timer.ToString();
        }

        private void BtnLab03Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT3";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab03Start.Visible = false;
            BtnLab03Stop.Visible = true;
            TimerLab03.Enabled = true;
        }

        private void BtnLab03Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT3";
            client.WriteNode(tagName, false);
            BtnLab03Start.Visible = true;
            BtnLab03Stop.Visible = false;
            TimerLab03.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab03_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}
