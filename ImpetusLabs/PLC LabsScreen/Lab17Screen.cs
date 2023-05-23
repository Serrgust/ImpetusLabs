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
    public partial class Lab17Screen : UserControl
    {
        private OpcValue[] Lab17Tests = new OpcValue[6];
        private Label[] Lbl2Lab17 = new Label[6];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab17NodeIds = new string[10] { "ns=2;s=[GustavoDevice]LAB17.START", "ns=2;s=[GustavoDevice]LAB17.IN_BOTTLE_SENSOR", "ns=2;s=[GustavoDevice]LAB17.OUT_BOTTLE_SENSOR", "ns=2;s=[GustavoDevice]LAB17.CONVEYOR", "ns=2;s=[GustavoDevice]LAB17.CLIP_HOLD", "ns=2;s=[GustavoDevice]LAB17.CLIP_RELEASE", "ns=2;s=[GustavoDevice]LAB17.MOTOR_FORWARD", "ns=2;s=[GustavoDevice]LAB17.MOTOR_REVERSE", "ns=2;s=[GustavoDevice]LAB17.WATER", "ns=2;s=[GustavoDevice]LAB17.CYLINDER" };
        private OpcValue[] Lab17Nodes = new OpcValue[10];
        public Lab17Screen()
        {
            InitializeComponent();

            Lbl2Lab17[0] = Lbl2Lab17Test1;
            Lbl2Lab17[1] = Lbl2Lab17Test2;
            Lbl2Lab17[2] = Lbl2Lab17Test3;
            Lbl2Lab17[3] = Lbl2Lab17Test4;
            Lbl2Lab17[4] = Lbl2Lab17Test5;
            Lbl2Lab17[5] = Lbl2Lab17Test6;

        }

        private void UpdateLabStatus()  //Method for updating the LabStatus label
        {
            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab17Tests.Length; i++) //Loop that verifies the test results of the lab

            {
                if (Lab17Tests[i] != null) //Verifys the element if its not null for absence in data
                {
                    string testValue = Lab17Tests[i].ToString(); //Reads and converts the value to string 

                    if (testValue.Equals("1"))
                    {
                        allFailed = false;

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

            if (allPassed) //If all test value equals "1", it will display the following:
            {
                lblLabStatus.Text = "LAB #17 PASSED"; //Set the label text to passed 
                lblLabStatus.BackColor = Color.Green; //Set label color Green.
                lblLabStatus.ForeColor = Color.White;  //Set label text color to White. 
            }
            else if (allFailed) //If all test vaule equals "0", it  will display the following:
            {
                lblLabStatus.Text = "LAB FAILED"; //Set the label text to failed.
                lblLabStatus.BackColor = Color.Red; //Set the label color to Red.
                lblLabStatus.ForeColor = Color.White; //Set the label color to White.
            }
            else if (anyFailed) //If any test value equals "-1", it will fail the lab 
            {
                lblLabStatus.Text = "LAB FAILED"; //Set the label text to Failed
                lblLabStatus.BackColor = Color.Red;  //Set the label color to Red.
                lblLabStatus.ForeColor = Color.White; //Set the label color to White.
            }
        }


        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab17Tests.Length; i++)
            {
                Lab17Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab17.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab17Tests.Length; i++)
            {
                if (Lab17Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab17[i].BackColor = Color.Silver;
                    Lbl2Lab17[i].Text = "NOT RUN";
                }
                if (Lab17Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab17[i].BackColor = Color.LightGreen;
                    Lbl2Lab17[i].Text = "PASSED";
                }
                if (Lab17Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab17[i].BackColor = Color.Red;
                    Lbl2Lab17[i].Text = "FAILED";
                }


                // Fotos
                for (int b = 0; b < Lab17Nodes.Length; b++)
                {
                    Lab17Nodes[b] = client.ReadNode(Lab17NodeIds[b]);
                }

                // Start
                if ((bool)Lab17Nodes[0].Value)
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

                //IN sensor
                if ((bool)Lab17Nodes[1].Value)
                {
                    PicInSensor.Image = imageList1.Images[2];
                    lblInSensor.ForeColor = Color.White;
                    lblInSensor.BackColor = Color.Green;
                    lblInSensor.Text = "IN SENSOR ON";
                }
                else
                {
                    PicInSensor.Image = imageList1.Images[2];
                    lblInSensor.ForeColor = Color.White;
                    lblInSensor.BackColor = Color.Red;
                    lblInSensor.Text = "IN SENSOR OFF";
                }
                //OUT SENSOR
                if ((bool)Lab17Nodes[2].Value)
                {
                    PicOutSensor.Image = imageList1.Images[2];
                    lblOutSensor.ForeColor = Color.White;
                    lblOutSensor.BackColor = Color.Green;
                    lblOutSensor.Text = "OUT SENSOR ON";
                }
                else
                {
                    PicOutSensor.Image = imageList1.Images[2];
                    lblOutSensor.ForeColor = Color.White;
                    lblOutSensor.BackColor = Color.Red;
                    lblOutSensor.Text = "OUT SENSOR OFF";
                }

                //Conveyor  MOTOR
                if ((bool)Lab17Nodes[3].Value)
                {
                    PicConveyor.Image = imageList1.Images[3];
                    lblConveyor.ForeColor = Color.White;
                    lblConveyor.BackColor = Color.Green;
                    lblConveyor.Text = "CONVEYOR MOTOR ON";
                }
                else
                {
                    PicConveyor.Image = imageList1.Images[3];
                    lblConveyor.ForeColor = Color.White;
                    lblConveyor.BackColor = Color.Red;
                    lblConveyor.Text = "CONVEYOR MOTOR OFF";
                }

                //CLIP HOLD
                if ((bool)Lab17Nodes[4].Value)
                {
                    PicClipHold.Image = imageList1.Images[5];
                    lblClipHold.ForeColor = Color.White;
                    lblClipHold.BackColor = Color.Green;
                    lblClipHold.Text = "ClIP HOLD ON";
                }
                else
                {
                    PicClipHold.Image = imageList1.Images[4];
                    lblClipHold.ForeColor = Color.White;
                    lblClipHold.BackColor = Color.Red;
                    lblClipHold.Text = "CLIP HOLD OFF";
                }

                // Clip Release
                if ((bool)Lab17Nodes[5].Value)
                {
                    PicClipRelease.Image = imageList1.Images[3];
                    lblClipRelease.ForeColor = Color.White;
                    lblClipRelease.BackColor = Color.Green;
                    lblConveyor.Text = "CLIP RELEASE ON";
                }

                else
                {
                    PicClipRelease.Image = imageList1.Images[3];
                    lblClipRelease.ForeColor = Color.White;
                    lblClipRelease.BackColor = Color.Red;
                    lblClipRelease.Text = "CLIP RELEASE OFF";
                }
                // MOtor FWD
                if ((bool)Lab17Nodes[6].Value)
                {
                    PicMotorFWD.Image = imageList1.Images[3];
                    lblMotorFWD.ForeColor = Color.White;
                    lblMotorFWD.BackColor = Color.Green;
                    lblMotorFWD.Text = "MOTOR FWD  ON";
                }
                else
                {
                    PicMotorFWD.Image = imageList1.Images[3];
                    lblMotorFWD.ForeColor = Color.White;
                    lblMotorFWD.BackColor = Color.Red;
                    lblMotorFWD.Text = "MOTOR FWD OFF";
                }

                //    // MOTOR BACK
                if ((bool)Lab17Nodes[7].Value)
                {
                    PicMotorBack.Image = imageList1.Images[3];
                    lblMotorBack.ForeColor = Color.White;
                    lblMotorBack.BackColor = Color.Green;
                    lblMotorBack.Text = "MOTOR BACK  ON";
                }
                else
                {
                    PicMotorBack.Image = imageList1.Images[3];
                    lblMotorBack.ForeColor = Color.White;
                    lblMotorBack.BackColor = Color.Red;
                    lblMotorBack.Text = "MOTOR BACK OFF";
                }
                //   Water
                if ((bool)Lab17Nodes[8].Value)
                {
                    PicWater.Image = imageList1.Images[6];
                    lblWater.ForeColor = Color.White;
                    lblWater.BackColor = Color.Green;
                    lblWater.Text = "WATER ON";
                }
                else
                {
                    PicWater.Image = imageList1.Images[7];
                    lblWater.ForeColor = Color.White;
                    lblWater.BackColor = Color.Red;
                    lblWater.Text = "WATER OFF";
                }

                //   cylinder
                if ((bool)Lab17Nodes[9].Value)
                {
                    PicCylinder.Image = imageList1.Images[3];
                    lblCylinder.ForeColor = Color.White;
                    lblCylinder.BackColor = Color.Green;
                    lblCylinder.Text = "CYLINDER ON";
                }
                else
                {
                    PicCylinder.Image = imageList1.Images[3];
                    lblCylinder.ForeColor = Color.White;
                    lblCylinder.BackColor = Color.Red;
                    lblCylinder.Text = "Cylinder OFF";
                }

                //declaring nodeValue as a string variable that holds the simulation message node from the OPC Server.
                string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

                switch (nodeValue) //switch case reads the number from the OPC server that is on the variable
                {
                    case "1701":  //Compares the value to the value of the OPC nodde
                        lblLabMessage.Text = "TOGGLE START, CONVEYOR AND CYLINDER SHOULD TURN ON"; //Sets label text to "TOGGLING START1, MOTOR1 SHOULD REMAIN ON."
                        lblLabMessage.ForeColor = Color.White; //Sets the label text color to White.
                        lblLabMessage.BackColor = Color.Black; //Sets the label color to Black.
                        break; //Exit block after it gets executed
                    case "1702":
                        lblLabMessage.Text = "TOGGLE BOTTLE SENSOR, CLIP BOTTLE SHOULD TURN ON";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1703":
                        lblLabMessage.Text = "TOGGLE CLIPPER SENSOR, FORWARD MOTOR SHOULD TURN ON";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1704":
                        lblLabMessage.Text = "BOTTHE IS IN UPSIDE POSITION, BOTTLE FORWARD SHOULD TURN OFF AND WATER SUPPLY SHOUD ACTIVATE";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1705":
                        lblLabMessage.Text = "AFTER 5 SECONDS, WATER SUPPLY TURNS OFF AND REVERSE MOTOR ACTIVATES FOR 5 SECONDS";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1706":
                        lblLabMessage.Text = "BOTTLE IS TURNED, TOGGLE SENSOR FOR LEAVE BOTTLE. CLIP BOTTLE RELEASE SHOULD ACTIVATE";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1707":
                        lblLabStatus.Text = "Lab #17 PASSED";
                        lblLabStatus.BackColor = Color.Green;
                        lblLabStatus.ForeColor = Color.White;
                        lblLabMessage.Text = "";
                        lblLabMessage.BackColor = Color.Gray;
                        break;
                }
            }
        }

            private void button1_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT16";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab17Start.Visible = false;
            BtnLab17Stop.Visible = true;
            TimerLab17.Enabled = true;
        }

        private void BtnLab17Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT16";
            client.WriteNode(tagName, false);
            BtnLab17Start.Visible = true;
            BtnLab17Stop.Visible = false;
            TimerLab17.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab17_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnLab17Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT16";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab17Start.Visible = false;
            BtnLab17Stop.Visible = true;
            TimerLab17.Enabled = true;
        }

        private void BtnLab17Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT16";
            client.WriteNode(tagName, false);
            BtnLab17Start.Visible = true;
            BtnLab17Stop.Visible = false;
            TimerLab17.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackTolab16 = new Lab16Screen(); 
            Parent.Controls.Add(BackTolab16);
            BackTolab16.Dock = DockStyle.Fill; 
            Parent.Controls.Remove(this); 
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab18Screen(); 
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this); 
            secondUserControl.Dock = DockStyle.Fill; 
        }
    }
}