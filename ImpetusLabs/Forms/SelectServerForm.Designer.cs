using MaterialSkin;
using MaterialSkin.Controls;
namespace ImpetusLabs.Forms
{
    partial class SelectServerForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ServerTxtBox = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.ServerBtn = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ImpetusLabs.Properties.Resources.JCA_n_logo_new_ns_js_copy_3;
            this.pictureBox1.Location = new System.Drawing.Point(167, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // ServerTxtBox
            // 
            this.ServerTxtBox.AnimateReadOnly = false;
            this.ServerTxtBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ServerTxtBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ServerTxtBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ServerTxtBox.Depth = 0;
            this.ServerTxtBox.HideSelection = true;
            this.ServerTxtBox.Location = new System.Drawing.Point(156, 213);
            this.ServerTxtBox.MaxLength = 32767;
            this.ServerTxtBox.MouseState = MaterialSkin.MouseState.OUT;
            this.ServerTxtBox.Name = "ServerTxtBox";
            this.ServerTxtBox.PasswordChar = '\0';
            this.ServerTxtBox.ReadOnly = false;
            this.ServerTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ServerTxtBox.SelectedText = "";
            this.ServerTxtBox.SelectionLength = 0;
            this.ServerTxtBox.SelectionStart = 0;
            this.ServerTxtBox.ShortcutsEnabled = true;
            this.ServerTxtBox.Size = new System.Drawing.Size(277, 35);
            this.ServerTxtBox.TabIndex = 10;
            this.ServerTxtBox.TabStop = false;
            this.ServerTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ServerTxtBox.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(96, 221);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(45, 19);
            this.materialLabel1.TabIndex = 11;
            this.materialLabel1.Text = "Server";
            // 
            // ServerBtn
            // 
            this.ServerBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ServerBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ServerBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ServerBtn.Depth = 0;
            this.ServerBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ServerBtn.HighEmphasis = true;
            this.ServerBtn.Icon = null;
            this.ServerBtn.Location = new System.Drawing.Point(222, 305);
            this.ServerBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ServerBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ServerBtn.Name = "ServerBtn";
            this.ServerBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ServerBtn.Size = new System.Drawing.Size(89, 36);
            this.ServerBtn.TabIndex = 12;
            this.ServerBtn.Text = "Connect";
            this.ServerBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ServerBtn.UseAccentColor = false;
            this.ServerBtn.UseVisualStyleBackColor = false;
            this.ServerBtn.Click += new System.EventHandler(this.ServerBtn_Click);
            // 
            // SelectServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 411);
            this.Controls.Add(this.ServerBtn);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.ServerTxtBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SelectServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SelectServerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 ServerTxtBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton ServerBtn;
    }
}