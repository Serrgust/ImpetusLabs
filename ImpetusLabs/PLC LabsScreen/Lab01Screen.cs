﻿using ImpetusLabs.LabsScreen;
using Opc.Ua;
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

namespace ImpetusLabs
{
    public partial class Lab01Screen : UserControl
    {
        private OpcValue[] Lab01Tests = new OpcValue[6];
        private Label[] Lbl2Lab01 = new Label[6];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");

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

                    OpcValue nodeValueMotor = client.ReadNode("ns=2;s=[GustavoDevice]LAB01.MOTOR1");
                    OpcValue nodeValueStart = client.ReadNode("ns=2;s=[GustavoDevice]LAB01.START1");

                    bool isMotorValueTrue = (bool)nodeValueMotor.Value;
                    bool isStartValueTrue = (bool)nodeValueStart.Value;

                    //if (isMotorValueTrue)
                    //{
                    //    PicMotor1.Image = Image.FromFile(@"C:\Users\lopez\source\repos\Impetus lab images implementation\ImpetusLabs\Forms\SymbolFactoryGreatValue\Motor.jpg");
                    //}
                    //else
                    //{
                    //    PicMotor2.Image = Image.FromFile(@"C:\Users\lopez\source\repos\Impetus lab images implementation\ImpetusLabs\Forms\SymbolFactoryGreatValue\Motor.jpg");
                    //}

                    if (isStartValueTrue)
                    { 
                        PicStart1.Image = Image.FromFile(@"C:\Users\lopez\source\repos\Impetus lab images implementation\ImpetusLabs\Forms\SymbolFactoryGreatValue\pushbutton (Green Up off).jpg");
                        //LblStart1.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        PicStart1.Image = Image.FromFile(@"C:\Users\lopez\source\repos\Impetus lab images implementation\ImpetusLabs\Forms\SymbolFactoryGreatValue\pushbutton (Green Up On).jpg");
                        //LblStart1.BackColor = Color.Red;
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


