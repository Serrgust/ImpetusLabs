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
    public partial class Lab17Screen : UserControl
    {
        private OpcValue[] Lab17Tests = new OpcValue[6];
        private Label[] Lbl2Lab17 = new Label[6];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        public Lab17Screen()
        {
            InitializeComponent();

            Lbl2Lab17[0] = Lbl2Lab17Test1;
            Lbl2Lab17[1] = Lbl2Lab17Test2;
            Lbl2Lab17[2] = Lbl2Lab17Test3;
            Lbl2Lab17[3] = Lbl2Lab17Test4;
            Lbl2Lab17[4] = Lbl2Lab17Test5;
            Lbl2Lab17[5] = Lbl2Lab17Test6;

            string currentlab = "Lab #17";
            LblCurrentLab.Text = currentlab;
        }

        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab17Tests.Length; i++)
            {
                Lab17Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab17.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab17Tests.Length; i++)
            {
                if (Lab17Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab17[i].BackColor = Color.Silver;
                    Lbl2Lab17[i].Text = "NOT RUN";
                }
                if (Lab17Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab17[i].BackColor = Color.LightGreen;
                    Lbl2Lab17[i].Text = "PASSED";
                }
                if (Lab17Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab17[i].BackColor = Color.Red;
                    Lbl2Lab17[i].Text = "FAILED";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT16";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab17Start.Visible = false;
            BtnLab17Stop.Visible = true;
            TimerLab17.Enabled = true;
        }

        private void BtnLab17Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT16";
            client.WriteNode(tagName, false);
            BtnLab17Start.Visible = true;
            BtnLab17Stop.Visible = false;
            TimerLab17.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab17_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}
