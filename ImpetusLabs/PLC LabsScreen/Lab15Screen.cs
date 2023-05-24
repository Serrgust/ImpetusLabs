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
    public partial class Lab15Screen : UserControl
    {
        private OpcValue[] Lab15Tests = new OpcValue[4];
        private Label[] Lbl2Lab15 = new Label[4];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab15NodeIds = new string[7] { "ns=2;s=[GustavoDevice]LAB15.START", "ns=2;s=[GustavoDevice]LAB15.STOP", "ns=2;s=[GustavoDevice]LAB15.CONVEYOR1", "ns=2;s=[GustavoDevice]LAB15.CONVEYOR2", "ns=2;s=[GustavoDevice]LAB15.FEEDER", "ns=2;s=[GustavoDevice]LAB15.CELL1", "ns=2;s=[GustavoDevice]LAB15.CELL2" };
        private OpcValue[] Lab15Nodes = new OpcValue[7];
        public Lab15Screen()
        {
            InitializeComponent();


            Lbl2Lab15[0] = Lbl2Lab15Test1;
            Lbl2Lab15[1] = Lbl2Lab15Test2;
            Lbl2Lab15[2] = Lbl2Lab15Test3;
            Lbl2Lab15[3] = Lbl2Lab15Test4;

          
        }


        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab15Tests.Length; i++)
            {
                if (Lab15Tests[i] != null)
                {
                    string testValue = Lab15Tests[i].ToString();

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
                lblLabStatus.Text = "LAB #15 PASSED";
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

                //codigo para hacer updates de los test labels
                for (int i = 0; i < Lab15Tests.Length; i++)
                {
                    Lab15Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab15.VAR[" + i + "]");
                }

                for (int i = 0; i < Lab15Tests.Length; i++)
                {
                    if (Lab15Tests[i].ToString().Equals("0"))
                    {
                        Lbl2Lab15[i].BackColor = Color.Silver;
                        Lbl2Lab15[i].Text = "NOT RUN";
                    }
                    if (Lab15Tests[i].ToString().Equals("1"))
                    {
                        Lbl2Lab15[i].BackColor = Color.DarkGreen;
                        Lbl2Lab15[i].Text = "PASSED";
                    }
                    if (Lab15Tests[i].ToString().Equals("-1"))
                    {
                        Lbl2Lab15[i].BackColor = Color.Red;
                        Lbl2Lab15[i].Text = "FAILED";
                    }


                    // Fotos
                    for (int b = 0; b < Lab15Nodes.Length; b++)
                    {
                        Lab15Nodes[b] = client.ReadNode(Lab15NodeIds[b]);
                    }

                    // Start
                    if ((bool)Lab15Nodes[0].Value)
                    {
                        PicStart.Image = imageList1.Images[1];
                        lblStart.ForeColor = Color.White;
                        lblStart.BackColor = Color.Green;
                        lblStart.Text = "START ON";
                    }
                    else
                    {
                        PicStart.Image = imageList1.Images[0];
                        lblStart.ForeColor = Color.White;
                        lblStart.BackColor = Color.Red;
                        lblStart.Text = "START OFF";
                    }

                    //STOP
                    if ((bool)Lab15Nodes[1].Value)
                    {
                        PicStop.Image = imageList1.Images[3];
                        lblStop.ForeColor = Color.White;
                        lblStop.BackColor = Color.Green;
                        lblStop.Text = "STOP ON";
                    }
                    else
                    {
                        PicStop.Image = imageList1.Images[2];
                        lblStop.ForeColor = Color.White;
                        lblStop.BackColor = Color.Red;
                        lblStop.Text = "STOP OFF";
                    }
                    //MOTOR1
                    if ((bool)Lab15Nodes[2].Value)
                    {
                        PicMotor.Image = imageList1.Images[4];
                        lblMotor.ForeColor = Color.White;
                        lblMotor.BackColor = Color.Green;
                        lblMotor.Text = "MOTOR ON";
                    }
                    else
                    {
                        PicMotor.Image = imageList1.Images[4];
                        lblMotor.ForeColor = Color.White;
                        lblMotor.BackColor = Color.Red;
                        lblMotor.Text = "MOTOR OFF";
                    }

                    //MOTOR 2
                    if ((bool)Lab15Nodes[3].Value)
                    {
                        PicMotor2.Image = imageList1.Images[4];
                        lblMotor2.ForeColor = Color.White;
                        lblMotor2.BackColor = Color.Green;
                        lblMotor2.Text = "MOTOR2 ON";
                    }
                    else
                    {
                        PicMotor2.Image = imageList1.Images[4];
                        lblMotor2.ForeColor = Color.White;
                        lblMotor2.BackColor = Color.Red;
                        lblMotor2.Text = "MOTOR2 OFF";
                    }

                    //FEEDER
                    if ((bool)Lab15Nodes[4].Value)
                    {
                        PicFeeder.Image = imageList1.Images[5];
                        lblFeeder.ForeColor = Color.White;
                        lblFeeder.BackColor = Color.Green;
                        lblFeeder.Text = "FEEDER  ON";
                    }
                    else
                    {
                        PicFeeder.Image = imageList1.Images[5];
                        lblFeeder.ForeColor = Color.White;
                        lblFeeder.BackColor = Color.Red;
                        lblFeeder.Text = "FEEDER OFF";
                    }
                    lblCell1.Text = Lab15Nodes[5].Value.ToString();
                    lblCell2.Text = Lab15Nodes[6].Value.ToString();

                }

                string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

                switch (nodeValue)
                {
                    case "1501":
                        lblLabMessage.Text = "TOGGLE START, FEEDER SHOULD START UNTIL LOAD CELL 1 DECTECTS A FORCE HIGHER THAN 10 NEWTONS";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1502":
                        lblLabMessage.Text = "FEEDER MOTOR STOPS, CONVEYOR 1 SHOULD START";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1503":
                        lblLabMessage.Text = "LOAD CELL 2 DETECTS A FORCE HIGHER THAN 10 NEWTONS, CONVEYOR 1 SHOULD STOP AND CONVEYOR 2 AND FEEDER SHOULD TURN ON";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1504":
                        lblLabMessage.Text = "LOAD CELL 2 DETECTS A FORCE HIGHER THAN 10 NEWTONS, CONVEYOR 1 SHOULD STOP AND CONVEYOR 2 AND FEEDER SHOULD TURN ON LOAD CELL 1 DETECTS A FORCE HIGHER THAN 10 NEWTONS, CONVEYOR 1 SHOULD START AGAIN AND CONVEYOR 2 AND FEEDER SHOULD STOP";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1505":
                        lblLabStatus.Text = "LAB #15 PASSED";
                        lblLabStatus.BackColor = Color.Green;
                        lblLabStatus.ForeColor = Color.White;
                        lblLabMessage.Text = "";
                        lblLabMessage.BackColor = Color.Gray;
                        break;
                   
                }


                }
            }

        private void TimerLab15_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab15Start_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT14";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab15Start.Visible = false;
            BtnLab15Stop.Visible = true;
            TimerLab15.Enabled = true;
        }

        private void BtnLab15Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT14";
            client.WriteNode(tagName, false);
            BtnLab15Start.Visible = true;
            BtnLab15Stop.Visible = false;
            TimerLab15.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void Lab15Screen_Load(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab14 = new Lab14Screen();
            Parent.Controls.Add(BackToLab14);
            BackToLab14.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
            
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab16Screen();
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this);
            secondUserControl.Dock = DockStyle.Fill;
        }
    }
}

