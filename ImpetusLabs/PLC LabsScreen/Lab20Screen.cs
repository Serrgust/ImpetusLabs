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
    public partial class Lab20Screen : UserControl
    {
        private OpcValue[] Lab20Tests = new OpcValue[20];
        private Label[] Lbl2Lab20 = new Label[20];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");

        public Lab20Screen()
        {
            InitializeComponent();

            Lbl2Lab20[0] = Lbl2Lab20Test1;
            Lbl2Lab20[1] = Lbl2Lab20Test2;
            Lbl2Lab20[2] = Lbl2Lab20Test3;
            Lbl2Lab20[3] = Lbl2Lab20Test4;
            Lbl2Lab20[4] = Lbl2Lab20Test5;
            Lbl2Lab20[5] = Lbl2Lab20Test6;
            Lbl2Lab20[6] = Lbl2Lab20Test7;
            Lbl2Lab20[7] = Lbl2Lab20Test8;
            Lbl2Lab20[8] = Lbl2Lab20Test9;
            Lbl2Lab20[9] = Lbl2Lab20Test10;
            Lbl2Lab20[10] = Lbl2Lab20Test11;
            Lbl2Lab20[11] = Lbl2Lab20Test12;
            Lbl2Lab20[12] = Lbl2Lab20Test13;
            Lbl2Lab20[13] = Lbl2Lab20Test14;
            Lbl2Lab20[14] = Lbl2Lab20Test15;
            Lbl2Lab20[15] = Lbl2Lab20Test16;
            Lbl2Lab20[16] = Lbl2Lab20Test17;
            Lbl2Lab20[17] = Lbl2Lab20Test18;
            Lbl2Lab20[18] = Lbl2Lab20Test19;
            Lbl2Lab20[19] = Lbl2Lab20Test20;



            string currentlab = "Lab #20";
            LblCurrentLab.Text = currentlab;

        }

        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab20Tests.Length; i++)
            {
                Lab20Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab20.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab20Tests.Length; i++)
            {
                if (Lab20Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab20[i].BackColor = Color.Silver;
                    Lbl2Lab20[i].Text = "NOT RUN";
                }
                if (Lab20Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab20[i].BackColor = Color.DarkGreen;
                    Lbl2Lab20[i].Text = "PASSED";
                }
                if (Lab20Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab20[i].BackColor = Color.Red;
                    Lbl2Lab20[i].Text = "FAILED";
                }
            }
        }


        private void TimerLab20_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab20Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT20";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab20Start.Visible = false;
            BtnLab20Stop.Visible = true;
            TimerLab20.Enabled = true;
        }

        private void BtnLab20Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT20";
            client.WriteNode(tagName, false);
            BtnLab20Start.Visible = true;
            BtnLab20Stop.Visible = false;
            TimerLab20.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab20_Tick_1(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackTolab19 = new Lab19Screen();
            Parent.Controls.Add(BackTolab19);
            BackTolab19.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab01Screen();
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this);
            secondUserControl.Dock = DockStyle.Fill;
        }
    }
}