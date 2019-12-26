namespace LankaStocks.UserControls
{
    partial class UIExcel
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
            this.Open = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.Open, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Save, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(364, 41);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Open
            // 
            this.Open.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Open.Image = global::LankaStocks.Properties.Resources.csv_24px;
            this.Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Open.Location = new System.Drawing.Point(3, 3);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(176, 35);
            this.Open.TabIndex = 1;
            this.Open.Text = "Open With Excel";
            this.Open.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Image = global::LankaStocks.Properties.Resources.ms_excel_24px;
            this.Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save.Location = new System.Drawing.Point(185, 3);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(176, 35);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save As Excel";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // UIExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Orange;
            this.Name = "UIExcel";
            this.Size = new System.Drawing.Size(364, 41);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button Open;
        public System.Windows.Forms.Button Save;
    }
}
