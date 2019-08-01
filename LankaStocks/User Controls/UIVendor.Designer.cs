namespace LankaStocks.User_Controls
{
    partial class UIVendor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.VendorID = new System.Windows.Forms.TextBox();
            this.BusinessInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiPerson1 = new LankaStocks.User_Controls.UIPerson();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ForeColor = System.Drawing.Color.Orange;
            this.groupBox1.Location = new System.Drawing.Point(0, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 127);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other Detail\'s";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79F));
            this.tableLayoutPanel1.Controls.Add(this.VendorID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BusinessInfo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 108);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // VendorID
            // 
            this.VendorID.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.VendorID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VendorID.ForeColor = System.Drawing.Color.Orange;
            this.VendorID.Location = new System.Drawing.Point(85, 3);
            this.VendorID.Name = "VendorID";
            this.VendorID.ReadOnly = true;
            this.VendorID.Size = new System.Drawing.Size(306, 20);
            this.VendorID.TabIndex = 0;
            // 
            // BusinessInfo
            // 
            this.BusinessInfo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BusinessInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BusinessInfo.ForeColor = System.Drawing.Color.Orange;
            this.BusinessInfo.Location = new System.Drawing.Point(85, 30);
            this.BusinessInfo.Multiline = true;
            this.BusinessInfo.Name = "BusinessInfo";
            this.BusinessInfo.Size = new System.Drawing.Size(306, 75);
            this.BusinessInfo.TabIndex = 1;
            this.BusinessInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BusinessInfo_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 81);
            this.label2.TabIndex = 3;
            this.label2.Text = "Business Info :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiPerson1
            // 
            this.uiPerson1.BackColor = System.Drawing.Color.Transparent;
            this.uiPerson1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPerson1.Location = new System.Drawing.Point(0, 0);
            this.uiPerson1.Name = "uiPerson1";
            this.uiPerson1.Size = new System.Drawing.Size(400, 142);
            this.uiPerson1.TabIndex = 3;
            // 
            // UIVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.uiPerson1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UIVendor";
            this.Size = new System.Drawing.Size(400, 269);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TextBox VendorID;
        public System.Windows.Forms.TextBox BusinessInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private UIPerson uiPerson1;
    }
}
