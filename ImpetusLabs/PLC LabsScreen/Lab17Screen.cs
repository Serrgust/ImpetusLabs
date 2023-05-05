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

            string currentlab = "Lab #17";
            LblCurrentLab.Text = currentlab;
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
                    //        }

                    //        //DRILL MOTOR
                    //        if ((bool)Lab16Nodes[3].Value)
                    //        {
                    //            PicDrill.Image = imageList1.Images[3];
                    //            lblDrill.ForeColor = Color.White;
                    //            lblDrill.BackColor = Color.Green;
                    //            lblDrill.Text = "DRILL MOTOR ON";
                    //        }
                    //        else
                    //        {
                    //            PicDrill.Image = imageList1.Images[3];
                    //            lblDrill.ForeColor = Color.White;
                    //            lblDrill.BackColor = Color.Red;
                    //            lblDrill.Text = "DRILL MOTOR OFF";
                    //        }

                    //        //CLAMP
                    //        if ((bool)Lab16Nodes[4].Value)
                    //        {
                    //            PicClamp.Image = imageList1.Images[5];
                    //            lblClipHold.ForeColor = Color.White;
                    //            lblClipHold.BackColor = Color.Green;
                    //            lblClipHold.Text = "CLAMP  ON";
                    //        }
                    //        else
                    //        {
                    //            PicClamp.Image = imageList1.Images[4];
                    //            lblClipHold.ForeColor = Color.White;
                    //            lblClipHold.BackColor = Color.Red;
                    //            lblClipHold.Text = "CLAMP OFF";
                    //        }
                    //        // UP MOTOR
                    //        if ((bool)Lab16Nodes[5].Value)
                    //        {
                    //            PicUpMotor.Image = imageList1.Images[3];
                    //            lblUpMotor.ForeColor = Color.White;
                    //            lblUpMotor.BackColor = Color.Green;
                    //            lblUpMotor.Text = "UP MOTOR  ON";
                    //        }
                    //        else
                    //        {
                    //            PicUpMotor.Image = imageList1.Images[3];
                    //            lblUpMotor.ForeColor = Color.White;
                    //            lblUpMotor.BackColor = Color.Red;
                    //            lblUpMotor.Text = "UP MOTOR OFF";
                    //        }
                    //        // down motor
                    //        if ((bool)Lab16Nodes[6].Value)
                    //        {
                    //            PicDownMotor.Image = imageList1.Images[3];
                    //            lblMotorBack.ForeColor = Color.White;
                    //            lblMotorBack.BackColor = Color.Green;
                    //            lblMotorBack.Text = "DOWN MOTOR  ON";
                    //        }
                    //        else
                    //        {
                    //            PicDownMotor.Image = imageList1.Images[3];
                    //            lblMotorBack.ForeColor = Color.White;
                    //            lblMotorBack.BackColor = Color.Red;
                    //            lblMotorBack.Text = "DOWN MOTOR OFF";
                    //        }
                    //        // Up Limit Sensor
                    //        if ((bool)Lab16Nodes[8].Value)
                    //        {
                    //            PicUpSensor.Image = imageList2.Images[0];
                    //            lblClipRelease.ForeColor = Color.White;
                    //            lblClipRelease.BackColor = Color.Green;
                    //            lblClipRelease.Text = "UP LIMIT  ON";
                    //        }
                    //        else
                    //        {
                    //            PicUpSensor.Image = imageList2.Images[0];
                    //            lblClipRelease.ForeColor = Color.White;
                    //            lblClipRelease.BackColor = Color.Red;
                    //            lblClipRelease.Text = "UP LIMIT OFF";
                    //        }
                    //        // low Limit Sensor
                    //        if ((bool)Lab16Nodes[7].Value)
                    //        {
                    //            PicLowSensor.Image = imageList2.Images[0];
                    //            lblLowSensor.ForeColor = Color.White;
                    //            lblLowSensor.BackColor = Color.Green;
                    //            lblLowSensor.Text = "LOW LIMIT  ON";
                    //        }
                    //        else
                    //        {
                    //            PicLowSensor.Image = imageList2.Images[0];
                    //            lblLowSensor.ForeColor = Color.White;
                    //            lblLowSensor.BackColor = Color.Red;
                    //            lblLowSensor.Text = "LOW LIMIT OFF";
                    //        }
                    //    }
                    //}
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
    }
}
