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
    public partial class Lab16Screen : UserControl
    {
        private OpcValue[] Lab16Tests = new OpcValue[6];
        private Label[] Lbl2Lab16 = new Label[6];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab16NodeIds = new string[9] { "ns=2;s=[GustavoDevice]LAB16.START", "ns=2;s=[GustavoDevice]LAB16.OBJECT_DETECT", "ns=2;s=[GustavoDevice]LAB16.CLAMP_SENSOR", "ns=2;s=[GustavoDevice]LAB16.DRILL", "ns=2;s=[GustavoDevice]LAB16.CLAMP", "ns=2;s=[GustavoDevice]LAB16.MOTOR_UP", "ns=2;s=[GustavoDevice]LAB16.MOTOR_DOWN", "ns=2;s=[GustavoDevice]LAB16.LOW_LIMIT", "ns=2;s=[GustavoDevice]LAB16.HIGH_LIMIT" };
        private OpcValue[] Lab16Nodes = new OpcValue[9];
        public Lab16Screen()
        {
            InitializeComponent();
            Lbl2Lab16[0] = Lbl2Lab16Test1;
            Lbl2Lab16[1] = Lbl2Lab16Test2;
            Lbl2Lab16[2] = Lbl2Lab16Test3;
            Lbl2Lab16[3] = Lbl2Lab16Test4;
            Lbl2Lab16[4] = Lbl2Lab16Test5;
            Lbl2Lab16[5] = Lbl2Lab16Test6;

            
        }


        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab16Tests.Length; i++)
            {
                if (Lab16Tests[i] != null)
                {
                    string testValue = Lab16Tests[i].ToString();

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
                lblLabStatus.Text = "LAB #16 PASSED";
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
            for (int i = 0; i < Lab16Tests.Length; i++)
            {
                Lab16Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab16.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab16Tests.Length; i++)
            {
                if (Lab16Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab16[i].BackColor = Color.Silver;
                    Lbl2Lab16[i].Text = "NOT RUN";
                }
                if (Lab16Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab16[i].BackColor = Color.LightGreen;
                    Lbl2Lab16[i].Text = "PASSED";
                }
                if (Lab16Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab16[i].BackColor = Color.Red;
                    Lbl2Lab16[i].Text = "FAILED";
                }

                // Fotos
                for (int b = 0; b < Lab16Nodes.Length; b++)
                {
                    Lab16Nodes[b] = client.ReadNode(Lab16NodeIds[b]);
                }

                // Start
                if ((bool)Lab16Nodes[0].Value)
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

                //Object sensor 
                if ((bool)Lab16Nodes[1].Value)
                {
                    PicObjSensor.Image = imageList1.Images[2];
                    lblObjSensor.ForeColor = Color.White;
                    lblObjSensor.BackColor = Color.Green;
                    lblObjSensor.Text = "OBJECT SENSOR ON";
                }
                else
                {
                    PicObjSensor.Image = imageList1.Images[2];
                    lblObjSensor.ForeColor = Color.White;
                    lblObjSensor.BackColor = Color.Red;
                    lblObjSensor.Text = "OBJECT SENSOR OFF";
                }
                //CLAMP SENSOR
                if ((bool)Lab16Nodes[2].Value)
                {
                    PicClampSensor.Image = imageList1.Images[2];
                    lblClampSensor.ForeColor = Color.White;
                    lblClampSensor.BackColor = Color.Green;
                    lblClampSensor.Text = "CLAMP SENSOR ON";
                }
                else
                {
                    PicClampSensor.Image = imageList1.Images[2];
                    lblClampSensor.ForeColor = Color.White;
                    lblClampSensor.BackColor = Color.Red;
                    lblClampSensor.Text = "CLAMP SENSOR OFF";
                }

                //DRILL MOTOR
                if ((bool)Lab16Nodes[3].Value)
                {
                    PicDrill.Image = imageList1.Images[3];
                    lblDrill.ForeColor = Color.White;
                    lblDrill.BackColor = Color.Green;
                    lblDrill.Text = "DRILL MOTOR ON";
                }
                else
                {
                    PicDrill.Image = imageList1.Images[3];
                    lblDrill.ForeColor = Color.White;
                    lblDrill.BackColor = Color.Red;
                    lblDrill.Text = "DRILL MOTOR OFF";
                }

                //CLAMP
                if ((bool)Lab16Nodes[4].Value)
                {
                    PicClamp.Image = imageList1.Images[5];
                    lblClamp.ForeColor = Color.White;
                    lblClamp.BackColor = Color.Green;
                    lblClamp.Text = "CLAMP  ON";
                }
                else
                {
                    PicClamp.Image = imageList1.Images[4];
                    lblClamp.ForeColor = Color.White;
                    lblClamp.BackColor = Color.Red;
                    lblClamp.Text = "CLAMP OFF";
                }
                // UP MOTOR
                if ((bool)Lab16Nodes[5].Value)
                {
                    PicUpMotor.Image = imageList1.Images[3];
                    lblUpMotor.ForeColor = Color.White;
                    lblUpMotor.BackColor = Color.Green;
                    lblUpMotor.Text = "UP MOTOR  ON";
                }
                else
                {
                    PicUpMotor.Image = imageList1.Images[3];
                    lblUpMotor.ForeColor = Color.White;
                    lblUpMotor.BackColor = Color.Red;
                    lblUpMotor.Text = "UP MOTOR OFF";
                }
                // down motor
                if ((bool)Lab16Nodes[6].Value)
                {
                    PicDownMotor.Image = imageList1.Images[3];
                    lblDownMotor.ForeColor = Color.White;
                    lblDownMotor.BackColor = Color.Green;
                    lblDownMotor.Text = "DOWN MOTOR  ON";
                }
                else
                {
                    PicDownMotor.Image = imageList1.Images[3];
                    lblDownMotor.ForeColor = Color.White;
                    lblDownMotor.BackColor = Color.Red;
                    lblDownMotor.Text = "DOWN MOTOR OFF";
                }
                // Up Limit Sensor
                if ((bool)Lab16Nodes[8].Value)
                {
                    PicUpSensor.Image = imageList2.Images[0];
                    lblUpSensor.ForeColor = Color.White;
                    lblUpSensor.BackColor = Color.Green;
                    lblUpSensor.Text = "UP LIMIT  ON";
                }
                else
                {
                    PicUpSensor.Image = imageList2.Images[0];
                    lblUpSensor.ForeColor = Color.White;
                    lblUpSensor.BackColor = Color.Red;
                    lblUpSensor.Text = "UP LIMIT OFF";
                }
                // low Limit Sensor
                if ((bool)Lab16Nodes[7].Value)
                {
                    PicLowSensor.Image = imageList2.Images[0];
                    lblLowSensor.ForeColor = Color.White;
                    lblLowSensor.BackColor = Color.Green;
                    lblLowSensor.Text = "LOW LIMIT  ON";
                }
                else
                {
                    PicLowSensor.Image = imageList2.Images[0];
                    lblLowSensor.ForeColor = Color.White;
                    lblLowSensor.BackColor = Color.Red;
                    lblLowSensor.Text = "LOW LIMIT OFF";
                }
                string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

                switch (nodeValue)
                {
                    case "1601":
                        lblLabMessage.Text = "TOGGLE START, NOTHING SHOULD BE ON.";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1602":
                        lblLabMessage.Text = "TOGGLE OBJECT SENSOR, CLAMP SHOULD TURN ON.";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1603":
                        lblLabMessage.Text = "TOGGLE CLAMP SENSOR AND UPPER LIMIT, DRILLING MOTOR SHOULD TURN ON";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1604":
                        lblLabMessage.Text = "MOTOR DOWN SHOULD TURN ON UNTIL LOW LIMIT IS REACHED.";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1605":
                        lblLabMessage.Text = "LOW LIMIT REACHED, MOTOR UP TURNS ON UNTIL UP LIMIT REACHED. IF HIGH LIMIT REACHED, CLAMP AND DRILL TURNS OFF.";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1606":
                        lblLabMessage.Text = "CLAMP AND DRILL ARE OFF, CLAMP SENSOR AND OBJECT SENSOR SHOULD TURN OFF";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1607":
                        lblLabStatus.Text = "LAB #16 PASSED";
                        lblLabStatus.BackColor = Color.Green;
                        lblLabStatus.ForeColor = Color.White;
                        lblLabMessage.Text = "";
                        lblLabMessage.BackColor = Color.Gray;
                        break;
                }
            }
            }
            private void BtnLab16Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT15";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab16Start.Visible = false;
            BtnLab16Stop.Visible = true;
            TimerLab16.Enabled = true;
        }

        private void BtnLab16Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT15";
            client.WriteNode(tagName, false);
            BtnLab16Start.Visible = true;
            BtnLab16Stop.Visible = false;
            TimerLab16.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab16_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab16Start_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT15";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab16Start.Visible = false;
            BtnLab16Stop.Visible = true;
            TimerLab16.Enabled = true;
        }

        private void BtnLab16Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT15";
            client.WriteNode(tagName, false);
            BtnLab16Start.Visible = true;
            BtnLab16Stop.Visible = false;
            TimerLab16.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab15 = new Lab15Screen();
            Parent.Controls.Add(BackToLab15);
            BackToLab15.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab17Screen();
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this);

        }
    }
}