using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.UaFx.Client;

namespace ImpetusLabs
{
    public partial class Form1 : Form
    {
        OpcClient client = new OpcClient("opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1");

        public Form1()
        {
            InitializeComponent();
            //    BtnLab01Stop.Visible = false;
            //    Lbl2Lab01Test1.BackColor = Color.Silver;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnOpcWrite_Click(object sender, EventArgs e)
        {
           

            //var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";

            //client.Connect();

            //string temperature;

            //temperature = Convert.ToString(txtOpcDataWrite.Text);

            //client.WriteNode(tagName, temperature);
            client.Disconnect();

        }

        private void btnOpcRead_Click(object sender, EventArgs e)
        {
          
            //string opcUrl = "opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1";
            //var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            //var client = new OpcClient(opcUrl);
            client.Connect();
            //var temperature = client.ReadNode(tagName);

            //txtOpcDataRead.Text = temperature.ToString();
        }

        private void BtnLab01Start_Click(object sender, EventArgs e)
        {
            //string opcUrl = "opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1";
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            //var client = new OpcClient(opcUrl);
            client.Connect();

            client.WriteNode(tagName, true);
         //   BtnLab01Start.Visible = false;
         //   BtnLab01Stop.Visible = true;
            timer1.Start();

            client.Disconnect();
        }

        private void BtnLab01Stop_Click(object sender, EventArgs e)
        {
            //string opcUrl = "opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1";
            var tagName = "ns=2;s=::[GustavoDevice]Program:SIMULATION.BIT";
            //var client = new OpcClient(opcUrl);
            client.Connect();

            timer1.Stop();
            client.WriteNode(tagName, false);
/*            BtnLab01Start.Visible = true;
            BtnLab01Stop.Visible = false;
            client.Disconnect();
            Lbl2Lab01Test1.BackColor = Color.Silver;
            Lbl2Lab01Test1.Text = "NOT RUN";
            Lbl2Lab01Test2.BackColor = Color.Silver;
            Lbl2Lab01Test2.Text = "NOT RUN";
            Lbl2Lab01Test3.BackColor = Color.Silver;
            Lbl2Lab01Test3.Text = "NOT RUN";
            Lbl2Lab01Test4.BackColor = Color.Silver;
            Lbl2Lab01Test4.Text = "NOT RUN";
            Lbl2Lab01Test5.BackColor = Color.Silver;
            Lbl2Lab01Test5.Text = "NOT RUN";
            Lbl2Lab01Test6.BackColor = Color.Silver;
            Lbl2Lab01Test6.Text = "NOT RUN";*/
        }

        public void Lbl2Lab01Test1_Click(object sender, EventArgs e)
        {

            //string opcUrl = "opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1";
            var tagName = "ns=2;s=[GustavoDevice]LAB01.VAR[1]";
            //var client = new OpcClient(opcUrl);
            client.Connect();
            var Lab01Test1 = client.ReadNode(tagName);
            if (Lab01Test1.Equals(1))
            {
            //    LblLab01Test1.BackColor = Color.Green;
            }
            if (Lab01Test1.Equals(-1))
            {
            //    LblLab01Test1.BackColor = Color.Red;
            }
            client.Disconnect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //string opcUrl = "opc.tcp://192.168.4.44:4990/FactoryTalkLinxGateway1";
            var var1 = "ns=2;s=[GustavoDevice]LAB01.VAR[0]";
            var var2 = "ns=2;s=[GustavoDevice]LAB01.VAR[1]";
            var var3 = "ns=2;s=[GustavoDevice]LAB01.VAR[2]";
            var var4 = "ns=2;s=[GustavoDevice]LAB01.VAR[3]";
            var var5 = "ns=2;s=[GustavoDevice]LAB01.VAR[4]";
            var var6 = "ns=2;s=[GustavoDevice]LAB01.VAR[5]";
            //var client = new OpcClient(opcUrl);
            client.Connect();
            var Lab01Test1 = client.ReadNode(var1);
            var Lab01Test2 = client.ReadNode(var2);
            var Lab01Test3 = client.ReadNode(var3);
            var Lab01Test4 = client.ReadNode(var4);
            var Lab01Test5 = client.ReadNode(var5);
            var Lab01Test6 = client.ReadNode(var6);
            if (Lab01Test1.ToString().Equals("0"))
            {
            //    Lbl2Lab01Test1.BackColor = Color.Silver;
            //    Lbl2Lab01Test1.Text = "NOT RUN";
            }
            if (Lab01Test1.ToString().Equals("1"))
            {
             //   Lbl2Lab01Test1.BackColor = Color.Green;
             //   Lbl2Lab01Test1.Text = "PASSED";
            }
           /* if (Lab01Test1.ToString().Equals("-1"))
            {
                Lbl2Lab01Test1.BackColor = Color.Red;
                Lbl2Lab01Test1.Text = "FAILED";
            }
            if (Lab01Test2.ToString().Equals("0"))
            {
                Lbl2Lab01Test2.BackColor = Color.Silver;
                Lbl2Lab01Test2.Text = "NOT RUN";
            }
            if (Lab01Test2.ToString().Equals("1"))
            {
                Lbl2Lab01Test2.BackColor = Color.Green;
                Lbl2Lab01Test2.Text = "PASSED";
            }
            if (Lab01Test2.ToString().Equals("-1"))
            {
                Lbl2Lab01Test2.BackColor = Color.Red;
                Lbl2Lab01Test2.Text = "FAILED";
            }
            if (Lab01Test3.ToString().Equals("0"))
            {
                Lbl2Lab01Test3.BackColor = Color.Silver;
                Lbl2Lab01Test3.Text = "NOT RUN";
            }
            if (Lab01Test3.ToString().Equals("1"))
            {
                Lbl2Lab01Test3.BackColor = Color.Green;
                Lbl2Lab01Test3.Text = "PASSED";
            }
            if (Lab01Test3.ToString().Equals("-1"))
            {
                Lbl2Lab01Test3.BackColor = Color.Red;
                Lbl2Lab01Test3.Text = "FAILED";
            }
            if (Lab01Test4.ToString().Equals("0"))
            {
                Lbl2Lab01Test4.BackColor = Color.Silver;
                Lbl2Lab01Test4.Text = "NOT RUN";
            }
            if (Lab01Test4.ToString().Equals("1"))
            {
                Lbl2Lab01Test4.BackColor = Color.Green;
                Lbl2Lab01Test4.Text = "PASSED";
            }
            if (Lab01Test4.ToString().Equals("-1"))
            {
                Lbl2Lab01Test4.BackColor = Color.Red;
                Lbl2Lab01Test4.Text = "FAILED";
            }
            if (Lab01Test5.ToString().Equals("0"))
            {
                Lbl2Lab01Test5.BackColor = Color.Silver;
                Lbl2Lab01Test5.Text = "NOT RUN";
            }
            if (Lab01Test5.ToString().Equals("1"))
            {
                Lbl2Lab01Test5.BackColor = Color.Green;
                Lbl2Lab01Test5.Text = "PASSED";
            }
            if (Lab01Test5.ToString().Equals("-1"))
            {
                Lbl2Lab01Test5.BackColor = Color.Red;
                Lbl2Lab01Test5.Text = "FAILED";
            }
            if (Lab01Test6.ToString().Equals("0"))
            {
                Lbl2Lab01Test6.BackColor = Color.Silver;
                Lbl2Lab01Test6.Text = "NOT RUN";
            }
            if (Lab01Test6.ToString().Equals("1"))
            {
                Lbl2Lab01Test6.BackColor = Color.Green;
                Lbl2Lab01Test6.Text = "PASSED";
            }
            if (Lab01Test6.ToString().Equals("-1"))
            {
                Lbl2Lab01Test6.BackColor = Color.Red;
                Lbl2Lab01Test6.Text = "FAILED";
            }*/
            client.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userControl1_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Que buscas hueputa");
        }
    }
}
