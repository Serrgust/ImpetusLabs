namespace ImpetusLabs
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.TopTime = new System.Windows.Forms.Label();
            this.TopDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TopMainText = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnLabSelection = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.materialBtnLabSelection = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialBtnLogin = new MaterialSkin.Controls.MaterialRaisedButton();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TopPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Yellow;
            this.TopPanel.Controls.Add(this.label3);
            this.TopPanel.Controls.Add(this.TopTime);
            this.TopPanel.Controls.Add(this.TopDate);
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Controls.Add(this.TopMainText);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1264, 80);
            this.TopPanel.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1054, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "User:";
            // 
            // TopTime
            // 
            this.TopTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TopTime.AutoSize = true;
            this.TopTime.BackColor = System.Drawing.Color.Transparent;
            this.TopTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopTime.Location = new System.Drawing.Point(78, 44);
            this.TopTime.Name = "TopTime";
            this.TopTime.Size = new System.Drawing.Size(47, 20);
            this.TopTime.TabIndex = 4;
            this.TopTime.Text = "Time:";
            // 
            // TopDate
            // 
            this.TopDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TopDate.AutoSize = true;
            this.TopDate.BackColor = System.Drawing.Color.Transparent;
            this.TopDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopDate.Location = new System.Drawing.Point(78, 9);
            this.TopDate.Name = "TopDate";
            this.TopDate.Size = new System.Drawing.Size(48, 20);
            this.TopDate.TabIndex = 3;
            this.TopDate.Text = "Date:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date:";
            // 
            // TopMainText
            // 
            this.TopMainText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TopMainText.AutoSize = true;
            this.TopMainText.BackColor = System.Drawing.Color.Transparent;
            this.TopMainText.Cursor = System.Windows.Forms.Cursors.Default;
            this.TopMainText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopMainText.Location = new System.Drawing.Point(220, 9);
            this.TopMainText.Name = "TopMainText";
            this.TopMainText.Size = new System.Drawing.Size(729, 55);
            this.TopMainText.TabIndex = 0;
            this.TopMainText.Text = "JC AUTOMATION Training Hub";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Blue;
            this.flowLayoutPanel1.Controls.Add(this.BtnLabSelection);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.BtnLogin);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Controls.Add(this.button5);
            this.flowLayoutPanel1.Controls.Add(this.button6);
            this.flowLayoutPanel1.Controls.Add(this.materialBtnLabSelection);
            this.flowLayoutPanel1.Controls.Add(this.materialBtnLogin);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 80);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(155, 601);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // BtnLabSelection
            // 
            this.BtnLabSelection.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnLabSelection.Location = new System.Drawing.Point(10, 20);
            this.BtnLabSelection.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.BtnLabSelection.Name = "BtnLabSelection";
            this.BtnLabSelection.Size = new System.Drawing.Size(124, 52);
            this.BtnLabSelection.TabIndex = 8;
            this.BtnLabSelection.Text = "PLC LABS";
            this.BtnLabSelection.UseVisualStyleBackColor = true;
            this.BtnLabSelection.Click += new System.EventHandler(this.BtnLabSelection_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.Location = new System.Drawing.Point(10, 112);
            this.button2.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 52);
            this.button2.TabIndex = 9;
            this.button2.Text = "STUDIO 5000";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BtnLogin
            // 
            this.BtnLogin.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnLogin.Location = new System.Drawing.Point(10, 204);
            this.BtnLogin.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(124, 52);
            this.BtnLogin.TabIndex = 10;
            this.BtnLogin.Text = "LOGIN";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Default;
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.Location = new System.Drawing.Point(10, 296);
            this.button4.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 52);
            this.button4.TabIndex = 11;
            this.button4.Text = "RSLOGIX 500";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Default;
            this.button5.Dock = System.Windows.Forms.DockStyle.Left;
            this.button5.Location = new System.Drawing.Point(10, 388);
            this.button5.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 52);
            this.button5.TabIndex = 12;
            this.button5.Text = "PROGRESS REPORT";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Default;
            this.button6.Dock = System.Windows.Forms.DockStyle.Left;
            this.button6.Location = new System.Drawing.Point(10, 480);
            this.button6.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(124, 52);
            this.button6.TabIndex = 13;
            this.button6.Text = "TEST CODE";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // materialBtnLabSelection
            // 
            this.materialBtnLabSelection.AutoSize = true;
            this.materialBtnLabSelection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialBtnLabSelection.BackColor = System.Drawing.Color.Blue;
            this.materialBtnLabSelection.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialBtnLabSelection.Depth = 0;
            this.materialBtnLabSelection.ForeColor = System.Drawing.SystemColors.ControlText;
            this.materialBtnLabSelection.Icon = null;
            this.materialBtnLabSelection.Location = new System.Drawing.Point(154, 20);
            this.materialBtnLabSelection.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.materialBtnLabSelection.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialBtnLabSelection.Name = "materialBtnLabSelection";
            this.materialBtnLabSelection.Primary = true;
            this.materialBtnLabSelection.Size = new System.Drawing.Size(121, 36);
            this.materialBtnLabSelection.TabIndex = 14;
            this.materialBtnLabSelection.Text = "LAB SELECTION";
            this.materialBtnLabSelection.UseVisualStyleBackColor = false;
            this.materialBtnLabSelection.Click += new System.EventHandler(this.materialBtnLabSelection_Click_1);
            // 
            // materialBtnLogin
            // 
            this.materialBtnLogin.AutoSize = true;
            this.materialBtnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialBtnLogin.BackColor = System.Drawing.Color.Blue;
            this.materialBtnLogin.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialBtnLogin.Depth = 0;
            this.materialBtnLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.materialBtnLogin.Icon = null;
            this.materialBtnLogin.Location = new System.Drawing.Point(154, 96);
            this.materialBtnLogin.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.materialBtnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialBtnLogin.Name = "materialBtnLogin";
            this.materialBtnLogin.Primary = true;
            this.materialBtnLogin.Size = new System.Drawing.Size(61, 36);
            this.materialBtnLogin.TabIndex = 15;
            this.materialBtnLogin.Text = "LOGIN";
            this.materialBtnLogin.UseVisualStyleBackColor = false;
            this.materialBtnLogin.Click += new System.EventHandler(this.materialBtnLogin_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Location = new System.Drawing.Point(155, 80);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1106, 601);
            this.MainPanel.TabIndex = 15;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.TopPanel);
            this.IsMdiContainer = true;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Window";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BtnLabSelection;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TopTime;
        private System.Windows.Forms.Label TopDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TopMainText;
        private MaterialSkin.Controls.MaterialRaisedButton materialBtnLabSelection;
        private MaterialSkin.Controls.MaterialRaisedButton materialBtnLogin;
    }
}