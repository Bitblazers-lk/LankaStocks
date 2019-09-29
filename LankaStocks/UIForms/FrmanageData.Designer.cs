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
            this.btnConsole = new System.Windows.Forms.Button();
            this.btnuser = new System.Windows.Forms.Button();
            this.btnvendor = new System.Windows.Forms.Button();
            this.btnperson = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnhide = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCode = new System.Windows.Forms.TextBox();
            this.TxtBarcode = new System.Windows.Forms.TextBox();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnRef = new System.Windows.Forms.Button();
            this.uiExcel1 = new LankaStocks.UserControls.UIExcel();
            this.Fpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(31)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 743);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1515, 5);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(31)))));
            this.panel2.Controls.Add(this.btnConsole);
            this.panel2.Controls.Add(this.btnuser);
            this.panel2.Controls.Add(this.btnvendor);
            this.panel2.Controls.Add(this.btnperson);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnhide);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 743);
            this.panel2.TabIndex = 15;
            // 
            // btnConsole
            // 
            this.btnConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConsole.FlatAppearance.BorderSize = 0;
            this.btnConsole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsole.ForeColor = System.Drawing.Color.Orange;
            this.btnConsole.Image = global::LankaStocks.Properties.Resources.console_24px;
            this.btnConsole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsole.Location = new System.Drawing.Point(0, 703);
            this.btnConsole.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsole.Name = "btnConsole";
            this.btnConsole.Size = new System.Drawing.Size(171, 40);
            this.btnConsole.TabIndex = 17;
            this.btnConsole.Text = "Open Console";
            this.toolTip1.SetToolTip(this.btnConsole, "Manage With CLI Interface... Dev Only!");
            this.btnConsole.UseVisualStyleBackColor = true;
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
            this.btnuser.Size = new System.Drawing.Size(168, 40);
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
            this.btnvendor.Size = new System.Drawing.Size(168, 40);
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
            this.btnperson.Size = new System.Drawing.Size(168, 40);
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
            this.btnAdd.Size = new System.Drawing.Size(168, 40);
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
            this.btnhide.Size = new System.Drawing.Size(171, 34);
            this.btnhide.TabIndex = 10;
            this.btnhide.UseVisualStyleBackColor = true;
            this.btnhide.Click += new System.EventHandler(this.btnhide_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel3.Controls.Add(this.splitContainer2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(171, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1344, 743);
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
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.Fpanel);
            this.splitContainer2.Size = new System.Drawing.Size(1344, 743);
            this.splitContainer2.SplitterDistance = 780;
            this.splitContainer2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(780, 743);
            this.splitContainer1.SplitterDistance = 425;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Orange;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 425);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Person\'s";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(774, 404);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DGV
            // 
            this.DGV.AllowUserToOrderColumns = true;
            this.DGV.BackgroundColor = System.Drawing.Color.Black;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(3, 57);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(768, 294);
            this.DGV.TabIndex = 3;
            this.DGV.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_CellMouseClick);
            this.DGV.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellMouseEnter);
            this.DGV.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellMouseLeave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.Color.Orange;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(768, 48);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.767148F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.56618F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.767148F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.56618F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.767148F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.56618F));
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.TxtCode, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.TxtBarcode, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.TxtName, 5, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(762, 27);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(256, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 27);
            this.label4.TabIndex = 1;
            this.label4.Text = "Barcode :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(509, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 27);
            this.label5.TabIndex = 2;
            this.label5.Text = "Name :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TxtCode
            // 
            this.TxtCode.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCode.Location = new System.Drawing.Point(62, 3);
            this.TxtCode.Name = "TxtCode";
            this.TxtCode.Size = new System.Drawing.Size(188, 22);
            this.TxtCode.TabIndex = 3;
            // 
            // TxtBarcode
            // 
            this.TxtBarcode.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBarcode.Location = new System.Drawing.Point(315, 3);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.Size = new System.Drawing.Size(188, 22);
            this.TxtBarcode.TabIndex = 4;
            // 
            // TxtName
            // 
            this.TxtName.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtName.Location = new System.Drawing.Point(568, 3);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(191, 22);
            this.TxtName.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tableLayoutPanel2.Controls.Add(this.BtnRef, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.uiExcel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 357);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(768, 44);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // BtnRef
            // 
            this.BtnRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRef.Image = global::LankaStocks.Properties.Resources.recurring_appointment_24px;
            this.BtnRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRef.Location = new System.Drawing.Point(3, 3);
            this.BtnRef.Name = "BtnRef";
            this.BtnRef.Size = new System.Drawing.Size(422, 38);
            this.BtnRef.TabIndex = 5;
            this.BtnRef.Text = "Refresh";
            this.BtnRef.UseVisualStyleBackColor = true;
            this.BtnRef.Click += new System.EventHandler(this.BtnRef_Click);
            // 
            // uiExcel1
            // 
            this.uiExcel1.BackColor = System.Drawing.Color.Transparent;
            this.uiExcel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiExcel1.ForeColor = System.Drawing.Color.Orange;
            this.uiExcel1.Location = new System.Drawing.Point(432, 4);
            this.uiExcel1.Margin = new System.Windows.Forms.Padding(4);
            this.uiExcel1.Name = "uiExcel1";
            this.uiExcel1.Size = new System.Drawing.Size(332, 36);
            this.uiExcel1.TabIndex = 6;
            // 
            // Fpanel
            // 
            this.Fpanel.AutoScroll = true;
            this.Fpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fpanel.Location = new System.Drawing.Point(0, 0);
            this.Fpanel.Name = "Fpanel";
            this.Fpanel.Size = new System.Drawing.Size(560, 743);
            this.Fpanel.TabIndex = 0;
            // 
            // FrmanageData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1515, 748);
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
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCode;
        private System.Windows.Forms.TextBox TxtBarcode;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnRef;
        private UserControls.UIExcel uiExcel1;
        private System.Windows.Forms.FlowLayoutPanel Fpanel;
        private System.Windows.Forms.Button btnConsole;
    }
}