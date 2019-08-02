namespace LankaStocks.UserControls
{
    partial class UITransaction
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
            this.Type = new System.Windows.Forms.ComboBox();
            this.User = new System.Windows.Forms.ComboBox();
            this.Secondparty = new System.Windows.Forms.ComboBox();
            this.OfficePersonID = new System.Windows.Forms.ComboBox();
            this.TransactionID = new System.Windows.Forms.TextBox();
            this.Total = new System.Windows.Forms.TextBox();
            this.Paid = new System.Windows.Forms.TextBox();
            this.Liability = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.TextBox();
            this.Note = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.Type, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.User, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.Secondparty, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.OfficePersonID, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.TransactionID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Total, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Paid, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Liability, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Confirm, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.Note, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 350);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Type
            // 
            this.Type.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Type.ForeColor = System.Drawing.Color.Orange;
            this.Type.FormattingEnabled = true;
            this.Type.Location = new System.Drawing.Point(83, 115);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(314, 21);
            this.Type.TabIndex = 0;
            this.Type.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Type_KeyDown);
            // 
            // User
            // 
            this.User.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.User.ForeColor = System.Drawing.Color.Orange;
            this.User.FormattingEnabled = true;
            this.User.Location = new System.Drawing.Point(83, 143);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(314, 21);
            this.User.TabIndex = 1;
            this.User.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User_KeyDown);
            // 
            // Secondparty
            // 
            this.Secondparty.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Secondparty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Secondparty.ForeColor = System.Drawing.Color.Orange;
            this.Secondparty.FormattingEnabled = true;
            this.Secondparty.Location = new System.Drawing.Point(83, 171);
            this.Secondparty.Name = "Secondparty";
            this.Secondparty.Size = new System.Drawing.Size(314, 21);
            this.Secondparty.TabIndex = 2;
            this.Secondparty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Secondparty_KeyDown);
            // 
            // OfficePersonID
            // 
            this.OfficePersonID.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.OfficePersonID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OfficePersonID.ForeColor = System.Drawing.Color.Orange;
            this.OfficePersonID.FormattingEnabled = true;
            this.OfficePersonID.Location = new System.Drawing.Point(83, 325);
            this.OfficePersonID.Name = "OfficePersonID";
            this.OfficePersonID.Size = new System.Drawing.Size(314, 21);
            this.OfficePersonID.TabIndex = 3;
            this.OfficePersonID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OfficePersonID_KeyDown);
            // 
            // TransactionID
            // 
            this.TransactionID.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TransactionID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TransactionID.ForeColor = System.Drawing.Color.Orange;
            this.TransactionID.Location = new System.Drawing.Point(83, 3);
            this.TransactionID.Name = "TransactionID";
            this.TransactionID.ReadOnly = true;
            this.TransactionID.Size = new System.Drawing.Size(314, 20);
            this.TransactionID.TabIndex = 4;
            // 
            // Total
            // 
            this.Total.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Total.ForeColor = System.Drawing.Color.Orange;
            this.Total.Location = new System.Drawing.Point(83, 31);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(314, 20);
            this.Total.TabIndex = 5;
            this.Total.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Total_KeyDown);
            // 
            // Paid
            // 
            this.Paid.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Paid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Paid.ForeColor = System.Drawing.Color.Orange;
            this.Paid.Location = new System.Drawing.Point(83, 59);
            this.Paid.Name = "Paid";
            this.Paid.Size = new System.Drawing.Size(314, 20);
            this.Paid.TabIndex = 6;
            this.Paid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Paid_KeyDown);
            // 
            // Liability
            // 
            this.Liability.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Liability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Liability.ForeColor = System.Drawing.Color.Orange;
            this.Liability.Location = new System.Drawing.Point(83, 87);
            this.Liability.Name = "Liability";
            this.Liability.Size = new System.Drawing.Size(314, 20);
            this.Liability.TabIndex = 7;
            this.Liability.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Liability_KeyDown);
            // 
            // Confirm
            // 
            this.Confirm.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Confirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Confirm.ForeColor = System.Drawing.Color.Orange;
            this.Confirm.Location = new System.Drawing.Point(83, 199);
            this.Confirm.Multiline = true;
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(314, 57);
            this.Confirm.TabIndex = 8;
            this.Confirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Confirm_KeyDown);
            // 
            // Note
            // 
            this.Note.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Note.ForeColor = System.Drawing.Color.Orange;
            this.Note.Location = new System.Drawing.Point(83, 262);
            this.Note.Multiline = true;
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(314, 57);
            this.Note.TabIndex = 9;
            this.Note.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Note_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "Total :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "Paid :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 28);
            this.label4.TabIndex = 13;
            this.label4.Text = "Liability :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(3, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 28);
            this.label5.TabIndex = 14;
            this.label5.Text = "Type :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(3, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 28);
            this.label6.TabIndex = 15;
            this.label6.Text = "User :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(3, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 28);
            this.label7.TabIndex = 16;
            this.label7.Text = "Second Party :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.Color.Orange;
            this.label8.Location = new System.Drawing.Point(3, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 63);
            this.label8.TabIndex = 17;
            this.label8.Text = "Confirmation :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ForeColor = System.Drawing.Color.Orange;
            this.label9.Location = new System.Drawing.Point(3, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 63);
            this.label9.TabIndex = 18;
            this.label9.Text = "Note :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ForeColor = System.Drawing.Color.Orange;
            this.label10.Location = new System.Drawing.Point(3, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 28);
            this.label10.TabIndex = 19;
            this.label10.Text = "Officer ID :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UITransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UITransaction";
            this.Size = new System.Drawing.Size(400, 350);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ComboBox Type;
        public System.Windows.Forms.ComboBox User;
        public System.Windows.Forms.ComboBox Secondparty;
        public System.Windows.Forms.ComboBox OfficePersonID;
        public System.Windows.Forms.TextBox TransactionID;
        public System.Windows.Forms.TextBox Total;
        public System.Windows.Forms.TextBox Paid;
        public System.Windows.Forms.TextBox Liability;
        public System.Windows.Forms.TextBox Confirm;
        public System.Windows.Forms.TextBox Note;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}
