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
    public partial class Lab13Screen : UserControl
    {
        private OpcValue[] Lab13Tests = new OpcValue[7];
        private Label[] Lbl2Lab13 = new Label[7];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        public Lab13Screen()
        {
            InitializeComponent();

            Lbl2Lab13[0] = Lbl2Lab13Test1;
            Lbl2Lab13[1] = Lbl2Lab13Test2;
            Lbl2Lab13[2] = Lbl2Lab13Test3;
            Lbl2Lab13[3] = Lbl2Lab13Test4;
            Lbl2Lab13[4] = Lbl2Lab13Test5;
            Lbl2Lab13[5] = Lbl2Lab13Test6;
            Lbl2Lab13[6] = Lbl2Lab13Test7;

            
            string currentlab = "Lab #13";
            LblCurrentLab.Text = currentlab;

        }

        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab13Tests.Length; i++)
            {
                Lab13Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab13.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab13Tests.Length; i++)
            {
                if (Lab13Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab13[i].BackColor = Color.Silver;
                    Lbl2Lab13[i].Text = "NOT RUN";
                }
                if (Lab13Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab13[i].BackColor = Color.LightGreen;
                    Lbl2Lab13[i].Text = "PASSED";
                }
                if (Lab13Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab13[i].BackColor = Color.Red;
                    Lbl2Lab13[i].Text = "FAILED";
                }
            }
        }

        private void BtnLab13Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT12";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab13Start.Visible = false;
            BtnLab13Stop.Visible = true;
            TimerLab13.Enabled = true;
        }

        private void BtnLab13Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT12";
            client.WriteNode(tagName, false);
            BtnLab13Start.Visible = true;
            BtnLab13Stop.Visible = false;
            TimerLab13.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab13_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}
