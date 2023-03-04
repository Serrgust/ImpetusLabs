using Opc.Ua;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpetusLabs
{
    public partial class Lab01Screen : UserControl
    {
        Node[] LabTests = new Node[5];
        Label[] Lbl2Lab01 = new Label[5];

        public Lab01Screen()
        {
            Lbl2Lab01[0] = Lbl2Lab01Test1;
            Lbl2Lab01[1] = Lbl2Lab01Test2;
            Lbl2Lab01[2] = Lbl2Lab01Test3;
            Lbl2Lab01[3] = Lbl2Lab01Test4;
            Lbl2Lab01[4] = Lbl2Lab01Test5;
            Lbl2Lab01[5] = Lbl2Lab01Test6;
            InitializeComponent();
        }

        private void TimerLab01_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void RefreshLabs()
        {
            //string opcUrl = "opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1";
            var var1 = "ns=2;s=[GustavoDevice]LAB01.VAR[0]";
            var var2 = "ns=2;s=[GustavoDevice]LAB01.VAR[1]";
            var var3 = "ns=2;s=[GustavoDevice]LAB01.VAR[2]";
            var var4 = "ns=2;s=[GustavoDevice]LAB01.VAR[3]";
            var var5 = "ns=2;s=[GustavoDevice]LAB01.VAR[4]";
            var var6 = "ns=2;s=[GustavoDevice]LAB01.VAR[5]";

            var client = new OpcClient(opcUrl);

            LabTests[0] = client.ReadNode(var1);
            LabTests[1] = client.ReadNode(var2);
            LabTests[2] = client.ReadNode(var3);
            LabTests[3] = client.ReadNode(var4);
            LabTests[4] = client.ReadNode(var5);
            LabTests[5] = client.ReadNode(var6);

            for (int i = 0; i < 5; i++)
            {
                if (LabTests[i].ToString().Equals("0"))
                {
                    Lbl2Lab01[i].BackColor = Color.Silver;
                    Lbl2Lab01[i].Text = "NOT RUN";
                }
                if (LabTests[i].ToString().Equals("1"))
                {
                    Lbl2Lab01[i].BackColor = Color.Green;
                    Lbl2Lab01[i].Text = "PASSED";
                }
                if (LabTests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab01[i].BackColor = Color.Red;
                    Lbl2Lab01[i].Text = "FAILED";
                }
            client.Disconnect();
            }
        }
    }
}

