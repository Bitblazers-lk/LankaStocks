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
            this.uiUserParty = new LankaStocks.UserControls.UISelectPerson();
            this.uiSecondParty = new LankaStocks.UserControls.UISelectPerson();
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
            this.tableLayoutPanel1.Controls.Add(this.uiUserParty, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.uiSecondParty, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.133698F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.133698F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.133698F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.133698F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.133698F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.105035F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.62482F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.30082F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.30083F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 587);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Type
            // 
            this.Type.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Type.ForeColor = System.Drawing.Color.Orange;
            this.Type.FormattingEnabled = true;
            this.Type.Location = new System.Drawing.Point(127, 191);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(492, 21);
            this.Type.TabIndex = 2;
            // 
            // TransactionID
            // 
            this.TransactionID.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TransactionID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TransactionID.ForeColor = System.Drawing.Color.Orange;
            this.TransactionID.Location = new System.Drawing.Point(127, 3);
            this.TransactionID.Name = "TransactionID";
            this.TransactionID.ReadOnly = true;
            this.TransactionID.Size = new System.Drawing.Size(492, 20);
            this.TransactionID.TabIndex = 10;
            // 
            // Total
            // 
            this.Total.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Total.ForeColor = System.Drawing.Color.Orange;
            this.Total.Location = new System.Drawing.Point(127, 50);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(492, 20);
            this.Total.TabIndex = 0;
            // 
            // Paid
            // 
            this.Paid.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Paid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Paid.ForeColor = System.Drawing.Color.Orange;
            this.Paid.Location = new System.Drawing.Point(127, 97);
            this.Paid.Name = "Paid";
            this.Paid.Size = new System.Drawing.Size(492, 20);
            this.Paid.TabIndex = 1;
            this.Paid.TextChanged += new System.EventHandler(this.Paid_TextChanged);
            // 
            // Liability
            // 
            this.Liability.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Liability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Liability.ForeColor = System.Drawing.Color.Orange;
            this.Liability.Location = new System.Drawing.Point(127, 144);
            this.Liability.Name = "Liability";
            this.Liability.ReadOnly = true;
            this.Liability.Size = new System.Drawing.Size(492, 20);
            this.Liability.TabIndex = 10;
            // 
            // Confirm
            // 
            this.Confirm.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Confirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Confirm.ForeColor = System.Drawing.Color.Orange;
            this.Confirm.Location = new System.Drawing.Point(127, 370);
            this.Confirm.Multiline = true;
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(492, 101);
            this.Confirm.TabIndex = 5;
            // 
            // Note
            // 
            this.Note.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Note.ForeColor = System.Drawing.Color.Orange;
            this.Note.Location = new System.Drawing.Point(127, 477);
            this.Note.Multiline = true;
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(492, 107);
            this.Note.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 47);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 47);
            this.label2.TabIndex = 11;
            this.label2.Text = "Total :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(3, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 47);
            this.label3.TabIndex = 12;
            this.label3.Text = "Paid :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(3, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 47);
            this.label4.TabIndex = 13;
            this.label4.Text = "Liability :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(3, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 47);
            this.label5.TabIndex = 14;
            this.label5.Text = "Type :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(3, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 41);
            this.label6.TabIndex = 15;
            this.label6.Text = "User :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(3, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 91);
            this.label7.TabIndex = 16;
            this.label7.Text = "Second Party :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.Color.Orange;
            this.label8.Location = new System.Drawing.Point(3, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 107);
            this.label8.TabIndex = 17;
            this.label8.Text = "Confirmation :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ForeColor = System.Drawing.Color.Orange;
            this.label9.Location = new System.Drawing.Point(3, 474);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 113);
            this.label9.TabIndex = 18;
            this.label9.Text = "Note :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiUserParty
            // 
            this.uiUserParty.BackColor = System.Drawing.Color.Transparent;
            this.uiUserParty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiUserParty.Location = new System.Drawing.Point(127, 238);
            this.uiUserParty.Name = "uiUserParty";
            this.uiUserParty.PreferedPeopleGroup = "users";
            this.uiUserParty.ShowRadioButtons = false;
            this.uiUserParty.Size = new System.Drawing.Size(492, 35);
            this.uiUserParty.TabIndex = 3;
            // 
            // uiSecondParty
            // 
            this.uiSecondParty.BackColor = System.Drawing.Color.Transparent;
            this.uiSecondParty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSecondParty.Location = new System.Drawing.Point(127, 279);
            this.uiSecondParty.Name = "uiSecondParty";
            this.uiSecondParty.PreferedPeopleGroup = "all";
            this.uiSecondParty.ShowRadioButtons = true;
            this.uiSecondParty.Size = new System.Drawing.Size(492, 85);
            this.uiSecondParty.TabIndex = 4;
            // 
            // UITransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UITransaction";
            this.Size = new System.Drawing.Size(622, 587);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ComboBox Type;
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
        private UISelectPerson uiUserParty;
        private UISelectPerson uiSecondParty;
    }
}
