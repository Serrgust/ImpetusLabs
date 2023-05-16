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
    public partial class Lab19Screen : UserControl
    {
        private OpcValue[] Lab19Tests = new OpcValue[4];
        private Label[] Lbl2Lab19 = new Label[4];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab17NodeIds = new string[7] { "ns=2;s=[GustavoDevice]LAB19.START", "ns=2;s=[GustavoDevice]LAB19.STOP", "ns=2;s=[GustavoDevice]LAB19.OBJECT_SENSOR", "ns=2;s=[GustavoDevice]LAB19.BOX_SENSOR", "ns=2;s=[GustavoDevice]LAB19.M1", "ns=2;s=[GustavoDevice]LAB19.M2", "ns=2;s=[GustavoDevice]LAB19.ACC" };
        private OpcValue[] Lab17Nodes = new OpcValue[7];
        public Lab19Screen()
        {
            InitializeComponent();

            Lbl2Lab19[0] = Lbl2Lab19Test1;
            Lbl2Lab19[1] = Lbl2Lab19Test2;
            Lbl2Lab19[2] = Lbl2Lab19Test3;
            Lbl2Lab19[3] = Lbl2Lab19Test4;

         
        }

        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab19Tests.Length; i++)
            {
                Lab19Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab19.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab19Tests.Length; i++)
            {
                if (Lab19Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab19[i].BackColor = Color.Silver;
                    Lbl2Lab19[i].Text = "NOT RUN";
                }
                if (Lab19Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab19[i].BackColor = Color.LightGreen;
                    Lbl2Lab19[i].Text = "PASSED";
                }
                if (Lab19Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab19[i].BackColor = Color.Red;
                    Lbl2Lab19[i].Text = "FAILED";
                }
            }
        }

        private void BtnLab19Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT18";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab19Start.Visible = false;
            BtnLab19Stop.Visible = true;
            TimerLab19.Enabled = true;
        }

        private void BtnLab19Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT18";
            client.WriteNode(tagName, false);
            BtnLab19Start.Visible = true;
            BtnLab19Stop.Visible = false;
            TimerLab19.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab19_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}