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
        private string[] Lab09NodeIds = new string[6] { "ns=2;s=[GustavoDevice]LAB09.OS1", "ns=2;s=[GustavoDevice]LAB09.OS2", "ns=2;s=[GustavoDevice]LAB09.M1", "ns=2;s=[GustavoDevice]LAB09.M2", "ns=2;s=[GustavoDevice]LAB09.TIMER1.ACC", "ns=2;s=[GustavoDevice]LAB09.COUNT" };
        private OpcValue[] Lab09Nodes = new OpcValue[6];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        
        public Lab09Screen()
        {
            InitializeComponent();

            Lbl2Lab09[0] = Lbl2Lab09Test1;
            Lbl2Lab09[1] = Lbl2Lab09Test2;
            Lbl2Lab09[2] = Lbl2Lab09Test3;
            Lbl2Lab09[3] = Lbl2Lab09Test4;
            Lbl2Lab09[4] = Lbl2Lab09Test5;

           


        }




        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab09Tests.Length; i++)
            {
                if (Lab09Tests[i] != null)
                {
                    string testValue = Lab09Tests[i].ToString();

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
                lblLabStatus.Text = "LAB #9 PASSED";
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
                    Lbl2Lab09[i].BackColor = Color.DarkGreen;
                    Lbl2Lab09[i].Text = "PASSED";
                }
                if (Lab09Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab09[i].BackColor = Color.Red;
                    Lbl2Lab09[i].Text = "FAILED";
                }




                // Fotos
                for (int b = 0; b < Lab09Nodes.Length; b++)
                {
                    Lab09Nodes[b] = client.ReadNode(Lab09NodeIds[b]);
                }

                // OS1
                if ((bool)Lab09Nodes[0].Value)
                {
                    PicOS1.Image = imageList1.Images[1];
                    lblOS1.ForeColor = Color.White;
                    lblOS1.BackColor = Color.Green;
                    lblOS1.Text = "OS1 ON";
                }
                else
                {
                    PicOS1.Image = imageList1.Images[0];
                    lblOS1.ForeColor = Color.White;
                    lblOS1.BackColor = Color.Red;
                    lblOS1.Text = "OS1 OFF";
                }

                //OS2
                if ((bool)Lab09Nodes[1].Value)
                {
                    PicOS2.Image = imageList1.Images[2];
                    lblOS2.ForeColor = Color.White;
                    lblOS2.BackColor = Color.Green;
                    lblOS2.Text = "OS2  ON";
                }
                else
                {
                    PicOS2.Image = imageList1.Images[3];
                    lblOS2.ForeColor = Color.White;
                    lblOS2.BackColor = Color.Red;
                    lblOS2.Text = "OS2 OFF";
                }
                //MOTOR1
                if ((bool)Lab09Nodes[2].Value)
                {
                    PicMotor1.Image = imageList1.Images[4];
                    lblMotor1.ForeColor = Color.White;
                    lblMotor1.BackColor = Color.Green;
                    lblMotor1.Text = "MOTOR1  ON";
                }
                else
                {
                    PicMotor1.Image = imageList1.Images[4];
                    lblMotor1.ForeColor = Color.White;
                    lblMotor1.BackColor = Color.Red;
                    lblMotor1.Text = "MOTOR1  ON";
                }
                //MOTOR2  
                if ((bool)Lab09Nodes[3].Value)
                {
                    PicMotor2.Image = imageList1.Images[5];
                    lblMotor2.ForeColor = Color.White;
                    lblMotor2.BackColor = Color.Green;
                    lblMotor2.Text = "MOTOR2  ON";
                }
                else
                {
                    PicMotor2.Image = imageList1.Images[5];
                    lblMotor2.ForeColor = Color.White;
                    lblMotor2.BackColor = Color.Red;
                    lblMotor2.Text = "MOTOR2  OFF";
                }

                //COUNTER
                lblCounter.Text = Lab09Nodes[5].Value.ToString();


                //Timer
                lblTimer.Text = ((int)Math.Round(Convert.ToDouble(Lab09Nodes[4].Value) / 1000)).ToString();
            }


            string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

            switch (nodeValue)
            {
                case "90":
                    lblLabMessage.Text = "TOGGLE START, NO BOXES ENTERED, M1 IS ON AND M2 OFF";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "91":
                    lblLabMessage.Text = "TOGGLE OS1 1 TIME, M1 AND M2 ARE ON";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "92":
                    lblLabMessage.Text = "TOGGLE OS1 5 TIMES, M1 IS OFF AND M2 STAYS ON";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "93":
                    lblLabMessage.Text = "TOGGLE OS2 4 TIMES, M1 AND M2 ARE OFF";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "94":
                    lblLabMessage.Text = "WAITING 30 SECONDS FOR M1 TO TUNR ON. M2 SHOULD STAY OFF";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "95":
                    lblLabStatus.Text = "LAB #9 PASSED";
                    lblLabStatus.BackColor = Color.Green;
                    lblLabStatus.ForeColor = Color.White;
                    lblLabMessage.Text = "";
                    lblLabMessage.BackColor = Color.Gray;
                    break;
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

        private void BtnLab09Start_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT8";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab09Start.Visible = false;
            BtnLab09Stop.Visible = true;
            TimerLab09.Enabled = true;
        }

        private void BtnLab09Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT8";
            client.WriteNode(tagName, false);
            BtnLab09Start.Visible = true;
            BtnLab09Stop.Visible = false;
            TimerLab09.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab08 = new Lab08Screen();
            Parent.Controls.Add(BackToLab08);
            BackToLab08.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab10Screen();
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this);
            secondUserControl.Dock = DockStyle.Fill;
        }
    }
    }
