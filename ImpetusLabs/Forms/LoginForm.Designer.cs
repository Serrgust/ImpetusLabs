namespace ImpetusLabs
{
    partial class LoginForm
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
            this.UsernameText = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.PasswordText = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.UsernameField = new MaterialSkin2Framework.Controls.MaterialMultiLineTextBox2();
            this.PasswordField = new MaterialSkin2Framework.Controls.MaterialMultiLineTextBox2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameText
            // 
            this.UsernameText.AutoSize = true;
            this.UsernameText.Depth = 0;
            this.UsernameText.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.UsernameText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UsernameText.Location = new System.Drawing.Point(75, 179);
            this.UsernameText.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(72, 19);
            this.UsernameText.TabIndex = 0;
            this.UsernameText.Text = "Username";
            // 
            // PasswordText
            // 
            this.PasswordText.AutoSize = true;
            this.PasswordText.Depth = 0;
            this.PasswordText.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PasswordText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PasswordText.Location = new System.Drawing.Point(75, 234);
            this.PasswordText.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(71, 19);
            this.PasswordText.TabIndex = 1;
            this.PasswordText.Text = "Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ImpetusLabs.Properties.Resources.JCA_n_logo_new_ns_js_copy_3;
            this.pictureBox1.Location = new System.Drawing.Point(151, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BtnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnLogin.FlatAppearance.BorderSize = 10;
            this.BtnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnLogin.Location = new System.Drawing.Point(179, 323);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(164, 35);
            this.BtnLogin.TabIndex = 6;
            this.BtnLogin.Text = "LOG IN";
            this.BtnLogin.UseVisualStyleBackColor = false;
            // 
            // UsernameField
            // 
            this.UsernameField.AnimateReadOnly = false;
            this.UsernameField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.UsernameField.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.UsernameField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UsernameField.Depth = 0;
            this.UsernameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameField.HideSelection = true;
            this.UsernameField.Location = new System.Drawing.Point(164, 171);
            this.UsernameField.MaxLength = 32767;
            this.UsernameField.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.PasswordChar = '\0';
            this.UsernameField.ReadOnly = false;
            this.UsernameField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UsernameField.SelectedText = "";
            this.UsernameField.SelectionLength = 0;
            this.UsernameField.SelectionStart = 0;
            this.UsernameField.ShortcutsEnabled = true;
            this.UsernameField.Size = new System.Drawing.Size(250, 35);
            this.UsernameField.TabIndex = 8;
            this.UsernameField.TabStop = false;
            this.UsernameField.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UsernameField.UseSystemPasswordChar = false;
            this.UsernameField.Click += new System.EventHandler(this.materialMultiLineTextBox21_Click);
            // 
            // PasswordField
            // 
            this.PasswordField.AnimateReadOnly = false;
            this.PasswordField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PasswordField.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.PasswordField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordField.Depth = 0;
            this.PasswordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordField.HideSelection = true;
            this.PasswordField.Location = new System.Drawing.Point(164, 226);
            this.PasswordField.MaxLength = 32767;
            this.PasswordField.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '\0';
            this.PasswordField.ReadOnly = false;
            this.PasswordField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PasswordField.SelectedText = "";
            this.PasswordField.SelectionLength = 0;
            this.PasswordField.SelectionStart = 0;
            this.PasswordField.ShortcutsEnabled = true;
            this.PasswordField.Size = new System.Drawing.Size(250, 35);
            this.PasswordField.TabIndex = 9;
            this.PasswordField.TabStop = false;
            this.PasswordField.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PasswordField.UseSystemPasswordChar = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 411);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.UsernameField);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.UsernameText);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoginForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin2Framework.Controls.MaterialLabel UsernameText;
        private MaterialSkin2Framework.Controls.MaterialLabel PasswordText;
   //     private MaterialSkin2Framework.Controls.MaterialSingleLineTextField UsernameField;
   //     private MaterialSkin2Framework.Controls.MaterialSingleLineTextField PasswordField;
  //      private MaterialSkin2Framework.Controls.MaterialRaisedButton materialLoginEnter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin2Framework.Controls.MaterialMultiLineTextBox2 UsernameField;
        private MaterialSkin2Framework.Controls.MaterialMultiLineTextBox2 PasswordField;
        private System.Windows.Forms.Button BtnLogin;
    }
}