namespace LankaStocks.UIForms
{
    partial class FrmEditQty
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
            this.TxtQty = new System.Windows.Forms.NumericUpDown();
            this.labelName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TxtQty)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtQty
            // 
            this.TxtQty.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQty.ForeColor = System.Drawing.Color.Orange;
            this.TxtQty.Location = new System.Drawing.Point(12, 29);
            this.TxtQty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TxtQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtQty.Name = "TxtQty";
            this.TxtQty.Size = new System.Drawing.Size(277, 22);
            this.TxtQty.TabIndex = 4;
            this.TxtQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(12, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 13);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "label1";
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::LankaStocks.Properties.Resources.ok_24px;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(12, 69);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(130, 36);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::LankaStocks.Properties.Resources.cancel_2_24px;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(159, 69);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 36);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmEditQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 117);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.TxtQty);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(317, 156);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(317, 156);
            this.Name = "FrmEditQty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LankaStocks > Edit Qty";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmEditQty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown TxtQty;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label labelName;
    }
}