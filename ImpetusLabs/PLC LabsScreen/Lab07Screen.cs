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
    public partial class Lab07Screen : UserControl
    {
        public OpcValue[] Lab07Tests = new OpcValue[17];
        private Label[] Lbl2Lab07 = new Label[17];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        
        public Lab07Screen()
        {
            InitializeComponent();
            /*            for (int i = 0; i < Lab07Tests.Length; i++)
                        {
                            Lbl2Lab07[i-1] = Lbl2Lab07Test[i];
                        }*/
            Lbl2Lab07[0] = Lbl2Lab07Test1;
            Lbl2Lab07[1] = Lbl2Lab07Test2;
            Lbl2Lab07[2] = Lbl2Lab07Test3;
            Lbl2Lab07[3] = Lbl2Lab07Test4;
            Lbl2Lab07[4] = Lbl2Lab07Test5;
            Lbl2Lab07[5] = Lbl2Lab07Test6;
            Lbl2Lab07[6] = Lbl2Lab07Test7;
            Lbl2Lab07[7] = Lbl2Lab07Test8;
            Lbl2Lab07[8] = Lbl2Lab07Test9;
            Lbl2Lab07[9] = Lbl2Lab07Test10;
            Lbl2Lab07[10] = Lbl2Lab07Test11;
            Lbl2Lab07[11] = Lbl2Lab07Test12;
            Lbl2Lab07[12] = Lbl2Lab07Test13;
            Lbl2Lab07[13] = Lbl2Lab07Test14;
            Lbl2Lab07[14] = Lbl2Lab07Test15;
            Lbl2Lab07[15] = Lbl2Lab07Test16;
            Lbl2Lab07[16] = Lbl2Lab07Test17;

            //Lab Display Label
            string currentlab = "Lab #7";
            LblCurrentLab.Text = currentlab;
        }
        private void RefreshLabs()
        {
            for (int i = 0; i < Lab07Tests.Length; i++)
            {
                Lab07Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]LAB07.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab07Tests.Length; i++)
            {
                if (Lab07Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab07[i].BackColor = Color.Silver;
                    Lbl2Lab07[i].Text = "NOT RUN";
                }
                if (Lab07Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab07[i].BackColor = Color.LightGreen;
                    Lbl2Lab07[i].Text = "PASSED";
                }
                if (Lab07Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab07[i].BackColor = Color.Red;
                    Lbl2Lab07[i].Text = "FAILED";
                }
            }
        }

        private void BtnLab07Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT7";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab07Start.Visible = false;
            BtnLab07Stop.Visible = true;
            TimerLab07.Enabled = true;
        }

        private void BtnLab07Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT7";
            client.WriteNode(tagName, false);
            BtnLab07Start.Visible = true;
            BtnLab07Stop.Visible = false;
            TimerLab07.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab07_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}
