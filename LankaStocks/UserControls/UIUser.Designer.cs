namespace LankaStocks.UserControls
{
    partial class UIUser
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.UserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UserPass = new System.Windows.Forms.TextBox();
            this.IsAdmin = new System.Windows.Forms.ComboBox();
            this.uiPerson1 = new LankaStocks.UserControls.UIPerson();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ForeColor = System.Drawing.Color.Orange;
            this.groupBox1.Location = new System.Drawing.Point(0, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 129);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other Detail\'s";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.UserName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.UserID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.UserPass, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.IsAdmin, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.25253F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.26263F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.25253F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 110);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(3, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "Admin :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 27);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "User Name :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UserName
            // 
            this.UserName.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.UserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserName.ForeColor = System.Drawing.Color.Orange;
            this.UserName.Location = new System.Drawing.Point(81, 30);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(310, 20);
            this.UserName.TabIndex = 3;
            this.UserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserName_KeyDown);
            // 
            // UserID
            // 
            this.UserID.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.UserID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserID.Location = new System.Drawing.Point(81, 3);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(310, 20);
            this.UserID.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "User ID :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UserPass
            // 
            this.UserPass.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.UserPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPass.ForeColor = System.Drawing.Color.Orange;
            this.UserPass.Location = new System.Drawing.Point(81, 58);
            this.UserPass.Name = "UserPass";
            this.UserPass.Size = new System.Drawing.Size(310, 20);
            this.UserPass.TabIndex = 8;
            this.UserPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserPass_KeyDown);
            // 
            // IsAdmin
            // 
            this.IsAdmin.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.IsAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IsAdmin.ForeColor = System.Drawing.Color.Orange;
            this.IsAdmin.FormattingEnabled = true;
            this.IsAdmin.Items.AddRange(new object[] {
            "NO",
            "YES"});
            this.IsAdmin.Location = new System.Drawing.Point(81, 85);
            this.IsAdmin.Name = "IsAdmin";
            this.IsAdmin.Size = new System.Drawing.Size(310, 21);
            this.IsAdmin.TabIndex = 9;
            this.IsAdmin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsAdmin_KeyDown);
            // 
            // uiPerson1
            // 
            this.uiPerson1.BackColor = System.Drawing.Color.Transparent;
            this.uiPerson1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPerson1.Location = new System.Drawing.Point(0, 0);
            this.uiPerson1.Name = "uiPerson1";
            this.uiPerson1.Size = new System.Drawing.Size(400, 147);
            this.uiPerson1.TabIndex = 4;
            // 
            // UIUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.uiPerson1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UIUser";
            this.Size = new System.Drawing.Size(400, 276);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox UserName;
        public System.Windows.Forms.TextBox UserID;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox UserPass;
        public System.Windows.Forms.ComboBox IsAdmin;
        private UIPerson uiPerson1;
    }
}
