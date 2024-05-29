using ImpetusLabs.LabsScreen;
using Opc.UaFx;
using Opc.UaFx.Client;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImpetusLabs
{
    public partial class Lab01Screen : UserControl
    {
        private OpcValue[] Lab01Tests = new OpcValue[6]; // Array to store test values from OPC Server
        private Label[] Lbl2Lab01 = new Label[6]; // Array to store label control for displaying the results
        private string[] Lab01NodeIds = new string[6]
        {
            "ns=2;s=[GustavoDevice]LAB01.MOTOR1",
            "ns=2;s=[GustavoDevice]LAB01.MOTOR2",
            "ns=2;s=[GustavoDevice]LAB01.START1",
            "ns=2;s=[GustavoDevice]LAB01.START2",
            "ns=2;s=[GustavoDevice]LAB01.STOP1",
            "ns=2;s=[GustavoDevice]LAB01.STOP2"
        };

        public Lab01Screen()
        {
            InitializeComponent();

            // Assign labels to the Lbl2Lab01 array 
            Lbl2Lab01[0] = Lbl2Lab01Test1;
            Lbl2Lab01[1] = Lbl2Lab01Test2;
            Lbl2Lab01[2] = Lbl2Lab01Test3;
            Lbl2Lab01[3] = Lbl2Lab01Test4;
            Lbl2Lab01[4] = Lbl2Lab01Test5;
            Lbl2Lab01[5] = Lbl2Lab01Test6;

            // Ensure the OPC client is connected
            if (!OpcClientManager.IsConnected)
            {
                MessageBox.Show("Please connect to the OPC server first.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void TimerLab01_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void UpdateLabStatus()
        {
            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

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
                lblLabStatus.Text = "LAB #1 PASSED";
                lblLabStatus.BackColor = Color.Green;
                lblLabStatus.ForeColor = Color.White;
            }
            else if (allFailed || anyFailed)
            {
                lblLabStatus.Text = "LAB FAILED";
                lblLabStatus.BackColor = Color.Red;
                lblLabStatus.ForeColor = Color.White;
            }
        }

        private void RefreshLabs()
        {
            UpdateLabStatus();

            try
            {
                OpcValue[] Lab01Nodes = new OpcValue[6];
                for (int i = 0; i < Lab01NodeIds.Length; i++)
                {
                    Lab01Nodes[i] = new OpcValue(OpcClientManager.ReadNode(Lab01NodeIds[i]));
                }

                UpdateImageAndLabel(Lab01Nodes[0], PicMotor1, lblMotor1, "Motor1 ON", "Motor1 OFF", 0, 1);
                UpdateImageAndLabel(Lab01Nodes[1], PicMotor2, lblMotor2, "Motor2 ON", "Motor2 OFF", 1, 0);
                UpdateImageAndLabel(Lab01Nodes[2], PicStart1, lblStart1, "Start1 ON", "Start1 OFF", 3, 2);
                UpdateImageAndLabel(Lab01Nodes[3], PicStart2, lblStart2, "Start2 ON", "Start2 OFF", 5, 4);
                UpdateImageAndLabel(Lab01Nodes[4], PicStop1, lblStop1, "Stop1 ON", "Stop1 OFF", 6, 7);
                UpdateImageAndLabel(Lab01Nodes[5], PicStop2, lblStop2, "Stop2 ON", "Stop2 OFF", 8, 9);

                for (int i = 0; i < Lab01Tests.Length; i++)
                {
                    Lab01Tests[i] = new OpcValue(OpcClientManager.ReadNode("ns=2;s=[GustavoDevice]LAB01.VAR[" + i + "]"));
                }

                UpdateTestResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while refreshing the lab data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateImageAndLabel(OpcValue nodeValue, PictureBox picBox, Label lbl, string onText, string offText, int onImageIndex, int offImageIndex)
        {
            if ((bool)nodeValue.Value)
            {
                picBox.Image = imageList1.Images[onImageIndex];
                lbl.ForeColor = Color.White;
                lbl.BackColor = Color.Green;
                lbl.Text = onText;
            }
            else
            {
                picBox.Image = imageList1.Images[offImageIndex];
                lbl.ForeColor = Color.White;
                lbl.BackColor = Color.Red;
                lbl.Text = offText;
            }
        }

        private void UpdateTestResults()
        {
            for (int i = 0; i < Lab01Tests.Length; i++)
            {
                if (Lab01Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab01[i].BackColor = Color.Silver;
                    Lbl2Lab01[i].Text = "NOT RUN";
                }
                else if (Lab01Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab01[i].BackColor = Color.DarkGreen;
                    Lbl2Lab01[i].Text = "PASSED";
                }
                else if (Lab01Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab01[i].BackColor = Color.Red;
                    Lbl2Lab01[i].Text = "FAILED";
                }
            }

            string nodeValue = OpcClientManager.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

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
                    lblLabStatus.Text = "LAB #1 PASSED";
                    lblLabStatus.BackColor = Color.Green;
                    lblLabStatus.ForeColor = Color.White;
                    lblLabMessage.Text = "";
                    lblLabMessage.BackColor = Color.Gray;
                    break;
            }
        }

        private void BtnLab01Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            OpcClientManager.WriteNode(tagName, true);
            BtnLab01Start.Visible = false;
            BtnLab01Stop.Visible = true;
            TimerLab01.Enabled = true;
        }

        private void BtnLab01Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            OpcClientManager.WriteNode(tagName, false);
            BtnLab01Start.Visible = true;
            BtnLab01Stop.Visible = false;
            TimerLab01.Enabled = false;
            RefreshLabs();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLabSelection = new LabSelection();
            Parent.Controls.Add(BackToLabSelection);
            BackToLabSelection.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab02Screen();
            Parent.Controls.Add(secondUserControl);
            secondUserControl.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }
    }
}
