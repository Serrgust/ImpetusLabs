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

namespace ImpetusLabs.LabsScreen
{
    public partial class Lab02Screen : UserControl
    {
        private OpcValue[] Lab02Tests = new OpcValue[2];
        private Label[] Lbl2Lab02 = new Label[2];
        private OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");
        //private OpcValue[] Lab01Nodes = new OpcValue[6];
      // private string[] Lab02NodeIds = new string[6] {"ns=2;s=[GustavoDevice]LAB02.START","ns=2;s=[GustavoDevice]LAB02.TIMER1.ACC","ns=2;s=[GustavoDevice]LAB02.TIMER1.DN", "ns=2;s=[GustavoDevice]LAB02.TIMER1.EN","ns=2;s=[GustavoDevice]LAB02.TIMER1.PRE","ns=2;s=[GustavoDevice]LAB02.TIMER1.TT" };
        public Lab02Screen()
        {
            InitializeComponent();
            Lbl2Lab02[0] = Lbl2Lab02Test1;
            Lbl2Lab02[1] = Lbl2Lab02Test2;

          
        }


        private void RefreshLabs()
        {
            for (int i = 0; i < Lab02Tests.Length; i++)
            {
                Lab02Tests[i] = client.ReadNode("ns=2;s=[GustavoDevice]LAB02.VAR[" + i + "]");
            }

            for (int i = 0; i < Lab02Tests.Length; i++)
            {
                if (Lab02Tests[i].ToString().Equals("0"))
                {
                    Lbl2Lab02[i].BackColor = Color.Silver;
                    Lbl2Lab02[i].Text = "NOT RUN";
                }
                if (Lab02Tests[i].ToString().Equals("1"))
                {
                    Lbl2Lab02[i].BackColor = Color.LightGreen;
                    Lbl2Lab02[i].Text = "PASSED";
                }
                if (Lab02Tests[i].ToString().Equals("-1"))
                {
                    Lbl2Lab02[i].BackColor = Color.Red;
                    Lbl2Lab02[i].Text = "FAILED";
                }
            }
        }

        private void BtnLab02Stop_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT2";
            client.WriteNode(tagName, false);
            BtnLab02Start.Visible = true;
            BtnLab02Stop.Visible = false;
            TimerLab02.Enabled = false;
            RefreshLabs();
            client.Disconnect();
        }

        private void BtnLab02Start_Click(object sender, EventArgs e)
        {
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT2";
            client.Connect();
            try
            {
                client.Connect();
                client.WriteNode(tagName, true);
            }
            catch (Opc.UaFx.OpcException)
            {
                //MessageBox.Show("Connection to OPC UA Server failed");
            }
            BtnLab02Start.Visible = false;
            BtnLab02Stop.Visible = true;
            TimerLab02.Enabled = true;

        }

        private void TimerLab02_Tick(object sender, EventArgs e)
        {
            RefreshLabs();
        }

        private void Lab02Screen_Load(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Lab01Screen targetform= new Lab01Screen();
            this.Visible = false;
            this.Parent.Controls.Add(targetform);
            targetform.Visible= true;
        }
    }
}
