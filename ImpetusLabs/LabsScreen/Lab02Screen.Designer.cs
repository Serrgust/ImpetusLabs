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
            this.Lbl2Lab02Test1 = new System.Windows.Forms.Label();
            this.LblLab02Test1 = new System.Windows.Forms.Label();
            this.Lbl2Lab02Test2 = new System.Windows.Forms.Label();
            this.LblLab02Test2 = new System.Windows.Forms.Label();
            this.BtnLab02Start = new System.Windows.Forms.Button();
            this.BtnLab02Stop = new System.Windows.Forms.Button();
            this.TimerLab02 = new System.Windows.Forms.Timer(this.components);
            this.LblCurrentLab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lbl2Lab02Test1
            // 
            this.Lbl2Lab02Test1.BackColor = System.Drawing.Color.Silver;
            this.Lbl2Lab02Test1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl2Lab02Test1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl2Lab02Test1.Location = new System.Drawing.Point(604, 183);
            this.Lbl2Lab02Test1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl2Lab02Test1.Name = "Lbl2Lab02Test1";
            this.Lbl2Lab02Test1.Size = new System.Drawing.Size(194, 55);
            this.Lbl2Lab02Test1.TabIndex = 31;
            this.Lbl2Lab02Test1.Text = "NOT RUN";
            this.Lbl2Lab02Test1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblLab02Test1
            // 
            this.LblLab02Test1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLab02Test1.Location = new System.Drawing.Point(507, 193);
            this.LblLab02Test1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblLab02Test1.Name = "LblLab02Test1";
            this.LblLab02Test1.Size = new System.Drawing.Size(89, 28);
            this.LblLab02Test1.TabIndex = 32;
            this.LblLab02Test1.Text = "Test 1";
            // 
            // Lbl2Lab02Test2
            // 
            this.Lbl2Lab02Test2.BackColor = System.Drawing.Color.Silver;
            this.Lbl2Lab02Test2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl2Lab02Test2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl2Lab02Test2.Location = new System.Drawing.Point(604, 283);
            this.Lbl2Lab02Test2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl2Lab02Test2.Name = "Lbl2Lab02Test2";
            this.Lbl2Lab02Test2.Size = new System.Drawing.Size(194, 55);
            this.Lbl2Lab02Test2.TabIndex = 33;
            this.Lbl2Lab02Test2.Text = "NOT RUN";
            this.Lbl2Lab02Test2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblLab02Test2
            // 
            this.LblLab02Test2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLab02Test2.Location = new System.Drawing.Point(507, 293);
            this.LblLab02Test2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblLab02Test2.Name = "LblLab02Test2";
            this.LblLab02Test2.Size = new System.Drawing.Size(89, 28);
            this.LblLab02Test2.TabIndex = 34;
            this.LblLab02Test2.Text = "Test 2";
            // 
            // BtnLab02Start
            // 
            this.BtnLab02Start.Location = new System.Drawing.Point(603, 473);
            this.BtnLab02Start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnLab02Start.Name = "BtnLab02Start";
            this.BtnLab02Start.Size = new System.Drawing.Size(197, 97);
            this.BtnLab02Start.TabIndex = 42;
            this.BtnLab02Start.Text = "START SIM";
            this.BtnLab02Start.UseVisualStyleBackColor = true;
            this.BtnLab02Start.Click += new System.EventHandler(this.BtnLab02Start_Click);
            // 
            // BtnLab02Stop
            // 
            this.BtnLab02Stop.Location = new System.Drawing.Point(601, 473);
            this.BtnLab02Stop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnLab02Stop.Name = "BtnLab02Stop";
            this.BtnLab02Stop.Size = new System.Drawing.Size(197, 97);
            this.BtnLab02Stop.TabIndex = 43;
            this.BtnLab02Stop.Text = "STOP SIM";
            this.BtnLab02Stop.UseVisualStyleBackColor = true;
            this.BtnLab02Stop.Click += new System.EventHandler(this.BtnLab02Stop_Click);
            // 
            // TimerLab02
            // 
            this.TimerLab02.Interval = 500;
            this.TimerLab02.Tick += new System.EventHandler(this.TimerLab02_Tick);
            // 
            // LblCurrentLab
            // 
            this.LblCurrentLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrentLab.Location = new System.Drawing.Point(46, 60);
            this.LblCurrentLab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCurrentLab.Name = "LblCurrentLab";
            this.LblCurrentLab.Size = new System.Drawing.Size(89, 28);
            this.LblCurrentLab.TabIndex = 44;
            // 
            // Lab02Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblCurrentLab);
            this.Controls.Add(this.BtnLab02Start);
            this.Controls.Add(this.BtnLab02Stop);
            this.Controls.Add(this.LblLab02Test2);
            this.Controls.Add(this.Lbl2Lab02Test2);
            this.Controls.Add(this.LblLab02Test1);
            this.Controls.Add(this.Lbl2Lab02Test1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Lab02Screen";
            this.Size = new System.Drawing.Size(1485, 740);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Lbl2Lab02Test1;
        private System.Windows.Forms.Label LblLab02Test1;
        private System.Windows.Forms.Label Lbl2Lab02Test2;
        private System.Windows.Forms.Label LblLab02Test2;
        private System.Windows.Forms.Button BtnLab02Start;
        private System.Windows.Forms.Button BtnLab02Stop;
        private System.Windows.Forms.Timer TimerLab02;
        private System.Windows.Forms.Label LblCurrentLab;
    }
}
