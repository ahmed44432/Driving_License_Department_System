namespace DVLD.MainForms.MainRelatedForms.Drivers
{
    partial class DriverLicensesHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpLocal = new System.Windows.Forms.TabPage();
            this.lb_LLH_RecordNumbers = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLocalLH = new System.Windows.Forms.DataGridView();
            this.tbpInternational = new System.Windows.Forms.TabPage();
            this.lb_ILH_RecordNumbers = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvInternationalLH = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLH)).BeginInit();
            this.tbpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLH)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 293);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpLocal);
            this.tabControl1.Controls.Add(this.tbpInternational);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(739, 274);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpLocal
            // 
            this.tbpLocal.Controls.Add(this.lb_LLH_RecordNumbers);
            this.tbpLocal.Controls.Add(this.label2);
            this.tbpLocal.Controls.Add(this.label1);
            this.tbpLocal.Controls.Add(this.dgvLocalLH);
            this.tbpLocal.Location = new System.Drawing.Point(4, 22);
            this.tbpLocal.Name = "tbpLocal";
            this.tbpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tbpLocal.Size = new System.Drawing.Size(731, 248);
            this.tbpLocal.TabIndex = 0;
            this.tbpLocal.Text = "Local";
            this.tbpLocal.UseVisualStyleBackColor = true;
            // 
            // lb_LLH_RecordNumbers
            // 
            this.lb_LLH_RecordNumbers.AutoSize = true;
            this.lb_LLH_RecordNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_LLH_RecordNumbers.Location = new System.Drawing.Point(102, 215);
            this.lb_LLH_RecordNumbers.Name = "lb_LLH_RecordNumbers";
            this.lb_LLH_RecordNumbers.Size = new System.Drawing.Size(14, 16);
            this.lb_LLH_RecordNumbers.TabIndex = 20;
            this.lb_LLH_RecordNumbers.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "#Records :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Local Licenses History : ";
            // 
            // dgvLocalLH
            // 
            this.dgvLocalLH.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvLocalLH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLH.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalLH.Location = new System.Drawing.Point(11, 43);
            this.dgvLocalLH.Name = "dgvLocalLH";
            this.dgvLocalLH.Size = new System.Drawing.Size(708, 147);
            this.dgvLocalLH.TabIndex = 17;
            // 
            // tbpInternational
            // 
            this.tbpInternational.Controls.Add(this.lb_ILH_RecordNumbers);
            this.tbpInternational.Controls.Add(this.label4);
            this.tbpInternational.Controls.Add(this.label5);
            this.tbpInternational.Controls.Add(this.dgvInternationalLH);
            this.tbpInternational.Location = new System.Drawing.Point(4, 22);
            this.tbpInternational.Name = "tbpInternational";
            this.tbpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tbpInternational.Size = new System.Drawing.Size(731, 248);
            this.tbpInternational.TabIndex = 1;
            this.tbpInternational.Text = "International";
            this.tbpInternational.UseVisualStyleBackColor = true;
            // 
            // lb_ILH_RecordNumbers
            // 
            this.lb_ILH_RecordNumbers.AutoSize = true;
            this.lb_ILH_RecordNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ILH_RecordNumbers.Location = new System.Drawing.Point(116, 247);
            this.lb_ILH_RecordNumbers.Name = "lb_ILH_RecordNumbers";
            this.lb_ILH_RecordNumbers.Size = new System.Drawing.Size(14, 16);
            this.lb_ILH_RecordNumbers.TabIndex = 24;
            this.lb_ILH_RecordNumbers.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "#Records :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "International Licenses History : ";
            // 
            // dgvInternationalLH
            // 
            this.dgvInternationalLH.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvInternationalLH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLH.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvInternationalLH.Location = new System.Drawing.Point(13, 43);
            this.dgvInternationalLH.Name = "dgvInternationalLH";
            this.dgvInternationalLH.Size = new System.Drawing.Size(708, 147);
            this.dgvInternationalLH.TabIndex = 21;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 34);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.id_search24;
            this.showLicenseDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // DriverLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DriverLicensesHistory";
            this.Size = new System.Drawing.Size(745, 293);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbpLocal.ResumeLayout(false);
            this.tbpLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLH)).EndInit();
            this.tbpInternational.ResumeLayout(false);
            this.tbpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLH)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpLocal;
        private System.Windows.Forms.TabPage tbpInternational;
        private System.Windows.Forms.Label lb_LLH_RecordNumbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLocalLH;
        private System.Windows.Forms.Label lb_ILH_RecordNumbers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvInternationalLH;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
    }
}
