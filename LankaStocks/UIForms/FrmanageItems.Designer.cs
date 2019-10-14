namespace LankaStocks.UIForms
{
    partial class FrmanageItems
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConsole = new System.Windows.Forms.Button();
            this.btnStockIntake = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnhide = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(31)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 747);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 5);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(31)))));
            this.panel2.Controls.Add(this.btnConsole);
            this.panel2.Controls.Add(this.btnStockIntake);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnhide);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 747);
            this.panel2.TabIndex = 15;
            this.panel2.SizeChanged += new System.EventHandler(this.panel2_SizeChanged);
            // 
            // btnConsole
            // 
            this.btnConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConsole.FlatAppearance.BorderSize = 0;
            this.btnConsole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsole.ForeColor = System.Drawing.Color.Orange;
            this.btnConsole.Image = global::LankaStocks.Properties.Resources.console_24px;
            this.btnConsole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsole.Location = new System.Drawing.Point(0, 707);
            this.btnConsole.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsole.Name = "btnConsole";
            this.btnConsole.Size = new System.Drawing.Size(167, 40);
            this.btnConsole.TabIndex = 19;
            this.btnConsole.Text = "Open Console";
            this.toolTip1.SetToolTip(this.btnConsole, "Manage With CLI Interface... Dev Only!");
            this.btnConsole.UseVisualStyleBackColor = true;
            // 
            // btnStockIntake
            // 
            this.btnStockIntake.FlatAppearance.BorderSize = 0;
            this.btnStockIntake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockIntake.ForeColor = System.Drawing.Color.Orange;
            this.btnStockIntake.Image = global::LankaStocks.Properties.Resources.purchase_order_24px;
            this.btnStockIntake.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockIntake.Location = new System.Drawing.Point(0, 144);
            this.btnStockIntake.Margin = new System.Windows.Forms.Padding(4);
            this.btnStockIntake.Name = "btnStockIntake";
            this.btnStockIntake.Size = new System.Drawing.Size(168, 40);
            this.btnStockIntake.TabIndex = 18;
            this.btnStockIntake.Text = "Stock Intake";
            this.toolTip1.SetToolTip(this.btnStockIntake, "New Stock Intake");
            this.btnStockIntake.UseVisualStyleBackColor = true;
            this.btnStockIntake.Click += new System.EventHandler(this.btnStockIntake_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.Orange;
            this.btnAdd.Image = global::LankaStocks.Properties.Resources.plus_math_24px;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(0, 192);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(168, 40);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add New";
            this.toolTip1.SetToolTip(this.btnAdd, "Add New Items");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Orange;
            this.button1.Image = global::LankaStocks.Properties.Resources.management_24px;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 96);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 40);
            this.button1.TabIndex = 11;
            this.button1.Text = "Manage";
            this.toolTip1.SetToolTip(this.button1, "Analyze, Manage Items");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnhide
            // 
            this.btnhide.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnhide.FlatAppearance.BorderSize = 0;
            this.btnhide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhide.ForeColor = System.Drawing.Color.White;
            this.btnhide.Image = global::LankaStocks.Properties.Resources.menu_24px;
            this.btnhide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhide.Location = new System.Drawing.Point(0, 0);
            this.btnhide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnhide.Name = "btnhide";
            this.btnhide.Size = new System.Drawing.Size(167, 34);
            this.btnhide.TabIndex = 10;
            this.btnhide.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(167, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1333, 747);
            this.panel3.TabIndex = 17;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1333, 747);
            this.splitContainer2.SplitterDistance = 766;
            this.splitContainer2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(766, 747);
            this.splitContainer1.SplitterDistance = 428;
            this.splitContainer1.TabIndex = 0;
            // 
            // FrmanageItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1500, 752);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmanageItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LanakaStocks > Manage Item\'s";
            this.Load += new System.EventHandler(this.FrmanageItems_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnStockIntake;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnConsole;
    }
}