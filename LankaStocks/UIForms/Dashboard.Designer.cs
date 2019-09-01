namespace LankaStocks.UIForms
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnabout = new System.Windows.Forms.Button();
            this.btnManageData = new System.Windows.Forms.Button();
            this.btnManageItem = new System.Windows.Forms.Button();
            this.btnIssueItem = new System.Windows.Forms.Button();
            this.pblogo = new System.Windows.Forms.PictureBox();
            this.btnhide = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.xuiWifiPercentageAPI1 = new XanderUI.XUIWifiPercentageAPI();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(11)))), ((int)(((byte)(31)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 747);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1463, 5);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(11)))), ((int)(((byte)(31)))));
            this.panel2.Controls.Add(this.btnSettings);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.btnTransaction);
            this.panel2.Controls.Add(this.btnSales);
            this.panel2.Controls.Add(this.btnabout);
            this.panel2.Controls.Add(this.btnManageData);
            this.panel2.Controls.Add(this.btnManageItem);
            this.panel2.Controls.Add(this.btnIssueItem);
            this.panel2.Controls.Add(this.pblogo);
            this.panel2.Controls.Add(this.btnhide);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 747);
            this.panel2.TabIndex = 13;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.Orange;
            this.btnSettings.Image = global::LankaStocks.Properties.Resources.settings3_24px;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 667);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(220, 40);
            this.btnSettings.TabIndex = 18;
            this.btnSettings.Text = "Settings";
            this.toolTip1.SetToolTip(this.btnSettings, "Settings");
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Orange;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(0, 535);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(220, 40);
            this.button5.TabIndex = 17;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnTransaction
            // 
            this.btnTransaction.FlatAppearance.BorderSize = 0;
            this.btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransaction.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransaction.ForeColor = System.Drawing.Color.Orange;
            this.btnTransaction.Image = global::LankaStocks.Properties.Resources.bank_24px;
            this.btnTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransaction.Location = new System.Drawing.Point(0, 487);
            this.btnTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(220, 40);
            this.btnTransaction.TabIndex = 16;
            this.btnTransaction.Text = "Transactions";
            this.toolTip1.SetToolTip(this.btnTransaction, "Transaction Detail\'s");
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.BtnTransaction_Click);
            // 
            // btnSales
            // 
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.ForeColor = System.Drawing.Color.Orange;
            this.btnSales.Image = global::LankaStocks.Properties.Resources.total_sales_1_24px;
            this.btnSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSales.Location = new System.Drawing.Point(0, 439);
            this.btnSales.Margin = new System.Windows.Forms.Padding(4);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(220, 40);
            this.btnSales.TabIndex = 15;
            this.btnSales.Text = "Sales";
            this.toolTip1.SetToolTip(this.btnSales, "View Sales History & Summary");
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.BtnSales_Click);
            // 
            // btnabout
            // 
            this.btnabout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnabout.FlatAppearance.BorderSize = 0;
            this.btnabout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnabout.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnabout.ForeColor = System.Drawing.Color.Orange;
            this.btnabout.Image = global::LankaStocks.Properties.Resources.about_us_24px;
            this.btnabout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnabout.Location = new System.Drawing.Point(0, 707);
            this.btnabout.Margin = new System.Windows.Forms.Padding(4);
            this.btnabout.Name = "btnabout";
            this.btnabout.Size = new System.Drawing.Size(220, 40);
            this.btnabout.TabIndex = 14;
            this.btnabout.Text = "About";
            this.toolTip1.SetToolTip(this.btnabout, "About");
            this.btnabout.UseVisualStyleBackColor = true;
            // 
            // btnManageData
            // 
            this.btnManageData.FlatAppearance.BorderSize = 0;
            this.btnManageData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageData.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageData.ForeColor = System.Drawing.Color.Orange;
            this.btnManageData.Image = global::LankaStocks.Properties.Resources.data_configuration_24px;
            this.btnManageData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageData.Location = new System.Drawing.Point(0, 391);
            this.btnManageData.Margin = new System.Windows.Forms.Padding(4);
            this.btnManageData.Name = "btnManageData";
            this.btnManageData.Size = new System.Drawing.Size(220, 40);
            this.btnManageData.TabIndex = 13;
            this.btnManageData.Text = "Manage Data";
            this.toolTip1.SetToolTip(this.btnManageData, "Manage User\'s, Person\'s & Vendor\'s...");
            this.btnManageData.UseVisualStyleBackColor = true;
            this.btnManageData.Click += new System.EventHandler(this.BtnManageData_Click);
            // 
            // btnManageItem
            // 
            this.btnManageItem.FlatAppearance.BorderSize = 0;
            this.btnManageItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageItem.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageItem.ForeColor = System.Drawing.Color.Orange;
            this.btnManageItem.Image = global::LankaStocks.Properties.Resources.management_24px;
            this.btnManageItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageItem.Location = new System.Drawing.Point(0, 343);
            this.btnManageItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnManageItem.Name = "btnManageItem";
            this.btnManageItem.Size = new System.Drawing.Size(220, 40);
            this.btnManageItem.TabIndex = 12;
            this.btnManageItem.Text = "Manage Item\'s";
            this.toolTip1.SetToolTip(this.btnManageItem, "Add, Remove, Manage Item\'s");
            this.btnManageItem.UseVisualStyleBackColor = true;
            this.btnManageItem.Click += new System.EventHandler(this.BtnManageItem_Click);
            // 
            // btnIssueItem
            // 
            this.btnIssueItem.FlatAppearance.BorderSize = 0;
            this.btnIssueItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueItem.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueItem.ForeColor = System.Drawing.Color.Orange;
            this.btnIssueItem.Image = global::LankaStocks.Properties.Resources.add_shopping_cart_24px;
            this.btnIssueItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueItem.Location = new System.Drawing.Point(0, 295);
            this.btnIssueItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnIssueItem.Name = "btnIssueItem";
            this.btnIssueItem.Size = new System.Drawing.Size(220, 40);
            this.btnIssueItem.TabIndex = 11;
            this.btnIssueItem.Text = "Issue Item\'s";
            this.toolTip1.SetToolTip(this.btnIssueItem, "Issue Item\'s To Customer\'s...");
            this.btnIssueItem.UseVisualStyleBackColor = true;
            this.btnIssueItem.Click += new System.EventHandler(this.BtnIssueItem_Click);
            // 
            // pblogo
            // 
            this.pblogo.BackColor = System.Drawing.Color.Transparent;
            this.pblogo.Image = global::LankaStocks.Properties.Resources.Logo;
            this.pblogo.Location = new System.Drawing.Point(30, 68);
            this.pblogo.Margin = new System.Windows.Forms.Padding(4);
            this.pblogo.Name = "pblogo";
            this.pblogo.Size = new System.Drawing.Size(160, 166);
            this.pblogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pblogo.TabIndex = 10;
            this.pblogo.TabStop = false;
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
            this.btnhide.Size = new System.Drawing.Size(220, 38);
            this.btnhide.TabIndex = 9;
            this.btnhide.UseVisualStyleBackColor = true;
            this.btnhide.Click += new System.EventHandler(this.Btnhide_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(5)))), ((int)(((byte)(10)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(220, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1243, 747);
            this.panel4.TabIndex = 14;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "LankaStocks";
            this.notifyIcon1.Visible = true;
            // 
            // xuiWifiPercentageAPI1
            // 
            this.xuiWifiPercentageAPI1.Enabled = true;
            this.xuiWifiPercentageAPI1.Interval = 3000;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1463, 752);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pblogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.Button btnabout;
        private System.Windows.Forms.Button btnManageData;
        private System.Windows.Forms.Button btnManageItem;
        private System.Windows.Forms.Button btnIssueItem;
        private System.Windows.Forms.PictureBox pblogo;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSettings;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private XanderUI.XUIWifiPercentageAPI xuiWifiPercentageAPI1;
    }
}