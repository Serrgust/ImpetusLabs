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
    public partial class Lab19Screen : UserControl
    {
        private OpcValue[] Lab19Tests = new OpcValue[4];
        private Label[] Lbl2Lab19 = new Label[4];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab17NodeIds = new string[7] { "ns=2;s=[GustavoDevice]LAB19.START", "ns=2;s=[GustavoDevice]LAB19.STOP", "ns=2;s=[GustavoDevice]LAB19.OBJECT_SENSOR", "ns=2;s=[GustavoDevice]LAB19.BOX_SENSOR", "ns=2;s=[GustavoDevice]LAB19.M1", "ns=2;s=[GustavoDevice]LAB19.M2", "ns=2;s=[GustavoDevice]LAB19.ACC" };
        private OpcValue[] Lab17Nodes = new OpcValue[7];
        public Lab19Screen()
        {
            InitializeComponent();

            Lbl2Lab19[0] = Lbl2Lab19Test1;
            Lbl2Lab19[1] = Lbl2Lab19Test2;
            Lbl2Lab19[2] = Lbl2Lab19Test3;
            Lbl2Lab19[3] = Lbl2Lab19Test4;

         
        }

        private void UpdateLabStatus()  //Method for updating the LabStatus label
        {
            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab19Tests.Length; i++) //Loop that verifies the test results of the lab

            {
                if (Lab19Tests[i] != null) //Verifys the element if its not null for absence in data
                {
                    string testValue = Lab19Tests[i].ToString(); //Reads and converts the value to string 

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
                lblLabStatus.Text = "LAB #19 PASSED"; //Set the label text to passed 
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
            for (int i = 0; i < Lab19Tests.Length; i++)
            {
                Lab19Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab19.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab19Tests.Length; i++)
            {
                if (Lab19Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab19[i].BackColor = Color.Silver;
                    Lbl2Lab19[i].Text = "NOT RUN";
                }
                if (Lab19Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab19[i].BackColor = Color.DarkGreen;
                    Lbl2Lab19[i].Text = "PASSED";
                }
                if (Lab19Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab19[i].BackColor = Color.Red;
                    Lbl2Lab19[i].Text = "FAILED";
                }
            }
        }

        private void BtnLab19Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT18";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab19Start.Visible = false;
            BtnLab19Stop.Visible = true;
            TimerLab19.Enabled = true;
        }

        private void BtnLab19Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT18";
            client.WriteNode(tagName, false);
            BtnLab19Start.Visible = true;
            BtnLab19Stop.Visible = false;
            TimerLab19.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab19_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackTolab18 = new Lab18Screen();
            Parent.Controls.Add(BackTolab18);
            BackTolab18.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab20Screen();
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this);
            secondUserControl.Dock = DockStyle.Fill;
        }
    }
}