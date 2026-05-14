namespace DVLD.MainForms.MainRelatedForms
{
    partial class PersonFilter
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
            this.filter1 = new DVLD.MainForms.MainRelatedForms.Filter();
            this.personDetails1 = new DVLD.PersonDetails();
            this.SuspendLayout();
            // 
            // filter1
            // 
            this.filter1.Location = new System.Drawing.Point(69, 16);
            this.filter1.Name = "filter1";
            this.filter1.Size = new System.Drawing.Size(554, 69);
            this.filter1.TabIndex = 0;
            // 
            // personDetails1
            // 
            this.personDetails1.Location = new System.Drawing.Point(27, 91);
            this.personDetails1.Name = "personDetails1";
            this.personDetails1.Size = new System.Drawing.Size(653, 252);
            this.personDetails1.TabIndex = 1;
            // 
            // PersonFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.personDetails1);
            this.Controls.Add(this.filter1);
            this.Name = "PersonFilter";
            this.Size = new System.Drawing.Size(711, 373);
            this.ResumeLayout(false);

        }

        #endregion

        private Filter filter1;
        private PersonDetails personDetails1;
    }
}
