using ImpetusLabs.LabsScreen;
using Opc.Ua;
using Opc.UaFx;
using Opc.UaFx.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ImpetusLabs
{
    public partial class Lab01Screen : UserControl
    {
        private OpcValue[] Lab01Tests = new OpcValue[6];
        private Label[] Lbl2Lab01 = new Label[6];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private OpcValue[] Lab01Nodes = new OpcValue[6];
        private string[] Lab01NodeIds = new string[6] { "ns=2;s=[GustavoDevice]LAB01.MOTOR1", "ns=2;s=[GustavoDevice]LAB01.MOTOR2", "ns=2;s=[GustavoDevice]LAB01.START1", "ns=2;s=[GustavoDevice]LAB01.START2", "ns=2;s=[GustavoDevice]LAB01.STOP1", "ns=2;s=[GustavoDevice]LAB01.STOP2" };
        private string[] Lab01SequenceMessage = new string[] { "ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE" };
        private OpcValue[] Lab01Message = new OpcValue[7];
        public Lab01Screen()
        {
            InitializeComponent();
            Lbl2Lab01[0] = Lbl2Lab01Test1;
            Lbl2Lab01[1] = Lbl2Lab01Test2;
            Lbl2Lab01[2] = Lbl2Lab01Test3;
            Lbl2Lab01[3] = Lbl2Lab01Test4;
            Lbl2Lab01[4] = Lbl2Lab01Test5;
            Lbl2Lab01[5] = Lbl2Lab01Test6;

           
        }

        private void TimerLab01_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
        private void UpdateLabStatus()
        {
            bool allPassed = true;
            bool allFailed = true;
            bool anyfailed = false;

            for (int i = 0; i < Lab01Tests.Length; i++)
            {
                if (Lab01Tests[i] != null)
                {
                    string testValue = Lab01Tests[i].ToString();

                    if (testValue.Equals("1"))
                    {
                        allFailed = false;
                    }
                    else if (testValue.Equals("-1"))
                    {
                        allPassed = false;
                        anyfailed = true;
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
                lblLabStatus.Text = "Lab #1 Passed";
                lblLabStatus.BackColor = Color.Green;
                lblLabStatus.ForeColor = Color.White;
            }
            else if (allFailed)
            {
                lblLabStatus.Text = "Lab Failed";
                lblLabStatus.BackColor = Color.Red;
                lblLabStatus.ForeColor = Color.White;
            }
            else if (anyfailed)
            {
                lblLabStatus.Text = "Lab Failed";
                lblLabStatus.BackColor = Color.Red;
                lblLabStatus.ForeColor = Color.White;
            }

            }


        private void RefreshLabs()

        {
            UpdateLabStatus();

            {
                for (int i = 0; i < Lab01Nodes.Length; i++)
                {
                    Lab01Nodes[i] = client.ReadNode(Lab01NodeIds[i]);
                }

                if ((bool)Lab01Nodes[0].Value) // Motor 1
                {
                    PicMotor1.Image = imageList1.Images[0];
                    lblMotor1.ForeColor = Color.White;
                    lblMotor1.BackColor = Color.Green;
                    lblMotor1.Text = "Motor1 ON";



                }

                else
                {
                    PicStart1.Image = imageList1.Images[1];
                    lblMotor1.ForeColor = Color.White;
                    lblMotor1.BackColor = Color.Red;
                    lblMotor1.Text = "Motor1 OFF";
                }

                if ((bool)Lab01Nodes[1].Value) // Motor 2
                {
                    PicMotor2.Image = imageList1.Images[1];
                    lblMotor2.ForeColor = Color.White;
                    lblMotor2.BackColor = Color.Green;
                    lblMotor2.Text = "Motor2 ON";
                }
                else
                {
                    PicMotor2.Image = imageList1.Images[0];
                    lblMotor2.ForeColor = Color.White;
                    lblMotor2.BackColor = Color.Red;
                    lblMotor2.Text = "Motor2 OFF";
                }

                if ((bool)Lab01Nodes[2].Value) // Start 1
                {
                    PicStart1.Image = imageList1.Images[3];
                    lblStart1.ForeColor = Color.White;
                    lblStart1.BackColor = Color.Green;
                    lblStart1.Text = "Start1 ON";
                }
                else
                {
                    PicStart1.Image = imageList1.Images[2];
                    lblStart1.ForeColor = Color.White;
                    lblStart1.BackColor = Color.Red;
                    lblStart1.Text = "Start1 OFF";
                }

                if ((bool)Lab01Nodes[3].Value) // Start 2
                {
                    PicStart2.Image = imageList1.Images[5];
                    lblStart2.ForeColor = Color.White;
                    lblStart2.BackColor = Color.Green;
                    lblStart2.Text = "Start2 ON";
                }
                else
                {
                    PicStart2.Image = imageList1.Images[4];
                    lblStart2.ForeColor = Color.White;
                    lblStart2.BackColor = Color.Red;
                    lblStart2.Text = "Start2 OFF";
                }

                if ((bool)Lab01Nodes[4].Value) // Stop 1
                {
                    PicStop1.Image = imageList1.Images[6];
                    lblStop1.ForeColor = Color.White;
                    lblStop1.BackColor = Color.Green;
                    lblStop1.Text = "Stop1 ON";
                }
                else
                {
                    PicStop1.Image = imageList1.Images[7];
                    lblStop1.ForeColor = Color.White;
                    lblStop1.BackColor = Color.Red;
                    lblStop1.Text = "Stop1 OFF";
                }

                if ((bool)Lab01Nodes[5].Value) // Stop 2
                {
                    PicStop2.Image = imageList1.Images[8];
                    lblStop2.ForeColor = Color.White;
                    lblStop2.BackColor = Color.Green;
                    lblStop2.Text = "Stop2 ON";
                }
                else
                {
                    PicStop2.Image = imageList1.Images[9];
                    lblStop2.ForeColor = Color.White;
                    lblStop2.BackColor = Color.Red;
                    lblStop2.Text = "Stop2 OFF";
                }

                for (int i = 0; i < Lab01Tests.Length; i++)
                {
                    Lab01Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]LAB01.VAR[" + i + "]");
                }

                for (int i = 0; i < Lab01Tests.Length; i++)
                {
                    if (Lab01Tests[i].ToString().Equals("0"))
                    {
                        Lbl2Lab01[i].BackColor = Color.Silver;
                        Lbl2Lab01[i].Text = "NOT RUN";
                    }
                    if (Lab01Tests[i].ToString().Equals("1"))
                    {
                        Lbl2Lab01[i].BackColor = Color.DarkGreen;
                        Lbl2Lab01[i].Text = "PASSED";

                    }
                    if (Lab01Tests[i].ToString().Equals("-1"))
                    {
                        Lbl2Lab01[i].BackColor = Color.Red;
                        Lbl2Lab01[i].Text = "FAILED";

                
                        }
                    string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

                    switch (nodeValue)
                    {
                        case "501":
                            lblLabMessage.Text = "TOGGLING START1, MOTOR1 SHOULD REMAIN ON.";
                            lblLabMessage.ForeColor = Color.White;
                            lblLabMessage.BackColor = Color.Black;
                            break;
                        case "502":
                            lblLabMessage.Text = "TOGGLING STOP1, MOTOR 1 SHOULD TURN OFF";
                            lblLabMessage.ForeColor = Color.White;
                            lblLabMessage.BackColor = Color.Black;
                            break;
                        case "503":
                            lblLabMessage.Text = "START2 OFF AND STOP2 OFF, MOTOR SHOULD BE OFF";
                            lblLabMessage.ForeColor = Color.White;
                            lblLabMessage.BackColor = Color.Black;
                            break;
                        case "504":
                            lblLabMessage.Text = "START2 OFF AND STOP2 ON, MOTOR2 SHOULD BE OFF";
                            lblLabMessage.ForeColor = Color.White;
                            lblLabMessage.BackColor = Color.Black;
                            break;
                        case "505":
                            lblLabMessage.Text = "START2 ON AND STOP2 ON, MOTOR2 SHOULD BE OFF";
                            lblLabMessage.ForeColor = Color.White;
                            lblLabMessage.BackColor = Color.Black;
                            break;
                        case "506":
                            lblLabMessage.Text = "START2 ON AND STOP2 OFF, MOTOR2 SHOULD BE ON";
                            lblLabMessage.ForeColor = Color.White;
                            lblLabMessage.BackColor = Color.Black;
                            break;
                        case "507":
                            lblLabStatus.Text = "Lab #1 Passed";
                            lblLabStatus.BackColor = Color.Green;
                            lblLabStatus.ForeColor = Color.White;
                            lblLabMessage.Text = "";
                            lblLabMessage.BackColor = Color.Gray;
                            break;
                    }
                }
                
            }
        }

     
            private void BtnLab01Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            client.Connect();
            try
            {
                client.Connect();
                client.WriteNode(tagName, true);
            }
            catch (Opc.UaFx.OpcException)
            {
                //MessageBox.Show("Connection to OPC UA Server failed");
            }
            BtnLab01Start.Visible = false;
            BtnLab01Stop.Visible = true;
            TimerLab01.Enabled = true;
        }

        private void BtnLab01Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            client.WriteNode(tagName, false);
            BtnLab01Start.Visible = true;
            BtnLab01Stop.Visible = false;
            TimerLab01.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void panelInputOuput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LabSelection1 frm = new LabSelection1();
            this.ParentForm.Close();
            frm.Show();

        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {

            Lab02Screen lab02Screen = new Lab02Screen();
            lab02Screen.Show();
            this.Hide();
        }

        private void Lab01Screen_Load(object sender, EventArgs e)
        {

        }

        private void LblCurrentLab_Click(object sender, EventArgs e)
        {

        }
    }
}


