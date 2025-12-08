namespace DVLD.MainForms.MainRelatedForms
{
    partial class AddingUser
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.personDetails1 = new DVLD.PersonDetails();
            this.filter1 = new DVLD.MainForms.MainRelatedForms.Filter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(768, 435);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Tan;
            this.tabPage1.Controls.Add(this.personDetails1);
            this.tabPage1.Controls.Add(this.filter1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(760, 409);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personal Info";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(760, 409);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Login Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // personDetails1
            // 
            this.personDetails1.BackColor = System.Drawing.Color.SeaShell;
            this.personDetails1.Location = new System.Drawing.Point(51, 114);
            this.personDetails1.Margin = new System.Windows.Forms.Padding(4);
            this.personDetails1.Name = "personDetails1";
            this.personDetails1.Size = new System.Drawing.Size(651, 255);
            this.personDetails1.TabIndex = 1;
            // 
            // filter1
            // 
            this.filter1.BackColor = System.Drawing.Color.Linen;
            this.filter1.Location = new System.Drawing.Point(100, 23);
            this.filter1.Margin = new System.Windows.Forms.Padding(4);
            this.filter1.Name = "filter1";
            this.filter1.Size = new System.Drawing.Size(557, 71);
            this.filter1.TabIndex = 0;
            this.filter1.Load += new System.EventHandler(this.filter1_Load);
            // 
            // AddingUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "AddingUser";
            this.Size = new System.Drawing.Size(790, 438);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Filter filter1;
        private PersonDetails personDetails1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
