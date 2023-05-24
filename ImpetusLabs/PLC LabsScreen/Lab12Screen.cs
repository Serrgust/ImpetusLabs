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
using System.Net.NetworkInformation;
using System.Drawing.Drawing2D;
using System.ComponentModel.Design;

namespace ImpetusLabs.LabsScreen
{
    public partial class Lab12Screen : UserControl
    {
        private OpcValue[] Lab12Tests = new OpcValue[3];
        private Label[] Lbl2Lab12 = new Label[3];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab12NodeIds = new string[10] { "ns=2;s=[GustavoDevice]LAB12.FILL", "ns=2;s=[GustavoDevice]LAB12.DRAIN", "ns=2;s=[GustavoDevice]LAB12.L_LEVEL_T1", "ns=2;s=[GustavoDevice]LAB12.H_LEVEL_T1", "ns=2;s=[GustavoDevice]LAB12.L_LEVEL_T2", "ns=2;s=[GustavoDevice]LAB12.INT_VALVE", "ns=2;s=[GustavoDevice]LAB12.IN_VALVE", "ns=2;s=[GustavoDevice]LAB12.OUT_VALVE", "ns=2;s=[GustavoDevice]Lab12.TANK_LEVEL", "ns=2;s=[GustavoDevice]Lab12.TANK_LEVEL2" };
        private OpcValue[] Lab12Nodes = new OpcValue[10];
        public Lab12Screen()
        {
            InitializeComponent();

            Lbl2Lab12[0] = Lbl2Lab12Test1;
            Lbl2Lab12[1] = Lbl2Lab12Test2;
            Lbl2Lab12[2] = Lbl2Lab12Test3;


        }


        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab12Tests.Length; i++)
            {
                if (Lab12Tests[i] != null)
                {
                    string testValue = Lab12Tests[i].ToString();

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
                lblLabStatus.Text = "LAB #12 PASSED";
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
                for (int i = 0; i < Lab12Tests.Length; i++)
                {
                    Lab12Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab12.VAR[" + i + "]");
                }

                for (int i = 0; i < Lab12Tests.Length; i++)
                {
                    if (Lab12Tests[i].ToString().Equals("0"))
                    {
                        Lbl2Lab12[i].BackColor = Color.Silver;
                        Lbl2Lab12[i].Text = "NOT RUN";
                    }
                    if (Lab12Tests[i].ToString().Equals("1"))
                    {
                        Lbl2Lab12[i].BackColor = Color.DarkGreen;
                        Lbl2Lab12[i].Text = "PASSED";
                    }
                    if (Lab12Tests[i].ToString().Equals("-1"))
                    {
                        Lbl2Lab12[i].BackColor = Color.Red;
                        Lbl2Lab12[i].Text = "FAILED";
                    }
                }
                // Fotos
                for (int b = 0; b < Lab12Nodes.Length; b++)
                {
                    Lab12Nodes[b] = client.ReadNode(Lab12NodeIds[b]);
                }

                // FILL
                if ((bool)Lab12Nodes[0].Value)
                {
                    PicFILL.Image = imageList1.Images[1];
                    lblFILL.ForeColor = Color.White;
                    lblFILL.BackColor = Color.Green;
                    lblFILL.Text = "FILL ON";
                }
                else
                {
                    PicFILL.Image = imageList1.Images[0];
                    lblFILL.ForeColor = Color.White;
                    lblFILL.BackColor = Color.Red;
                    lblFILL.Text = "FILL OFF";
                }

                //DRAIN
                if ((bool)Lab12Nodes[1].Value)
                {
                    PicDrain.Image = imageList1.Images[3];
                    lblDRAIN.ForeColor = Color.White;
                    lblDRAIN.BackColor = Color.Green;
                    lblDRAIN.Text = "DRAIN  ON";
                }
                else
                {
                    PicDrain.Image = imageList1.Images[2];
                    lblDRAIN.ForeColor = Color.White;
                    lblDRAIN.BackColor = Color.Red;
                    lblDRAIN.Text = "DRAIN OFF";
                }
                //IN VALVE
                if ((bool)Lab12Nodes[6].Value)
                {
                    PicInvalve.Image = imageList1.Images[4];
                    lblInvalve.ForeColor = Color.White;
                    lblInvalve.BackColor = Color.Green;
                    lblInvalve.Text = "IN VALVE  ON";
                }
                else
                {
                    PicInvalve.Image = imageList1.Images[4];
                    lblInvalve.ForeColor = Color.White;
                    lblInvalve.BackColor = Color.Red;
                    lblInvalve.Text = "IN VALVE OFF";
                }

                //INT valve
                if ((bool)Lab12Nodes[5].Value)
                {
                    PicIntvalve.Image = imageList1.Images[5];
                    lblIntvalve.ForeColor = Color.White;
                    lblIntvalve.BackColor = Color.Green;
                    lblIntvalve.Text = "INT VALVE  ON";
                }
                else
                {
                    PicIntvalve.Image = imageList1.Images[5];
                    lblIntvalve.ForeColor = Color.White;
                    lblIntvalve.BackColor = Color.Red;
                    lblIntvalve.Text = "INT VALVE OFF";
                }

                //OUT valve
                if ((bool)Lab12Nodes[7].Value)
                {
                    PicOutvalve.Image = imageList1.Images[6];
                    lblOutvalve.ForeColor = Color.White;
                    lblOutvalve.BackColor = Color.Green;
                    lblOutvalve.Text = "OUT VALVE  ON";
                }
                else
                {
                    PicOutvalve.Image = imageList1.Images[6];
                    lblOutvalve.ForeColor = Color.White;
                    lblOutvalve.BackColor = Color.Red;
                    lblOutvalve.Text = "OUT VALVE OFF";

                }



                //HighSwitch
                bool hSwitch = (bool)Lab12Nodes[3].Value;
                PicHSwitch.Image = hSwitch ? imageList2.Images[0] : imageList2.Images[1];

                //LowSwitch
                bool lSwitch = (bool)Lab12Nodes[2].Value;
                PicLSwitch.Image = lSwitch ? imageList2.Images[0] : imageList2.Images[1];

                //L2Switch
                bool l2Switch = (bool)Lab12Nodes[4].Value;
                PicLLT2.Image = l2Switch ? imageList2.Images[0] : imageList2.Images[1];

            }
            string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

            switch (nodeValue)
            {
                case "1201":
                    lblLabMessage.Text = "TOGGLE START, INLET AND OUTLET VALVES SHOUD BE OFF";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "1202":
                    lblLabMessage.Text = "TOGGLE FILL, INTLET VALVE AND CONNECTING VALVE ARE ON";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "1203":
                    lblLabMessage.Text = "LOW LIMIT OF TANK 1 IS REACHED. CONNECTING VALVE IS OFF";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1204":
                    lblLabMessage.Text = "HIGH LIMIT OF TANK 1 IS REACHED. INLET VALVE IS OFF";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1205":
                    lblLabMessage.Text = "TOGGLE DRAIN, OUTLET VALVE AND CONNECTING VALVE ARE ON";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1206":
                    lblLabMessage.Text = "LOW LIMIT OF TANK 1 IS REACHED.CONNECTING VALVE IS OFF";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1207":
                    lblLabMessage.Text = "LOW LIMIT OF TANK 2 IS REACHED. OUTLET VALVE IS OFF";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1208":
                    lblLabStatus.Text = "LAB #12 PASSED";
                    lblLabStatus.BackColor = Color.Green;
                    lblLabStatus.ForeColor = Color.White;
                    lblLabMessage.Text = "";
                    lblLabMessage.BackColor = Color.Gray;
                    break;


            }

        }
         
           


