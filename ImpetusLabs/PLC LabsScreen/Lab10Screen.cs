﻿using Opc.UaFx.Client;
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
    public partial class Lab10Screen : UserControl
    {
        public OpcValue[] Lab10Tests = new OpcValue[8];
        private Label[] Lbl2Lab10 = new Label[8];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab10NodeIds = new string[4] { "ns=2;s=[GustavoDevice]LAB10.GO", "ns=2;s=[GustavoDevice]LAB10.STOP", "ns=2;s=[GustavoDevice]LAB10.MOTOR", "ns=2;s=[GustavoDevice]LAB10.LIGHT" };
        private OpcValue[] Lab10Nodes = new OpcValue[4];


        public Lab10Screen()
        {
            InitializeComponent();

            Lbl2Lab10[0] = Lbl2Lab10Test1;
            Lbl2Lab10[1] = Lbl2Lab10Test2;
            Lbl2Lab10[2] = Lbl2Lab10Test3;
            Lbl2Lab10[3] = Lbl2Lab10Test4;
            Lbl2Lab10[4] = Lbl2Lab10Test5;
            Lbl2Lab10[5] = Lbl2Lab10Test6;
            Lbl2Lab10[6] = Lbl2Lab10Test7;
            Lbl2Lab10[7] = Lbl2Lab10Test8;
        }


        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab10Tests.Length; i++)
            {
                Lab10Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab10.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab10Tests.Length; i++)
            {
                if (Lab10Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab10[i].BackColor = Color.Silver;
                    Lbl2Lab10[i].Text = "NOT RUN";
                }
                if (Lab10Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab10[i].BackColor = Color.LightGreen;
                    Lbl2Lab10[i].Text = "PASSED";
                }
                if (Lab10Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab10[i].BackColor = Color.Red;
                    Lbl2Lab10[i].Text = "FAILED";
                }
            }



            // Fotos
            for (int b = 0; b < Lab10Nodes.Length; b++)
            {
                Lab10Nodes[b] = client.ReadNode(Lab10NodeIds[b]);
            }

            // GO
            if ((bool)Lab10Nodes[0].Value)
            {
                PicGO.Image = imageList1.Images[1];
                lblGO.ForeColor = Color.White;
                lblGO.BackColor = Color.Green;
                lblGO.Text = "GO ON";
            }
            else
            {
                PicGO.Image = imageList1.Images[0];
                lblGO.ForeColor = Color.White;
                lblGO.BackColor = Color.Red;
                lblGO.Text = "GO OFF";
            }

            //STOP
            if ((bool)Lab10Nodes[1].Value)
            {
                PicStop.Image = imageList1.Images[3];
                lblStop.ForeColor = Color.White;
                lblStop.BackColor = Color.Green;
                lblStop.Text = "STOP  ON";
            }
            else
            {
                PicStop.Image = imageList1.Images[2];
                lblStop.ForeColor = Color.White;
                lblStop.BackColor = Color.Red;
                lblStop.Text = "STOP OFF";
            }
            //MOTOR1
            if ((bool)Lab10Nodes[2].Value)
            {
                PicMotor.Image = imageList1.Images[4];
                lblMotor.ForeColor = Color.White;
                lblMotor.BackColor = Color.Green;
                lblMotor.Text = "MOTOR  ON";
            }
            else
            {
                PicMotor.Image = imageList1.Images[4];
                lblMotor.ForeColor = Color.White;
                lblMotor.BackColor = Color.Red;
                lblMotor.Text = "MOTOR  ON";
            }
            //LGHT  
            if ((bool)Lab10Nodes[3].Value)
            {
                PicLight.Image = imageList1.Images[5];
                lblLight.ForeColor = Color.White;
                lblLight.BackColor = Color.Green;
                lblLight.Text = "LIGHT  ON";
            }
            else
            {
                PicLight.Image = imageList1.Images[5];
                lblLight.ForeColor = Color.White;
                lblLight.BackColor = Color.Red;
                lblLight.Text = "LIGHT  OFF";
            }
        }




        

        private void BtnLab10Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT9";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab10Start.Visible = false;
            BtnLab10Stop.Visible = true;
            TimerLab10.Enabled = true;
        }

        private void BtnLab10Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT9";
            client.Connect();
            client.WriteNode(tagName, false);
            BtnLab10Start.Visible = true;
            BtnLab10Stop.Visible = true;
            TimerLab10.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab10_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab10Start_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT9";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab10Start.Visible = false;
            BtnLab10Stop.Visible = true;
            TimerLab10.Enabled = true;
        }

        private void BtnLab10Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT9";
            client.Connect();
            client.WriteNode(tagName, false);
            BtnLab10Start.Visible = true;
            BtnLab10Stop.Visible = true;
            TimerLab10.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void Lab10Screen_Load(object sender, EventArgs e)
        {

        }
    }
}
