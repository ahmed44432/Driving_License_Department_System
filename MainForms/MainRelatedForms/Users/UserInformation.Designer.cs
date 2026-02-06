namespace DVLD.MainForms.MainRelatedForms
{
    partial class UserInformation
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
            this.userDetails1 = new DVLD.MainForms.MainRelatedForms.UserDetails();
            this.SuspendLayout();
            // 
            // userDetails1
            // 
            this.userDetails1.Location = new System.Drawing.Point(12, 2);
            this.userDetails1.Name = "userDetails1";
            this.userDetails1.Size = new System.Drawing.Size(657, 362);
            this.userDetails1.TabIndex = 0;
            // 
            // UserInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 365);
            this.Controls.Add(this.userDetails1);
            this.MaximizeBox = false;
            this.Name = "UserInformation";
            this.Text = "UserInformation";
            this.ResumeLayout(false);

        }

        #endregion

        private UserDetails userDetails1;
    }
}