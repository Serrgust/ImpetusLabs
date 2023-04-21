namespace ImpetusLabs.LabsScreen
{
    partial class Lab02Screen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lab02Screen));
            this.Lbl2Lab02Test1 = new System.Windows.Forms.Label();
            this.LblLab02Test1 = new System.Windows.Forms.Label();
            this.Lbl2Lab02Test2 = new System.Windows.Forms.Label();
            this.LblLab02Test2 = new System.Windows.Forms.Label();
            this.TimerLab02 = new System.Windows.Forms.Timer(this.components);
            this.LblCurrentLab = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnNextLab = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.BtnLab02Start = new System.Windows.Forms.Button();
            this.BtnLab02Stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelInputOuput = new System.Windows.Forms.Panel();
            this.lblTimer1 = new System.Windows.Forms.Label();
            this.PicTimer1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOutSeconds = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLabStatus = new System.Windows.Forms.Label();
            this.lblLabMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelInputOuput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTimer1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl2Lab02Test1
            // 
            this.Lbl2Lab02Test1.BackColor = System.Drawing.Color.Silver;
            this.Lbl2Lab02Test1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl2Lab02Test1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl2Lab02Test1.Location = new System.Drawing.Point(394, 166);
            this.Lbl2Lab02Test1.Name = "Lbl2Lab02Test1";
            this.Lbl2Lab02Test1.Size = new System.Drawing.Size(140, 45);
            this.Lbl2Lab02Test1.TabIndex = 31;
            this.Lbl2Lab02Test1.Text = "NOT RUN";
            this.Lbl2Lab02Test1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblLab02Test1
            // 
            this.LblLab02Test1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLab02Test1.Location = new System.Drawing.Point(232, 166);
            this.LblLab02Test1.Name = "LblLab02Test1";
            this.LblLab02Test1.Size = new System.Drawing.Size(140, 45);
            this.LblLab02Test1.TabIndex = 32;
            this.LblLab02Test1.Text = "Test 1";
            this.LblLab02Test1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl2Lab02Test2
            // 
            this.Lbl2Lab02Test2.BackColor = System.Drawing.Color.Silver;
            this.Lbl2Lab02Test2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl2Lab02Test2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl2Lab02Test2.Location = new System.Drawing.Point(394, 234);
            this.Lbl2Lab02Test2.Name = "Lbl2Lab02Test2";
            this.Lbl2Lab02Test2.Size = new System.Drawing.Size(140, 45);
            this.Lbl2Lab02Test2.TabIndex = 33;
            this.Lbl2Lab02Test2.Text = "NOT RUN";
            this.Lbl2Lab02Test2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblLab02Test2
            // 
            this.LblLab02Test2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLab02Test2.Location = new System.Drawing.Point(232, 234);
            this.LblLab02Test2.Name = "LblLab02Test2";
            this.LblLab02Test2.Size = new System.Drawing.Size(140, 45);
            this.LblLab02Test2.TabIndex = 34;
            this.LblLab02Test2.Text = "Test 2";
            this.LblLab02Test2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimerLab02
            // 
            this.TimerLab02.Interval = 500;
            this.TimerLab02.Tick += new System.EventHandler(this.TimerLab02_Tick);
            // 
            // LblCurrentLab
            // 
            this.LblCurrentLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrentLab.Location = new System.Drawing.Point(34, 49);
            this.LblCurrentLab.Name = "LblCurrentLab";
            this.LblCurrentLab.Size = new System.Drawing.Size(67, 23);
            this.LblCurrentLab.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LblLab02Test2);
            this.panel1.Controls.Add(this.Lbl2Lab02Test2);
            this.panel1.Controls.Add(this.LblLab02Test1);
            this.panel1.Controls.Add(this.Lbl2Lab02Test1);
            this.panel1.Location = new System.Drawing.Point(465, 180);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 449);
            this.panel1.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(247, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 45);
            this.label3.TabIndex = 57;
            this.label3.Text = "SIMULATION";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.BtnNextLab);
            this.panel3.Controls.Add(this.BtnBack);
            this.panel3.Controls.Add(this.BtnLab02Start);
            this.panel3.Controls.Add(this.BtnLab02Stop);
            this.panel3.Location = new System.Drawing.Point(612, 695);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(498, 95);
            this.panel3.TabIndex = 58;
            // 
            // BtnNextLab
            // 
            this.BtnNextLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNextLab.Location = new System.Drawing.Point(349, 14);
            this.BtnNextLab.Name = "BtnNextLab";
            this.BtnNextLab.Size = new System.Drawing.Size(138, 62);
            this.BtnNextLab.TabIndex = 54;
            this.BtnNextLab.Text = "NEXT";
            this.BtnNextLab.UseVisualStyleBackColor = true;
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.Location = new System.Drawing.Point(3, 14);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(138, 62);
            this.BtnBack.TabIndex = 43;
            this.BtnBack.Text = "BACK";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // BtnLab02Start
            // 
            this.BtnLab02Start.FlatAppearance.BorderSize = 0;
            this.BtnLab02Start.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.BtnLab02Start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnLab02Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLab02Start.Location = new System.Drawing.Point(179, 14);
            this.BtnLab02Start.Name = "BtnLab02Start";
            this.BtnLab02Start.Size = new System.Drawing.Size(138, 62);
            this.BtnLab02Start.TabIndex = 26;
            this.BtnLab02Start.Text = "START SIM";
            this.BtnLab02Start.UseVisualStyleBackColor = true;
            this.BtnLab02Start.Click += new System.EventHandler(this.BtnLab02Start_Click_1);
            // 
            // BtnLab02Stop
            // 
            this.BtnLab02Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLab02Stop.Location = new System.Drawing.Point(180, 14);
            this.BtnLab02Stop.Name = "BtnLab02Stop";
            this.BtnLab02Stop.Size = new System.Drawing.Size(138, 62);
            this.BtnLab02Stop.TabIndex = 39;
            this.BtnLab02Stop.Text = "STOP SIM";
            this.BtnLab02Stop.UseVisualStyleBackColor = true;
            this.BtnLab02Stop.Click += new System.EventHandler(this.BtnLab02Stop_Click_1);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(759, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 45);
            this.label1.TabIndex = 59;
            this.label1.Text = "LAB #2";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelInputOuput
            // 
            this.panelInputOuput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelInputOuput.Controls.Add(this.lblTimer1);
            this.panelInputOuput.Controls.Add(this.PicTimer1);
            this.panelInputOuput.Controls.Add(this.label2);
            this.panelInputOuput.Location = new System.Drawing.Point(1284, 180);
            this.panelInputOuput.Name = "panelInputOuput";
            this.panelInputOuput.Size = new System.Drawing.Size(346, 269);
            this.panelInputOuput.TabIndex = 60;
            // 
            // lblTimer1
            // 
            this.lblTimer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer1.Location = new System.Drawing.Point(122, 120);
            this.lblTimer1.Name = "lblTimer1";
            this.lblTimer1.Size = new System.Drawing.Size(81, 55);
            this.lblTimer1.TabIndex = 43;
            this.lblTimer1.Text = "TIMER OFF";
            this.lblTimer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicTimer1
            // 
            this.PicTimer1.Location = new System.Drawing.Point(122, 40);
            this.PicTimer1.Name = "PicTimer1";
            this.PicTimer1.Size = new System.Drawing.Size(81, 65);
            this.PicTimer1.TabIndex = 48;
            this.PicTimer1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, -8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 45);
            this.label2.TabIndex = 43;
            this.label2.Text = "INPUTS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Timeroff.png");
            this.imageList1.Images.SetKeyName(1, "TimerON.jpg");
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblOutSeconds);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(1284, 515);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 114);
            this.panel2.TabIndex = 61;
            // 
            // lblOutSeconds
            // 
            this.lblOutSeconds.BackColor = System.Drawing.Color.Transparent;
            this.lblOutSeconds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutSeconds.Location = new System.Drawing.Point(155, 75);
            this.lblOutSeconds.Name = "lblOutSeconds";
            this.lblOutSeconds.Size = new System.Drawing.Size(142, 28);
            this.lblOutSeconds.TabIndex = 58;
            this.lblOutSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 28);
            this.label4.TabIndex = 58;
            this.label4.Text = "SECONDS:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(91, -2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 45);
            this.label5.TabIndex = 43;
            this.label5.Text = "OUTPUTS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLabStatus
            // 
            this.lblLabStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabStatus.Location = new System.Drawing.Point(0, 651);
            this.lblLabStatus.Name = "lblLabStatus";
            this.lblLabStatus.Size = new System.Drawing.Size(1771, 41);
            this.lblLabStatus.TabIndex = 62;
            this.lblLabStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLabMessage
            // 
            this.lblLabMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabMessage.Location = new System.Drawing.Point(-28, 136);
            this.lblLabMessage.Name = "lblLabMessage";
            this.lblLabMessage.Size = new System.Drawing.Size(1771, 41);
            this.lblLabMessage.TabIndex = 63;
            this.lblLabMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab02Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.lblLabMessage);
            this.Controls.Add(this.lblLabStatus);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelInputOuput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblCurrentLab);
            this.Name = "Lab02Screen";
            this.Size = new System.Drawing.Size(1700, 857);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelInputOuput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicTimer1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Lbl2Lab02Test1;
        private System.Windows.Forms.Label LblLab02Test1;
        private System.Windows.Forms.Label Lbl2Lab02Test2;
        private System.Windows.Forms.Label LblLab02Test2;
        private System.Windows.Forms.Timer TimerLab02;
        private System.Windows.Forms.Label LblCurrentLab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnNextLab;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Button BtnLab02Start;
        private System.Windows.Forms.Button BtnLab02Stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelInputOuput;
        private System.Windows.Forms.Label lblTimer1;
        private System.Windows.Forms.PictureBox PicTimer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOutSeconds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLabStatus;
        private System.Windows.Forms.Label lblLabMessage;
    }
}
