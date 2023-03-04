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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.UsernameField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.PasswordField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLoginEnter = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(75, 179);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(77, 18);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Username";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(75, 234);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(75, 18);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Password";
            // 
            // UsernameField
            // 
            this.UsernameField.Depth = 0;
            this.UsernameField.Hint = "";
            this.UsernameField.Location = new System.Drawing.Point(158, 179);
            this.UsernameField.MaxLength = 32767;
            this.UsernameField.MouseState = MaterialSkin.MouseState.HOVER;
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.PasswordChar = '\0';
            this.UsernameField.SelectedText = "";
            this.UsernameField.SelectionLength = 0;
            this.UsernameField.SelectionStart = 0;
            this.UsernameField.Size = new System.Drawing.Size(221, 23);
            this.UsernameField.TabIndex = 2;
            this.UsernameField.TabStop = false;
            this.UsernameField.UseSystemPasswordChar = false;
            // 
            // PasswordField
            // 
            this.PasswordField.Depth = 0;
            this.PasswordField.Hint = "";
            this.PasswordField.Location = new System.Drawing.Point(158, 234);
            this.PasswordField.MaxLength = 32767;
            this.PasswordField.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '\0';
            this.PasswordField.SelectedText = "";
            this.PasswordField.SelectionLength = 0;
            this.PasswordField.SelectionStart = 0;
            this.PasswordField.Size = new System.Drawing.Size(221, 23);
            this.PasswordField.TabIndex = 3;
            this.PasswordField.TabStop = false;
            this.PasswordField.UseSystemPasswordChar = false;
            // 
            // materialLoginEnter
            // 
            this.materialLoginEnter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialLoginEnter.Depth = 0;
            this.materialLoginEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLoginEnter.Icon = null;
            this.materialLoginEnter.Location = new System.Drawing.Point(158, 300);
            this.materialLoginEnter.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLoginEnter.Name = "materialLoginEnter";
            this.materialLoginEnter.Primary = true;
            this.materialLoginEnter.Size = new System.Drawing.Size(221, 36);
            this.materialLoginEnter.TabIndex = 4;
            this.materialLoginEnter.Text = "LOG IN";
            this.materialLoginEnter.UseVisualStyleBackColor = true;
            this.materialLoginEnter.Click += new System.EventHandler(this.materialLoginEnter_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ImpetusLabs.Properties.Resources.JCA_n_logo_new_ns_js_copy_3;
            this.pictureBox1.Location = new System.Drawing.Point(158, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.BorderSize = 10;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(179, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "LOG IN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 411);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.materialLoginEnter);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.UsernameField);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField UsernameField;
        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordField;
        private MaterialSkin.Controls.MaterialRaisedButton materialLoginEnter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}