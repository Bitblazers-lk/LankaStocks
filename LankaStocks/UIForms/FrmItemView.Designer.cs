namespace LankaStocks.UIForms
{
    partial class FrmItemView
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
            this.Gbhead = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labS1 = new System.Windows.Forms.Label();
            this.labS2 = new System.Windows.Forms.Label();
            this.labS3 = new System.Windows.Forms.Label();
            this.TxtS1 = new System.Windows.Forms.TextBox();
            this.TxtS2 = new System.Windows.Forms.TextBox();
            this.TxtS3 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnRef = new System.Windows.Forms.Button();
            this.uiExcel1 = new LankaStocks.UserControls.UIExcel();
            this.Gbhead.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gbhead
            // 
            this.Gbhead.Controls.Add(this.tableLayoutPanel1);
            this.Gbhead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gbhead.ForeColor = System.Drawing.Color.Orange;
            this.Gbhead.Location = new System.Drawing.Point(0, 0);
            this.Gbhead.Name = "Gbhead";
            this.Gbhead.Size = new System.Drawing.Size(965, 427);
            this.Gbhead.TabIndex = 4;
            this.Gbhead.TabStop = false;
            this.Gbhead.Text = "Store";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(959, 408);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DGV
            // 
            this.DGV.AllowUserToOrderColumns = true;
            this.DGV.BackgroundColor = System.Drawing.Color.Black;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(3, 57);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(953, 292);
            this.DGV.TabIndex = 3;
            this.DGV.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellMouseEnter);
            this.DGV.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellMouseLeave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.Color.Orange;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(953, 48);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.767148F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.56618F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.767148F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.56618F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.767148F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.56618F));
            this.tableLayoutPanel5.Controls.Add(this.labS1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.labS2, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.labS3, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.TxtS1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.TxtS2, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.TxtS3, 5, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(947, 29);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // labS1
            // 
            this.labS1.AutoSize = true;
            this.labS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labS1.Location = new System.Drawing.Point(3, 0);
            this.labS1.Name = "labS1";
            this.labS1.Size = new System.Drawing.Size(67, 29);
            this.labS1.TabIndex = 0;
            this.labS1.Text = "Code :";
            this.labS1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labS2
            // 
            this.labS2.AutoSize = true;
            this.labS2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labS2.Location = new System.Drawing.Point(318, 0);
            this.labS2.Name = "labS2";
            this.labS2.Size = new System.Drawing.Size(67, 29);
            this.labS2.TabIndex = 1;
            this.labS2.Text = "Barcode :";
            this.labS2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labS3
            // 
            this.labS3.AutoSize = true;
            this.labS3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labS3.Location = new System.Drawing.Point(633, 0);
            this.labS3.Name = "labS3";
            this.labS3.Size = new System.Drawing.Size(67, 29);
            this.labS3.TabIndex = 2;
            this.labS3.Text = "Name :";
            this.labS3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TxtS1
            // 
            this.TxtS1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtS1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtS1.Location = new System.Drawing.Point(76, 3);
            this.TxtS1.Name = "TxtS1";
            this.TxtS1.Size = new System.Drawing.Size(236, 20);
            this.TxtS1.TabIndex = 3;
            this.TxtS1.TextChanged += new System.EventHandler(this.TxtS1_TextChanged);
            // 
            // TxtS2
            // 
            this.TxtS2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtS2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtS2.Location = new System.Drawing.Point(391, 3);
            this.TxtS2.Name = "TxtS2";
            this.TxtS2.Size = new System.Drawing.Size(236, 20);
            this.TxtS2.TabIndex = 4;
            this.TxtS2.TextChanged += new System.EventHandler(this.TxtS2_TextChanged);
            // 
            // TxtS3
            // 
            this.TxtS3.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtS3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtS3.Location = new System.Drawing.Point(706, 3);
            this.TxtS3.Name = "TxtS3";
            this.TxtS3.Size = new System.Drawing.Size(238, 20);
            this.TxtS3.TabIndex = 5;
            this.TxtS3.TextChanged += new System.EventHandler(this.TxtS3_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tableLayoutPanel2.Controls.Add(this.BtnRef, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.uiExcel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 355);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(953, 50);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // BtnRef
            // 
            this.BtnRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRef.Image = global::LankaStocks.Properties.Resources.recurring_appointment_24px;
            this.BtnRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRef.Location = new System.Drawing.Point(3, 3);
            this.BtnRef.Name = "BtnRef";
            this.BtnRef.Size = new System.Drawing.Size(607, 44);
            this.BtnRef.TabIndex = 5;
            this.BtnRef.Text = "Refresh";
            this.BtnRef.UseVisualStyleBackColor = true;
            this.BtnRef.Click += new System.EventHandler(this.BtnRef_Click);
            // 
            // uiExcel1
            // 
            this.uiExcel1.BackColor = System.Drawing.Color.Transparent;
            this.uiExcel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiExcel1.ForeColor = System.Drawing.Color.Orange;
            this.uiExcel1.Location = new System.Drawing.Point(617, 4);
            this.uiExcel1.Margin = new System.Windows.Forms.Padding(4);
            this.uiExcel1.Name = "uiExcel1";
            this.uiExcel1.Size = new System.Drawing.Size(332, 42);
            this.uiExcel1.TabIndex = 6;
            // 
            // FrmItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(965, 427);
            this.Controls.Add(this.Gbhead);
            this.Name = "FrmItemView";
            this.Text = "FrmItemView";
            this.Load += new System.EventHandler(this.FrmItemView_Load);
            this.Gbhead.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox TxtS3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.GroupBox Gbhead;
        public System.Windows.Forms.DataGridView DGV;
        public System.Windows.Forms.Label labS1;
        public System.Windows.Forms.Label labS2;
        public System.Windows.Forms.Label labS3;
        public System.Windows.Forms.TextBox TxtS1;
        public System.Windows.Forms.TextBox TxtS2;
        public System.Windows.Forms.Button BtnRef;
        public UserControls.UIExcel uiExcel1;
    }
}