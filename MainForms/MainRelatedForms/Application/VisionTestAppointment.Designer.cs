namespace DVLD.MainForms.MainRelatedForms.Application
{
    partial class VisionTestAppointment
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
            this.lbTitel = new System.Windows.Forms.Label();
            this.dgvAppontments = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRecordNumbers = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.localLicenseApplicationDetails1 = new DVLD.MainForms.MainRelatedForms.Application.LocalLicenseApplicationDetails();
            this.btnADD = new System.Windows.Forms.Button();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppontments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitel
            // 
            this.lbTitel.AutoSize = true;
            this.lbTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitel.ForeColor = System.Drawing.Color.Firebrick;
            this.lbTitel.Location = new System.Drawing.Point(214, 83);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(280, 25);
            this.lbTitel.TabIndex = 1;
            this.lbTitel.Text = "Vision Test Appointments";
            // 
            // dgvAppontments
            // 
            this.dgvAppontments.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvAppontments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppontments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAppontments.Location = new System.Drawing.Point(0, 534);
            this.dgvAppontments.Name = "dgvAppontments";
            this.dgvAppontments.Size = new System.Drawing.Size(708, 100);
            this.dgvAppontments.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 507);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Appointments : ";
            // 
            // lbRecordNumbers
            // 
            this.lbRecordNumbers.AutoSize = true;
            this.lbRecordNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordNumbers.Location = new System.Drawing.Point(106, 647);
            this.lbRecordNumbers.Name = "lbRecordNumbers";
            this.lbRecordNumbers.Size = new System.Drawing.Size(14, 16);
            this.lbRecordNumbers.TabIndex = 16;
            this.lbRecordNumbers.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 647);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "#Records :";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 86);
            // 
            // localLicenseApplicationDetails1
            // 
            this.localLicenseApplicationDetails1.Location = new System.Drawing.Point(0, 111);
            this.localLicenseApplicationDetails1.Name = "localLicenseApplicationDetails1";
            this.localLicenseApplicationDetails1.Size = new System.Drawing.Size(708, 374);
            this.localLicenseApplicationDetails1.TabIndex = 0;
            // 
            // btnADD
            // 
            this.btnADD.Image = global::DVLD.Properties.Resources.PLUS;
            this.btnADD.Location = new System.Drawing.Point(677, 500);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(31, 32);
            this.btnADD.TabIndex = 17;
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit24;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.test_write24;
            this.takeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.eye72;
            this.pictureBox1.Location = new System.Drawing.Point(323, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 68);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // VisionTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 672);
            this.Controls.Add(this.btnADD);
            this.Controls.Add(this.lbRecordNumbers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAppontments);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbTitel);
            this.Controls.Add(this.localLicenseApplicationDetails1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VisionTestAppointment";
            this.Text = "VisionTestAppointment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppontments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LocalLicenseApplicationDetails localLicenseApplicationDetails1;
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvAppontments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRecordNumbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}