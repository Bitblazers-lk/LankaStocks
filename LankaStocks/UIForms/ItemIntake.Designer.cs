﻿namespace LankaStocks.UIForms
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
            this.uiStockIntake = new LankaStocks.UserControls.UIStockIntake();
            this.uiSaveData = new LankaStocks.UserControls.UISaveData();
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
            // uiStockIntake
            // 
            this.uiStockIntake.BackColor = System.Drawing.Color.Transparent;
            this.uiStockIntake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiStockIntake.Location = new System.Drawing.Point(0, 0);
            this.uiStockIntake.Margin = new System.Windows.Forms.Padding(4);
            this.uiStockIntake.Name = "uiStockIntake";
            this.uiStockIntake.Size = new System.Drawing.Size(573, 636);
            this.uiStockIntake.TabIndex = 16;
            // 
            // uiSaveData
            // 
            this.uiSaveData.BackColor = System.Drawing.Color.Transparent;
            this.uiSaveData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiSaveData.Location = new System.Drawing.Point(0, 636);
            this.uiSaveData.Margin = new System.Windows.Forms.Padding(4);
            this.uiSaveData.Name = "uiSaveData";
            this.uiSaveData.Size = new System.Drawing.Size(573, 62);
            this.uiSaveData.TabIndex = 15;
            // 
            // ItemIntake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(573, 710);
            this.Controls.Add(this.uiStockIntake);
            this.Controls.Add(this.uiSaveData);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ItemIntake";
            this.Text = "LanakaStocks > Stock Intake";
            this.Load += new System.EventHandler(this.ItemIntake_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private UserControls.UISaveData uiSaveData;
        private UserControls.UIStockIntake uiStockIntake;
    }
}