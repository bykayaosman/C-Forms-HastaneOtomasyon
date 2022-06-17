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
    public partial class frHasta : Form
    {
        public frHasta()
        {
            InitializeComponent();
        }
         public static string idx;
         SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");


         void kontrol()
         {
             //yatış yapan hasta randevu alamasın
             

             baglanti.Open();
             SqlCommand a = new SqlCommand("select kontrol from hastalar where Hasta_id=@id", baglanti);
             a.Parameters.AddWithValue("@id", label2.Text);
             SqlDataReader oku = a.ExecuteReader();
             while (oku.Read())
             {
                 label14.Text = oku[0].ToString();
             }
             baglanti.Close();
             if (label14.Text == "2")
             {
                 button1.Enabled = false;
                 button3.Enabled = false;
                 button4.Enabled = false;
             }


         }


        private void frHasta_Load(object sender, EventArgs e)
        {
            try
            {

                label4.Text = frGiris.kid;
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand id = new SqlCommand("select * from hastalar where Hasta_ePosta=@eposta", baglanti);
                id.Parameters.AddWithValue("@eposta", SqlDbType.NVarChar).Value = label4.Text;
                SqlDataReader oku = id.ExecuteReader();
                while (oku.Read())
                {
                    label2.Text = oku[0].ToString();
                    label13.Text = oku[1].ToString();
                    label11.Text = oku[2].ToString();
                    label12.Text = oku[3].ToString();

                }
                baglanti.Close();
                idx = label2.Text;
                kontrol();
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
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
            frHastaBilgileri yeni = new frHastaBilgileri();
            yeni.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frRandevuAl yeni1 = new frRandevuAl();
            yeni1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand randevu = new SqlCommand("select * from randevular where randevu_hasta_id=@id", baglanti);
                randevu.Parameters.AddWithValue("@id", label2.Text);
                SqlDataReader oku2 = randevu.ExecuteReader();
                if (oku2.Read())
                {
                    label5.Text = oku2[6].ToString();
                    if (label5.Text == "2")
                    {
                        DialogResult cevap = MessageBox.Show("Randevunuz Doktor Tarafından İptal Edilmiştir Randevularınızı Kontrol Etmek İster misiniz ?.", "Randevular", MessageBoxButtons.YesNo);

                        if (cevap == DialogResult.Yes)
                        {
                            if (baglanti.State == ConnectionState.Open)
                                baglanti.Close();
                            baglanti.Open();
                            SqlCommand sil = new SqlCommand("delete from randevular where randevu_hasta_id=@id", baglanti);
                            sil.Parameters.AddWithValue("@id", label2.Text);
                            sil.ExecuteNonQuery();
                            baglanti.Close();

                            frRandevuGoruntule yeni = new frRandevuGoruntule();
                            yeni.Show();
                        }
                        else if (cevap == DialogResult.No)
                        {
                            baglanti.Open();
                            SqlCommand sil = new SqlCommand("delete from randevular where randevu_hasta_id=@id", baglanti);
                            sil.Parameters.AddWithValue("@id", label2.Text);
                            sil.ExecuteNonQuery();
                            baglanti.Close();
                        }
                    }
                    else
                    {
                        frRandevuGoruntule yeni2 = new frRandevuGoruntule();
                        yeni2.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Herhangi bir randevunuz bulunmamaktadır.");
                }
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frRandevuSil yeni3 = new frRandevuSil();
            yeni3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frHastaRecete yeni = new frHastaRecete();
            yeni.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frHastaLab yeni = new frHastaLab();
            yeni.Show();
        }
    }
}
