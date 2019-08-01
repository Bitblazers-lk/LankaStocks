namespace LankaStocks.UIForms
{
    partial class ItemIntake
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
            this.uiSaveData1 = new LankaStocks.User_Controls.UISaveData();
            this.uiStockIntake1 = new LankaStocks.User_Controls.UIStockIntake();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(31)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 698);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 12);
            this.panel1.TabIndex = 14;
            // 
            // uiSaveData1
            // 
            this.uiSaveData1.BackColor = System.Drawing.Color.Transparent;
            this.uiSaveData1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiSaveData1.Location = new System.Drawing.Point(0, 636);
            this.uiSaveData1.Margin = new System.Windows.Forms.Padding(4);
            this.uiSaveData1.Name = "uiSaveData1";
            this.uiSaveData1.Size = new System.Drawing.Size(573, 62);
            this.uiSaveData1.TabIndex = 15;
            // 
            // uiStockIntake1
            // 
            this.uiStockIntake1.BackColor = System.Drawing.Color.Transparent;
            this.uiStockIntake1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiStockIntake1.Location = new System.Drawing.Point(0, 0);
            this.uiStockIntake1.Margin = new System.Windows.Forms.Padding(4);
            this.uiStockIntake1.Name = "uiStockIntake1";
            this.uiStockIntake1.Size = new System.Drawing.Size(573, 636);
            this.uiStockIntake1.TabIndex = 16;
            // 
            // ItemIntake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(573, 710);
            this.Controls.Add(this.uiStockIntake1);
            this.Controls.Add(this.uiSaveData1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ItemIntake";
            this.Text = "LanakaStocks > Stock Intake";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private User_Controls.UISaveData uiSaveData1;
        private User_Controls.UIStockIntake uiStockIntake1;
    }
}