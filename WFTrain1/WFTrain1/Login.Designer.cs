namespace WFTrain1
{
    partial class FLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.PictureBox pictureBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLogin));
            this.btnLogin = new System.Windows.Forms.Button();
            this.lbEmail = new System.Windows.Forms.Label();
            this.tbEmailLogin = new System.Windows.Forms.TextBox();
            this.tbPasswordLogin = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.llRegister = new System.Windows.Forms.LinkLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            pictureBox1.Location = new System.Drawing.Point(574, 146);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(296, 206);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.Location = new System.Drawing.Point(724, 486);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(135, 36);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbEmail.Location = new System.Drawing.Point(441, 378);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(107, 21);
            this.lbEmail.TabIndex = 2;
            this.lbEmail.Text = "Email              :";
            // 
            // tbEmailLogin
            // 
            this.tbEmailLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbEmailLogin.Location = new System.Drawing.Point(574, 375);
            this.tbEmailLogin.Name = "tbEmailLogin";
            this.tbEmailLogin.Size = new System.Drawing.Size(285, 29);
            this.tbEmailLogin.TabIndex = 3;
            // 
            // tbPasswordLogin
            // 
            this.tbPasswordLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPasswordLogin.Location = new System.Drawing.Point(574, 434);
            this.tbPasswordLogin.Name = "tbPasswordLogin";
            this.tbPasswordLogin.Size = new System.Drawing.Size(285, 29);
            this.tbPasswordLogin.TabIndex = 5;
            this.tbPasswordLogin.UseSystemPasswordChar = true;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPassword.Location = new System.Drawing.Point(441, 437);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(107, 21);
            this.lbPassword.TabIndex = 4;
            this.lbPassword.Text = "Password       :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(662, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "anda belum memiliki akun?";
            // 
            // llRegister
            // 
            this.llRegister.AutoSize = true;
            this.llRegister.Location = new System.Drawing.Point(810, 534);
            this.llRegister.Name = "llRegister";
            this.llRegister.Size = new System.Drawing.Size(49, 15);
            this.llRegister.TabIndex = 9;
            this.llRegister.TabStop = true;
            this.llRegister.Text = "Register";
            this.llRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRegister_LinkClicked);
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.llRegister);
            this.Controls.Add(this.label1);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(this.tbPasswordLogin);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.tbEmailLogin);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.btnLogin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnLogin;
        private Label lbEmail;
        private TextBox tbEmailLogin;
        private TextBox tbPasswordLogin;
        private Label lbPassword;
        private Label label1;
        private LinkLabel llRegister;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}