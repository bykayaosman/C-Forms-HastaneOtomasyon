using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital
{
    public partial class frYonetici : Form
    {
        public frYonetici()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult karar = new DialogResult();
            karar = MessageBox.Show("Çıkış istediğinize emin misiniz ? ", "Uyarı", MessageBoxButtons.YesNo);
            if (karar == DialogResult.Yes)
            {
                this.Hide();                
                frGiris yeni = new frGiris();
                yeni.Show();
            }
            else if (karar == DialogResult.No)
            {
                MessageBox.Show("Oturum Kapatılmadı.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frYoneticiBilgiler yeni = new frYoneticiBilgiler();
            yeni.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            frYoneticiHastalar yeni = new frYoneticiHastalar();
            yeni.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frYoneticiDoktor yeni = new frYoneticiDoktor();
            yeni.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frEleman yeni = new frEleman();
            yeni.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frYoneticiKlinikler yeni = new frYoneticiKlinikler();
            yeni.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frYoneticiIletisim yeni = new frYoneticiIletisim();
            yeni.Show();
        }

        private void frYonetici_Load(object sender, EventArgs e)
        {
            label2.Text = frGiris.ykid;
            if (label2.Text != "basyonetici")
                button7.Enabled = false;
        }
    }
}
