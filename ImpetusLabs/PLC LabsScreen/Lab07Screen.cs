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
    public partial class Lab07Screen : UserControl
    {
        public OpcValue[] Lab07Tests = new OpcValue[17];
        private Label[] Lbl2Lab07 = new Label[17];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab07NodeIds = new string[6] { "ns=2;s=[GustavoDevice]LAB07.START", "ns=2;s=[GustavoDevice]LAB07.STOP", "ns=2;s=[GustavoDevice]LAB07.MOTOR", "ns=2;s=[GustavoDevice]LAB07.CYLINDER", "ns=2;s=[GustavoDevice]LAB07.LIGHT", "ns=2;s=[GustavoDevice]LAB07.OPT_SENSOR" };
        private OpcValue[] Lab07Nodes = new OpcValue[6];


        public Lab07Screen()
        {
            InitializeComponent();
            Lbl2Lab07[0] = Lbl2Lab07Test1;
            Lbl2Lab07[1] = Lbl2Lab07Test2;
            Lbl2Lab07[2] = Lbl2Lab07Test3;
            Lbl2Lab07[3] = Lbl2Lab07Test4;
            Lbl2Lab07[4] = Lbl2Lab07Test5;
            Lbl2Lab07[5] = Lbl2Lab07Test6;
            Lbl2Lab07[6] = Lbl2Lab07Test7;
            Lbl2Lab07[7] = Lbl2Lab07Test8;
            Lbl2Lab07[8] = Lbl2Lab07Test9;
            Lbl2Lab07[9] = Lbl2Lab07Test10;
            Lbl2Lab07[10] = Lbl2Lab07Test11;
            Lbl2Lab07[11] = Lbl2Lab07Test12;
            Lbl2Lab07[12] = Lbl2Lab07Test13;
            Lbl2Lab07[13] = Lbl2Lab07Test14;
            Lbl2Lab07[14] = Lbl2Lab07Test15;
            Lbl2Lab07[15] = Lbl2Lab07Test16;
            Lbl2Lab07[16] = Lbl2Lab07Test17;


        }


        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab07Tests.Length; i++)
            {
                if (Lab07Tests[i] != null)
                {
                    string testValue = Lab07Tests[i].ToString();

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
                lblLabStatus.Text = "LAB #7 PASSED";
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

                for (int i = 0; i < Lab07Tests.Length; i++)
                {
                    Lab07Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]LAB07.VAR[" + i + "]");
                }

                for (int i = 0; i < Lab07Tests.Length; i++)
                {
                    if (Lab07Tests[i].ToString().Equals("0"))
                    {
                        Lbl2Lab07[i].BackColor = Color.Silver;
                        Lbl2Lab07[i].Text = "NOT RUN";
                    }
                    if (Lab07Tests[i].ToString().Equals("1"))
                    {
                        Lbl2Lab07[i].BackColor = Color.DarkGreen;
                        Lbl2Lab07[i].Text = "PASSED";
                    }
                    if (Lab07Tests[i].ToString().Equals("-1"))
                    {
                        Lbl2Lab07[i].BackColor = Color.Red;
                        Lbl2Lab07[i].Text = "FAILED";
                    }
                }


                //Fotos
                for (int b = 0; b < Lab07Nodes.Length; b++)
                {
                    Lab07Nodes[b] = client.ReadNode(Lab07NodeIds[b]);
                }

                // start on
                if ((bool)Lab07Nodes[0].Value)
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

                //Stop off
                if ((bool)Lab07Nodes[1].Value)
                {
                    PicStop.Image = imageList1.Images[6];
                    lblStop.ForeColor = Color.White;
                    lblStop.BackColor = Color.Green;
                    lblStop.Text = "STOP  ON";
                }
                else
                {
                    PicStop.Image = imageList1.Images[7];
                    lblStop.ForeColor = Color.White;
                    lblStop.BackColor = Color.Red;
                    lblStop.Text = "STOP OFF";
                }
                //Motor
                if ((bool)Lab07Nodes[2].Value)
                {
                    PicMotor.Image = imageList1.Images[4];
                    lblMotor.ForeColor = Color.White;
                    lblMotor.BackColor = Color.Green;
                    lblMotor.Text = "MOTOR  ON";
                }
                else
                {
                    PicMotor.Image = imageList1.Images[5];
                    lblMotor.ForeColor = Color.White;
                    lblMotor.BackColor = Color.Red;
                    lblMotor.Text = "MOTOR OFF";
                }
                //Cylinder
                if ((bool)Lab07Nodes[3].Value)
                {
                    PicCylinder.Image = imageList1.Images[8];
                    lblCylinder.ForeColor = Color.White;
                    lblCylinder.BackColor = Color.Green;
                    lblCylinder.Text = "CYLINDER  ON";
                }
                else
                {
                    PicCylinder.Image = imageList1.Images[8];
                    lblCylinder.ForeColor = Color.White;
                    lblCylinder.BackColor = Color.Red;
                    lblCylinder.Text = "CYLINDER OFF";
                }
                //Light
                if ((bool)Lab07Nodes[4].Value)
                {
                    PicLight.Image = imageList1.Images[6];
                    lblLight.ForeColor = Color.White;
                    lblLight.BackColor = Color.Green;
                    lblLight.Text = "LIGHT  ON";
                }
                else
                {
                    PicLight.Image = imageList1.Images[7];
                    lblLight.ForeColor = Color.White;
                    lblLight.BackColor = Color.Red;
                    lblLight.Text = "LIGHT OFF";
                }
                //SENSOR
                if ((bool)Lab07Nodes[5].Value)
                {
                    PicSensor.Image = imageList1.Images[9];
                    lblSensor.ForeColor = Color.White;
                    lblSensor.BackColor = Color.Green;
                    lblSensor.Text = "SENSOR  ON";
                }
                else
                {
                    PicSensor.Image = imageList1.Images[9];
                    lblSensor.ForeColor = Color.White;
                    lblSensor.BackColor = Color.Red;
                    lblSensor.Text = "SENSOR OFF";

                }
            }
            string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();



            switch (nodeValue)
            {

                case "301":
                    lblLabMessage.Text = "PRESSING START BUTTON, LIGHT SHOULD TURN ON AND MOTOR SHOULD START";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;

                case "302":
                    lblLabMessage.Text = "PRESSING STOP BUTTON, LIGHT SHOULD TURN OFF AND MOTOR SHOULD STOP";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;

                case "303":
                    lblLabMessage.Text = "PRESSING START BUTTON, LIGHT SHOULD TURN ON AND MOTOR SHOULD START";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;

                case "304":
                    lblLabMessage.Text = "OPTICAL SESNOR DETECTS PART, MOTOR SHOULD STAY ON FOR 10 SECONDS";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;

                case "305":
                    lblLabMessage.Text = "VERIFYING THAT MOTOR IS OFF, LIGHT SHOULD BE ON";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;

                case "306":
                    lblLabMessage.Text = "VERIFYING TIME MOTOR IS OFF ";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;

                case "307":
                    lblLabMessage.Text = "VERIFYING MOTOR TURNS ON";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;

                case "308":
                    lblLabMessage.Text = "OPTICAL SESNOR DETECTS PART, MOTOR SHOULD STAYON FOR 10 SECONDS ";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;

                case "309":
                    lblLabMessage.Text = "VERIFYING THAT MOTOR IS OFF, LIGHT SHOULD BE ON";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;

                case "310":
                    lblLabMessage.Text = "VERIFYING TIME MOTOR IS OFF";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;

                case "311":
                    lblLabMessage.Text = "VERIFYING MOTOR TURNS ON ";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;

                case "312":
                    lblLabMessage.Text = "PRESSING STOP BUTTON, LIGHT SHOULD TURN OFF AND MOTOR SHOULD STOP ";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
    
                case "314":
                    lblLabMessage.Text = "PRESSING START BUTTON, LIGHT SHOULD TURN ON AND MOTOR SHOULD START ";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;

                case "315":
                    lblLabMessage.Text = "PRESSING STOP BUTTON, LIGHT SHOULD TURN OFF AND MOTOR SHOULD STOP";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "316":
                    lblLabMessage.Text = "PRESSING START BUTTON, LIGHT SHOULD TURN ON AND MOTOR SHOULD START";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "317":
                    lblLabMessage.Text = "OPTICAL SESNOR DETECTS PART, MOTOR SHOULD STAY ON, LIGHT SHOULD REMAIN ON,CYLINDER SHOULD ACTIVATE";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "318":
                    lblLabMessage.Text = "AFTER 5 SECONDS, CYLINDER SHOULD DEACTIVATE, MOTOR SHOULD STAY ON, LIGHT SHOULD REMAIN ON";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "319":
                    lblLabMessage.Text = "OPTICAL SENSOR DETECTS PART, MOTOR SHOULD STAY ON, LIGHT SHOULD REMAIN ON,CYLINDER SHOULD ACTIVATE";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "320":
                    lblLabMessage.Text = "AFTER 5 SECONDS, CYLINDER SHOULD DEACTIVATE, MOTOR SHOULD STAY ON, LIGHT SHOULD REMAIN ON";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "321":
                    lblLabMessage.Text = "PRESSING STOP BUTTON, LIGHT SHOULD TURN OFF AND MOTOR SHOULD STOP";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "322":
                    lblLabStatus.Text = "LAB #7 PASSED";
                    lblLabStatus.BackColor = Color.Green;
                    lblLabStatus.ForeColor = Color.White;
                    lblLabMessage.Text = "";
                    lblLabMessage.BackColor = Color.Gray;
                    break;

            }
        }


            private void BtnLab07Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT7";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab07Start.Visible = false;
            BtnLab07Stop.Visible = true;
            TimerLab07.Enabled = true;
        }

        private void BtnLab07Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT7";
            client.WriteNode(tagName, false);
            BtnLab07Start.Visible = true;
            BtnLab07Stop.Visible = false;
            TimerLab07.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab07_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void Lab07Screen_Load(object sender, EventArgs e)
        {
            {

            }
        }

        private void BtnLab07Start_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT7";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab07Start.Visible = false;
            BtnLab07Stop.Visible = true;
            TimerLab07.Enabled = true;
        }

        private void BtnLab07Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT7";
            client.WriteNode(tagName, false);
            BtnLab07Start.Visible = true;
            BtnLab07Stop.Visible = false;
            TimerLab07.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;


        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab06 = new Lab06Screen();
            Parent.Controls.Add(BackToLab06);
            BackToLab06.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab08Screen();
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this);
            secondUserControl.Dock = DockStyle.Fill;
        }
    }
}
