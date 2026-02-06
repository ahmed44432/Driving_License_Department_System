namespace DVLD.MainForms.MainRelatedForms.Application
{
    partial class LDLApplicationInformation
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
            this.localLicenseApplicationDetails1 = new DVLD.MainForms.MainRelatedForms.Application.LocalLicenseApplicationDetails();
            this.lbtitel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // localLicenseApplicationDetails1
            // 
            this.localLicenseApplicationDetails1.Location = new System.Drawing.Point(12, 53);
            this.localLicenseApplicationDetails1.Name = "localLicenseApplicationDetails1";
            this.localLicenseApplicationDetails1.Size = new System.Drawing.Size(708, 374);
            this.localLicenseApplicationDetails1.TabIndex = 0;
            // 
            // lbtitel
            // 
            this.lbtitel.AutoSize = true;
            this.lbtitel.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitel.ForeColor = System.Drawing.Color.Firebrick;
            this.lbtitel.Location = new System.Drawing.Point(436, 9);
            this.lbtitel.Name = "lbtitel";
            this.lbtitel.Size = new System.Drawing.Size(226, 26);
            this.lbtitel.TabIndex = 1;
            this.lbtitel.Text = "Show App Details";
            // 
            // LDLApplicationInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 428);
            this.Controls.Add(this.lbtitel);
            this.Controls.Add(this.localLicenseApplicationDetails1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LDLApplicationInformation";
            this.Text = "LDLApplicationInformation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LocalLicenseApplicationDetails localLicenseApplicationDetails1;
        private System.Windows.Forms.Label lbtitel;
    }
}