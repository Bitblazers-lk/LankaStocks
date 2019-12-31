namespace LankaStocks.UserControls
{
    partial class UIntake
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DGVin = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnRef = new System.Windows.Forms.Button();
            this.uiExcel1 = new LankaStocks.UserControls.UIExcel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.uiExcel2 = new LankaStocks.UserControls.UIExcel();
            this.DGVit = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.COMB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBabm = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVin)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVit)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1385, 849);
            this.splitContainer1.SplitterDistance = 1048;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(1048, 849);
            this.splitContainer2.SplitterDistance = 99;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.splitContainer3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.Color.Orange;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1048, 99);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter";
            this.groupBox3.Enter += new System.EventHandler(this.GroupBox3_Enter);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 16);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer3.Size = new System.Drawing.Size(1042, 80);
            this.splitContainer3.SplitterDistance = 623;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Orange;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1048, 746);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DGVin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1042, 727);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // DGVin
            // 
            this.DGVin.AllowUserToOrderColumns = true;
            this.DGVin.BackgroundColor = System.Drawing.Color.Black;
            this.DGVin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVin.Location = new System.Drawing.Point(3, 3);
            this.DGVin.Name = "DGVin";
            this.DGVin.ReadOnly = true;
            this.DGVin.Size = new System.Drawing.Size(1036, 676);
            this.DGVin.TabIndex = 3;
            this.DGVin.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVin_CellMouseClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tableLayoutPanel2.Controls.Add(this.BtnRef, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.uiExcel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 685);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1036, 39);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // BtnRef
            // 
            this.BtnRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRef.ForeColor = System.Drawing.Color.Orange;
            this.BtnRef.Image = global::LankaStocks.Properties.Resources.recurring_appointment_24px;
            this.BtnRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRef.Location = new System.Drawing.Point(3, 3);
            this.BtnRef.Name = "BtnRef";
            this.BtnRef.Size = new System.Drawing.Size(690, 33);
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
            this.uiExcel1.Location = new System.Drawing.Point(700, 4);
            this.uiExcel1.Margin = new System.Windows.Forms.Padding(4);
            this.uiExcel1.Name = "uiExcel1";
            this.uiExcel1.Size = new System.Drawing.Size(332, 31);
            this.uiExcel1.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Orange;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 849);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Item\'s";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.uiExcel2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.DGVit, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(327, 830);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // uiExcel2
            // 
            this.uiExcel2.BackColor = System.Drawing.Color.Transparent;
            this.uiExcel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiExcel2.ForeColor = System.Drawing.Color.Orange;
            this.uiExcel2.Location = new System.Drawing.Point(4, 789);
            this.uiExcel2.Margin = new System.Windows.Forms.Padding(4);
            this.uiExcel2.Name = "uiExcel2";
            this.uiExcel2.Size = new System.Drawing.Size(319, 37);
            this.uiExcel2.TabIndex = 7;
            // 
            // DGVit
            // 
            this.DGVit.AllowUserToOrderColumns = true;
            this.DGVit.BackgroundColor = System.Drawing.Color.Black;
            this.DGVit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVit.Location = new System.Drawing.Point(3, 3);
            this.DGVit.Name = "DGVit";
            this.DGVit.ReadOnly = true;
            this.DGVit.Size = new System.Drawing.Size(321, 779);
            this.DGVit.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.44783F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.55217F));
            this.tableLayoutPanel4.Controls.Add(this.CBabm, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.COMB, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.75F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(623, 80);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // COMB
            // 
            this.COMB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.COMB.FormattingEnabled = true;
            this.COMB.Location = new System.Drawing.Point(174, 3);
            this.COMB.Name = "COMB";
            this.COMB.Size = new System.Drawing.Size(446, 21);
            this.COMB.TabIndex = 0;
            this.COMB.SelectedIndexChanged += new System.EventHandler(this.COMB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date / Month -";
            // 
            // CBabm
            // 
            this.CBabm.AutoSize = true;
            this.CBabm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBabm.Location = new System.Drawing.Point(3, 30);
            this.CBabm.Name = "CBabm";
            this.CBabm.Size = new System.Drawing.Size(165, 47);
            this.CBabm.TabIndex = 2;
            this.CBabm.Text = "Analyze By Months";
            this.CBabm.UseVisualStyleBackColor = true;
            this.CBabm.CheckedChanged += new System.EventHandler(this.CBabm_CheckedChanged);
            // 
            // UIntake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.Color.Orange;
            this.Name = "UIntake";
            this.Size = new System.Drawing.Size(1385, 849);
            this.Load += new System.EventHandler(this.UIntake_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVin)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVit)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Button BtnRef;
        public UIExcel uiExcel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public UIExcel uiExcel2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        public System.Windows.Forms.DataGridView DGVin;
        public System.Windows.Forms.DataGridView DGVit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox CBabm;
        private System.Windows.Forms.ComboBox COMB;
        private System.Windows.Forms.Label label1;
    }
}
