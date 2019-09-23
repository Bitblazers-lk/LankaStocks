namespace LankaStocks.UIForms
{
    partial class FrmQuickSale
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.btnfund = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnhide = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtQty = new System.Windows.Forms.NumericUpDown();
            this.TxtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CBspecialSale = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelInNO = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtQty)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(11)))), ((int)(((byte)(31)))));
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.btnfund);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btnhide);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 524);
            this.panel1.TabIndex = 0;
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(0, 181);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(143, 40);
            this.button7.TabIndex = 13;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // btnfund
            // 
            this.btnfund.FlatAppearance.BorderSize = 0;
            this.btnfund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfund.Image = global::LankaStocks.Properties.Resources.refund_2_24px;
            this.btnfund.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfund.Location = new System.Drawing.Point(0, 135);
            this.btnfund.Name = "btnfund";
            this.btnfund.Size = new System.Drawing.Size(143, 40);
            this.btnfund.TabIndex = 12;
            this.btnfund.Text = "Refund";
            this.btnfund.UseVisualStyleBackColor = true;
            this.btnfund.Click += new System.EventHandler(this.Btnfund_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::LankaStocks.Properties.Resources.sell_24px;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(0, 89);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(143, 40);
            this.button5.TabIndex = 11;
            this.button5.Text = "Quick Sell";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnhide
            // 
            this.btnhide.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnhide.FlatAppearance.BorderSize = 0;
            this.btnhide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhide.ForeColor = System.Drawing.Color.White;
            this.btnhide.Image = global::LankaStocks.Properties.Resources.menu_24px;
            this.btnhide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhide.Location = new System.Drawing.Point(0, 0);
            this.btnhide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnhide.Name = "btnhide";
            this.btnhide.Size = new System.Drawing.Size(143, 34);
            this.btnhide.TabIndex = 10;
            this.btnhide.UseVisualStyleBackColor = true;
            this.btnhide.Click += new System.EventHandler(this.Btnhide_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(143, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(686, 524);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 478F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.CBspecialSale, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(686, 205);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnIssue);
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(107, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 114);
            this.panel2.TabIndex = 4;
            // 
            // btnIssue
            // 
            this.btnIssue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIssue.FlatAppearance.BorderSize = 3;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.Color.Orange;
            this.btnIssue.Location = new System.Drawing.Point(0, 68);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(472, 46);
            this.btnIssue.TabIndex = 3;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.BtnIssue_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.73881F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.26119F));
            this.tableLayoutPanel2.Controls.Add(this.TxtQty, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.TxtCode, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(472, 68);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // TxtQty
            // 
            this.TxtQty.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQty.ForeColor = System.Drawing.Color.Orange;
            this.TxtQty.Location = new System.Drawing.Point(72, 37);
            this.TxtQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtQty.Name = "TxtQty";
            this.TxtQty.Size = new System.Drawing.Size(397, 22);
            this.TxtQty.TabIndex = 4;
            this.TxtQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQty_KeyDown);
            // 
            // TxtCode
            // 
            this.TxtCode.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCode.ForeColor = System.Drawing.Color.Orange;
            this.TxtCode.Location = new System.Drawing.Point(72, 3);
            this.TxtCode.Name = "TxtCode";
            this.TxtCode.Size = new System.Drawing.Size(397, 22);
            this.TxtCode.TabIndex = 3;
            this.TxtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Qty :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CBspecialSale
            // 
            this.CBspecialSale.AutoSize = true;
            this.CBspecialSale.Dock = System.Windows.Forms.DockStyle.Top;
            this.CBspecialSale.Location = new System.Drawing.Point(107, 182);
            this.CBspecialSale.Name = "CBspecialSale";
            this.CBspecialSale.Size = new System.Drawing.Size(472, 20);
            this.CBspecialSale.TabIndex = 5;
            this.CBspecialSale.Text = "Special Sale";
            this.CBspecialSale.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.labelTotal, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelInNO, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(107, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.35052F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.16495F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(472, 53);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.Orange;
            this.labelTotal.Location = new System.Drawing.Point(3, 0);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(466, 29);
            this.labelTotal.TabIndex = 0;
            this.labelTotal.Text = "Total : ";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInNO
            // 
            this.labelInNO.AutoSize = true;
            this.labelInNO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInNO.ForeColor = System.Drawing.Color.Orange;
            this.labelInNO.Location = new System.Drawing.Point(3, 29);
            this.labelInNO.Name = "labelInNO";
            this.labelInNO.Size = new System.Drawing.Size(466, 24);
            this.labelInNO.TabIndex = 1;
            this.labelInNO.Text = "Invoice NO. :";
            this.labelInNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Orange;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 315);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cart";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.DGV, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.50685F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(680, 294);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // DGV
            // 
            this.DGV.AllowUserToOrderColumns = true;
            this.DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(5)))), ((int)(((byte)(10)))));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.GridColor = System.Drawing.Color.Orange;
            this.DGV.Location = new System.Drawing.Point(3, 3);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(674, 288);
            this.DGV.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(143, 519);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(686, 5);
            this.panel3.TabIndex = 2;
            // 
            // FrmQuickSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(5)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(829, 524);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Orange;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmQuickSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LanakaStocks > Quick Sell";
            this.Load += new System.EventHandler(this.FrmQuickSale_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtQty)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown TxtQty;
        private System.Windows.Forms.TextBox TxtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.CheckBox CBspecialSale;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnfund;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelInNO;
    }
}