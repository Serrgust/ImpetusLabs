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
    public partial class Lab14Screen : UserControl
    {
        private OpcValue[] Lab14Tests = new OpcValue[8];
        private Label[] Lbl2Lab14 = new Label[8];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab14NodeIds = new string[15] { "ns=2;s=[GustavoDevice]LAB14.START", "ns=2;s=[GustavoDevice]LAB14.HEAT", "ns=2;s=[GustavoDevice]LAB14.COOL", "ns=2;s=[GustavoDevice]LAB14.IN_HEAT", "ns=2;s=[GustavoDevice]LAB14.TANK_LEVEL_H", "ns=2;s=[GustavoDevice]LAB14.HEATER", "ns=2;s=[GustavoDevice]LAB14.HIGH_HEAT", "ns=2;s=[GustavoDevice]LAB14.OUT_HEAT", "ns=2;s=[GustavoDevice]LAB14.LOW_HEAT", "ns=2;s=[GustavoDevice]LAB14.IN_COOL", "ns=2;s=[GustavoDevice]LAB14.TANK_LEVEL_C", "ns=2;s=[GustavoDevice]LAB14.COOLER", "ns=2;s=[GustavoDevice]LAB14.HIGH_COOL", "ns=2;s=[GustavoDevice]LAB14.OUT_COOL", "ns=2;s=[GustavoDevice]LAB14.LOW_COOL" };
        private OpcValue[] Lab14Nodes = new OpcValue[15];
        public Lab14Screen()
        {
            InitializeComponent();

            Lbl2Lab14[0] = Lbl2Lab14Test1;
            Lbl2Lab14[1] = Lbl2Lab14Test2;
            Lbl2Lab14[2] = Lbl2Lab14Test3;
            Lbl2Lab14[3] = Lbl2Lab14Test4;
            Lbl2Lab14[4] = Lbl2Lab14Test5;
            Lbl2Lab14[5] = Lbl2Lab14Test6;
            Lbl2Lab14[6] = Lbl2Lab14Test7;
            Lbl2Lab14[7] = Lbl2Lab14Test8;


        }

        private void UpdateLabStatus()
        {

            bool allPassed = true;
            bool allFailed = true;
            bool anyFailed = false;

            for (int i = 0; i < Lab14Tests.Length; i++)
            {
                if (Lab14Tests[i] != null)
                {
                    string testValue = Lab14Tests[i].ToString();

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
                lblLabStatus.Text = "LAB #13 PASSED";
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

                //codigo para hacer updates de los test labels
                for (int i = 0; i < Lab14Tests.Length; i++)
                {
                    Lab14Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab14.VAR[" + i + "]");
                }

                for (int i = 0; i < Lab14Tests.Length; i++)
                {
                    if (Lab14Tests[i].ToString().Equals("0"))
                    {
                        Lbl2Lab14[i].BackColor = Color.Silver;
                        Lbl2Lab14[i].Text = "NOT RUN";
                    }
                    if (Lab14Tests[i].ToString().Equals("1"))
                    {
                        Lbl2Lab14[i].BackColor = Color.LightGreen;
                        Lbl2Lab14[i].Text = "PASSED";
                    }
                    if (Lab14Tests[i].ToString().Equals("-1"))
                    {
                        Lbl2Lab14[i].BackColor = Color.Red;
                        Lbl2Lab14[i].Text = "FAILED";
                    }


                    // Fotos
                    for (int b = 0; b < Lab14Nodes.Length; b++)
                    {
                        Lab14Nodes[b] = client.ReadNode(Lab14NodeIds[b]);
                    }

                    // Start
                    if ((bool)Lab14Nodes[0].Value)
                    {
                        PicStart.Image = imageList1.Images[1];
                        lblStart.ForeColor = Color.White;
                        lblStart.BackColor = Color.Green;
                        lblStart.Text = "START ON";
                    }
                    else
                    {
                        PicStart.Image = imageList1.Images[0];
                        lblStart.ForeColor = Color.White;
                        lblStart.BackColor = Color.Red;
                        lblStart.Text = "START OFF";
                    }

                    //HEAT
                    if ((bool)Lab14Nodes[1].Value)
                    {
                        PicHeat.Image = imageList1.Images[2];
                        lblHeat.ForeColor = Color.White;
                        lblHeat.BackColor = Color.Green;
                        lblHeat.Text = "HEAT MODE ON";
                    }
                    else
                    {
                        PicHeat.Image = imageList1.Images[3];
                        lblHeat.ForeColor = Color.White;
                        lblHeat.BackColor = Color.Red;
                        lblHeat.Text = "HEAT MODE OFF";
                    }
                    //cool
                    if ((bool)Lab14Nodes[2].Value)
                    {
                        PicCool.Image = imageList1.Images[5];
                        lblCool.ForeColor = Color.White;
                        lblCool.BackColor = Color.Green;
                        lblCool.Text = "COOL MODE ON";
                    }
                    else
                    {
                        PicCool.Image = imageList1.Images[4];
                        lblCool.ForeColor = Color.White;
                        lblCool.BackColor = Color.Red;
                        lblCool.Text = "COOL MODE OFF";
                    }

                    //in  heat
                    if ((bool)Lab14Nodes[3].Value)
                    {
                        PicInHeat.Image = imageList1.Images[6];
                        lblInHeat.ForeColor = Color.White;
                        lblInHeat.BackColor = Color.Green;
                        lblInHeat.Text = "INLET VALVE ON";
                    }
                    else
                    {
                        PicInHeat.Image = imageList1.Images[6];
                        lblInHeat.ForeColor = Color.White;
                        lblInHeat.BackColor = Color.Red;
                        lblInHeat.Text = "INLET VALVE OFF";
                    }

                    //heater
                    if ((bool)Lab14Nodes[5].Value)
                    {
                        PicHeater.Image = imageList1.Images[7];
                        lblHeater.ForeColor = Color.White;
                        lblHeater.BackColor = Color.Green;
                        lblHeater.Text = "HEATER  ON";
                    }
                    else
                    {
                        PicHeater.Image = imageList1.Images[7];
                        lblHeater.ForeColor = Color.White;
                        lblHeater.BackColor = Color.Red;
                        lblHeater.Text = "HEATER OFF";

                    }
                    //out heat
                    if ((bool)Lab14Nodes[7].Value)
                    {
                        PicOutvalve.Image = imageList1.Images[8];
                        lblOutvalve.ForeColor = Color.White;
                        lblOutvalve.BackColor = Color.Green;
                        lblOutvalve.Text = "OUT VALVE  ON";
                    }
                    else
                    {
                        PicOutvalve.Image = imageList1.Images[8];
                        lblOutvalve.ForeColor = Color.White;
                        lblOutvalve.BackColor = Color.Red;
                        lblOutvalve.Text = "OUT VALVE OFF";

                    }
                    //in cool
                    if ((bool)Lab14Nodes[9].Value)
                    {
                        PicInCool.Image = imageList1.Images[6];
                        lblInCool.ForeColor = Color.White;
                        lblInCool.BackColor = Color.Green;
                        lblInCool.Text = "INLET VALVE ON";
                    }
                    else
                    {
                        PicInCool.Image = imageList1.Images[6];
                        lblInCool.ForeColor = Color.White;
                        lblInCool.BackColor = Color.Red;
                        lblInCool.Text = "INLET VALVE OFF";

                    }

                    //cooler
                    if ((bool)Lab14Nodes[11].Value)
                    {
                        PicCooler.Image = imageList1.Images[9];
                        lblCooler.ForeColor = Color.White;
                        lblCooler.BackColor = Color.Green;
                        lblCooler.Text = "COOLER ON";
                    }
                    else
                    {
                        PicCooler.Image = imageList1.Images[9];
                        lblCooler.ForeColor = Color.White;
                        lblCooler.BackColor = Color.Red;
                        lblCooler.Text = "COOLER OFF";
                    }
                    //out cool
                    if ((bool)Lab14Nodes[13].Value)
                    {
                        PicOutCool.Image = imageList1.Images[8];
                        lblOutCool.ForeColor = Color.White;
                        lblOutCool.BackColor = Color.Green;
                        lblOutCool.Text = "OUT VALVE ON";
                    }
                    else
                    {
                        PicOutCool.Image = imageList1.Images[8];
                        lblOutCool.ForeColor = Color.White;
                        lblOutCool.BackColor = Color.Red;
                        lblOutCool.Text = "OUT VALVE OFF";

                    }
                    // High Heat Switch
                    bool highHeat = (bool)Lab14Nodes[6].Value;
                    PicHighHeat.Image = highHeat ? imageList2.Images[0] : imageList2.Images[1];

                    // Low Heat Switch
                    bool lowHeat = (bool)Lab14Nodes[8].Value;
                    PicLowHeat.Image = lowHeat ? imageList2.Images[0] : imageList2.Images[1];

                    // High Cool Switch
                    bool highCool = (bool)Lab14Nodes[12].Value;
                    PicHighCool.Image = highCool ? imageList2.Images[0] : imageList2.Images[1];

                    // Low Cool Switch
                    bool lowCool = (bool)Lab14Nodes[14].Value;
                    PicLowCool.Image = lowCool ? imageList2.Images[0] : imageList2.Images[1];
                }
                string nodeValue = client.ReadNode("ns=2;s=::[GustavoDevice]Program:SIMULATION.MESSAGE").ToString();

                switch (nodeValue)
                {
                    case "1401":
                        lblLabMessage.Text = "TOGGLE START, NOTHING SHOULD BE ON.";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1402":
                        lblLabMessage.Text = "TOGGLE HEAT BUTTON, INLET VALVE OF HEAT TANK SHOULD TURN ON UNTIL HIGH LIMIT IS REACHED";
                        lblLabMessage.ForeColor = Color.White;
                        lblLabMessage.BackColor = Color.Black;
                        break;
                    case "1403":
                        lblLabMessage.Text = "TANK IS FULL, HEATING UNTIL ABOVE SET POINT 100";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1404":
                        lblLabMessage.Text = "AFTER TANK IS HEATED, OUTLET VALVE OF HEAT TANK SHOULD TURN ON UNTIL LOW LIMIT IS REACHED";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1405":
                        lblLabMessage.Text = "TOGGLE COOL BUTTON, INLET VALVE OF COOL TANK SHOULD TURN ON UNTIL HIGH LIMIT IS REACHED";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1406":
                        lblLabMessage.Text = "TANK IS FUL, COOLING UNTIL BELLOW SET POINT 5";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1407":
                        lblLabMessage.Text = "AFTER COOLING IS DONE, OUTLET VALVE OF COOL TANK SHOULD TURN ON UNTIL LOW LIMIT IS REACHED";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1408":
                        lblLabMessage.Text = "BOTH HEAT AND COOL MODES ARE SELECTED, SYSTEM SHOULD EXECUTE BOTH AT THE SAME TIME";
                        lblLabMessage.BackColor = Color.Black;
                        lblLabMessage.ForeColor = Color.White;
                        break;
                    case "1409":
                        lblLabStatus.Text = "LAB #14 PASSED";
                        lblLabStatus.BackColor = Color.Green;
                        lblLabStatus.ForeColor = Color.White;
                        lblLabMessage.Text = "";
                        lblLabMessage.BackColor = Color.Gray;
                        break;



                }

            }


        }



        private void TimerLab14_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void Lab14Screen_Load(object sender, EventArgs e)
        {

        }

        private void BtnLab14Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT13";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab14Start.Visible = false;
            BtnLab14Stop.Visible = true;
            TimerLab14.Enabled = true;
            TimerFilling.Enabled = true;

        }

        private void BtnLab14Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT13";
            client.WriteNode(tagName, false);
            BtnLab14Start.Visible = true;
            BtnLab14Stop.Visible = false;
            TimerLab14.Enabled = false;
            TimerFilling.Enabled = false;
            RefreshLabs();
            client.Disconnect();
            lblLabStatus.Text = "";
            lblLabStatus.BackColor = Color.Gray;
            lblLabMessage.Text = "";
            lblLabMessage.BackColor = Color.Gray;
        }

        private void TimerFilling_Tick(object sender, EventArgs e)
        {
            if (Lab14Nodes != null && Lab14Nodes.Length > 4 && Lab14Nodes[4] != null && Lab14Nodes[4].Value != null &&
                  Lab14Nodes.Length > 8 && Lab14Nodes[8] != null && Lab14Nodes[8].Value != null &&
                  Lab14Nodes.Length > 9 && Lab14Nodes[9] != null && Lab14Nodes[9].Value != null)
            {
                // Read the value of the TANK_LEVEL and TANK_LEVEL2 nodes and set the maximum value of the ProgressBar controls
                double tankLevel1 = Convert.ToDouble(Lab14Nodes[4].Value);
                double tankLevel2 = Convert.ToDouble(Lab14Nodes[10].Value);
                verticalProgressBar1.Maximum = (int)tankLevel1;
                verticalProgressBar2.Maximum = (int)tankLevel2;

                // Read the value of the Lab12.TANK_LEVEL node and set the ProgressBar value for verticalProgressBar1
                double nodeValue1 = Convert.ToDouble(Lab14Nodes[4].Value);
                verticalProgressBar1.Value = (int)nodeValue1;

                // Read the value of the Lab12.TANK_LEVEL2 node and set the ProgressBar value for verticalProgressBar2
                double nodeValue2 = Convert.ToDouble(Lab14Nodes[10].Value);
                verticalProgressBar2.Value = (int)nodeValue2;

                // Set the Text property of the labels to the percentage value
                lblTankFill.Text = verticalProgressBar1.Value.ToString() + "%";
                lblTankFill2.Text = verticalProgressBar2.Value.ToString() + "%";
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var BackToLab13 = new Lab13Screen();
            Parent.Controls.Add(BackToLab13);
            BackToLab13.Dock = DockStyle.Fill;
            Parent.Controls.Remove(this);
        }

        private void BtnNextLab_Click(object sender, EventArgs e)
        {
            var secondUserControl = new Lab15Screen();
            Parent.Controls.Add(secondUserControl);
            Parent.Controls.Remove(this);
            secondUserControl.Dock = DockStyle.Fill;
        }
    }
    }
