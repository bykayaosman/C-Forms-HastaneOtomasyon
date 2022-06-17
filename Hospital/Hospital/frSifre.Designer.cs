namespace Hospital
{
    partial class frSifre
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
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.vezneButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.kontrol2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.yeniS = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kontrol = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(1, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "E-Posta:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 18);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 20);
            this.textBox1.TabIndex = 0;
            // 
            // vezneButton
            // 
            this.vezneButton.BackColor = System.Drawing.Color.Azure;
            this.vezneButton.Location = new System.Drawing.Point(174, 45);
            this.vezneButton.Margin = new System.Windows.Forms.Padding(2);
            this.vezneButton.Name = "vezneButton";
            this.vezneButton.Size = new System.Drawing.Size(86, 29);
            this.vezneButton.TabIndex = 3;
            this.vezneButton.Text = "Gönder";
            this.vezneButton.UseVisualStyleBackColor = false;
            this.vezneButton.Click += new System.EventHandler(this.vezneButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Azure;
            this.button1.Location = new System.Drawing.Point(4, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Doktor";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Azure;
            this.button2.Location = new System.Drawing.Point(94, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 29);
            this.button2.TabIndex = 5;
            this.button2.Text = "Hasta ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Azure;
            this.button3.Location = new System.Drawing.Point(184, 10);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 29);
            this.button3.TabIndex = 6;
            this.button3.Text = "Vezne";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Azure;
            this.button5.Location = new System.Drawing.Point(130, 44);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 29);
            this.button5.TabIndex = 8;
            this.button5.Text = "Hasta Kabul ";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Azure;
            this.button4.Location = new System.Drawing.Point(40, 44);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 29);
            this.button4.TabIndex = 7;
            this.button4.Text = "Lab";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.vezneButton);
            this.panel1.Location = new System.Drawing.Point(61, 92);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 81);
            this.panel1.TabIndex = 15;
            this.panel1.Visible = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Azure;
            this.button6.Location = new System.Drawing.Point(84, 45);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(86, 29);
            this.button6.TabIndex = 4;
            this.button6.Text = "Değiştir";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // kontrol2
            // 
            this.kontrol2.AutoSize = true;
            this.kontrol2.Location = new System.Drawing.Point(10, 73);
            this.kontrol2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.kontrol2.Name = "kontrol2";
            this.kontrol2.Size = new System.Drawing.Size(13, 13);
            this.kontrol2.TabIndex = 20;
            this.kontrol2.Text = "1";
            this.kontrol2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Yeni Şifreniz";
            this.label1.Visible = false;
            // 
            // yeniS
            // 
            this.yeniS.AutoSize = true;
            this.yeniS.Location = new System.Drawing.Point(10, 23);
            this.yeniS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yeniS.Name = "yeniS";
            this.yeniS.Size = new System.Drawing.Size(35, 13);
            this.yeniS.TabIndex = 18;
            this.yeniS.Text = "label1";
            this.yeniS.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(61, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 82);
            this.panel2.TabIndex = 17;
            // 
            // kontrol
            // 
            this.kontrol.AutoSize = true;
            this.kontrol.Location = new System.Drawing.Point(10, 5);
            this.kontrol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.kontrol.Name = "kontrol";
            this.kontrol.Size = new System.Drawing.Size(35, 13);
            this.kontrol.TabIndex = 16;
            this.kontrol.Text = "label1";
            this.kontrol.Visible = false;
            // 
            // frSifre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(376, 179);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kontrol2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yeniS);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.kontrol);
            this.Name = "frSifre";
            this.Text = "frSifre";
            this.Load += new System.EventHandler(this.frSifre_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button vezneButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label kontrol2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label yeniS;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label kontrol;
    }
}