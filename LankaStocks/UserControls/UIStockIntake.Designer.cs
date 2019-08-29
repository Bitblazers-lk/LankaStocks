namespace LankaStocks.UserControls
{
    partial class UIStockIntake
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
            this.IntakeID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Qty = new System.Windows.Forms.TextBox();
            this.uiSelecVendor = new LankaStocks.UserControls.UISelectPerson();
            this.uiSelItem = new LankaStocks.UserControls.UISelItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiTransaction = new LankaStocks.UserControls.UITransaction();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.IntakeID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Qty, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiSelecVendor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiSelItem, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(424, 108);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // IntakeID
            // 
            this.IntakeID.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.IntakeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IntakeID.ForeColor = System.Drawing.Color.Orange;
            this.IntakeID.Location = new System.Drawing.Point(87, 3);
            this.IntakeID.Name = "IntakeID";
            this.IntakeID.ReadOnly = true;
            this.IntakeID.Size = new System.Drawing.Size(334, 20);
            this.IntakeID.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 27);
            this.label1.TabIndex = 14;
            this.label1.Text = "Intake ID :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 27);
            this.label2.TabIndex = 15;
            this.label2.Text = "Vendor ID :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 27);
            this.label3.TabIndex = 16;
            this.label3.Text = "Item ID :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 27);
            this.label4.TabIndex = 17;
            this.label4.Text = "Qty. :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Qty
            // 
            this.Qty.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Qty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Qty.ForeColor = System.Drawing.Color.Orange;
            this.Qty.Location = new System.Drawing.Point(87, 84);
            this.Qty.Name = "Qty";
            this.Qty.Size = new System.Drawing.Size(334, 20);
            this.Qty.TabIndex = 2;
            this.Qty.Text = "0";
            this.Qty.TextChanged += new System.EventHandler(this.Qty_TextChanged);
            this.Qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Qty_KeyDown_1);
            // 
            // uiSelecVendor
            // 
            this.uiSelecVendor.BackColor = System.Drawing.Color.Transparent;
            this.uiSelecVendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSelecVendor.Location = new System.Drawing.Point(87, 30);
            this.uiSelecVendor.Name = "uiSelecVendor";
            this.uiSelecVendor.PreferedPeopleGroup = "vendors";
            this.uiSelecVendor.ShowRadioButtons = false;
            this.uiSelecVendor.Size = new System.Drawing.Size(334, 21);
            this.uiSelecVendor.TabIndex = 0;
            // 
            // uiSelItem
            // 
            this.uiSelItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSelItem.Location = new System.Drawing.Point(87, 57);
            this.uiSelItem.Name = "uiSelItem";
            this.uiSelItem.Size = new System.Drawing.Size(334, 21);
            this.uiSelItem.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiTransaction);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Orange;
            this.groupBox1.Location = new System.Drawing.Point(0, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 376);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction";
            // 
            // uiTransaction
            // 
            this.uiTransaction.BackColor = System.Drawing.Color.Transparent;
            this.uiTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTransaction.Location = new System.Drawing.Point(3, 16);
            this.uiTransaction.Name = "uiTransaction";
            this.uiTransaction.Size = new System.Drawing.Size(418, 357);
            this.uiTransaction.TabIndex = 3;
            // 
            // UIStockIntake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UIStockIntake";
            this.Size = new System.Drawing.Size(424, 484);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public UITransaction uiTransaction;
        public System.Windows.Forms.TextBox IntakeID;
        public System.Windows.Forms.TextBox Qty;
        private UISelectPerson uiSelecVendor;
        private UISelItem uiSelItem;
    }
}