        private void TimerLab12_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TimerFilling_Tick(object sender, EventArgs e)
        {
            if (Lab12Nodes != null && Lab12Nodes.Length > 4 && Lab12Nodes[4] != null && Lab12Nodes[4].Value != null &&
                    Lab12Nodes.Length > 8 && Lab12Nodes[8] != null && Lab12Nodes[8].Value != null &&
                    Lab12Nodes.Length > 9 && Lab12Nodes[9] != null && Lab12Nodes[9].Value != null)
                            {
                // Read the value of the TANK_LEVEL and TANK_LEVEL2 nodes and set the maximum value of the ProgressBar controls
                double tankLevel1 = Convert.ToDouble(Lab12Nodes[8].Value);
                double tankLevel2 = Convert.ToDouble(Lab12Nodes[9].Value);
                verticalProgressBar1.Maximum = (int)tankLevel1;
                verticalProgressBar2.Maximum = (int)tankLevel2;

                // Read the value of the Lab12.TANK_LEVEL node and set the ProgressBar value for verticalProgressBar1
                double nodeValue1 = Convert.ToDouble(Lab12Nodes[8].Value);
                verticalProgressBar1.Value = (int)nodeValue1;

                // Read the value of the Lab12.TANK_LEVEL2 node and set the ProgressBar value for verticalProgressBar2
                double nodeValue2 = Convert.ToDouble(Lab12Nodes[9].Value);
                verticalProgressBar2.Value = (int)nodeValue2;

                // Set the Text property of the labels to the percentage value
                lblTankFill.Text = verticalProgressBar1.Value.ToString() + "%";
                lblTankFill2.Text = verticalProgressBar2.Value.ToString() + "%";
            }
        }

        

        private void BtnLab12Start_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT11";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab12Start.Visible = false;
            BtnLab12Stop.Visible = true;
            TimerLab12.Enabled = true;
            TimerFilling.Enabled = true;

        }

        private void BtnLab12Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT11";
            client.WriteNode(tagName, false);
            BtnLab12Start.Visible = true;
            BtnLab12Stop.Visible = false;
            TimerLab12.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab11 = new Lab11Screen();
            Parent.Controls.Add(BackToLab11);
            BackToLab11.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab13Screen();
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this);
            secondUserControl.Dock = DockStyle.Fill;
        }

        private void Lab12Screen_Load(object sender, EventArgs e)
        {

        }
    }
    }

