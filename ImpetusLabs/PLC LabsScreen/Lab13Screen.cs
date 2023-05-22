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
    public partial class Lab13Screen : UserControl
    {
        private OpcValue[] Lab13Tests = new OpcValue[7];
        private Label[] Lbl2Lab13 = new Label[7];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab13NodeIds = new string[9] { "ns=2;s=[GustavoDevice]LAB13.START", "ns=2;s=[GustavoDevice]LAB13.START_DETECT", "ns=2;s=[GustavoDevice]LAB13.END_DETECT", "ns=2;s=[GustavoDevice]LAB13.SOAP", "ns=2;s=[GustavoDevice]LAB13.WATER", "ns=2;s=[GustavoDevice]LAB13.ROLLERS", "ns=2;s=[GustavoDevice]LAB13.CONVEYOR", "ns=2;s=[GustavoDevice]LAB13.DRYER", "ns=2;s=[GustavoDevice]LAB13.TIMER1.ACC" };
        private OpcValue[] Lab13Nodes = new OpcValue[9];
        public Lab13Screen()
        {
            InitializeComponent();

            Lbl2Lab13[0] = Lbl2Lab13Test1;
            Lbl2Lab13[1] = Lbl2Lab13Test2;
            Lbl2Lab13[2] = Lbl2Lab13Test3;
            Lbl2Lab13[3] = Lbl2Lab13Test4;
            Lbl2Lab13[4] = Lbl2Lab13Test5;
            Lbl2Lab13[5] = Lbl2Lab13Test6;
            Lbl2Lab13[6] = Lbl2Lab13Test7;




        }


        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab13Tests.Length; i++)
            {
                if (Lab13Tests[i] != null)
                {
                    string testValue = Lab13Tests[i].ToString();

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
                lblLabStatus.Text = "LAB #13 PASSED";
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
;
            { 
            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab13Tests.Length; i++)
            {
                Lab13Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab13.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab13Tests.Length; i++)
            {
                if (Lab13Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab13[i].BackColor = Color.Silver;
                    Lbl2Lab13[i].Text = "NOT RUN";
                }
                if (Lab13Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab13[i].BackColor = Color.LightGreen;
                    Lbl2Lab13[i].Text = "PASSED";
                }
                if (Lab13Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab13[i].BackColor = Color.Red;
                    Lbl2Lab13[i].Text = "FAILED";
                }
            }

            // Fotos
            for (int b = 0; b < Lab13Nodes.Length; b++)
            {
                Lab13Nodes[b] = client.ReadNode(Lab13NodeIds[b]);
            }

            // Start
            if ((bool)Lab13Nodes[0].Value)
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

            //Sensor 1
            if ((bool)Lab13Nodes[1].Value)
            {
                PicSensor1.Image = imageList1.Images[2];
                lblSensor1.ForeColor = Color.White;
                lblSensor1.BackColor = Color.Green;
                lblSensor1.Text = "SENSOR  ON";
            }
            else
            {
                PicSensor1.Image = imageList1.Images[2];
                lblSensor1.ForeColor = Color.White;
                lblSensor1.BackColor = Color.Red;
                lblSensor1.Text = "SENSOR OFF";
            }
            //Sensor 2
            if ((bool)Lab13Nodes[2].Value)
            {
                PicSensor2.Image = imageList1.Images[2];
                lblSensor2.ForeColor = Color.White;
                lblSensor2.BackColor = Color.Green;
                lblSensor2.Text = "SENSOR ON";
            }
            else
            {
                PicSensor2.Image = imageList1.Images[2];
                lblSensor2.ForeColor = Color.White;
                lblSensor2.BackColor = Color.Red;
                lblSensor2.Text = "SENSOR OFF";
            }

            //SOAP
            if ((bool)Lab13Nodes[3].Value)
            {
                PicSoap.Image = imageList1.Images[3];
                lblSoap.ForeColor = Color.White;
                lblSoap.BackColor = Color.Green;
                lblSoap.Text = "SOAP  ON";
            }
            else
            {
                PicSoap.Image = imageList1.Images[3];
                lblSoap.ForeColor = Color.White;
                lblSoap.BackColor = Color.Red;
                lblSoap.Text = "SOAP OFF";
            }

            //WATER
            if ((bool)Lab13Nodes[4].Value)
            {
                PicWater.Image = imageList1.Images[4];
                lblWater.ForeColor = Color.White;
                lblWater.BackColor = Color.Green;
                lblWater.Text = "WATER  ON";
            }
            else
            {
                PicWater.Image = imageList1.Images[5];
                lblWater.ForeColor = Color.White;
                lblWater.BackColor = Color.Red;
                lblWater.Text = "WATER OFF";

            }
            //ROLLER
            if ((bool)Lab13Nodes[5].Value)
            {
                PicRollers.Image = imageList1.Images[6];
                lblRollers.ForeColor = Color.White;
                lblRollers.BackColor = Color.Green;
                lblRollers.Text = "ROLLERS  ON";
            }
            else
            {
                PicRollers.Image = imageList1.Images[6];
                lblRollers.ForeColor = Color.White;
                lblRollers.BackColor = Color.Red;
                lblRollers.Text = "ROLLERS OFF";

            }
            //MOTOR
            if ((bool)Lab13Nodes[6].Value)
            {
                PicMotor.Image = imageList1.Images[7];
                lblMotor.ForeColor = Color.White;
                lblMotor.BackColor = Color.Green;
                lblMotor.Text = "MOTOR ON";
            }
            else
            {
                PicMotor.Image = imageList1.Images[7];
                lblMotor.ForeColor = Color.White;
                lblMotor.BackColor = Color.Red;
                lblMotor.Text = "MOTOR OFF";

            }

            //Dryer
            if ((bool)Lab13Nodes[7].Value)
            {
                PicDryer.Image = imageList1.Images[8];
                lblDryer.ForeColor = Color.White;
                lblDryer.BackColor = Color.Green;
                lblDryer.Text = "DRYER ON";
            }
            else
            {
                PicDryer.Image = imageList1.Images[8];
                lblDryer.ForeColor = Color.White;
                lblDryer.BackColor = Color.Red;
                lblDryer.Text = "DRYER OFF";

            }

            lblTimer.Text = ((int)Math.Round(Convert.ToDouble(Lab13Nodes[8].Value) / 1000)).ToString();
        }
            string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

            switch (nodeValue)
            {
                case "1301":
                    lblLabMessage.Text = "TOGGLE START, TOGGLE START CAR DETECTION, CONVEYOR SHOULD BE ON.";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "1302":
                    lblLabMessage.Text = "WATER SPRINKLER SHOULD BE ON FOR 10 SECONDS";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "1303":
                    lblLabMessage.Text = "SOAP SPRINKLER SHOULD BE ON FOR 5 SECONDS";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1304":
                    lblLabMessage.Text = "CLEANING ROLLERS SHOULD BE ON FOR 10 SECONDS";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1305":
                    lblLabMessage.Text = "WATER SPRINKLER SHOULD BE ON AGAIN FOR 10 SECONDS";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1306":
                    lblLabMessage.Text = "CONVEYOR STOPS AND DRYER TURNS ON FOR 15 SECONDS";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1307":
                    lblLabMessage.Text = "CONVEYOR TURNS ON AGAIN UNTIL END CAR DETECTION IS ACTIVATED";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1308":
                    lblLabStatus.Text = "LAB #13 PASSED";
                    lblLabStatus.BackColor = Color.Green;
                    lblLabStatus.ForeColor = Color.White;
                    lblLabMessage.Text = "";
                    lblLabMessage.BackColor = Color.Gray;
                    break;


            }

            }


        private void TimerLab13_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblMotor_Click(object sender, EventArgs e)
        {

        }

        private void BtnLab13Start_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT12";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab13Start.Visible = false;
            BtnLab13Stop.Visible = true;
            TimerLab13.Enabled = true;
        }

        private void BtnLab13Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT12";
            client.WriteNode(tagName, false);
            BtnLab13Start.Visible = true;
            BtnLab13Stop.Visible = false;
            TimerLab13.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab12 = new Lab12Screen();
            Parent.Controls.Add(BackToLab12);
            BackToLab12.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab14Screen();
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this);
            secondUserControl.Dock = DockStyle.Fill;

        }
    }
}
