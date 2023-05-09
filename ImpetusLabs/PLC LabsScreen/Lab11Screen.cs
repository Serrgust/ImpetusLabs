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



    public partial class Lab11Screen : UserControl
    {

        public OpcValue[] Lab11Tests = new OpcValue[5];
        private Label[] Lbl2Lab11 = new Label[5];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab11NodeIds = new string[5] { "ns=2;s=[GustavoDevice]LAB11.FILL", "ns=2;s=[GustavoDevice]LAB11.DRAIN", "ns=2;s=[GustavoDevice]LAB11.L_SWITCH", "ns=2;s=[GustavoDevice]LAB11.H_SWITCH", "ns=2;s=[GustavoDevice]Lab11.TANK_LEVEL" };
        private OpcValue[] Lab11Nodes = new OpcValue[5];
        private int TankHeight;
        public Lab11Screen()
        {
            InitializeComponent();

            Lbl2Lab11[0] = Lbl2Lab11Test1;
            Lbl2Lab11[1] = Lbl2Lab11Test2;
            Lbl2Lab11[2] = Lbl2Lab11Test3;
            Lbl2Lab11[3] = Lbl2Lab11Test4;
            Lbl2Lab11[4] = Lbl2Lab11Test5;


        }

        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab11Tests.Length; i++)
            {
                if (Lab11Tests[i] != null)
                {
                    string testValue = Lab11Tests[i].ToString();

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
                lblLabStatus.Text = "LAB #11 PASSED";
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

            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab11Tests.Length; i++)
            {
                Lab11Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab11.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab11Tests.Length; i++)
            {
                if (Lab11Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab11[i].BackColor = Color.Silver;
                    Lbl2Lab11[i].Text = "NOT RUN";
                }
                if (Lab11Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab11[i].BackColor = Color.LightGreen;
                    Lbl2Lab11[i].Text = "PASSED";
                }
                if (Lab11Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab11[i].BackColor = Color.Red;
                    Lbl2Lab11[i].Text = "FAILED";
                }

            }

            // Fotos
            for (int b = 0; b < Lab11Nodes.Length; b++)
            {
                Lab11Nodes[b] = client.ReadNode(Lab11NodeIds[b]);
            }

            // FILL
            if ((bool)Lab11Nodes[0].Value)
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
            if ((bool)Lab11Nodes[1].Value)
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




            //HighSwitch
            bool hSwitch = (bool)Lab11Nodes[3].Value;
            PicHSwitch.Image = hSwitch ? imageList1.Images[4] : imageList1.Images[5];

            //LowSwitch
            bool lSwitch = (bool)Lab11Nodes[2].Value;
            PicLSwitch.Image = lSwitch ? imageList1.Images[4] : imageList1.Images[5];







            string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

            switch (nodeValue)
            {
                case "1106":
                    lblLabMessage.Text = "TOGGLE START, INLET AND OUTLET VALVES SHOUD BE OFF";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "1107":
                    lblLabMessage.Text = "TOGGLE FILL BUTTON, INLET VALVE SHOULD TURN ON. OUTLET VALVE SHOULD BE OFF";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "1108":
                    lblLabMessage.Text = "WHEN UPPER LIMIT SWITCH IS ACTIVATED, INLET VALVE SHOULD TURN OFF";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1109":
                    lblLabMessage.Text = "TOGGLE DRAIN BUTTON, OUTLET VALVE SHOULD TURN ON. INLET VALVE SHOULD BE OFF";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1110":
                    lblLabMessage.Text = "WHEN LOWER LIMIT SWITCH IS ACTIVATED, OUTLET VALVE SHOULD TURN OFF";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "1105":
                    lblLabStatus.Text = "LAB #11 PASSED";
                    lblLabStatus.BackColor = Color.Green;
                    lblLabStatus.ForeColor = Color.White;
                    lblLabMessage.Text = "";
                    lblLabMessage.BackColor = Color.Gray;
                    break;
            
              

            }

        }



        private void TimerLab11_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab11Start_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT10";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab11Start.Visible = false;
            BtnLab11Stop.Visible = true;
            TimerLab11.Enabled = true;
            TimerFilling.Enabled = true;
        }

        private void BtnLab11Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT10";
            client.WriteNode(tagName, false);
            BtnLab11Start.Visible = true;
            BtnLab11Stop.Visible = false;
            TimerLab11.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void TimerFilling_Tick(object sender, EventArgs e)
        {

            // Check if the Lab11Nodes array has been initialized and has a value at index 4
            if (Lab11Nodes != null && Lab11Nodes.Length > 4 && Lab11Nodes[4] != null && Lab11Nodes[4].Value != null)
            {
                // Read the value of your node and set the ProgressBar value
                double nodeValue = Convert.ToDouble(Lab11Nodes[4].Value);
                verticalProgressBar2.Value = (int)nodeValue;

                // Set the Text property of the label to the percentage value
                lblTankFill.Text = verticalProgressBar2.Value.ToString() + "%";

            }
        }


        private void Lab11Screen_Load(object sender, EventArgs e)
        {

        }

        private void TankLevelBar_Click(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab10 = new Lab10Screen();
            Parent.Controls.Add(BackToLab10);
            BackToLab10.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab12Screen();
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this);

        }
    }
    }



