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
    public partial class Lab15Screen : UserControl
    {
        private OpcValue[] Lab15Tests = new OpcValue[4];
        private Label[] Lbl2Lab15 = new Label[4];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        public Lab15Screen()
        {
            InitializeComponent();


            Lbl2Lab15[0] = Lbl2Lab15Test1;
            Lbl2Lab15[1] = Lbl2Lab15Test2;
            Lbl2Lab15[2] = Lbl2Lab15Test3;
            Lbl2Lab15[3] = Lbl2Lab15Test4;

            string currentlab = "Lab #15";
            LblCurrent.Text = currentlab;
        }

        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab15Tests.Length; i++)
            {
                Lab15Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab15.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab15Tests.Length; i++)
            {
                if (Lab15Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab15[i].BackColor = Color.Silver;
                    Lbl2Lab15[i].Text = "NOT RUN";
                }
                if (Lab15Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab15[i].BackColor = Color.LightGreen;
                    Lbl2Lab15[i].Text = "PASSED";
                }
                if (Lab15Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab15[i].BackColor = Color.Red;
                    Lbl2Lab15[i].Text = "FAILED";
                }
            }
        }

        private void BtnLab15Start_Click(object sender, EventArgs e)
        {

            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT14";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab15Start.Visible = false;
            BtnLab15Stop.Visible = true;
            TimerLab15.Enabled = true;
        }

        private void BtnLab15Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT14";
            client.WriteNode(tagName, false);
            BtnLab15Start.Visible = true;
            BtnLab15Stop.Visible = false;
            TimerLab15.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab15_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}

