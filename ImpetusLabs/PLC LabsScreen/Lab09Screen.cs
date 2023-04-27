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
//Jose was here
namespace ImpetusLabs.LabsScreen
{
    public partial class Lab09Screen : UserControl
    {
        public OpcValue[] Lab09Tests = new OpcValue[5];
        private Label[] Lbl2Lab09 = new Label[5];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");

        public Lab09Screen()
        {
            InitializeComponent();

            Lbl2Lab09[0] = Lbl2Lab09Test1;
            Lbl2Lab09[1] = Lbl2Lab09Test2;
            Lbl2Lab09[2] = Lbl2Lab09Test3;
            Lbl2Lab09[3] = Lbl2Lab09Test4;
            Lbl2Lab09[4] = Lbl2Lab09Test5;


            //Lab Display Label
            string currentlab = "Lab #9";

            LblCurrentLab.Text = currentlab;

        }


        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab09Tests.Length; i++)
            {
                Lab09Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab09.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab09Tests.Length; i++)
            {
                if (Lab09Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab09[i].BackColor = Color.Silver;
                    Lbl2Lab09[i].Text = "NOT RUN";
                }
                if (Lab09Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab09[i].BackColor = Color.LightGreen;
                    Lbl2Lab09[i].Text = "PASSED";
                }
                if (Lab09Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab09[i].BackColor = Color.Red;
                    Lbl2Lab09[i].Text = "FAILED";
                }
            }
        }

        private void BtnLab09Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT8";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab09Start.Visible = false;
            BtnLab09Stop.Visible = true;
            TimerLab09.Enabled = true;
        }

        private void TimerLab09_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab09Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT8";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab09Start.Visible = false;
            BtnLab09Stop.Visible = true;
            TimerLab09.Enabled = true;
        }

        private void Lab09Screen_Load(object sender, EventArgs e)
        {

        }
    }
