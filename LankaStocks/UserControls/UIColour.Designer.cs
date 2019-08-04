namespace LankaStocks.UserControls
{
    partial class UIColour
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ColourBox = new System.Windows.Forms.PictureBox();
            this.Browse = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColourBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ColourBox);
            this.panel1.Controls.Add(this.Browse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 25);
            this.panel1.TabIndex = 17;
            // 
            // ColourBox
            // 
            this.ColourBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ColourBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColourBox.Location = new System.Drawing.Point(0, 0);
            this.ColourBox.Name = "ColourBox";
            this.ColourBox.Size = new System.Drawing.Size(164, 25);
            this.ColourBox.TabIndex = 2;
            this.ColourBox.TabStop = false;
            // 
            // Browse
            // 
            this.Browse.Dock = System.Windows.Forms.DockStyle.Right;
            this.Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Browse.Location = new System.Drawing.Point(164, 0);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(89, 25);
            this.Browse.TabIndex = 1;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            // 
            // UIColour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Orange;
            this.Name = "UIColour";
            this.Size = new System.Drawing.Size(253, 25);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ColourBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox ColourBox;
        public System.Windows.Forms.Button Browse;
    }
}
