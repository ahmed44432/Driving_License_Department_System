namespace DVLD
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tspmiApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tspmiPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.tspmiDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.tspmiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tspmiAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspmiApplication,
            this.tspmiPeople,
            this.tspmiDrivers,
            this.tspmiUsers,
            this.tspmiAccountSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 56);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tspmiApplication
            // 
            this.tspmiApplication.Image = ((System.Drawing.Image)(resources.GetObject("tspmiApplication.Image")));
            this.tspmiApplication.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tspmiApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspmiApplication.Name = "tspmiApplication";
            this.tspmiApplication.Size = new System.Drawing.Size(168, 52);
            this.tspmiApplication.Text = "Application";
            // 
            // tspmiPeople
            // 
            this.tspmiPeople.BackColor = System.Drawing.Color.Gray;
            this.tspmiPeople.Image = ((System.Drawing.Image)(resources.GetObject("tspmiPeople.Image")));
            this.tspmiPeople.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspmiPeople.Name = "tspmiPeople";
            this.tspmiPeople.Size = new System.Drawing.Size(121, 52);
            this.tspmiPeople.Text = "People";
            this.tspmiPeople.Click += new System.EventHandler(this.tspmiPeople_Click);
            // 
            // tspmiDrivers
            // 
            this.tspmiDrivers.Image = ((System.Drawing.Image)(resources.GetObject("tspmiDrivers.Image")));
            this.tspmiDrivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspmiDrivers.Name = "tspmiDrivers";
            this.tspmiDrivers.Size = new System.Drawing.Size(131, 52);
            this.tspmiDrivers.Text = "Drivers";
            // 
            // tspmiUsers
            // 
            this.tspmiUsers.Image = ((System.Drawing.Image)(resources.GetObject("tspmiUsers.Image")));
            this.tspmiUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspmiUsers.Name = "tspmiUsers";
            this.tspmiUsers.Size = new System.Drawing.Size(118, 52);
            this.tspmiUsers.Text = "Users";
            // 
            // tspmiAccountSettings
            // 
            this.tspmiAccountSettings.Image = ((System.Drawing.Image)(resources.GetObject("tspmiAccountSettings.Image")));
            this.tspmiAccountSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspmiAccountSettings.Name = "tspmiAccountSettings";
            this.tspmiAccountSettings.Size = new System.Drawing.Size(213, 52);
            this.tspmiAccountSettings.Text = "Account Settings";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(300, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 140);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tspmiApplication;
        private System.Windows.Forms.ToolStripMenuItem tspmiPeople;
        private System.Windows.Forms.ToolStripMenuItem tspmiDrivers;
        private System.Windows.Forms.ToolStripMenuItem tspmiUsers;
        private System.Windows.Forms.ToolStripMenuItem tspmiAccountSettings;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}