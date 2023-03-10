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
using Xamarin.Forms.Internals;

namespace ImpetusLabs.LabsScreen
{//Jose was here :P
    public partial class Lab08Screen : UserControl
    {
        public OpcValue[] Lab08Tests = new OpcValue[4];
        private Label[] Lbl2Lab08 = new Label[4];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        public Lab08Screen()
        {
            InitializeComponent();
            /*            for (int i = 0; i < Lab08Tests.Length; i++)
                       {
                           Lbl2Lab08[i-1] = Lbl2Lab08Test[i];
                       }*/
            Lbl2Lab08[0] = Lbl2Lab08Test1;
            Lbl2Lab08[1] = Lbl2Lab08Test2;
            Lbl2Lab08[2] = Lbl2Lab08Test3;
            Lbl2Lab08[3] = Lbl2Lab08Test4;

            //Lab Display Label
            string currentlab = "Lab #8";

            LblCurrentLab.Text = currentlab;
            

        }
        private void RefreshLabs()
        {
           //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab08Tests.Length; i++)
            {
                Lab08Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab08.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab08Tests.Length; i++)
            {
                if (Lab08Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab08[i].BackColor = Color.Silver;
                    Lbl2Lab08[i].Text = "NOT RUN";
                }
                if (Lab08Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab08[i].BackColor = Color.LightGreen;
                    Lbl2Lab08[i].Text = "PASSED";
                }
                if (Lab08Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab08[i].BackColor = Color.Red;
                    Lbl2Lab08[i].Text = "FAILED";
                }
            }
        }

        private void BtnLab08Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT19";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab08Start.Visible = false;
            BtnLab08Stop.Visible = true;
            TimerLab08.Enabled = true;
        }

        private void BtnLab08Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT19";
            client.WriteNode(tagName, false);
            BtnLab08Start.Visible = true;
            BtnLab08Stop.Visible = false;
            TimerLab08.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab08_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}
