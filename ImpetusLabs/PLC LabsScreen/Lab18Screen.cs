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
    public partial class Lab18Screen : UserControl
    {
        private OpcValue[] Lab18Tests = new OpcValue[7];
        private Label[] Lbl2Lab18 = new Label[7];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab18NodeIds = new string[10] { "ns=2;s=[GustavoDevice]LAB18.START", "ns=2;s=[GustavoDevice]LAB18.STOP", "ns=2;s=[GustavoDevice]LAB18.", "ns=2;s=[GustavoDevice]LAB17.CONVEYOR", "ns=2;s=[GustavoDevice]LAB17.CLIP_HOLD", "ns=2;s=[GustavoDevice]LAB17.CLIP_RELEASE", "ns=2;s=[GustavoDevice]LAB17.MOTOR_FORWARD", "ns=2;s=[GustavoDevice]LAB17.MOTOR_REVERSE", "ns=2;s=[GustavoDevice]LAB17.WATER", "ns=2;s=[GustavoDevice]LAB17.CYLINDER" };
        private OpcValue[] Lab18Nodes = new OpcValue[10];
        public Lab18Screen()
        {
            InitializeComponent();

            Lbl2Lab18[0] = Lbl2Lab18Test1;
            Lbl2Lab18[1] = Lbl2Lab18Test2;
            Lbl2Lab18[2] = Lbl2Lab18Test3;
            Lbl2Lab18[3] = Lbl2Lab18Test4;
            Lbl2Lab18[4] = Lbl2Lab18Test5;
            Lbl2Lab18[5] = Lbl2Lab18Test6;
            Lbl2Lab18[6] = Lbl2Lab18Test7;

            string currenlab = "Lab #18";
            LblCurrentLab.Text = currenlab;
        }

        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab18Tests.Length; i++)
            {
                Lab18Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab18.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab18Tests.Length; i++)
            {
                if (Lab18Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab18[i].BackColor = Color.Silver;
                    Lbl2Lab18[i].Text = "NOT RUN";
                }
                if (Lab18Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab18[i].BackColor = Color.LightGreen;
                    Lbl2Lab18[i].Text = "PASSED";
                }
                if (Lab18Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab18[i].BackColor = Color.Red;
                    Lbl2Lab18[i].Text = "FAILED";
                }

                //Inputs and Outputs



            }
        }
        private void BtnLab18Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT17";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab18Start.Visible = false;
            BtnLab18Stop.Visible = true;
            TimerLab18.Enabled = true;
        }

        private void BtnLab18Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT17";
            client.WriteNode(tagName, false);
            BtnLab18Start.Visible = true;
            BtnLab18Stop.Visible = false;
            TimerLab18.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab18_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
    }
}
