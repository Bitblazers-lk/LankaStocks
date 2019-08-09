namespace LankaStocks.UserControls
{
    partial class UItem
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.l1 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.lp = new System.Windows.Forms.Label();
            this.btnaddtoc = new System.Windows.Forms.Button();
            this.PB = new System.Windows.Forms.PictureBox();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.l1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.l2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lp, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(196, 70);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l1.ForeColor = System.Drawing.Color.Orange;
            this.l1.Location = new System.Drawing.Point(3, 0);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(190, 23);
            this.l1.TabIndex = 0;
            this.l1.Text = "label1";
            this.l1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l2
            // 
            this.l2.AutoSize = true;
            this.l2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l2.ForeColor = System.Drawing.Color.Orange;
            this.l2.Location = new System.Drawing.Point(3, 23);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(190, 23);
            this.l2.TabIndex = 1;
            this.l2.Text = "label2";
            this.l2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lp
            // 
            this.lp.AutoSize = true;
            this.lp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lp.ForeColor = System.Drawing.Color.Orange;
            this.lp.Location = new System.Drawing.Point(3, 46);
            this.lp.Name = "lp";
            this.lp.Size = new System.Drawing.Size(190, 24);
            this.lp.TabIndex = 2;
            this.lp.Text = "label3";
            this.lp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnaddtoc
            // 
            this.btnaddtoc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnaddtoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnaddtoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddtoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnaddtoc.ForeColor = System.Drawing.Color.Orange;
            this.btnaddtoc.Image = global::LankaStocks.Properties.Resources.add_shopping_cart_24px;
            this.btnaddtoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaddtoc.Location = new System.Drawing.Point(32, 250);
            this.btnaddtoc.Name = "btnaddtoc";
            this.btnaddtoc.Size = new System.Drawing.Size(130, 30);
            this.btnaddtoc.TabIndex = 1;
            this.btnaddtoc.Text = "Add To Cart";
            this.btnaddtoc.UseVisualStyleBackColor = true;
            this.btnaddtoc.Click += new System.EventHandler(this.btnaddtoc_Click);
            // 
            // PB
            // 
            this.PB.Location = new System.Drawing.Point(27, 90);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(140, 140);
            this.PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB.TabIndex = 2;
            this.PB.TabStop = false;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(182, 26);
            this.cms.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cms_ItemClicked);
            // 
            // AddItem
            // 
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(181, 22);
            this.AddItem.Text = "Add/ Change Image";
            // 
            // UItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ContextMenuStrip = this.cms;
            this.Controls.Add(this.PB);
            this.Controls.Add(this.btnaddtoc);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Crimson;
            this.Name = "UItem";
            this.Size = new System.Drawing.Size(196, 296);
            this.Load += new System.EventHandler(this.UI_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_MouseClick);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnaddtoc;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label lp;
        private System.Windows.Forms.PictureBox PB;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem AddItem;
    }
}
