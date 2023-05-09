using Opc.UaFx;
using Opc.UaFx.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpetusLabs.LabsScreen
{
    public partial class Lab04Screen : UserControl
    {
        private OpcValue[] Lab04Tests = new OpcValue[7];
        private Label[] Lbl2Lab04 = new Label[7];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab04NodeIds = new string[6] { "ns=2;s=[GustavoDevice]LAB04.START", "ns=2;s=[GustavoDevice]LAB04.SECONDS.ACC", "ns=2;s=[GustavoDevice]LAB04.MINUTES.ACC", "ns=2;s=[GustavoDevice]LAB04.HOURS.ACC", "ns=2;s=[GustavoDevice]LAB04.DAYS.ACC", "ns=2;s=[GustavoDevice]LAB04.RESET" };
        private OpcValue[] Lab04Nodes = new OpcValue[6];

        public Lab04Screen()
        {
            InitializeComponent();
            Lbl2Lab04[0] = Lbl2Lab04Test1;
            Lbl2Lab04[1] = Lbl2Lab04Test2;
            Lbl2Lab04[2] = Lbl2Lab04Test3;
            Lbl2Lab04[3] = Lbl2Lab04Test4;
            Lbl2Lab04[4] = Lbl2Lab04Test5;
            Lbl2Lab04[5] = Lbl2Lab04Test6;
            Lbl2Lab04[6] = Lbl2Lab04Test7;



        }

        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab04Tests.Length; i++)
            {
                if (Lab04Tests[i] != null)
                {
                    string testValue = Lab04Tests[i].ToString();

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
                lblLabStatus.Text = "LAB #4 PASSED";
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

            for (int i = 0; i < Lab04Tests.Length; i++)
            {
                Lab04Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab04.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab04Tests.Length; i++)
            {
                if (Lab04Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab04[i].BackColor = Color.Silver;
                    Lbl2Lab04[i].Text = "NOT RUN";
                }
                if (Lab04Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab04[i].BackColor = Color.LightGreen;
                    Lbl2Lab04[i].Text = "PASSED";
                }
                if (Lab04Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab04[i].BackColor = Color.Red;
                    Lbl2Lab04[i].Text = "FAILED";
                }
            }
            for (int b = 0; b < Lab04Nodes.Length; b++)
            {
                Lab04Nodes[b] = client.ReadNode(Lab04NodeIds[b]);
            }

            // START 
            if ((bool)Lab04Nodes[0].Value)
            {
                PicTimer1.Image = imageList1.Images[1];
                lblTimer1.ForeColor = Color.White;
                lblTimer1.BackColor = Color.Green;
                lblTimer1.Text = "TIMER ON";
            }
            else
            {
                PicTimer1.Image = imageList1.Images[0];
                lblTimer1.ForeColor = Color.White;
                lblTimer1.BackColor = Color.Red;
                lblTimer1.Text = "TIMER OFF";
            }
                //Reset
            if ((bool)Lab04Nodes[5].Value)
            {
                PicReset.Image = imageList1.Images[3];
                lblReset.ForeColor = Color.White;
                lblReset.BackColor = Color.Green;
                lblReset.Text = "RESET  ON";
            }
            else
            {
                PicReset.Image = imageList1.Images[2];
                lblReset.ForeColor = Color.White;
                lblReset.BackColor = Color.Red;
                lblReset.Text = "RESET OFF";
            }



            // SECONDS
            lblTimerState.Text = Lab04Nodes[1].ToString();

            // MINUTES
            lblMinutes.Text = Lab04Nodes[2].ToString();

            // HOURS
            lblHours.Text = Lab04Nodes[3].ToString();

            // DAYS
            lblDays.Text = Lab04Nodes[4].ToString();


            if (Convert.ToInt32(Lab04Nodes[4].ToString()) >= 50)
            {
                PicDaysDone.Image = imageList1.Images[5]; //on 
                MessageBox.Show("FUCK PIERLUISI AND JENNIFER GONZALE");
            }
            else
            {
                PicDaysDone.Image = imageList1.Images[4];  //off  
            }

            string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

            switch (nodeValue)
            {
                case "701":
                    lblLabMessage.Text = "TESTING START_CLOCK BUTTON";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "702":
                    lblLabMessage.Text = "TESTING RETENTIVE ACTION";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "703":
                    lblLabMessage.Text = "TESTING MINUTE COUNTER";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "704":
                    lblLabMessage.Text = "TESTING HOUR COUNTER";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "705":
                    lblLabMessage.Text = "TESTING DAY COUNTER";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "706":
                    lblLabMessage.Text = "TESTING 50 DAY COUNTER";
                    lblLabMessage.ForeColor = Color.White;
                    lblLabMessage.BackColor = Color.Black;
                    break;
                case "707":
                    lblLabMessage.Text = "TESTING RESET BUTTON";
                    lblLabMessage.BackColor = Color.Black;
                    lblLabMessage.ForeColor = Color.White;
                    break;
                case "708":
                    lblLabStatus.Text = "LAB #4 PASSED";
                    lblLabStatus.BackColor = Color.Green;
                    lblLabStatus.ForeColor = Color.White;
                    lblLabMessage.Text = "";
                    lblLabMessage.BackColor = Color.Gray;
                    break;

            }
        }
    

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

      

        private void TimerLab04_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab04Start_Click_1(object sender, EventArgs e)
        {

            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT4";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab04Start.Visible = false;
            BtnLab04Stop.Visible = true;
            TimerLab04.Enabled = true;
        }

        private void BtnLab04Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT4";
            client.WriteNode(tagName, false);
            BtnLab04Start.Visible = true;
            BtnLab04Stop.Visible = false;
            TimerLab04.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var FifthUserControl = new Lab05Screen();
            Parent.Controls.Add(FifthUserControl);
            Parent.Controls.Remove(this);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab03 = new Lab03Screen();
            Parent.Controls.Add(BackToLab03);
            BackToLab03.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }
    }
}
