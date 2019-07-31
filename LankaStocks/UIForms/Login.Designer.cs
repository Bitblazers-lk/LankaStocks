namespace LankaStocks
{
    partial class Login
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.Panel();
            this.buttonlogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonabout = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.Animator = new XanderUI.XUIObjectAnimator();
            this.gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStatus.Location = new System.Drawing.Point(255, 363);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(20, 17);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(319, 436);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 9);
            this.label6.TabIndex = 10;
            this.label6.Text = "Design And Maked By Harindu Wijesinghe And Hasindu Lanka";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(83, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "      User Name -";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnLogin
            // 
            this.BtnLogin.FlatAppearance.BorderSize = 2;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.ForeColor = System.Drawing.Color.White;
            this.BtnLogin.Location = new System.Drawing.Point(412, 332);
            this.BtnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 58);
            this.BtnLogin.TabIndex = 8;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click_1);
            // 
            // TxtName
            // 
            this.TxtName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtName.ForeColor = System.Drawing.Color.White;
            this.TxtName.Location = new System.Drawing.Point(241, 332);
            this.TxtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(165, 23);
            this.TxtName.TabIndex = 4;
            this.TxtName.Text = "amanda";
            this.TxtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtName_KeyDown_1);
            // 
            // TxtPass
            // 
            this.TxtPass.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPass.ForeColor = System.Drawing.Color.White;
            this.TxtPass.Location = new System.Drawing.Point(241, 364);
            this.TxtPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(165, 23);
            this.TxtPass.TabIndex = 5;
            this.TxtPass.Text = "200";
            this.TxtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPass_KeyDown_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Chiller", 50F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.label2.Location = new System.Drawing.Point(57, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 77);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lanka Stocks";
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.gb.Controls.Add(this.pictureBox2);
            this.gb.Controls.Add(this.label2);
            this.gb.Controls.Add(this.BtnLogin);
            this.gb.Controls.Add(this.label4);
            this.gb.Controls.Add(this.TxtName);
            this.gb.Controls.Add(this.label3);
            this.gb.Controls.Add(this.label7);
            this.gb.Controls.Add(this.TxtPass);
            this.gb.Location = new System.Drawing.Point(224, 12);
            this.gb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(535, 407);
            this.gb.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LankaStocks.Properties.Resources.Logo;
            this.pictureBox2.Location = new System.Drawing.Point(12, 111);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(217, 186);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Old English Text MT", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(219, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 135);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mahinda\r\nRajapaksha\r\nCollege";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(93, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "      Password -";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.Orange;
            this.line.Location = new System.Drawing.Point(155, 151);
            this.line.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(11, 38);
            this.line.TabIndex = 4;
            // 
            // buttonlogin
            // 
            this.buttonlogin.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonlogin.ForeColor = System.Drawing.Color.White;
            this.buttonlogin.Image = global::LankaStocks.Properties.Resources.key_24px;
            this.buttonlogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonlogin.Location = new System.Drawing.Point(0, 151);
            this.buttonlogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonlogin.Name = "buttonlogin";
            this.buttonlogin.Size = new System.Drawing.Size(165, 38);
            this.buttonlogin.TabIndex = 1;
            this.buttonlogin.Text = "Login";
            this.buttonlogin.UseVisualStyleBackColor = true;
            this.buttonlogin.Click += new System.EventHandler(this.buttonlogin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.line);
            this.panel1.Controls.Add(this.buttonabout);
            this.panel1.Controls.Add(this.buttonlogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 496);
            this.panel1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LankaStocks.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(-7, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // buttonabout
            // 
            this.buttonabout.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.buttonabout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonabout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonabout.ForeColor = System.Drawing.Color.White;
            this.buttonabout.Image = global::LankaStocks.Properties.Resources.about_us_24px;
            this.buttonabout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonabout.Location = new System.Drawing.Point(-1, 455);
            this.buttonabout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonabout.Name = "buttonabout";
            this.buttonabout.Size = new System.Drawing.Size(165, 38);
            this.buttonabout.TabIndex = 2;
            this.buttonabout.Text = "About";
            this.buttonabout.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.gb);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(808, 496);
            this.panel2.TabIndex = 14;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2_Paint);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(808, 496);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel gb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel line;
        private System.Windows.Forms.Button buttonabout;
        private System.Windows.Forms.Button buttonlogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private XanderUI.XUIObjectAnimator Animator;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}