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

namespace ImpetusLabs.LabsScreen
{
    public partial class Lab03Screen : UserControl
    {
        private OpcValue[] Lab03Tests = new OpcValue[3];
        private Label[] Lbl2Lab03 = new Label[3];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab03NodeIds = new string[8] { "ns=2;s=[GustavoDevice]LAB03.SW1", "ns=2;s=[GustavoDevice]LAB03.ACK", "ns=2;s=[GustavoDevice]LAB03.LIGHT", "ns=2;s=[GustavoDevice]LAB03.TIMER1.ACC", "ns=2;s=[GustavoDevice]LAB03.TIMER1.EN", "ns=2;s=[GustavoDevice]LAB03.TIMER1.DN", "ns=2;s=[GustavoDevice]LAB03.TIMER1.PRE", "ns=2;s=[GustavoDevice]LAB03.TIMER.TT" };
        private OpcValue[] Lab03Nodes = new OpcValue[8];
     

        public Lab03Screen()
        {
            InitializeComponent();
            Lbl2Lab03[0] = Lbl2Lab03Test1;
            Lbl2Lab03[1] = Lbl2Lab03Test2;
            Lbl2Lab03[2] = Lbl2Lab03Test3;

        }

        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab03Tests.Length; i++)
            {
                if (Lab03Tests[i] != null)
                {
                    string testValue = Lab03Tests[i].ToString();

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
                lblLabStatus.Text = "LAB #3 PASSED";
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


                for (int i = 0; i < Lab03Tests.Length; i++)
                {
                    Lab03Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab03.VAR[" + i + "]");
                }

                for (int i = 0; i < Lab03Tests.Length; i++)
                {
                    if (Lab03Tests[i].ToString().Equals("0"))
                    {
                        Lbl2Lab03[i].BackColor = Color.Silver;
                        Lbl2Lab03[i].Text = "NOT RUN";
                    }
                    if (Lab03Tests[i].ToString().Equals("1"))
                    {
                        Lbl2Lab03[i].BackColor = Color.LightGreen;
                        Lbl2Lab03[i].Text = "PASSED";
                    }
                    if (Lab03Tests[i].ToString().Equals("-1"))
                    {
                        Lbl2Lab03[i].BackColor = Color.Red;
                        Lbl2Lab03[i].Text = "FAILED";
                    }
                }
                for (int b = 0; b < Lab03Nodes.Length; b++)
                {
                    Lab03Nodes[b] = client.ReadNode(Lab03NodeIds[b]);
                }

                //SW1
                if ((bool)Lab03Nodes[0].Value)
                {
                    PicSW1.Image = imageList1.Images[1];
                    lblSW1.ForeColor = Color.White;
                    lblSW1.BackColor = Color.Green;
                    lblSW1.Text = "SW1 ON";
                }
                else
                {
                    PicSW1.Image = imageList1.Images[0];
                    lblSW1.ForeColor = Color.White;
                    lblSW1.BackColor = Color.Red;
                    lblSW1.Text = "SW1 OFF";
                }

                // ACK
                if ((bool)Lab03Nodes[1].Value)
                {
                    PicACK.Image = imageList1.Images[3];
                    lblACK.ForeColor = Color.White;
                    lblACK.BackColor = Color.Green;
                    lblACK.Text = "ACK ON";
                }
                else
                {
                    PicACK.Image = imageList1.Images[2];
                    lblACK.ForeColor = Color.White;
                    lblACK.BackColor = Color.Red;
                    lblACK.Text = "ACK OFF";
                }

                // LIGHT 1
                if ((bool)Lab03Nodes[2].Value)
                {
                    PicLight1.Image = imageList1.Images[4];
                    lblLight.ForeColor = Color.White;
                    lblLight.BackColor = Color.Green;
                    lblLight.Text = "LIGHT ON";
                }
                else
                {
                    PicLight1.Image = imageList1.Images[5];
                    lblLight.ForeColor = Color.White;
                    lblLight.BackColor = Color.Red;
                    lblLight.Text = "LIGHT OFF";
                }


                // lblTimerOut.Text = Lab03Nodes[3].ToString(); // Display TIMER1 ACC value
                lblTimerOut.Text = ((int)Math.Round(Convert.ToDouble(Lab03Nodes[3].Value) / 1000)).ToString();
            }
            string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

            switch (nodeValue)
            {
                case "801":
                    lblLabMessage.Text = "SW1 ON FOR 15 SECONDS, AFTER 15 SECONDS LIGHT SHOULD TURN ON.";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "802":
                    lblLabMessage.Text = "TOGGLE SW1 OFF LIGHT SHOULD REMAIN ON";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "803":
                    lblLabMessage.Text = "TOGGLE ACK BUTTON ON, LIGHT SHOULD TURN OFF";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "804":
                    lblLabStatus.Text = "LAB #3 PASSED";
                    lblLabStatus.BackColor = Color.Green;
                    lblLabStatus.ForeColor = Color.White;
                    lblLabMessage.Text = "";
                    lblLabMessage.BackColor = Color.Gray;
                    break;


            }
        }
 



    private void BtnLab03Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT3";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab03Start.Visible = false;
            BtnLab03Stop.Visible = true;
            TimerLab03.Enabled = true;
            
        }

        private void BtnLab03Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT3";
            client.WriteNode(tagName, false);
            BtnLab03Start.Visible = true;
            BtnLab03Stop.Visible = false;
            TimerLab03.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;

        }

        private void TimerLab03_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var FourthUserControl = new Lab04Screen();
            Parent.Controls.Add(FourthUserControl);
            Parent.Controls.Remove(this);
            FourthUserControl.Dock = DockStyle.Fill;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab02 = new Lab02Screen();
            Parent.Controls.Add(BackToLab02);
            BackToLab02.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }
    }
}
