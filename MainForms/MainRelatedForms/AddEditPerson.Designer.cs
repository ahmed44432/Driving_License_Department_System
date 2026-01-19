namespace DVLD.MainRelatedForms
{
    partial class AddEditPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditPerson));
            this.lbTitel = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.addingPerson1 = new DVLD.AddingPerson();
            this.SuspendLayout();
            // 
            // lbTitel
            // 
            this.lbTitel.AutoSize = true;
            this.lbTitel.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitel.ForeColor = System.Drawing.Color.Blue;
            this.lbTitel.Location = new System.Drawing.Point(252, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(185, 30);
            this.lbTitel.TabIndex = 1;
            this.lbTitel.Text = "Add New Person";
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb2.Location = new System.Drawing.Point(26, 52);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(69, 15);
            this.lb2.TabIndex = 2;
            this.lb2.Text = "Person ID";
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.Location = new System.Drawing.Point(149, 52);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(33, 15);
            this.lbID.TabIndex = 3;
            this.lbID.Text = "N/A";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Location = new System.Drawing.Point(675, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 29);
            this.btnClose.TabIndex = 6;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // addingPerson1
            // 
            this.addingPerson1.Location = new System.Drawing.Point(1, 70);
            this.addingPerson1.Name = "addingPerson1";
            this.addingPerson1.Size = new System.Drawing.Size(714, 346);
            this.addingPerson1.TabIndex = 7;
            this.addingPerson1.Load += new System.EventHandler(this.addingPerson1_Load);
            // 
            // AddEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(717, 407);
            this.Controls.Add(this.addingPerson1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.lbTitel);
            this.MaximizeBox = false;
            this.Name = "AddEditPerson";
            this.Text = "AddEditPerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Button btnClose;
        private AddingPerson addingPerson1;
    }
}