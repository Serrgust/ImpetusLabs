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
    public partial class Lab12Screen : UserControl
    {
        private OpcValue[] Lab12Tests = new OpcValue[3];
        private Label[] Lbl2Lab12 = new Label[3];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        public Lab12Screen()
        {
            InitializeComponent();

            Lbl2Lab12[0] = Lbl2Lab12Test1;
            Lbl2Lab12[1] = Lbl2Lab12Test2;
            Lbl2Lab12[2] = Lbl2Lab12Test3;

            string currentlab = "Lab #12";
            LblCurrentLab.Text = currentlab;
        }

        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab12Tests.Length; i++)
            {
                Lab12Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab12.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab12Tests.Length; i++)
            {
                if (Lab12Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab12[i].BackColor = Color.Silver;
                    Lbl2Lab12[i].Text = "NOT RUN";
                }
                if (Lab12Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab12[i].BackColor = Color.LightGreen;
                    Lbl2Lab12[i].Text = "PASSED";
                }
                if (Lab12Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab12[i].BackColor = Color.Red;
                    Lbl2Lab12[i].Text = "FAILED";
                }
            }
        }

        private void BtnLab12Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT11";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab12Start.Visible = false;
            BtnLab12Stop.Visible = true;
            TimerLab12.Enabled = true;
        }

        private void BtnLab12Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT11";
            client.WriteNode(tagName, false);
            BtnLab12Start.Visible = true;
            BtnLab12Stop.Visible = false;
            TimerLab12.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab12_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}
