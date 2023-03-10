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
    
    public partial class Lab11Screen : UserControl
    {
        public OpcValue[] Lab11Tests = new OpcValue[5];
        private Label[] Lbl2Lab11 = new Label[5];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        public Lab11Screen()
        {
            InitializeComponent();

            Lbl2Lab11[0] = Lbl2Lab11Test1;
            Lbl2Lab11[1] = Lbl2Lab11Test2;
            Lbl2Lab11[2] = Lbl2Lab11Test3;
            Lbl2Lab11[3] = Lbl2Lab11Test4;
            Lbl2Lab11[4] = Lbl2Lab11Test5;

            string currentlab = "Lab #11";
            LblCurrentLab.Text = currentlab;    
         
        }
        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab11Tests.Length; i++)
            {
                Lab11Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab11.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab11Tests.Length; i++)
            {
                if (Lab11Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab11[i].BackColor = Color.Silver;
                    Lbl2Lab11[i].Text = "NOT RUN";
                }
                if (Lab11Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab11[i].BackColor = Color.LightGreen;
                    Lbl2Lab11[i].Text = "PASSED";
                }
                if (Lab11Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab11[i].BackColor = Color.Red;
                    Lbl2Lab11[i].Text = "FAILED";
                }
            }
        }

        private void BtnLab11Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT10";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab11Start.Visible = false;
            BtnLab11Stop.Visible = true;
            TimerLab11.Enabled = true;
        }

        private void BtnLab11Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT10";
            client.WriteNode(tagName, false);
            BtnLab11Start.Visible = true;
            BtnLab11Stop.Visible = false;
            TimerLab11.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab11_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}
