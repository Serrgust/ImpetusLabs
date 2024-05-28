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
using System.Windows.Documents;

namespace ImpetusLabs.LabsScreen
{
    public partial class Lab18Screen : UserControl
    {
        private OpcValue[] Lab18Tests = new OpcValue[7];
        private Label[] Lbl2Lab18 = new Label[7];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab18NodeIds = new string[10] { "ns=2;s=[GustavoDevice]LAB18.START", "ns=2;s=[GustavoDevice]LAB18.STOP", "ns=2;s=[GustavoDevice]LAB18.", "ns=2;s=[GustavoDevice]LAB17.CONVEYOR", "ns=2;s=[GustavoDevice]LAB17.CLIP_HOLD", "ns=2;s=[GustavoDevice]LAB17.CLIP_RELEASE", "ns=2;s=[GustavoDevice]LAB17.MOTOR_FORWARD", "ns=2;s=[GustavoDevice]LAB17.MOTOR_REVERSE", "ns=2;s=[GustavoDevice]LAB17.WATER", "ns=2;s=[GustavoDevice]LAB17.CYLINDER" };
        private OpcValue[] Lab18Nodes = new OpcValue[10];
        public Lab18Screen()
        {
            InitializeComponent();

            Lbl2Lab18[0] = Lbl2Lab18Test1;
            Lbl2Lab18[1] = Lbl2Lab18Test2;
            Lbl2Lab18[2] = Lbl2Lab18Test3;
            Lbl2Lab18[3] = Lbl2Lab18Test4;
            Lbl2Lab18[4] = Lbl2Lab18Test5;
            Lbl2Lab18[5] = Lbl2Lab18Test6;
            Lbl2Lab18[6] = Lbl2Lab18Test7;

            string currenlab = "Lab #18";
            LblCurrentLab.Text = currenlab;
        }

        private void UpdateLabStatus()  //Method for updating the LabStatus label
        {
            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab18Tests.Length; i++) //Loop that verifies the test results of the lab

            {
                if (Lab18Tests[i] != null) //Verifys the element if its not null for absence in data
                {
                    string testValue = Lab18Tests[i].ToString(); //Reads and converts the value to string 

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

            if (allPassed) //If all test value equals "1", it will display the following:
            {
                lblLabStatus.Text = "LAB #18 PASSED"; //Set the label text to passed 
                lblLabStatus.BackColor = Color.Green; //Set label color Green.
                lblLabStatus.ForeColor = Color.White;  //Set label text color to White. 
            }
            else if (allFailed) //If all test vaule equals "0", it  will display the following:
            {
                lblLabStatus.Text = "LAB FAILED"; //Set the label text to failed.
                lblLabStatus.BackColor = Color.Red; //Set the label color to Red.
                lblLabStatus.ForeColor = Color.White; //Set the label color to White.
            }
            else if (anyFailed) //If any test value equals "-1", it will fail the lab 
            {
                lblLabStatus.Text = "LAB FAILED"; //Set the label text to Failed
                lblLabStatus.BackColor = Color.Red;  //Set the label color to Red.
                lblLabStatus.ForeColor = Color.White; //Set the label color to White.
            }
        }

        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab18Tests.Length; i++)
            {
                Lab18Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab18.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab18Tests.Length; i++)
            {
                if (Lab18Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab18[i].BackColor = Color.Silver;
                    Lbl2Lab18[i].Text = "NOT RUN";
                }
                if (Lab18Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab18[i].BackColor = Color.DarkGreen;
                    Lbl2Lab18[i].Text = "PASSED";
                }
                if (Lab18Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab18[i].BackColor = Color.Red;
                    Lbl2Lab18[i].Text = "FAILED";
                }

                //Inputs and Outputs



            }
        }
        private void BtnLab18Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT17";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab18Start.Visible = false;
            BtnLab18Stop.Visible = true;
            TimerLab18.Enabled = true;
        }

        private void BtnLab18Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT17";
            client.WriteNode(tagName, false);
            BtnLab18Start.Visible = true;
            BtnLab18Stop.Visible = false;
            TimerLab18.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab18_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackTolab17 = new Lab17Screen();
            Parent.Controls.Add(BackTolab17);
            BackTolab17.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }
        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab19Screen();
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this);
            secondUserControl.Dock = DockStyle.Fill;
        }

    }
}
