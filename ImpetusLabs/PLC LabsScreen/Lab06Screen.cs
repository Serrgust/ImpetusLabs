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
using static ImpetusLabs.Forms.SelectServerForm;

namespace ImpetusLabs.LabsScreen
{
    public partial class Lab06Screen : UserControl
    {
        public OpcValue[] Lab06Tests = new OpcValue[10];
        private Label[] Lbl2Lab06 = new Label[10];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private OpcValue OutTimerLab06;
        public Lab06Screen()
        {
            InitializeComponent();
/*            for (int i = 0; i < Lab06Tests.Length; i++)
            {
                Lbl2Lab06[i-1] = Lbl2Lab06Test[i];
            }*/
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

            //Lab Display Label
            string currentlab = "Lab #6";
            LblCurrentLab.Text = currentlab;
        }
        private void RefreshLabs()
        {
            for (int i = 0; i < Lab06Tests.Length; i++)
            {
                Lab06Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR["+i+"]");
            }
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
