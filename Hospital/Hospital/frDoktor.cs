using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital
{
    public partial class frDoktor : Form
    {
        public frDoktor()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");
        public static string dkidd;
        public static string klinikid;

        private void frDoktor_Load(object sender, EventArgs e)
        {
            try
            {
                //kullaniciadi.Text = GirisSayfasi.dkid;
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand id = new SqlCommand("select *from doktorlar where kullanici_adi=@kid", baglanti);
                id.Parameters.AddWithValue("@kid", kullaniciadi.Text);
                SqlDataReader oku = id.ExecuteReader();
                while (oku.Read())
                {
                    this.id.Text = oku[0].ToString();
                    label6.Text = oku[3].ToString();
                    label7.Text = oku[5].ToString();
                    textBox1.Text = oku[12].ToString();
                    pictureBox1.ImageLocation = textBox1.Text;

                }
                dkidd = this.id.Text;
                this.id.Text = dkidd;

                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand acil = new SqlCommand("SELECT klinikler.klinik_id,klinikler.klinik_adi,doktorlar.doktor_id FROM doktorlar INNER JOIN klinikler ON doktorlar.doktor_klinik_id=klinikler.klinik_id WHERE doktorlar.doktor_klinik_id=@kid", baglanti);
                acil.Parameters.AddWithValue("@kid", this.id.Text);
                SqlDataReader ok = acil.ExecuteReader();
                while (ok.Read())
                {
                    Klinikid.Text = ok[0].ToString();
                    label8.Text = ok[1].ToString();

                    klinikid = Klinikid.Text;
                }
                baglanti.Close();
                if (Klinikid.Text == "16" || Klinikid.Text == "17" || Klinikid.Text == "18")
                {
                    btBekleyenHasta.Enabled = false;
                    btRandevular.Enabled = false;
                    btRandevuSil.Enabled = false;
                }
                else
                    btAcil.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void pcbGeri_Click(object sender, EventArgs e)
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

        private void btKullanici_Click(object sender, EventArgs e)
        {
            frDoktorBilgileri yeni = new frDoktorBilgileri();
            yeni.Show();
        }

        private void btRandevular_Click(object sender, EventArgs e)
        {
            frDoktorRandevuGoruntule yeni2 = new frDoktorRandevuGoruntule();
            yeni2.Show();
        }

        private void btRandevuSil_Click(object sender, EventArgs e)
        {
            frDoktorRandevuSil yeni3 = new frDoktorRandevuSil();
            yeni3.Show();
        }

        private void btBekleyenHasta_Click(object sender, EventArgs e)
        {
            frBekleyenHastalar yeni3 = new frBekleyenHastalar();
            yeni3.Show();
        }

        private void btTahlilSonuclari_Click(object sender, EventArgs e)
        {
            frDoktorTahlilSonucları yeni = new frDoktorTahlilSonucları();
            frYatanHasta.yatan = 0;
            yeni.Show();
        }

        private void btAcil_Click(object sender, EventArgs e)
        {
            frDoktorAcil yeni = new frDoktorAcil();
            yeni.Show();
        }

        private void btYatanHastalar_Click(object sender, EventArgs e)
        {
            frYatanHasta yeni = new frYatanHasta();
            yeni.Show();
        }
    }
}
