namespace LankaStocks.User_Controls
{
    partial class UIPerson
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ContactInfo = new System.Windows.Forms.TextBox();
            this.Details = new System.Windows.Forms.TextBox();
            this.PersonName = new System.Windows.Forms.TextBox();
            this.PersonID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ContactInfo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Details, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.PersonName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.PersonID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.98561F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.98561F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.04317F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.98561F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 140);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(3, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contact Info :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 64);
            this.label2.TabIndex = 1;
            this.label2.Text = "Details :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ContactInfo
            // 
            this.ContactInfo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ContactInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContactInfo.ForeColor = System.Drawing.Color.Orange;
            this.ContactInfo.Location = new System.Drawing.Point(83, 117);
            this.ContactInfo.Name = "ContactInfo";
            this.ContactInfo.Size = new System.Drawing.Size(314, 20);
            this.ContactInfo.TabIndex = 5;
            // 
            // Details
            // 
            this.Details.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Details.ForeColor = System.Drawing.Color.Orange;
            this.Details.Location = new System.Drawing.Point(83, 53);
            this.Details.Multiline = true;
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(314, 58);
            this.Details.TabIndex = 4;
            // 
            // PersonName
            // 
            this.PersonName.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.PersonName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonName.ForeColor = System.Drawing.Color.Orange;
            this.PersonName.Location = new System.Drawing.Point(83, 28);
            this.PersonName.Name = "PersonName";
            this.PersonName.Size = new System.Drawing.Size(314, 20);
            this.PersonName.TabIndex = 3;
            // 
            // PersonID
            // 
            this.PersonID.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.PersonID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonID.Location = new System.Drawing.Point(83, 3);
            this.PersonID.Name = "PersonID";
            this.PersonID.Size = new System.Drawing.Size(314, 20);
            this.PersonID.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "ID :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UIPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UIPerson";
            this.Size = new System.Drawing.Size(400, 140);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox PersonName;
        public System.Windows.Forms.TextBox Details;
        public System.Windows.Forms.TextBox ContactInfo;
        private System.Windows.Forms.TextBox PersonID;
        private System.Windows.Forms.Label label4;
    }
}
