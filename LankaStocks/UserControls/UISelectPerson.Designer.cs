namespace LankaStocks.UserControls
{
    partial class UISelectPerson
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
            this.RBSelVendor = new System.Windows.Forms.RadioButton();
            this.RBSelUser = new System.Windows.Forms.RadioButton();
            this.RBSelOther = new System.Windows.Forms.RadioButton();
            this.Cmb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // RBSelVendor
            // 
            this.RBSelVendor.AutoSize = true;
            this.RBSelVendor.ForeColor = System.Drawing.Color.White;
            this.RBSelVendor.Location = new System.Drawing.Point(56, 13);
            this.RBSelVendor.Name = "RBSelVendor";
            this.RBSelVendor.Size = new System.Drawing.Size(59, 17);
            this.RBSelVendor.TabIndex = 0;
            this.RBSelVendor.TabStop = true;
            this.RBSelVendor.Text = "Vendor";
            this.RBSelVendor.UseVisualStyleBackColor = true;
            this.RBSelVendor.CheckedChanged += new System.EventHandler(this.RBSelVendor_CheckedChanged);
            // 
            // RBSelUser
            // 
            this.RBSelUser.AutoSize = true;
            this.RBSelUser.ForeColor = System.Drawing.Color.White;
            this.RBSelUser.Location = new System.Drawing.Point(141, 13);
            this.RBSelUser.Name = "RBSelUser";
            this.RBSelUser.Size = new System.Drawing.Size(47, 17);
            this.RBSelUser.TabIndex = 0;
            this.RBSelUser.TabStop = true;
            this.RBSelUser.Text = "User";
            this.RBSelUser.UseVisualStyleBackColor = true;
            this.RBSelUser.CheckedChanged += new System.EventHandler(this.RBSelUser_CheckedChanged);
            // 
            // RBSelOther
            // 
            this.RBSelOther.AutoSize = true;
            this.RBSelOther.ForeColor = System.Drawing.Color.White;
            this.RBSelOther.Location = new System.Drawing.Point(214, 13);
            this.RBSelOther.Name = "RBSelOther";
            this.RBSelOther.Size = new System.Drawing.Size(86, 17);
            this.RBSelOther.TabIndex = 0;
            this.RBSelOther.TabStop = true;
            this.RBSelOther.Text = "Other people";
            this.RBSelOther.UseVisualStyleBackColor = true;
            this.RBSelOther.CheckedChanged += new System.EventHandler(this.RBSelOther_CheckedChanged);
            // 
            // Cmb
            // 
            this.Cmb.BackColor = System.Drawing.Color.DimGray;
            this.Cmb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cmb.FormattingEnabled = true;
            this.Cmb.Location = new System.Drawing.Point(0, 38);
            this.Cmb.Name = "Cmb";
            this.Cmb.Size = new System.Drawing.Size(392, 21);
            this.Cmb.TabIndex = 1;
            // 
            // UISelectPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Cmb);
            this.Controls.Add(this.RBSelOther);
            this.Controls.Add(this.RBSelUser);
            this.Controls.Add(this.RBSelVendor);
            this.Name = "UISelectPerson";
            this.Size = new System.Drawing.Size(392, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RBSelVendor;
        private System.Windows.Forms.RadioButton RBSelUser;
        private System.Windows.Forms.RadioButton RBSelOther;
        private System.Windows.Forms.ComboBox Cmb;
    }
}
