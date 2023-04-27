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
using static ImpetusLabs.Forms.SelectServerForm;

namespace ImpetusLabs.LabsScreen
{
    public partial class Lab06Screen : UserControl
    {
        public OpcValue[] Lab06Tests = new OpcValue[10];
        private Label[] Lbl2Lab06 = new Label[10];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        
        private string[] Lab06NodeIds = new string[3] { "ns=2;s=[GustavoDevice]LAB06.SW1", "ns=2;s=[GustavoDevice]LAB06.LIGHT", "ns=2;s=[GustavoDevice]LAB06.TIMER1.ACC"};
        private OpcValue[] Lab06Nodes = new OpcValue[3];
        public Lab06Screen()
        {
            InitializeComponent();

            Lbl2Lab06[0] = Lbl2Lab06Test1;
            Lbl2Lab06[1] = Lbl2Lab06Test2;
            Lbl2Lab06[2] = Lbl2Lab06Test3;
            Lbl2Lab06[3] = Lbl2Lab06Test4;
            Lbl2Lab06[4] = Lbl2Lab06Test5;
            Lbl2Lab06[5] = Lbl2Lab06Test6;
            Lbl2Lab06[6] = Lbl2Lab06Test7;
            Lbl2Lab06[7] = Lbl2Lab06Test8;
            Lbl2Lab06[8] = Lbl2Lab06Test9;
            Lbl2Lab06[9] = Lbl2Lab06Test10;

        }

        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab06Tests.Length; i++)
            {
                if (Lab06Tests[i] != null)
                {
                    string testValue = Lab06Tests[i].ToString();

                    if (testValue.Equals("1"))
                    {
                        allFailed = false;
                        // allPassed = false;
                    }
                    else if (testValue.Equals("-1"))
                    {
                        allPassed = false;
                        anyFailed = true;
                    }
                    else
                    {
                        allPassed = false;
                        allFailed = false;
                        break;
                    }
                }
                else
                {
                    allPassed = false;
                    allFailed = false;
                    break;
                }
            }

            if (allPassed)
            {
                lblLabStatus.Text = "LAB #6 PASSED";
                lblLabStatus.BackColor = Color.Green;
                lblLabStatus.ForeColor = Color.White;
            }
            else if (allFailed)
            {
                lblLabStatus.Text = "LAB FAILED";
                lblLabStatus.BackColor = Color.Red;
                lblLabStatus.ForeColor = Color.White;
            }
            else if (anyFailed)
            {
                lblLabStatus.Text = "LAB FAILED";
                lblLabStatus.BackColor = Color.Red;
                lblLabStatus.ForeColor = Color.White;
            }
        }






        private void RefreshLabs()
        {
            UpdateLabStatus();
            {


                for (int i = 0; i < Lab06Tests.Length; i++)
                {
                    Lab06Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]LAB06.VAR[" + i + "]");
                }
               

                for (int i = 0; i < Lab06Tests.Length; i++)
                {
                    if (Lab06Tests[i].ToString().Equals("0"))
                    {
                        Lbl2Lab06[i].BackColor = Color.Silver;
                        Lbl2Lab06[i].Text = "NOT RUN";
                    }
                    if (Lab06Tests[i].ToString().Equals("1"))
                    {
                        Lbl2Lab06[i].BackColor = Color.LightGreen;
                        Lbl2Lab06[i].Text = "PASSED";
                    }
                    if (Lab06Tests[i].ToString().Equals("-1"))
                    {
                        Lbl2Lab06[i].BackColor = Color.Red;
                        Lbl2Lab06[i].Text = "FAILED";
                    }
                }

                for (int b = 0; b < Lab06Nodes.Length; b++)
                {
                    Lab06Nodes[b] = client.ReadNode(Lab06NodeIds[b]);
                }

                // sw1 on
                if ((bool)Lab06Nodes[0].Value)
                {
                    PicSW1.Image = imageList1.Images[1];
                    lblSW1.ForeColor = Color.White;
                    lblSW1.BackColor = Color.Green;
                    lblSW1.Text = "SW1 ON";
                }
                else
                {
                    PicSW1.Image = imageList1.Images[0];
                    lblSW1.ForeColor = Color.White;
                    lblSW1.BackColor = Color.Red;
                    lblSW1.Text = "SW1 OFF";
                }

                //LIGHT
                if ((bool)Lab06Nodes[1].Value)
                {
                    PicLight.Image = imageList1.Images[2];
                    lblLight.ForeColor = Color.White;
                    lblLight.BackColor = Color.Green;
                    lblLight.Text = "LIGHT  ON";
                }
                else
                {
                    PicLight.Image = imageList1.Images[3];
                    lblLight.ForeColor = Color.White;
                    lblLight.BackColor = Color.Red;
                    lblLight.Text = "LIGHT OFF";
                }
                
                lblCount.Text = ((int)Math.Round(Convert.ToDouble(Lab06Nodes[2].Value) / 1000)).ToString();


                string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

                switch (nodeValue)
                {
                    case "1001":
                        lblLabMessage.Text = "TOGGLING SWITCH FOR 10 SECONDS AND THEN OFF";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1002":
                        lblLabMessage.Text = "TOGGLING SWITCH FOR 20 SECONDS";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1003":
                        lblLabMessage.Text = "WAITING 20 SECONDS, LIGHT SHOULN'T TURN OFF";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1004":
                        lblLabMessage.Text = "WAITING 20 SECONDS, LIGHT SHOULDN'T TURN OFF";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1005":
                        lblLabMessage.Text = "WAITING 20 SECONDS,LIGHT SHOULD TURN OFF";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1006":
                        lblLabMessage.Text = "TOGGLING SWITCH FOR 10 SECONDS AND THEN OFF";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1007":
                        lblLabMessage.Text = "TOGGLING SWITCH FOR 20 SECONDS";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1008":
                        lblLabMessage.Text = "WAITING 20 SECONDS, LIGHT SHOULDN'T TURN OFF";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1009":
                        lblLabMessage.Text = "WAITING 20 SECONDS, LIGHT SHOULDN'T TURN OFF";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1010":
                        lblLabMessage.Text = "WAITING 20 SECONDS,LIGHT SHOULD TURN OFF";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break; 
                    case "1011":
                        lblLabStatus.Text = "LAB #6 PASSED";
                        lblLabStatus.BackColor = Color.Green;
                        lblLabStatus.ForeColor = Color.White;
                        lblLabMessage.Text = "";
                        lblLabMessage.BackColor = Color.Gray;
                        break;
                }
            }

        }

        private void BtnLab06Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT6";
            client.Connect();
            client.WriteNode(tagName, true);
           BtnLab06Start.Visible = false;
          BtnLab06Stop.Visible = true;
            TimerLab06.Enabled = true;
        }

        private void BtnLab06Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT6";
            client.WriteNode(tagName, false);
            BtnLab06Start.Visible = true;
            BtnLab06Stop.Visible = false;
            TimerLab06.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab06_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab06Start_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT6";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab06Start.Visible = false;
            BtnLab06Stop.Visible = true;
            TimerLab06.Enabled = true;
        }

        private void BtnLab06Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT6";
            client.WriteNode(tagName, false);
            BtnLab06Start.Visible = true;
            BtnLab06Stop.Visible = false;
            TimerLab06.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void lblCount_Click(object sender, EventArgs e)
        {

        }

        private void Lab06Screen_Load(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab05 = new Lab05Screen();
            Parent.Controls.Add(BackToLab05);
            BackToLab05.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }
    }
}
