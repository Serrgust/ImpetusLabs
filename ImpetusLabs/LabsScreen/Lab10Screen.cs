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
    public partial class Lab10Screen : UserControl
    {
        public OpcValue[] Lab10Tests = new OpcValue[8];
        private Label[] Lbl2Lab10 = new Label[8];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");

        public Lab10Screen()
        {
            InitializeComponent();

            Lbl2Lab10[0] = Lbl2Lab10Test1;
            Lbl2Lab10[1] = Lbl2Lab10Test2;
            Lbl2Lab10[2] = Lbl2Lab10Test3;
            Lbl2Lab10[3] = Lbl2Lab10Test4;
            Lbl2Lab10[4] = Lbl2Lab10Test5;
            Lbl2Lab10[5] = Lbl2Lab10Test6;
            Lbl2Lab10[6] = Lbl2Lab10Test7;
            Lbl2Lab10[7] = Lbl2Lab10Test8;

            //Lab Display Label
            string currentlab = "Lab #10";
            LblDisplayLab.Text = currentlab;
        }






        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab10Tests.Length; i++)
            {
                Lab10Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab10.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab10Tests.Length; i++)
            {
                if (Lab10Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab10[i].BackColor = Color.Silver;
                    Lbl2Lab10[i].Text = "NOT RUN";
                }
                if (Lab10Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab10[i].BackColor = Color.LightGreen;
                    Lbl2Lab10[i].Text = "PASSED";
                }
                if (Lab10Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab10[i].BackColor = Color.Red;
                    Lbl2Lab10[i].Text = "FAILED";
                }
            }
        }

        private void BtnLab10Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT9";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab10Start.Visible = false;
            BtnLab10Stop.Visible = true;
            TimerLab10.Enabled = true;
        }

        private void BtnLab10Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT9";
            client.Connect();
            client.WriteNode(tagName, false);
            BtnLab10Start.Visible = true;
            BtnLab10Stop.Visible = true;
            TimerLab10.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab10_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}
