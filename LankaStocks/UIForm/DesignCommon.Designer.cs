namespace LankaStocks.UIForms
{
    partial class DesignCommon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignCommon));
            this.panelHead = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonmin = new System.Windows.Forms.Button();
            this.labelHeadder = new System.Windows.Forms.Label();
            this.btnexit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHead
            // 
            this.panelHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(31)))));
            this.panelHead.Controls.Add(this.label1);
            this.panelHead.Controls.Add(this.buttonmin);
            this.panelHead.Controls.Add(this.labelHeadder);
            this.panelHead.Controls.Add(this.btnexit);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Margin = new System.Windows.Forms.Padding(2);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(621, 31);
            this.panelHead.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(964, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "User - ";
            // 
            // buttonmin
            // 
            this.buttonmin.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonmin.FlatAppearance.BorderSize = 0;
            this.buttonmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonmin.Image = ((System.Drawing.Image)(resources.GetObject("buttonmin.Image")));
            this.buttonmin.Location = new System.Drawing.Point(565, 0);
            this.buttonmin.Margin = new System.Windows.Forms.Padding(2);
            this.buttonmin.Name = "buttonmin";
            this.buttonmin.Size = new System.Drawing.Size(28, 31);
            this.buttonmin.TabIndex = 7;
            this.buttonmin.UseVisualStyleBackColor = true;
            // 
            // labelHeadder
            // 
            this.labelHeadder.AutoSize = true;
            this.labelHeadder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeadder.ForeColor = System.Drawing.Color.White;
            this.labelHeadder.Location = new System.Drawing.Point(12, 7);
            this.labelHeadder.Name = "labelHeadder";
            this.labelHeadder.Size = new System.Drawing.Size(93, 17);
            this.labelHeadder.TabIndex = 5;
            this.labelHeadder.Text = "Lanka Stocks";
            // 
            // btnexit
            // 
            this.btnexit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.Location = new System.Drawing.Point(593, 0);
            this.btnexit.Margin = new System.Windows.Forms.Padding(2);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(28, 31);
            this.btnexit.TabIndex = 2;
            this.btnexit.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(31)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 567);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 10);
            this.panel1.TabIndex = 14;
            // 
            // DesignCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(621, 577);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DesignCommon";
            this.Text = "DesignCommon";
            this.panelHead.ResumeLayout(false);
            this.panelHead.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonmin;
        private System.Windows.Forms.Label labelHeadder;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Panel panel1;
    }
}