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
    public partial class Lab02Screen : UserControl
    {
        private OpcValue[] Lab02Tests = new OpcValue[2];
        private Label[] Lbl2Lab02 = new Label[2];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private OpcValue[] Lab02Nodes = new OpcValue[6];
        private string[] Lab02NodeIds = new string[6] { "ns=2;s=[GustavoDevice]LAB02.START", "ns=2;s=[GustavoDevice]LAB02.TIMER1.ACC", "ns=2;s=[GustavoDevice]LAB02.TIMER1.DN", "ns=2;s=[GustavoDevice]LAB02.TIMER1.EN", "ns=2;s=[GustavoDevice]LAB02.TIMER1.PRE", "ns=2;s=[GustavoDevice]LAB02.TIMER.TT" };

        public Lab02Screen()
        {
            InitializeComponent();

            Lbl2Lab02[0] = Lbl2Lab02Test1;
            Lbl2Lab02[1] = Lbl2Lab02Test2;


        
        }

        private void UpdateLabStatus() //Method for updating the LabStatus label
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab02Tests.Length; i++)
            {
                if (Lab02Tests[i] != null)
                {
                    string testValue = Lab02Tests[i].ToString(); //it checks the value of Lab02Test and assigns it to variable testValue

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
                lblLabStatus.Text = "LAB #2 PASSED";
                lblLabStatus.BackColor = Color.Green;
                lblLabStatus.ForeColor = Color.White;
            }
            else if (allFailed)
            {
                lblLabStatus.Text = "LAB FALED";
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
                for (int i = 0; i < Lab02Tests.Length; i++)
                {
                    Lab02Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab02.VAR[" + i + "]");
                }

                for (int i = 0; i < Lab02Tests.Length; i++)
                {
                    if (Lab02Tests[i].ToString().Equals("0"))
                    {
                        Lbl2Lab02[i].BackColor = Color.Silver;
                        Lbl2Lab02[i].Text = "NOT RUN";
                    }
                    if (Lab02Tests[i].ToString().Equals("1"))
                    {
                        Lbl2Lab02[i].BackColor = Color.DarkGreen;
                        Lbl2Lab02[i].Text = "PASSED";
                    }
                    if (Lab02Tests[i].ToString().Equals("-1"))
                    {
                        Lbl2Lab02[i].BackColor = Color.Red;
                        Lbl2Lab02[i].Text = "FAILED";

                    }

                    for (int b = 0; b < Lab02Nodes.Length; b++)
                    {
                        Lab02Nodes[b] = client.ReadNode(Lab02NodeIds[b]);
                    }

                    if ((bool)Lab02Nodes[0].Value) // Start
                    {
                        PicTimer1.Image = imageList1.Images[1]; // Green button ON
                        lblTimer1.ForeColor = Color.White;
                        lblTimer1.BackColor = Color.Green;
                        lblTimer1.Text = "TIMER ON";
                    }
                    else
                    {
                        PicTimer1.Image = imageList1.Images[0]; // Green button OFF
                        lblTimer1.ForeColor = Color.White;
                        lblTimer1.BackColor = Color.Red;
                        lblTimer1.Text = "TIMER OFF";
                    }

                    lblOutSeconds.Text = Lab02Nodes[1].ToString(); // Display TIMER1.ACC value
                }

            }
            string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

            switch (nodeValue)
            {
                case "601":
                    lblLabMessage.Text = "TURN ON START TIMER BIT, TIMER1 SHOULD START.";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "602":
                    lblLabMessage.Text = "TURN OFF START TIMER BIT, TIMER1 ACCUMULATOR SHOULD RESET TO ZERO";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "603":
                    lblLabStatus.Text = "LAB #2 PASSED";
                    lblLabStatus.BackColor = Color.Green;
                    lblLabStatus.ForeColor = Color.White;
                    lblLabMessage.Text = "";
                    lblLabMessage.BackColor = Color.Gray;
                    break;

            }
        }

       

        private void BtnLab02Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT2";
            client.WriteNode(tagName, false);
            BtnLab02Start.Visible = true;
            BtnLab02Stop.Visible = false;
            TimerLab02.Enabled = false;
            RefreshLabs();
            
        }

       
        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab01 = new Lab01Screen();
            Parent.Controls.Add(BackToLab01);
            BackToLab01.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }

        private void TimerLab02_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab02Start_Click_1(object sender, EventArgs e)
        {
            {
                var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT2";
                client.Connect();
                client.WriteNode(tagName, true);
                BtnLab02Start.Visible = false;
                BtnLab02Stop.Visible = true;
                TimerLab02.Enabled = true;
                
            }
        }

        private void BtnLab02Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT2";
            client.WriteNode(tagName, false);
            BtnLab02Start.Visible = true;
            BtnLab02Stop.Visible = false;
            TimerLab02.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var ThirdUserControl = new Lab03Screen();
            Parent.Controls.Add(ThirdUserControl);
            Parent.Controls.Remove(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
 }
