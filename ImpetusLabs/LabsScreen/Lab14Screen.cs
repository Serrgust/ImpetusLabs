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
    public partial class Lab14Screen : UserControl
    {
        private OpcValue[] Lab14Tests = new OpcValue[8];
        private Label[] Lbl2Lab14 = new Label[8];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        public Lab14Screen()
        {
            InitializeComponent();

            Lbl2Lab14[0] = Lbl2Lab14Test1;
            Lbl2Lab14[1] = Lbl2Lab14Test2;
            Lbl2Lab14[2] = Lbl2Lab14Test3;
            Lbl2Lab14[3] = Lbl2Lab14Test4;
            Lbl2Lab14[4] = Lbl2Lab14Test5;
            Lbl2Lab14[5] = Lbl2Lab14Test6;
            Lbl2Lab14[6] = Lbl2Lab14Test7;
            Lbl2Lab14[7] = Lbl2Lab14Test8;

            //Label that displays current lab
             string currentlab = "Lab #14";
            LblCurrentLab.Text = currentlab;

        }

        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab14Tests.Length; i++)
            {
                Lab14Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab14.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab14Tests.Length; i++)
            {
                if (Lab14Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab14[i].BackColor = Color.Silver;
                    Lbl2Lab14[i].Text = "NOT RUN";
                }
                if (Lab14Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab14[i].BackColor = Color.LightGreen;
                    Lbl2Lab14[i].Text = "PASSED";
                }
                if (Lab14Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab14[i].BackColor = Color.Red;
                    Lbl2Lab14[i].Text = "FAILED";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT13";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab14Start.Visible = false;
            BtnLab14Stop.Visible = true;
            TimerLab14.Enabled = true;
        }

        private void BtnLab14Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT13";
            client.WriteNode(tagName, false);
            BtnLab14Start.Visible = true;
            BtnLab14Stop.Visible = false;
            TimerLab14.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab14_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}
