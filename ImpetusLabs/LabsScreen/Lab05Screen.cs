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
    public partial class Lab05Screen : UserControl
    {
        private OpcValue[] Lab05Tests = new OpcValue[4];
        private Label[] Lbl2Lab05 = new Label[4];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private OpcValue Lab05Counter;
        public Lab05Screen()
        {
            InitializeComponent();
            Lbl2Lab05[0] = Lbl2Lab05Test1;
            Lbl2Lab05[1] = Lbl2Lab05Test2;
            Lbl2Lab05[2] = Lbl2Lab05Test3;
            Lbl2Lab05[3] = Lbl2Lab05Test4;

        }
        private void RefreshLabs()
        {
            Lab05Tests[0] = client.ReadNode("ns=2;s=[GustavoDevice]LAB05.VAR[0]");
            Lab05Tests[1] = client.ReadNode("ns=2;s=[GustavoDevice]LAB05.VAR[1]");
            Lab05Tests[2] = client.ReadNode("ns=2;s=[GustavoDevice]LAB05.VAR[2]");
            Lab05Tests[3] = client.ReadNode("ns=2;s=[GustavoDevice]LAB05.VAR[3]");
            Lab05Counter = client.ReadNode("ns=2;s=[GustavoDevice]LAB05.COUNTER1.ACC");

            for (int i = 0; i < Lab05Tests.Length; i++)
            {
                if (Lab05Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab05[i].BackColor = Color.Silver;
                    Lbl2Lab05[i].Text = "NOT RUN";
                }
                if (Lab05Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab05[i].BackColor = Color.LightGreen;
                    Lbl2Lab05[i].Text = "PASSED";
                }
                if (Lab05Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab05[i].BackColor = Color.Red;
                    Lbl2Lab05[i].Text = "FAILED";
                }
            }
            OutCtrLab05.Text = Lab05Counter.ToString();
        }

        private void BtnLab05Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT5";
            client.WriteNode(tagName, false);
            BtnLab05Start.Visible = true;
            BtnLab05Stop.Visible = false;
            TimerLab05.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab05_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab05Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT5";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab05Start.Visible = false;
            BtnLab05Stop.Visible = true;
            TimerLab05.Enabled = true;
        }
    }
}
