namespace DVLD
{
    partial class LoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnbMoreInfo = new System.Windows.Forms.LinkLabel();
            this.txbUN = new System.Windows.Forms.TextBox();
            this.txbPS = new System.Windows.Forms.TextBox();
            this.lbUN = new System.Windows.Forms.Label();
            this.lbPS = new System.Windows.Forms.Label();
            this.lbTitel = new System.Windows.Forms.Label();
            this.chkRM = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 334);
            this.panel1.TabIndex = 0;
            // 
            // lnbMoreInfo
            // 
            this.lnbMoreInfo.AutoSize = true;
            this.lnbMoreInfo.Location = new System.Drawing.Point(591, 312);
            this.lnbMoreInfo.Name = "lnbMoreInfo";
            this.lnbMoreInfo.Size = new System.Drawing.Size(58, 13);
            this.lnbMoreInfo.TabIndex = 1;
            this.lnbMoreInfo.TabStop = true;
            this.lnbMoreInfo.Text = "MoreInfo...";
            this.lnbMoreInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnbMoreInfo_LinkClicked);
            // 
            // txbUN
            // 
            this.txbUN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUN.Location = new System.Drawing.Point(452, 90);
            this.txbUN.Name = "txbUN";
            this.txbUN.Size = new System.Drawing.Size(177, 22);
            this.txbUN.TabIndex = 2;
            // 
            // txbPS
            // 
            this.txbPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPS.Location = new System.Drawing.Point(452, 130);
            this.txbPS.Name = "txbPS";
            this.txbPS.Size = new System.Drawing.Size(177, 22);
            this.txbPS.TabIndex = 3;
            // 
            // lbUN
            // 
            this.lbUN.AutoSize = true;
            this.lbUN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUN.Location = new System.Drawing.Point(331, 93);
            this.lbUN.Name = "lbUN";
            this.lbUN.Size = new System.Drawing.Size(81, 16);
            this.lbUN.TabIndex = 4;
            this.lbUN.Text = "UserName";
            // 
            // lbPS
            // 
            this.lbPS.AutoSize = true;
            this.lbPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPS.Location = new System.Drawing.Point(331, 137);
            this.lbPS.Name = "lbPS";
            this.lbPS.Size = new System.Drawing.Size(75, 16);
            this.lbPS.TabIndex = 5;
            this.lbPS.Text = "Password";
            // 
            // lbTitel
            // 
            this.lbTitel.AutoSize = true;
            this.lbTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitel.Location = new System.Drawing.Point(380, 35);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(212, 24);
            this.lbTitel.TabIndex = 6;
            this.lbTitel.Text = "Login to your account";
            // 
            // chkRM
            // 
            this.chkRM.AutoSize = true;
            this.chkRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRM.Location = new System.Drawing.Point(452, 171);
            this.chkRM.Name = "chkRM";
            this.chkRM.Size = new System.Drawing.Size(116, 20);
            this.chkRM.TabIndex = 8;
            this.chkRM.Text = "Remember Me";
            this.chkRM.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(422, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(412, 126);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 28);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(543, 237);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(86, 30);
            this.btnLogin.TabIndex = 11;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 334);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkRM);
            this.Controls.Add(this.lbTitel);
            this.Controls.Add(this.lbPS);
            this.Controls.Add(this.lbUN);
            this.Controls.Add(this.txbPS);
            this.Controls.Add(this.txbUN);
            this.Controls.Add(this.lnbMoreInfo);
            this.Controls.Add(this.panel1);
            this.Name = "LoginScreen";
            this.Text = "LoginScreen";
            this.Load += new System.EventHandler(this.LoginScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnbMoreInfo;
        private System.Windows.Forms.TextBox txbUN;
        private System.Windows.Forms.TextBox txbPS;
        private System.Windows.Forms.Label lbUN;
        private System.Windows.Forms.Label lbPS;
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.CheckBox chkRM;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}