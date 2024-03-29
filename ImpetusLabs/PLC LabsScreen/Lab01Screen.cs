﻿using ImpetusLabs.LabsScreen;
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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ImpetusLabs
{
    public partial class Lab01Screen : UserControl
    {
        private OpcValue[] Lab01Tests = new OpcValue[6]; //Array to store test values from OPC Server
        private Label[] Lbl2Lab01 = new Label[6]; //Array to store label control for displaying the results
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1"); //Communication with the OPC Server
        private OpcValue[] Lab01Nodes = new OpcValue[6]; //Array to store OPC node value for Lab 01
        private string[] Lab01NodeIds = new string[6] { "ns=2;s=[GustavoDevice]LAB01.MOTOR1", "ns=2;s=[GustavoDevice]LAB01.MOTOR2", "ns=2;s=[GustavoDevice]LAB01.START1", "ns=2;s=[GustavoDevice]LAB01.START2", "ns=2;s=[GustavoDevice]LAB01.STOP1", "ns=2;s=[GustavoDevice]LAB01.STOP2" };

        public Lab01Screen()
        {
            // Assigns labels to the Lbl2Lab01 array 
            InitializeComponent();
            Lbl2Lab01[0] = Lbl2Lab01Test1;
            Lbl2Lab01[1] = Lbl2Lab01Test2;
            Lbl2Lab01[2] = Lbl2Lab01Test3;
            Lbl2Lab01[3] = Lbl2Lab01Test4;
            Lbl2Lab01[4] = Lbl2Lab01Test5;
            Lbl2Lab01[5] = Lbl2Lab01Test6;


        }

        private void TimerLab01_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }
        private void UpdateLabStatus()  //Method for updating the LabStatus label
        {

            //Boolean variables that stores lab status 
            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab01Tests.Length; i++) //Loop that verifies the test results of the lab

            {
                if (Lab01Tests[i] != null) //Verifys the element if its not null for absence in data
                {
                    string testValue = Lab01Tests[i].ToString(); //Reads and converts the value to string 

                    if (testValue.Equals("1")) // If the is 1, it indicates a pass, sets all fail to false indicating not all test have failed
                    {
                        allFailed = false; 

                    }
                    else if (testValue.Equals("-1")) //If the test result is -1, indicates a failure 
                    {
                        allPassed = false; // Sets all passed to false, indicating that not all test cases passed
                        anyFailed = true; //Sets any failed to true. indicating that any test case failed.
                    }
                    else
                    {
                        allPassed = false; // if test value equals something else than -1, it will set  all passed false 
                        allFailed = false; // it will set all failed to false 
                        break;
                    }
                }
                else
                {
                    allPassed = false; //sets 
              allFailed = false;
                   break;
                }
            }

            if (allPassed) //If all test value equals "1", it will display the following:
            {
                lblLabStatus.Text = "LAB #1 PASSED"; //Set the label text to passed 
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


        private void RefreshLabs() //Method for updating the lab status labels

        {
            UpdateLabStatus(); // invokes this method to update the lab status label

          
            
            //Code for Input and Outputs Images
            {
                for (int i = 0; i < Lab01Nodes.Length; i++)
                {
                    Lab01Nodes[i] = client.ReadNode(Lab01NodeIds[i]); //Loop that Reads nodes from the opc server and assigns them to the element of 'Lab01Nodes'
                }

                // Motor 1 image,
                if ((bool)Lab01Nodes[0].Value) // If boolean value of ns=2;s=[GustavoDevice]LAB01.MOTOR1 is true 
                {
                    PicMotor1.Image = imageList1.Images[0]; //Assigns an image from the imagelist using index 0
                    lblMotor1.ForeColor = Color.White; //label text color is white
                    lblMotor1.BackColor = Color.Green; //label backcolor green 
                    lblMotor1.Text = "Motor1 ON"; //label text is set to "Motor1 ON"
                }
                else //If the boolean value is not true
                {
                    PicStart1.Image = imageList1.Images[1]; // Assigns an image from the imagelist using index 1
                    lblMotor1.ForeColor = Color.White; //label text color white
                    lblMotor1.BackColor = Color.Red; //label back color red
                    lblMotor1.Text = "Motor1 OFF"; //label text is set to Motor "off"
                }

                //The Same applies for all the code logic of this section


                if ((bool)Lab01Nodes[1].Value) // Motor 2
                {
                    PicMotor2.Image = imageList1.Images[1];
                    lblMotor2.ForeColor = Color.White;
                    lblMotor2.BackColor = Color.Green;
                    lblMotor2.Text = "Motor2 ON";
                }
                else
                {
                    PicMotor2.Image = imageList1.Images[0];
                    lblMotor2.ForeColor = Color.White;
                    lblMotor2.BackColor = Color.Red;
                    lblMotor2.Text = "Motor2 OFF";
                }


                if ((bool)Lab01Nodes[2].Value) // Start 1
                {
                    PicStart1.Image = imageList1.Images[3];
                    lblStart1.ForeColor = Color.White;
                    lblStart1.BackColor = Color.Green;
                    lblStart1.Text = "Start1 ON";
                }
                else
                {
                    PicStart1.Image = imageList1.Images[2];
                    lblStart1.ForeColor = Color.White;
                    lblStart1.BackColor = Color.Red;
                    lblStart1.Text = "Start1 OFF";
                }


                if ((bool)Lab01Nodes[3].Value) // Start 2
                {
                    PicStart2.Image = imageList1.Images[5];
                    lblStart2.ForeColor = Color.White;
                    lblStart2.BackColor = Color.Green;
                    lblStart2.Text = "Start2 ON";
                }
                else
                {
                    PicStart2.Image = imageList1.Images[4];
                    lblStart2.ForeColor = Color.White;
                    lblStart2.BackColor = Color.Red;
                    lblStart2.Text = "Start2 OFF";
                }


                if ((bool)Lab01Nodes[4].Value) // Stop 1
                {
                    PicStop1.Image = imageList1.Images[6];
                    lblStop1.ForeColor = Color.White;
                    lblStop1.BackColor = Color.Green;
                    lblStop1.Text = "Stop1 ON";
                }
                else
                {
                    PicStop1.Image = imageList1.Images[7];
                    lblStop1.ForeColor = Color.White;
                    lblStop1.BackColor = Color.Red;
                    lblStop1.Text = "Stop1 OFF";
                }


                if ((bool)Lab01Nodes[5].Value) // Stop 2
                {
                    PicStop2.Image = imageList1.Images[8];
                    lblStop2.ForeColor = Color.White;
                    lblStop2.BackColor = Color.Green;
                    lblStop2.Text = "Stop2 ON";
                }
                else
                {
                    PicStop2.Image = imageList1.Images[9];
                    lblStop2.ForeColor = Color.White;
                    lblStop2.BackColor = Color.Red;
                    lblStop2.Text = "Stop2 OFF";
                }
                //INPUT AND OUTPUT IMAGES END 


                //Label Status change Code 
                for (int i = 0; i < Lab01Tests.Length; i++) //in this array it will read the value on the opc servers and assign the value to "Lab01Tests"
                {
                    Lab01Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]LAB01.VAR[" + i + "]"); 
                }

                for (int i = 0; i < Lab01Tests.Length; i++) //In this loop it will check all the elements to verify the value of the node that is reading 
                {
                    // If the test result is 0
                    if (Lab01Tests[i].ToString().Equals("0"))
                    {
                        

                        Lbl2Lab01[i].BackColor = Color.Silver; //Sets label color to silver
                        Lbl2Lab01[i].Text = "NOT RUN"; //Sets label text to NOT RUN
                    }

                    //If the test result is 1
                    if (Lab01Tests[i].ToString().Equals("1"))
                    {
                        Lbl2Lab01[i].BackColor = Color.DarkGreen; //Sets the label color to dark green
                        Lbl2Lab01[i].Text = "PASSED"; //Sets label text to PASSED

                    }

                    // If the test result is -1
                    if (Lab01Tests[i].ToString().Equals("-1"))
                    {
                        Lbl2Lab01[i].BackColor = Color.Red; //Sets the label color to red
                        Lbl2Lab01[i].Text = "FAILED"; //Sets label text to FAILED


                    }

                    //declaring nodeValue as a string variable that holds the simulation message node from the OPC Server.
                    string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

                    switch (nodeValue) //switch case reads the number from the OPC server that is on the variable
                    {
                        case "501":  //Compares the value to the value of the OPC nodde
                            lblLabMessage.Text = "TOGGLING START1, MOTOR1 SHOULD REMAIN ON."; //Sets label text to "TOGGLING START1, MOTOR1 SHOULD REMAIN ON."
                            lblLabMessage.ForeColor = Color.White; //Sets the label text color to White.
                            lblLabMessage.BackColor = Color.Black; //Sets the label color to Black.
                            break; //Exit block after it gets executed

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

            }
        }


        private void BtnLab01Start_Click(object sender, EventArgs e) //Start button Event handler. When button is clicked it executes the following instructions:
        {


            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";   //Declare my variable for the OPC node that is going to write
            client.Connect(); //Connects to the OPC server
            client.WriteNode(tagName, true); //writes a true value to the specific OPC node
            BtnLab01Start.Visible = false; //Makes the button invisble when its pressed
            BtnLab01Stop.Visible = true; //Makes the stop button visible 
            TimerLab01.Enabled = true; //Timer goes on to perodically refresh and update the UI


        }

        private void BtnLab01Stop_Click(object sender, EventArgs e) //Stop Button Event handler
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT"; //Declare my variable for the OPC node that is going to write
            client.WriteNode(tagName, false);  //writes a true value to the specific OPC node
            BtnLab01Start.Visible = true; //Makes Start button visible.
            BtnLab01Stop.Visible = false; //Makes Stop button invisible.
            TimerLab01.Enabled = false; //Stops Timer1
            RefreshLabs();
            client.Disconnect(); //Disconnects from Server.
            lblLabStatus.Text = ""; //Clears the text from the Status Label
            lblLabStatus.BackColor = Color.Gray; //Sets lab status label color to gray.
            lblLabMessage.Text = ""; //Clears label lab message.
            lblLabMessage.BackColor = Color.Gray; //Sets lab message color to gray.
        }

      

        private void BtnBack_Click(object sender, EventArgs e) //Back button Event handler
        {
            var BackTolabselection = new LabSelection(); //Declaring variable for LabSelection screen
            Parent.Controls.Add(BackTolabselection); //Adds the variable to parent container
            BackTolabselection.Dock = DockStyle.Fill; // Sets the dock style to fill
            Parent.Controls.Remove(this); //Removes current form when executed

        }

        private void BtnNextLab_Click(object sender, EventArgs e) //Next button Event handler
        {
            var secondUserControl = new Lab02Screen(); //Declaring variable for Lab02 screen
            Parent.Controls.Add(secondUserControl); //Adds the variable to parent container
            Parent.Controls.Remove(this); //Removes current form when executed
            secondUserControl.Dock = DockStyle.Fill; //Sets de dock style to fill

        }

    }
}


