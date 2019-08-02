namespace LankaStocks.UIForms
{
    partial class AddItems
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
            this.uiSaveData1 = new LankaStocks.UserControls.UISaveData();
            this.uiAddItem1 = new LankaStocks.UserControls.UIAddItem();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(31)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 310);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 12);
            this.panel1.TabIndex = 14;
            // 
            // uiSaveData1
            // 
            this.uiSaveData1.BackColor = System.Drawing.Color.Transparent;
            this.uiSaveData1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiSaveData1.Location = new System.Drawing.Point(0, 248);
            this.uiSaveData1.Margin = new System.Windows.Forms.Padding(4);
            this.uiSaveData1.Name = "uiSaveData1";
            this.uiSaveData1.Size = new System.Drawing.Size(540, 62);
            this.uiSaveData1.TabIndex = 16;
            // 
            // uiAddItem1
            // 
            this.uiAddItem1.BackColor = System.Drawing.Color.Transparent;
            this.uiAddItem1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAddItem1.Location = new System.Drawing.Point(0, 0);
            this.uiAddItem1.Margin = new System.Windows.Forms.Padding(4);
            this.uiAddItem1.Name = "uiAddItem1";
            this.uiAddItem1.Size = new System.Drawing.Size(540, 248);
            this.uiAddItem1.TabIndex = 17;
            // 
            // AddItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(540, 322);
            this.Controls.Add(this.uiAddItem1);
            this.Controls.Add(this.uiSaveData1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AddItems";
            this.Text = "DesignCommon";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private UserControls.UISaveData uiSaveData1;
        private UserControls.UIAddItem uiAddItem1;
    }
}