using Opc.UaFx.Client;
using Opc.UaFx;
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
    public partial class Lab16Screen : UserControl
    {
        private OpcValue[] Lab16Tests = new OpcValue[6];
        private Label[] Lbl2Lab16 = new Label[6];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        public Lab16Screen()
        {
            InitializeComponent();
            Lbl2Lab16[0] = Lbl2Lab16Test1;
            Lbl2Lab16[1] = Lbl2Lab16Test2;
            Lbl2Lab16[2] = Lbl2Lab16Test3;
            Lbl2Lab16[3] = Lbl2Lab16Test4;
            Lbl2Lab16[4] = Lbl2Lab16Test5;
            Lbl2Lab16[5] = Lbl2Lab16Test6;

            string currentlab = "Lab #16";
            lblCurrentLab.Text = currentlab;
        }

        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab16Tests.Length; i++)
            {
                Lab16Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab16.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab16Tests.Length; i++)
            {
                if (Lab16Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab16[i].BackColor = Color.Silver;
                    Lbl2Lab16[i].Text = "NOT RUN";
                }
                if (Lab16Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab16[i].BackColor = Color.LightGreen;
                    Lbl2Lab16[i].Text = "PASSED";
                }
                if (Lab16Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab16[i].BackColor = Color.Red;
                    Lbl2Lab16[i].Text = "FAILED";
                }
            }
        }

        private void BtnLab16Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT15";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab16Start.Visible = false;
            BtnLab16Stop.Visible = true;
            TimerLab16.Enabled = true;
        }

        private void BtnLab16Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT15";
            client.WriteNode(tagName, false);
            BtnLab16Start.Visible = true;
            BtnLab16Stop.Visible = false;
            TimerLab16.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab16_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}