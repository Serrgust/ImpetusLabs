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
            this.LblLab02Test1 = new System.Windows.Forms.Label();
            this.LblLab02Test2 = new System.Windows.Forms.Label();
            this.Lbl2Lab02Test1 = new System.Windows.Forms.Label();
            this.Lbl2Lab02Test2 = new System.Windows.Forms.Label();
            this.BtnLab02Start = new System.Windows.Forms.Button();
            this.BtnLab02Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblLab02Test1
            // 
            this.LblLab02Test1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLab02Test1.Location = new System.Drawing.Point(368, 135);
            this.LblLab02Test1.Name = "LblLab02Test1";
            this.LblLab02Test1.Size = new System.Drawing.Size(67, 23);
            this.LblLab02Test1.TabIndex = 0;
            this.LblLab02Test1.Text = "Test 1";
            this.LblLab02Test1.Click += new System.EventHandler(this.LblLab02Test1_Click);
            // 
            // LblLab02Test2
            // 
            this.LblLab02Test2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLab02Test2.Location = new System.Drawing.Point(368, 216);
            this.LblLab02Test2.Name = "LblLab02Test2";
            this.LblLab02Test2.Size = new System.Drawing.Size(67, 23);
            this.LblLab02Test2.TabIndex = 1;
            this.LblLab02Test2.Text = "Test 2";
            this.LblLab02Test2.Click += new System.EventHandler(this.LblLab02Test2_Click);
            // 
            // Lbl2Lab02Test1
            // 
            this.Lbl2Lab02Test1.BackColor = System.Drawing.Color.Silver;
            this.Lbl2Lab02Test1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl2Lab02Test1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl2Lab02Test1.Location = new System.Drawing.Point(441, 127);
            this.Lbl2Lab02Test1.Name = "Lbl2Lab02Test1";
            this.Lbl2Lab02Test1.Size = new System.Drawing.Size(146, 45);
            this.Lbl2Lab02Test1.TabIndex = 29;
            this.Lbl2Lab02Test1.Text = "NOT RUN";
            this.Lbl2Lab02Test1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl2Lab02Test2
            // 
            this.Lbl2Lab02Test2.BackColor = System.Drawing.Color.Silver;
            this.Lbl2Lab02Test2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl2Lab02Test2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl2Lab02Test2.Location = new System.Drawing.Point(441, 208);
            this.Lbl2Lab02Test2.Name = "Lbl2Lab02Test2";
            this.Lbl2Lab02Test2.Size = new System.Drawing.Size(146, 45);
            this.Lbl2Lab02Test2.TabIndex = 30;
            this.Lbl2Lab02Test2.Text = "NOT RUN";
            this.Lbl2Lab02Test2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnLab02Start
            // 
            this.BtnLab02Start.Location = new System.Drawing.Point(441, 378);
            this.BtnLab02Start.Name = "BtnLab02Start";
            this.BtnLab02Start.Size = new System.Drawing.Size(148, 79);
            this.BtnLab02Start.TabIndex = 40;
            this.BtnLab02Start.Text = "START SIM";
            this.BtnLab02Start.UseVisualStyleBackColor = true;
            // 
            // BtnLab02Stop
            // 
            this.BtnLab02Stop.Location = new System.Drawing.Point(441, 378);
            this.BtnLab02Stop.Name = "BtnLab02Stop";
            this.BtnLab02Stop.Size = new System.Drawing.Size(148, 79);
            this.BtnLab02Stop.TabIndex = 41;
            this.BtnLab02Stop.Text = "STOP SIM";
            this.BtnLab02Stop.UseVisualStyleBackColor = true;
            this.BtnLab02Stop.Click += new System.EventHandler(this.BtnLab02Stop_Click);
            // 
            // Lab02Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnLab02Start);
            this.Controls.Add(this.BtnLab02Stop);
            this.Controls.Add(this.Lbl2Lab02Test2);
            this.Controls.Add(this.Lbl2Lab02Test1);
            this.Controls.Add(this.LblLab02Test2);
            this.Controls.Add(this.LblLab02Test1);
            this.Name = "Lab02Screen";
            this.Size = new System.Drawing.Size(1114, 601);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblLab02Test1;
        private System.Windows.Forms.Label LblLab02Test2;
        private System.Windows.Forms.Label Lbl2Lab02Test1;
        private System.Windows.Forms.Label Lbl2Lab02Test2;
        private System.Windows.Forms.Button BtnLab02Start;
        private System.Windows.Forms.Button BtnLab02Stop;
    }
}
