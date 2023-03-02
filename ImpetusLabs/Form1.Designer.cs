
namespace ImpetusLabs
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnLab01Start = new System.Windows.Forms.Button();
            this.BtnLab01Stop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lbl2Lab01Test1 = new System.Windows.Forms.Label();
            this.LblLab01Test1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnLab01Start
            // 
            this.BtnLab01Start.Location = new System.Drawing.Point(514, 492);
            this.BtnLab01Start.Name = "BtnLab01Start";
            this.BtnLab01Start.Size = new System.Drawing.Size(225, 138);
            this.BtnLab01Start.TabIndex = 0;
            this.BtnLab01Start.Text = "START SIM";
            this.BtnLab01Start.UseVisualStyleBackColor = true;
            this.BtnLab01Start.Click += new System.EventHandler(this.BtnLab01Start_Click_1);
            // 
            // BtnLab01Stop
            // 
            this.BtnLab01Stop.Location = new System.Drawing.Point(514, 492);
            this.BtnLab01Stop.Name = "BtnLab01Stop";
            this.BtnLab01Stop.Size = new System.Drawing.Size(225, 138);
            this.BtnLab01Stop.TabIndex = 1;
            this.BtnLab01Stop.Text = "STOP SIM";
            this.BtnLab01Stop.UseVisualStyleBackColor = true;
            this.BtnLab01Stop.Click += new System.EventHandler(this.BtnLab01Stop_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.Lbl2Lab01Test1);
            this.panel1.Controls.Add(this.LblLab01Test1);
            this.panel1.Location = new System.Drawing.Point(63, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 297);
            this.panel1.TabIndex = 2;
            // 
            // Lbl2Lab01Test1
            // 
            this.Lbl2Lab01Test1.BackColor = System.Drawing.Color.Silver;
            this.Lbl2Lab01Test1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl2Lab01Test1.Location = new System.Drawing.Point(100, 35);
            this.Lbl2Lab01Test1.Name = "Lbl2Lab01Test1";
            this.Lbl2Lab01Test1.Size = new System.Drawing.Size(73, 33);
            this.Lbl2Lab01Test1.TabIndex = 1;
            this.Lbl2Lab01Test1.Text = "NOT RUN";
            this.Lbl2Lab01Test1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lbl2Lab01Test1.Click += new System.EventHandler(this.Lbl2Lab01Test1_Click);
            // 
            // LblLab01Test1
            // 
            this.LblLab01Test1.Location = new System.Drawing.Point(35, 42);
            this.LblLab01Test1.Name = "LblLab01Test1";
            this.LblLab01Test1.Size = new System.Drawing.Size(59, 19);
            this.LblLab01Test1.TabIndex = 0;
            this.LblLab01Test1.Text = "Test 1";
            this.LblLab01Test1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 438);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 172);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnLab01Stop);
            this.Controls.Add(this.BtnLab01Start);
            this.Name = "Form1";
            this.Text = "Hey";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnLab01Start;
        private System.Windows.Forms.Button BtnLab01Stop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lbl2Lab01Test1;
        private System.Windows.Forms.Label LblLab01Test1;
        private System.Windows.Forms.Button button1;
    }
}

