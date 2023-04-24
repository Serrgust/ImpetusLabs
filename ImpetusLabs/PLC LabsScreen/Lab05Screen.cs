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

namespace ImpetusLabs.LabsScreen
{
    public partial class Lab05Screen : UserControl
    {
        private OpcValue[] Lab05Tests = new OpcValue[4];
        private Label[] Lbl2Lab05 = new Label[4];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private OpcValue Lab05Counter;
        private string[] Lab05NodeIds = new string[4] { "ns=2;s=[GustavoDevice]LAB05.SW1", "ns=2;s=[GustavoDevice]LAB05.PB1", "ns=2;s=[GustavoDevice]LAB05.COUNTER1.ACC", "ns=2;s=[GustavoDevice]LAB05.LIGHT" };
        private OpcValue[] Lab05Nodes = new OpcValue[4];
        public Lab05Screen()
        {
            InitializeComponent();
            Lbl2Lab05[0] = Lbl2Lab05Test1;
            Lbl2Lab05[1] = Lbl2Lab05Test2;
            Lbl2Lab05[2] = Lbl2Lab05Test3;
            Lbl2Lab05[3] = Lbl2Lab05Test4;



        }


        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab05Tests.Length; i++)
            {
                if (Lab05Tests[i] != null)
                {
                    string testValue = Lab05Tests[i].ToString();

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
                lblLabStatus.Text = "LAB #5 PASSED";
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

                for (int i = 0; i < Lab05Tests.Length; i++)
                {
                    Lab05Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab05.VAR[" + i + "]");
                }

                for (int i = 0; i < Lab05Tests.Length; i++)
                {
                    if (Lab05Tests[i].ToString().Equals("0"))
                    {
                        Lbl2Lab05[i].BackColor = Color.Silver;
                        Lbl2Lab05[i].Text = "NOT RUN";
                    }
                    if (Lab05Tests[i].ToString().Equals("1"))
                    {
                        Lbl2Lab05[i].BackColor = Color.LightGreen;
                        Lbl2Lab05[i].Text = "PASSED";
                    }
                    if (Lab05Tests[i].ToString().Equals("-1"))
                    {
                        Lbl2Lab05[i].BackColor = Color.Red;
                        Lbl2Lab05[i].Text = "FAILED";
                    }
                }



                for (int b = 0; b < Lab05Nodes.Length; b++)
                {
                    Lab05Nodes[b] = client.ReadNode(Lab05NodeIds[b]);
                }

                // sw1 on
                if ((bool)Lab05Nodes[0].Value)
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
                //PB1
                if ((bool)Lab05Nodes[1].Value)
                {
                    PicPB1.Image = imageList1.Images[3];
                    lblPB1.ForeColor = Color.White;
                    lblPB1.BackColor = Color.Green;
                    lblPB1.Text = "PB1  ON";
                }
                else
                {
                    PicPB1.Image = imageList1.Images[2];
                    lblPB1.ForeColor = Color.White;
                    lblPB1.BackColor = Color.Red;
                    lblPB1.Text = "PB1 OFF";
                }
                //LIGHT
                if ((bool)Lab05Nodes[3].Value)
                {
                    PicLight.Image = imageList1.Images[4];
                    lblLight.ForeColor = Color.White;
                    lblLight.BackColor = Color.Green;
                    lblLight.Text = "LIGHT  ON";
                }
                else
                {
                    PicLight.Image = imageList1.Images[5];
                    lblLight.ForeColor = Color.White;
                    lblLight.BackColor = Color.Red;
                    lblLight.Text = "LIGHT OFF";
                }

                lblCounter.Text = Lab05Nodes[2].ToString();

                string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

                switch (nodeValue)
                {
                    case "901":
                        lblLabMessage.Text = "TOGGLING SW1 10 TIMES, LIGHT SHOULD TURN ON AFTER 10 TOGGLES";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "902":
                        lblLabMessage.Text = "TOGGLING PB1, LIGHT SHOULD TURN OFF";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "903":
                        lblLabMessage.Text = "TOGGLING SW1 10, LIGHT SHOULD TURN ON AFTER 10 TRIES";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "904":
                        lblLabMessage.Text = "TOGGLING SW1 10 TIMES, LIGHT SHOULD TURN ON AFTER 10 TOGGLES";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "905":
                        lblLabStatus.Text = "LAB #5 PASSED";
                        lblLabStatus.BackColor = Color.Green;
                        lblLabStatus.ForeColor = Color.White;
                        lblLabMessage.Text = "";
                        lblLabMessage.BackColor = Color.Gray;
                        break;
                }
            }
        }
            private void BtnLab05Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT5";
            client.WriteNode(tagName, false);
            BtnLab05Start.Visible = true;
            BtnLab05Stop.Visible = false;
            TimerLab05.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void TimerLab05_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab05Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT5";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab05Start.Visible = false;
            BtnLab05Stop.Visible = true;
            TimerLab05.Enabled = true;
        }

        private void LblLab05Test4_Click(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab04 = new Lab04Screen();
            Parent.Controls.Add(BackToLab04);
            BackToLab04.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }
    }
}
