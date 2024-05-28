using MaterialSkin;
using MaterialSkin.Controls;

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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                // Dispose OPC connection manager here
                opcConnectionManager?.Disconnect();
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
            this.TopPanel = new MaterialSkin.Controls.MaterialCard();
            this.TopMainText = new MaterialSkin.Controls.MaterialLabel();
            this.TopTime = new MaterialSkin.Controls.MaterialLabel();
            this.TopDate = new MaterialSkin.Controls.MaterialLabel();
            this.label2 = new MaterialSkin.Controls.MaterialLabel();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.LeftLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnHome = new MaterialSkin.Controls.MaterialButton();
            this.BtnLabSelection = new MaterialSkin.Controls.MaterialButton();
            this.BtnLoginScreen = new MaterialSkin.Controls.MaterialButton();
            this.BtnX = new MaterialSkin.Controls.MaterialButton();
            this.BtnSelectServer = new MaterialSkin.Controls.MaterialButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MainPanel = new System.Windows.Forms.Panel();
            this.TopPanel.SuspendLayout();
            this.LeftLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Yellow; // Set background to yellow
            this.TopPanel.Controls.Add(this.TopMainText);
            this.TopPanel.Controls.Add(this.TopTime);
            this.TopPanel.Controls.Add(this.TopDate);
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Depth = 0;
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TopPanel.Location = new System.Drawing.Point(3, 64);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(14);
            this.TopPanel.MouseState = MaterialSkin.MouseState.HOVER;
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Padding = new System.Windows.Forms.Padding(14);
            this.TopPanel.Size = new System.Drawing.Size(1258, 80);
            this.TopPanel.TabIndex = 7;
            // 
            // TopMainText
            // 
            this.TopMainText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TopMainText.AutoSize = true;
            this.TopMainText.BackColor = System.Drawing.Color.Transparent;
            this.TopMainText.Depth = 0;
            this.TopMainText.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.TopMainText.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.TopMainText.Location = new System.Drawing.Point(262, 9);
            this.TopMainText.MouseState = MaterialSkin.MouseState.HOVER;
            this.TopMainText.Name = "TopMainText";
            this.TopMainText.Size = new System.Drawing.Size(661, 58);
            this.TopMainText.TabIndex = 0;
            this.TopMainText.Text = "JC AUTOMATION Training Hub";
            // 
            // TopTime
            // 
            this.TopTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TopTime.AutoSize = true;
            this.TopTime.BackColor = System.Drawing.Color.Transparent;
            this.TopTime.Depth = 0;
            this.TopTime.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TopTime.Location = new System.Drawing.Point(56, 44);
            this.TopTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.TopTime.Name = "TopTime";
            this.TopTime.Size = new System.Drawing.Size(41, 19);
            this.TopTime.TabIndex = 4;
            this.TopTime.Text = "Time:";
            // 
            // TopDate
            // 
            this.TopDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TopDate.AutoSize = true;
            this.TopDate.BackColor = System.Drawing.Color.Transparent;
            this.TopDate.Depth = 0;
            this.TopDate.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TopDate.Location = new System.Drawing.Point(56, 9);
            this.TopDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.TopDate.Name = "TopDate";
            this.TopDate.Size = new System.Drawing.Size(38, 19);
            this.TopDate.TabIndex = 3;
            this.TopDate.Text = "Date:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Depth = 0;
            this.label2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.MouseState = MaterialSkin.MouseState.HOVER;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date:";
            // 
            // LeftLayoutPanel
            // 
            this.LeftLayoutPanel.BackColor = System.Drawing.Color.Blue; // Set background to blue
            this.LeftLayoutPanel.ColumnCount = 1;
            this.LeftLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftLayoutPanel.Controls.Add(this.BtnHome, 0, 0);
            this.LeftLayoutPanel.Controls.Add(this.BtnLabSelection, 0, 1);
            this.LeftLayoutPanel.Controls.Add(this.BtnLoginScreen, 0, 2);
            this.LeftLayoutPanel.Controls.Add(this.BtnX, 0, 3);
            this.LeftLayoutPanel.Controls.Add(this.BtnSelectServer, 0, 4);
            this.LeftLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftLayoutPanel.Location = new System.Drawing.Point(3, 144);
            this.LeftLayoutPanel.Name = "LeftLayoutPanel";
            this.LeftLayoutPanel.RowCount = 5;
            this.LeftLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LeftLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LeftLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LeftLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LeftLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LeftLayoutPanel.Size = new System.Drawing.Size(200, 571);
            this.LeftLayoutPanel.TabIndex = 9;
            // 
            // BtnHome
            // 
            this.BtnHome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnHome.AutoSize = false;
            this.BtnHome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnHome.BackColor = System.Drawing.Color.Transparent;
            this.BtnHome.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnHome.Depth = 0;
            this.BtnHome.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.BtnHome.HighEmphasis = true;
            this.BtnHome.Icon = null;
            this.BtnHome.Location = new System.Drawing.Point(27, 32);
            this.BtnHome.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnHome.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnHome.Size = new System.Drawing.Size(145, 50);
            this.BtnHome.TabIndex = 0;
            this.BtnHome.Text = "HOME";
            this.BtnHome.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnHome.UseAccentColor = false;
            this.BtnHome.UseVisualStyleBackColor = true;
            this.BtnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // BtnLabSelection
            // 
            this.BtnLabSelection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnLabSelection.AutoSize = false;
            this.BtnLabSelection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnLabSelection.BackColor = System.Drawing.Color.Transparent;
            this.BtnLabSelection.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnLabSelection.Depth = 0;
            this.BtnLabSelection.HighEmphasis = true;
            this.BtnLabSelection.Icon = null;
            this.BtnLabSelection.Location = new System.Drawing.Point(27, 146);
            this.BtnLabSelection.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnLabSelection.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnLabSelection.Name = "BtnLabSelection";
            this.BtnLabSelection.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnLabSelection.Size = new System.Drawing.Size(145, 50);
            this.BtnLabSelection.TabIndex = 1;
            this.BtnLabSelection.Text = "PLC LABS";
            this.BtnLabSelection.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnLabSelection.UseAccentColor = false;
            this.BtnLabSelection.UseVisualStyleBackColor = false;
            this.BtnLabSelection.Click += new System.EventHandler(this.BtnLabSelection_Click);
            // 
            // BtnLoginScreen
            // 
            this.BtnLoginScreen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnLoginScreen.AutoSize = false;
            this.BtnLoginScreen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnLoginScreen.BackColor = System.Drawing.Color.Transparent;
            this.BtnLoginScreen.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnLoginScreen.Depth = 0;
            this.BtnLoginScreen.HighEmphasis = true;
            this.BtnLoginScreen.Icon = null;
            this.BtnLoginScreen.Location = new System.Drawing.Point(27, 260);
            this.BtnLoginScreen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnLoginScreen.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnLoginScreen.Name = "BtnLoginScreen";
            this.BtnLoginScreen.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnLoginScreen.Size = new System.Drawing.Size(145, 50);
            this.BtnLoginScreen.TabIndex = 2;
            this.BtnLoginScreen.Text = "LOG IN";
            this.BtnLoginScreen.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnLoginScreen.UseAccentColor = false;
            this.BtnLoginScreen.UseVisualStyleBackColor = false;
            this.BtnLoginScreen.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnX
            // 
            this.BtnX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnX.AutoSize = false;
            this.BtnX.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnX.BackColor = System.Drawing.Color.Transparent;
            this.BtnX.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnX.Depth = 0;
            this.BtnX.HighEmphasis = true;
            this.BtnX.Icon = null;
            this.BtnX.Location = new System.Drawing.Point(27, 374);
            this.BtnX.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnX.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnX.Name = "BtnX";
            this.BtnX.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnX.Size = new System.Drawing.Size(145, 50);
            this.BtnX.TabIndex = 3;
            this.BtnX.Text = "BUTTON X";
            this.BtnX.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnX.UseAccentColor = false;
            this.BtnX.UseVisualStyleBackColor = false;
            this.BtnX.Click += new System.EventHandler(this.BtnX_Click);
            // 
            // BtnSelectServer
            // 
            this.BtnSelectServer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSelectServer.AutoSize = false;
            this.BtnSelectServer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnSelectServer.BackColor = System.Drawing.Color.Transparent;
            this.BtnSelectServer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnSelectServer.Depth = 0;
            this.BtnSelectServer.HighEmphasis = true;
            this.BtnSelectServer.Icon = null;
            this.BtnSelectServer.Location = new System.Drawing.Point(27, 488);
            this.BtnSelectServer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnSelectServer.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnSelectServer.Name = "BtnSelectServer";
            this.BtnSelectServer.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnSelectServer.Size = new System.Drawing.Size(145, 50);
            this.BtnSelectServer.TabIndex = 4;
            this.BtnSelectServer.Text = "CONNECT";
            this.BtnSelectServer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnSelectServer.UseAccentColor = false;
            this.BtnSelectServer.UseVisualStyleBackColor = false;
            this.BtnSelectServer.Click += new System.EventHandler(this.BtnSelectServer_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Location = new System.Drawing.Point(209, 144);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1055, 574);
            this.MainPanel.TabIndex = 15;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 718);
            this.Controls.Add(this.LeftLayoutPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.TopPanel);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Window";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.LeftLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard TopPanel;
        private System.Windows.Forms.TableLayoutPanel LeftLayoutPanel;
        private MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialLabel TopTime;
        private MaterialSkin.Controls.MaterialLabel TopDate;
        private System.Windows.Forms.Timer timer1;
        private MaterialSkin.Controls.MaterialLabel TopMainText;
        private System.Windows.Forms.Panel MainPanel;
        private MaterialSkin.Controls.MaterialButton BtnHome;
        private MaterialSkin.Controls.MaterialButton BtnLabSelection;
        private MaterialSkin.Controls.MaterialButton BtnLoginScreen;
        private MaterialSkin.Controls.MaterialButton BtnX;
        private MaterialSkin.Controls.MaterialButton BtnSelectServer;
    }
}
