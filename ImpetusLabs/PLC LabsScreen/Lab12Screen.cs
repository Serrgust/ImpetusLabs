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
    public partial class Lab12Screen : UserControl
    {
        private OpcValue[] Lab12Tests = new OpcValue[3];
        private Label[] Lbl2Lab12 = new Label[3];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab12NodeIds = new string[9] { "ns=2;s=[GustavoDevice]LAB12.FILL", "ns=2;s=[GustavoDevice]LAB12.DRAIN", "ns=2;s=[GustavoDevice]LAB11.L_LEVEL_T1", "ns=2;s=[GustavoDevice]LAB11.H_LEVEL_T1", "ns=2;s=[GustavoDevice]LAB11.L_LEVEL_T2", "ns=2;s=[GustavoDevice]LAB11.IN_VALVE", "ns=2;s=[GustavoDevice]LAB11.INT_VALVE", "ns=2;s=[GustavoDevice]Lab11.TANK_LEVEL", "ns=2;s=[GustavoDevice]Lab11.TANK_LEVEL2" };
        private OpcValue[] Lab12Nodes = new OpcValue[9];
        public Lab12Screen()
        {
            InitializeComponent();

            Lbl2Lab12[0] = Lbl2Lab12Test1;
            Lbl2Lab12[1] = Lbl2Lab12Test2;
            Lbl2Lab12[2] = Lbl2Lab12Test3;

           
        }

        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab12Tests.Length; i++)
            {
                Lab12Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab12.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab12Tests.Length; i++)
            {
                if (Lab12Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab12[i].BackColor = Color.Silver;
                    Lbl2Lab12[i].Text = "NOT RUN";
                }
                if (Lab12Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab12[i].BackColor = Color.LightGreen;
                    Lbl2Lab12[i].Text = "PASSED";
                }
                if (Lab12Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab12[i].BackColor = Color.Red;
                    Lbl2Lab12[i].Text = "FAILED";
                }
            }
            // Fotos
            for (int b = 0; b < Lab12Nodes.Length; b++)
            {
                Lab12Nodes[b] = client.ReadNode(Lab12NodeIds[b]);
            }

            // FILL
            if ((bool)Lab12Nodes[0].Value)
            {
                PicFILL.Image = imageList1.Images[1];
                lblFILL.ForeColor = Color.White;
                lblFILL.BackColor = Color.Green;
                lblFILL.Text = "FILL ON";
            }
            else
            {
                PicFILL.Image = imageList1.Images[0];
                lblFILL.ForeColor = Color.White;
                lblFILL.BackColor = Color.Red;
                lblFILL.Text = "FILL OFF";
            }

            //DRAIN
            if ((bool)Lab12Nodes[1].Value)
            {
                PicDrain.Image = imageList1.Images[3];
                lblDRAIN.ForeColor = Color.White;
                lblDRAIN.BackColor = Color.Green;
                lblDRAIN.Text = "DRAIN  ON";
            }
            else
            {
                PicDrain.Image = imageList1.Images[2];
                lblDRAIN.ForeColor = Color.White;
                lblDRAIN.BackColor = Color.Red;
                lblDRAIN.Text = "DRAIN OFF";
            }
        }

        private void BtnLab12Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT11";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab12Start.Visible = false;
            BtnLab12Stop.Visible = true;
            TimerLab12.Enabled = true;
        }

        private void BtnLab12Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT11";
            client.WriteNode(tagName, false);
            BtnLab12Start.Visible = true;
            BtnLab12Stop.Visible = false;
            TimerLab12.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerLab12_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
