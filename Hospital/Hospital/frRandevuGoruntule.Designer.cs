namespace Hospital
{
    partial class frRandevuGoruntule
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
            this.Randevularım = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Randevularım
            // 
            this.Randevularım.AutoSize = true;
            this.Randevularım.Location = new System.Drawing.Point(30, 230);
            this.Randevularım.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Randevularım.Name = "Randevularım";
            this.Randevularım.Size = new System.Drawing.Size(0, 13);
            this.Randevularım.TabIndex = 3;
            this.Randevularım.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 8);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(795, 219);
            this.dataGridView1.TabIndex = 2;
            // 
            // frRandevuGoruntule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 239);
            this.Controls.Add(this.Randevularım);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frRandevuGoruntule";
            this.Text = "frRandevuGoruntule";
            this.Load += new System.EventHandler(this.frRandevuGoruntule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Randevularım;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}