namespace DVLD.MainForms.MainRelatedForms.Application
{
    partial class ScheduleTestForm
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
            this.scheduleTest1 = new DVLD.MainForms.MainRelatedForms.Application.ScheduleTest();
            this.SuspendLayout();
            // 
            // scheduleTest1
            // 
            this.scheduleTest1.Location = new System.Drawing.Point(12, 3);
            this.scheduleTest1.Name = "scheduleTest1";
            this.scheduleTest1.Size = new System.Drawing.Size(421, 656);
            this.scheduleTest1.TabIndex = 0;
            // 
            // ScheduleTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 663);
            this.Controls.Add(this.scheduleTest1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduleTestForm";
            this.Text = "ScheduleTestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ScheduleTest scheduleTest1;
    }
}