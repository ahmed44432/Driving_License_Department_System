namespace DVLD.MainForms.MainRelatedForms
{
    partial class AddUpdateUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateUser));
            this.btnClose = new System.Windows.Forms.Button();
            this.lbAddUpdateUser = new System.Windows.Forms.Label();
            this.addingUser1 = new DVLD.MainForms.MainRelatedForms.AddingUser();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(555, 492);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 36);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbAddUpdateUser
            // 
            this.lbAddUpdateUser.AutoSize = true;
            this.lbAddUpdateUser.BackColor = System.Drawing.Color.MistyRose;
            this.lbAddUpdateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddUpdateUser.ForeColor = System.Drawing.Color.Crimson;
            this.lbAddUpdateUser.Location = new System.Drawing.Point(310, 13);
            this.lbAddUpdateUser.Name = "lbAddUpdateUser";
            this.lbAddUpdateUser.Size = new System.Drawing.Size(145, 24);
            this.lbAddUpdateUser.TabIndex = 6;
            this.lbAddUpdateUser.Text = "Add New User";
            // 
            // addingUser1
            // 
            this.addingUser1.Location = new System.Drawing.Point(-4, 40);
            this.addingUser1.Name = "addingUser1";
            this.addingUser1.Size = new System.Drawing.Size(775, 505);
            this.addingUser1.TabIndex = 0;
            // 
            // AddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(769, 530);
            this.Controls.Add(this.lbAddUpdateUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.addingUser1);
            this.MaximizeBox = false;
            this.Name = "AddUpdateUser";
            this.Text = "AddUpdateUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AddingUser addingUser1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbAddUpdateUser;
    }
}