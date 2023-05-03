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
using Xamarin.Forms.Internals;

namespace ImpetusLabs.LabsScreen
{//Jose was here 
    public partial class Lab08Screen : UserControl
    {
        public OpcValue[] Lab08Tests = new OpcValue[4];
        private Label[] Lbl2Lab08 = new Label[4];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab08NodeIds = new string[6] { "ns=2;s=[GustavoDevice]LAB08.START", "ns=2;s=[GustavoDevice]LAB08.PART_SENSOR", "ns=2;s=[GustavoDevice]LAB08.HEAT", "ns=2;s=[GustavoDevice]LAB08.SPRAY", "ns=2;s=[GustavoDevice]LAB08.CLAMP", "ns=2;s=[GustavoDevice]LAB08.M1" };
        private OpcValue[] Lab08Nodes = new OpcValue[6];

        public Lab08Screen()
        {
            InitializeComponent();
            
            Lbl2Lab08[0] = Lbl2Lab08Test1;
            Lbl2Lab08[1] = Lbl2Lab08Test2;
            Lbl2Lab08[2] = Lbl2Lab08Test3;
            Lbl2Lab08[3] = Lbl2Lab08Test4;
        }


        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab08Tests.Length; i++)
            {
                if (Lab08Tests[i] != null)
                {
                    string testValue = Lab08Tests[i].ToString();

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
                lblLabStatus.Text = "LAB #8 PASSED";
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

            for (int i = 0; i < Lab08Tests.Length; i++)
            {
                Lab08Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]LAB08.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab08Tests.Length; i++)
            {
                if (Lab08Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab08[i].BackColor = Color.Silver;
                    Lbl2Lab08[i].Text = "NOT RUN";
                }
                if (Lab08Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab08[i].BackColor = Color.LightGreen;
                    Lbl2Lab08[i].Text = "PASSED";
                }
                if (Lab08Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab08[i].BackColor = Color.Red;
                    Lbl2Lab08[i].Text = "FAILED";
                }
            }
            // Fotos
            for (int b = 0; b < Lab08Nodes.Length; b++)
            {
                Lab08Nodes[b] = client.ReadNode(Lab08NodeIds[b]);
            }

            // start on
            if ((bool)Lab08Nodes[0].Value)
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

            //SENSOR
            if ((bool)Lab08Nodes[1].Value)
            {
                PicSensor.Image = imageList1.Images[2];
                lblSensor.ForeColor = Color.White;
                lblSensor.BackColor = Color.Green;
                lblSensor.Text = "SENSOR  ON";
            }
            else
            {
                PicSensor.Image = imageList1.Images[2];
                lblSensor.ForeColor = Color.White;
                lblSensor.BackColor = Color.Red;
                lblSensor.Text = "SENSOR OFF";
            }
            //HEATER
            if ((bool)Lab08Nodes[2].Value)
            {
                PicHeater.Image = imageList1.Images[3];
                lblHeater.ForeColor = Color.White;
                lblHeater.BackColor = Color.Green;
                lblHeater.Text = "HEATER  ON";
            }
            else
            {
                PicHeater.Image = imageList1.Images[4];
                lblHeater.ForeColor = Color.White;
                lblHeater.BackColor = Color.Red;
                lblHeater.Text = "HEATER OFF";
            }
            //SPRAY NOZZLE  
            if ((bool)Lab08Nodes[3].Value)
            {
                PicSpray.Image = imageList1.Images[6];
                lblSpray.ForeColor = Color.White;
                lblSpray.BackColor = Color.Green;
                lblSpray.Text = "SPRAY ON";
            }
            else
            {
                PicSpray.Image = imageList1.Images[5];
                lblSpray.ForeColor = Color.White;
                lblSpray.BackColor = Color.Red;
                lblSpray.Text = "SPRAY  OFF";
            }
            //Clamp
            if ((bool)Lab08Nodes[4].Value)
            {
                PicClamp.Image = imageList1.Images[7];
                lblClamp.ForeColor = Color.White;
                lblClamp.BackColor = Color.Green;
                lblClamp.Text = "CLAMP  ON";
            }
            else
            {
                PicClamp.Image = imageList1.Images[8];
                lblClamp.ForeColor = Color.White;
                lblClamp.BackColor = Color.Red;
                lblClamp.Text = "CLAMP OFF";
            }
            //MOTOR
            if ((bool)Lab08Nodes[5].Value)
            {
                PicHeater.Image = imageList1.Images[9];
                lblHeater.ForeColor = Color.White;
                lblHeater.BackColor = Color.Green;
                lblHeater.Text = "MOTOR  ON";
            }
            else
            {
                PicHeater.Image = imageList1.Images[9];
                lblHeater.ForeColor = Color.White;
                lblHeater.BackColor = Color.Red;
                lblHeater.Text = "MOTOR OFF";
            }

            string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

            switch (nodeValue)
            {
                case "81":
                    lblLabMessage.Text = "TOGGLE START, MOTOR1 SHOULD TURN ON";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "82":
                    lblLabMessage.Text = "SENSOR IS ACTIVATED, MOTOR TURNS OFF AND CLAMP TURNS ON FOR 10 SECONDS";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "83":
                    lblLabMessage.Text = "SPRAY TURNS ON FOR 2 SECONDS";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "84":
                    lblLabMessage.Text = "HEAT TURNS ON FOR 8 SECONDS. AFTER 8 SECONDS, HEAT AND CLAMP TURNS OFF AND MOTOR TURNS ON";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "85":
                    lblLabStatus.Text = "LAB #8 PASSED";
                    lblLabStatus.BackColor = Color.Green;
                    lblLabStatus.ForeColor = Color.White;
                    lblLabMessage.Text = "";
                    lblLabMessage.BackColor = Color.Gray;
                    break;

            }
        }



        private void TimerLab08_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab08Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT19";
            client.WriteNode(tagName, false);
            BtnLab08Start.Visible = true;
            BtnLab08Stop.Visible = false;
            TimerLab08.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }
    

        private void BtnLab08Start_Click_1(object sender, EventArgs e)
        {

        var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT19";
        client.Connect();
        client.WriteNode(tagName, true);
        BtnLab08Start.Visible = false;
        BtnLab08Stop.Visible = true;
        TimerLab08.Enabled = true; 


    }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab07 = new Lab07Screen();
            Parent.Controls.Add(BackToLab07);
            BackToLab07.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }
    }

}
