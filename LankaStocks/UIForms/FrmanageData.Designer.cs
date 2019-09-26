namespace LankaStocks.UIForms
{
    partial class FrmanageData
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
            this.btnuser = new System.Windows.Forms.Button();
            this.btnvendor = new System.Windows.Forms.Button();
            this.btnperson = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnhide = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(31)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 748);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1444, 5);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(31)))));
            this.panel2.Controls.Add(this.btnuser);
            this.panel2.Controls.Add(this.btnvendor);
            this.panel2.Controls.Add(this.btnperson);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnhide);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 748);
            this.panel2.TabIndex = 15;
            // 
            // btnuser
            // 
            this.btnuser.FlatAppearance.BorderSize = 0;
            this.btnuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnuser.ForeColor = System.Drawing.Color.Orange;
            this.btnuser.Image = global::LankaStocks.Properties.Resources.user_male_circle_24px;
            this.btnuser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnuser.Location = new System.Drawing.Point(0, 182);
            this.btnuser.Margin = new System.Windows.Forms.Padding(4);
            this.btnuser.Name = "btnuser";
            this.btnuser.Size = new System.Drawing.Size(196, 40);
            this.btnuser.TabIndex = 16;
            this.btnuser.Text = "User\'s";
            this.toolTip1.SetToolTip(this.btnuser, "Analyze, Manage Users");
            this.btnuser.UseVisualStyleBackColor = true;
            this.btnuser.Click += new System.EventHandler(this.btnuser_Click);
            // 
            // btnvendor
            // 
            this.btnvendor.FlatAppearance.BorderSize = 0;
            this.btnvendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvendor.ForeColor = System.Drawing.Color.Orange;
            this.btnvendor.Image = global::LankaStocks.Properties.Resources.anonymous_mask_24px;
            this.btnvendor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnvendor.Location = new System.Drawing.Point(0, 134);
            this.btnvendor.Margin = new System.Windows.Forms.Padding(4);
            this.btnvendor.Name = "btnvendor";
            this.btnvendor.Size = new System.Drawing.Size(196, 40);
            this.btnvendor.TabIndex = 15;
            this.btnvendor.Text = "Vendor\'s";
            this.toolTip1.SetToolTip(this.btnvendor, "Analyze, Manage Vendors");
            this.btnvendor.UseVisualStyleBackColor = true;
            this.btnvendor.Click += new System.EventHandler(this.btnvendor_Click);
            // 
            // btnperson
            // 
            this.btnperson.FlatAppearance.BorderSize = 0;
            this.btnperson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnperson.ForeColor = System.Drawing.Color.Orange;
            this.btnperson.Image = global::LankaStocks.Properties.Resources.Tall_Person_24px;
            this.btnperson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnperson.Location = new System.Drawing.Point(0, 86);
            this.btnperson.Margin = new System.Windows.Forms.Padding(4);
            this.btnperson.Name = "btnperson";
            this.btnperson.Size = new System.Drawing.Size(196, 40);
            this.btnperson.TabIndex = 14;
            this.btnperson.Text = "Person\'s";
            this.toolTip1.SetToolTip(this.btnperson, "Analyze, Manage Persons");
            this.btnperson.UseVisualStyleBackColor = true;
            this.btnperson.Click += new System.EventHandler(this.btnperson_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.Orange;
            this.btnAdd.Image = global::LankaStocks.Properties.Resources.plus_math_24px;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(0, 230);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(196, 40);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add New";
            this.toolTip1.SetToolTip(this.btnAdd, "Add New Person or Vendor Or User");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnhide.Size = new System.Drawing.Size(200, 34);
            this.btnhide.TabIndex = 10;
            this.btnhide.UseVisualStyleBackColor = true;
            this.btnhide.Click += new System.EventHandler(this.btnhide_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(200, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1244, 748);
            this.panel3.TabIndex = 17;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1244, 748);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1215, 740);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Person\'s";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1215, 740);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vendor\'s";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1215, 740);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "User\'s";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FrmanageData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1444, 753);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmanageData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LanakaStocks > Manage Data";
            this.Load += new System.EventHandler(this.FrmanageData_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnuser;
        private System.Windows.Forms.Button btnvendor;
        private System.Windows.Forms.Button btnperson;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
    }
}