using ImpetusLabs.LabsScreen;
using Opc.Ua;
using Opc.UaFx;
using Opc.UaFx.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpetusLabs
{
    public partial class Lab01Screen : UserControl
    {
        private OpcValue[] Lab01Tests = new OpcValue[6];
        private Label[] Lbl2Lab01 = new Label[6];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private OpcValue[] Lab01Nodes = new OpcValue[6];
        private string[] Lab01NodeIds = new string[6] { "ns=2;s=[GustavoDevice]LAB01.MOTOR1", "ns=2;s=[GustavoDevice]LAB01.MOTOR2", "ns=2;s=[GustavoDevice]LAB01.START1", "ns=2;s=[GustavoDevice]LAB01.START2", "ns=2;s=[GustavoDevice]LAB01.STOP1", "ns=2;s=[GustavoDevice]LAB01.STOP2" };

        public Lab01Screen()
        {
            InitializeComponent();
            Lbl2Lab01[0] = Lbl2Lab01Test1;
            Lbl2Lab01[1] = Lbl2Lab01Test2;
            Lbl2Lab01[2] = Lbl2Lab01Test3;
            Lbl2Lab01[3] = Lbl2Lab01Test4;
            Lbl2Lab01[4] = Lbl2Lab01Test5;
            Lbl2Lab01[5] = Lbl2Lab01Test6;

            //Lab Display Label
            string currentlab = "Lab #1";

            LblCurrentLab.Text = currentlab;
            //this.BackColor = Color.Gray;
        }

        private void TimerLab01_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void RefreshLabs()

        {


            {
                for (int i = 0; i < Lab01Nodes.Length; i++)
                {
                    Lab01Nodes[i] = client.ReadNode(Lab01NodeIds[i]);
                }

             ////   if ((bool)Lab01Nodes[0].Value) // Motor 1
             //   {
             //       PicStart1.Image = imageList1.Images[1];
             //   }
             //   else
             //   {
             //       PicStart1.Image = imageList1.Images[0];
             //   }

             //   if ((bool)Lab01Nodes[1].Value) // Motor 2
             //   {
             //       PicMotor2.Image = imageList1.Images[1];
             //   }
             //   else
             //   {
             //       PicMotor2.Image = imageList1.Images[0];
             //   }

                if ((bool)Lab01Nodes[2].Value) // Start 1
                {
                    PicStart1.Image = imageList1.Images[1];
                    lblStart1.ForeColor = Color.Green;
                    lblStart1.Text = "Start1 ON";
                }
                else
                {
                    PicStart1.Image = imageList1.Images[0];
                    lblStart1.ForeColor = Color.Red;
                    lblStart1.Text = "Start1 OFF";
                }

                if ((bool)Lab01Nodes[3].Value) // Start 2
                {
                    PicStart2.Image = imageList1.Images[5];
                    lblStart2.ForeColor = Color.Green;
                    lblStart2.Text = "Start2 ON";
                }
                else
                {
                    PicStart2.Image = imageList1.Images[4];
                    lblStart2.ForeColor = Color.Red;
                    lblStart2.Text = "Start2 OFF";
                }

                if ((bool)Lab01Nodes[4].Value) // Stop 1
                {
                    PicStop1.Image = imageList1.Images[3];
                    lblStop1.ForeColor = Color.Green;
                    lblStop1.Text = "Stop1 ON";
                }
                else
                {
                    PicStop1.Image = imageList1.Images[2];
                    lblStop1.ForeColor = Color.Red;
                    lblStop1.Text = "Stop1 OFF";
                }

                if ((bool)Lab01Nodes[5].Value) // Stop 2
                {
                    PicStop2.Image = imageList1.Images[7];
                    lblStop1.ForeColor = Color.Green;
                    lblStop1.Text = "Stop2 ON";
                }
                else
                {
                    PicStop2.Image = imageList1.Images[6];
                    lblStop1.ForeColor = Color.Red;
                    lblStop1.Text = "Stop2 OFF";
                }

                for (int i = 0; i < Lab01Tests.Length; i++)
                {
                    Lab01Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]LAB01.VAR[" + i + "]");
                }

                for (int i = 0; i < Lab01Tests.Length; i++)
                {
                    if (Lab01Tests[i].ToString().Equals("0"))
                    {
                        Lbl2Lab01[i].BackColor = Color.Silver;
                        Lbl2Lab01[i].Text = "NOT RUN";
                    }
                    if (Lab01Tests[i].ToString().Equals("1"))
                    {
                        Lbl2Lab01[i].BackColor = Color.LightGreen;
                        Lbl2Lab01[i].Text = "PASSED";
                    }
                    if (Lab01Tests[i].ToString().Equals("-1"))
                    {
                        Lbl2Lab01[i].BackColor = Color.Red;
                        Lbl2Lab01[i].Text = "FAILED";
                    }
                }
            }
        }

        private void BtnLab01Start_Click(object sender, EventArgs e)
            {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            client.Connect();
            try
            {
                client.Connect();
                client.WriteNode(tagName, true);
            }
            catch (Opc.UaFx.OpcException)
            {
                MessageBox.Show("Connection to OPC UA Server failed");
            }
            BtnLab01Start.Visible = false;
            BtnLab01Stop.Visible = true;
            TimerLab01.Enabled = true;
        }

        private void BtnLab01Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            client.WriteNode(tagName, false);
            BtnLab01Start.Visible = true;
            BtnLab01Stop.Visible = false;
            TimerLab01.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void panelInputOuput_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }


