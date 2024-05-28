using MaterialSkin2Framework;
using MaterialSkin2Framework.Controls;

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
            this.ServerTxtBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.materialLabel1 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.BtnConnect = new MaterialSkin2Framework.Controls.MaterialButton();
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
            this.ServerTxtBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ServerTxtBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ServerTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ServerTxtBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ServerTxtBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ServerTxtBox.Depth = 0;
            this.ServerTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ServerTxtBox.HideSelection = true;
            this.ServerTxtBox.Hint = "Enter Server URL";
            this.ServerTxtBox.LeadingIcon = null;
            this.ServerTxtBox.Location = new System.Drawing.Point(150, 194);
            this.ServerTxtBox.MaxLength = 32767;
            this.ServerTxtBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.ServerTxtBox.Name = "ServerTxtBox";
            this.ServerTxtBox.PasswordChar = '\0';
            this.ServerTxtBox.PrefixSuffixText = null;
            this.ServerTxtBox.ReadOnly = false;
            this.ServerTxtBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ServerTxtBox.SelectedText = "";
            this.ServerTxtBox.SelectionLength = 0;
            this.ServerTxtBox.SelectionStart = 0;
            this.ServerTxtBox.ShortcutsEnabled = true;
            this.ServerTxtBox.Size = new System.Drawing.Size(277, 48);
            this.ServerTxtBox.TabIndex = 10;
            this.ServerTxtBox.TabStop = false;
            this.ServerTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ServerTxtBox.TrailingIcon = null;
            this.ServerTxtBox.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(99, 207);
            this.materialLabel1.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(45, 19);
            this.materialLabel1.TabIndex = 11;
            this.materialLabel1.Text = "Server";
            // 
            // BtnConnect
            // 
            this.BtnConnect.AutoSize = false;
            this.BtnConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.BtnConnect.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnConnect.Depth = 0;
            this.BtnConnect.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnConnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnConnect.HighEmphasis = true;
            this.BtnConnect.Icon = null;
            this.BtnConnect.Location = new System.Drawing.Point(217, 286);
            this.BtnConnect.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnConnect.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnConnect.Size = new System.Drawing.Size(120, 40);
            this.BtnConnect.TabIndex = 12;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnConnect.UseAccentColor = false;
            this.BtnConnect.UseVisualStyleBackColor = false;
            this.BtnConnect.Click += new System.EventHandler(this.ServerBtn_Click);
            // 
            // SelectServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 411);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.ServerTxtBox);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormStyle = MaterialSkin2Framework.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.FormToManage = this;
            this.Name = "SelectServerForm";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SelectServerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin2Framework.Controls.MaterialTextBox2 ServerTxtBox;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel1;
        private MaterialSkin2Framework.Controls.MaterialButton BtnConnect;
    }
}
