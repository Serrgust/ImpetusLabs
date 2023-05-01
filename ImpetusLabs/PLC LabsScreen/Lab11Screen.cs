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
using System.Net.NetworkInformation;
using System.Drawing.Drawing2D;

namespace ImpetusLabs.LabsScreen
{

    public partial class Lab11Screen : UserControl
    {
        public OpcValue[] Lab11Tests = new OpcValue[5];
        private Label[] Lbl2Lab11 = new Label[5];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        private string[] Lab11NodeIds = new string[5] { "ns=2;s=[GustavoDevice]LAB11.FILL", "ns=2;s=[GustavoDevice]LAB11.DRAIN", "ns=2;s=[GustavoDevice]LAB11.L_SWITCH", "ns=2;s=[GustavoDevice]LAB11.H_SWITCH", "ns=2;s=[GustavoDevice]Lab11.TANK_LEVEL" };
        private OpcValue[] Lab11Nodes = new OpcValue[5];
        private int TankHeight;
        public Lab11Screen()
        {
            InitializeComponent();

            Lbl2Lab11[0] = Lbl2Lab11Test1;
            Lbl2Lab11[1] = Lbl2Lab11Test2;
            Lbl2Lab11[2] = Lbl2Lab11Test3;
            Lbl2Lab11[3] = Lbl2Lab11Test4;
            Lbl2Lab11[4] = Lbl2Lab11Test5;


        }
        private void RefreshLabs()
        {


            //codigo para hacer updates de los test labels
            for (int i = 0; i < Lab11Tests.Length; i++)
            {
                Lab11Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]Lab11.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab11Tests.Length; i++)
            {
                if (Lab11Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab11[i].BackColor = Color.Silver;
                    Lbl2Lab11[i].Text = "NOT RUN";
                }
                if (Lab11Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab11[i].BackColor = Color.LightGreen;
                    Lbl2Lab11[i].Text = "PASSED";
                }
                if (Lab11Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab11[i].BackColor = Color.Red;
                    Lbl2Lab11[i].Text = "FAILED";
                }

            }

            // Fotos
            for (int b = 0; b < Lab11Nodes.Length; b++)
            {
                Lab11Nodes[b] = client.ReadNode(Lab11NodeIds[b]);
            }

            // FILL
            if ((bool)Lab11Nodes[0].Value)
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
            if ((bool)Lab11Nodes[1].Value)
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


            // Nivel del Tanque
            double tankLevel = Convert.ToDouble(Lab11Nodes[4].Value);
            TankHeight = (int)((PicTank.Height - 4) * (tankLevel / 100.0));

            // Limit the tank height to the tank's height
            TankHeight = Math.Min(TankHeight, PicTank.Height - 4);

            // Update the tank level panel
            pnlTankLevel.Height = TankHeight;
            pnlTankLevel.Top = PicTank.Height - TankHeight - 2;


            //HighSwitch
            bool hSwitch = (bool)Lab11Nodes[3].Value;
            PicHSwitch.Image = hSwitch ? imageList1.Images[4] : imageList1.Images[5];

            //LowSwitch
            bool lSwitch = (bool)Lab11Nodes[2].Value;
            PicLSwitch.Image = lSwitch ? imageList1.Images[4] : imageList1.Images[5];


        }

        private void PicTank_Paint(object sender, PaintEventArgs e)
        {
            int tankTop = PicTank.Height - TankHeight - 2;
            int tankLeft = 2;
            int tankWidth = PicTank.Width - 4; //4

            // Draw the water
            e.Graphics.FillRectangle(Brushes.Blue, tankLeft, tankTop, tankWidth, TankHeight);

            // Draw the border around the tank
            e.Graphics.DrawRectangle(Pens.Black, tankLeft, 0, tankWidth, PicTank.Height - 2);
        }






        private void TimerLab11_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void BtnLab11Start_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT10";
            client.Connect();
            client.WriteNode(tagName, true);
            BtnLab11Start.Visible = false;
            BtnLab11Stop.Visible = true;
            TimerLab11.Enabled = true;
            TimerFilling.Enabled = true;
        }

        private void BtnLab11Stop_Click_1(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT10";
            client.WriteNode(tagName, false);
            BtnLab11Start.Visible = true;
            BtnLab11Stop.Visible = false;
            TimerLab11.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void TimerFilling_Tick(object sender, EventArgs e)
        {

            if (Lab11Nodes != null && Lab11Nodes[4] != null && Lab11Nodes[4].Value != null && PicTank != null)
            {
                //    double tankLevel = Convert.ToDouble(Lab11Nodes[4].Value);
                //    TankHeight = (int)((PicTank.Height - 4) * (tankLevel / 100.0));
                //    PicTank.Invalidate(); // Redraw the tank
                double tankLevel = Convert.ToDouble(Lab11Nodes[4].Value);
                TankHeight = (int)((PicTank.Height - 4) * (tankLevel / 100.0));
                int fillingHeight = Math.Min(TankHeight, pnlTankLevel.Height); // limit the filling height to the tank height
                int fillingTop = PicTank.Height - fillingHeight - 2; // position the filling panel at the bottom of the tank
                pnlTankLevel.Height = fillingHeight;
                pnlTankLevel.Top = fillingTop - 10;
                PicTank.Invalidate(); // Redraw the tank


            }
        }

  
            public static GraphicsPath Create(float x, float y, float width, float height, float radius)
            {
                GraphicsPath path = new GraphicsPath();
                path.StartFigure();
                path.AddArc(x + width - radius, y, radius, radius, 270, 90);
                path.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);
                path.AddArc(x, y + height - radius, radius, radius, 90, 90);
                path.AddArc(x, y, radius, radius, 180, 90);
                path.CloseFigure();
                return path;


            }
        }
    }





