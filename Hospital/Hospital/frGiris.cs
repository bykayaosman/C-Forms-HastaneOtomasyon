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
    public partial class frGiris : Form
    {
        public frGiris()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");
        public static string kid, ksifre;
        public static string dkid, dsifre;
        public static string ykid, ysifre;

        void gizle()
        {

            groupBox1.Visible = false;
            DoktorgroupBox2.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            pictureBox2.Visible = false;
            groupBox4.Visible = false;
            vezneB.Visible = false;

        }

        private void frGiris_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            gizle();
            groupBox1.Visible = true;
            GirisPaneli.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    baglanti.Open();
                    SqlCommand vezne = new SqlCommand("select sekreter.sekreter_kullanici_adi,sekreter.sekreter_parola from sekreter where sekreter_kullanici_adi=@kadi and sekreter_parola=@ksifre", baglanti);
                    vezne.Parameters.AddWithValue("@kadi", SqlDbType.NVarChar).Value = textBox1.Text;
                    vezne.Parameters.AddWithValue("@ksifre", SqlDbType.Int).Value = textBox2.Text;
                    SqlDataReader oku = vezne.ExecuteReader();
                    if (oku.Read())
                    {
                        MessageBox.Show("Giriş Başarılı");
                        frHastaKabul yeni2 = new frHastaKabul();
                        yeni2.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Böyle Bir Kayıt Bulunamadı");
                }
                catch
                {
                    MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

                }
                baglanti.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            gizle();
            GirisPaneli.Visible = true;
            groupBox2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gizle();
            DoktorgroupBox2.Visible = true;
            GirisPaneli.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gizle();
            groupBox3.Visible = true;
            GirisPaneli.Visible = true;
        }

        private void yöneticibutton_Click(object sender, EventArgs e)
        {
            if (yöneticikadi.Text != "" && yöneticisifre.Text != "")
            {
                try
                {
                    baglanti.Open();
                    SqlCommand yönetici = new SqlCommand("select yoneticiler.kullanici_kullanici_adi,yoneticiler.kullanici_sifre FROM yoneticiler WHERE kullanici_kullanici_adi=@kadi and kullanici_sifre=@ksifre", baglanti);
                    yönetici.Parameters.AddWithValue("@kadi", SqlDbType.NVarChar).Value = yöneticikadi.Text;
                    yönetici.Parameters.AddWithValue("@ksifre", SqlDbType.Int).Value = yöneticisifre.Text;
                    SqlDataReader oku = yönetici.ExecuteReader();
                    if (oku.Read())
                    {
                        ykid = yöneticikadi.Text;
                        MessageBox.Show("Giriş Başarılı");
                        frYonetici yeni = new frYonetici();
                        this.Hide();
                        yeni.Show();
                    }
                    else
                        MessageBox.Show("Böyle Bir Kayıt Bulunamadı");
                    baglanti.Close();
                }
                catch
                {
                    MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");
                }
            }
            else
                MessageBox.Show("Boş Alanları Doldurunuz");

        }

        private void doktorbutton_Click(object sender, EventArgs e)
        {
            if (doktorkadi.Text != "" && doktorsifre.Text != "")
            {
                try
                {
                    baglanti.Open();
                    SqlCommand doktor = new SqlCommand("select doktorlar.kullanici_adi,doktorlar.sifre from doktorlar where kullanici_adi=@kadi and sifre=@ksifre", baglanti);
                    doktor.Parameters.AddWithValue("@kadi", SqlDbType.NVarChar).Value = doktorkadi.Text;
                    doktor.Parameters.AddWithValue("@ksifre", SqlDbType.Int).Value = doktorsifre.Text;
                    SqlDataReader oku = doktor.ExecuteReader();
                    if (oku.Read())
                    {
                        MessageBox.Show("Giriş Başarılı");
                        dkid = doktorkadi.Text;
                        dsifre = doktorsifre.Text;
                        frDoktor yeni5 = new frDoktor();
                        this.Hide();
                        yeni5.Show();
                    }
                    else
                        MessageBox.Show("Böyle Bir Kayıt Bulunamadı.");
                }
                catch
                {
                    MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");
                }
            }
            else
            {
                MessageBox.Show("Boş Alanları Doldurunuz");
            }
        }

        private void hastabutton_Click(object sender, EventArgs e)
        {
            if (hastakadi.Text != "" && hastasifre.Text != "")
            {
                try
                {                   
                    baglanti.Open();
                    SqlCommand hasta = new SqlCommand("select hastalar.Hasta_ePosta,hastalar.Hasta_parola from hastalar where Hasta_ePosta=@kadi and Hasta_parola=@ksifre", baglanti);
                    hasta.Parameters.AddWithValue("@kadi", SqlDbType.NVarChar).Value = hastakadi.Text;
                    hasta.Parameters.AddWithValue("@ksifre", SqlDbType.Int).Value = hastasifre.Text;
                    SqlDataReader oku = hasta.ExecuteReader();
                    if (oku.Read())
                    {
                        kid = hastakadi.Text;
                        ksifre = hastasifre.Text;
                        MessageBox.Show("Giriş Başarılı");
                        frHasta yeni2 = new frHasta();
                        yeni2.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Böyle Bir Kayıt Bulunamadı");
                }
                catch
                {
                    MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");
                }
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gizle();
            groupBox4.Visible = true;
            GirisPaneli.Visible = true;
        }

        private void labbutton_Click(object sender, EventArgs e)
        {
            if (labkadi.Text != "" && labsifre.Text != "")
            {
                try
                {
                    baglanti.Open();
                    SqlCommand vezne = new SqlCommand("select labeleman.lab_kullanici_adi,labeleman.lab_eleman_parola from labeleman where lab_kullanici_adi=@kadi and lab_eleman_parola=@ksifre", baglanti);
                    vezne.Parameters.AddWithValue("@kadi", SqlDbType.NVarChar).Value = labkadi.Text;
                    vezne.Parameters.AddWithValue("@ksifre", SqlDbType.Int).Value = labsifre.Text;
                    SqlDataReader oku = vezne.ExecuteReader();
                    if (oku.Read())
                    {
                        MessageBox.Show("Giriş Başarılı");
                        frLaboratuvar yeni2 = new frLaboratuvar();
                        yeni2.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Böyle Bir Kayıt Bulunamadı");
                }
                catch
                {
                    MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");
                }
                baglanti.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gizle();
            vezneB.Visible = true;
            GirisPaneli.Visible = true;
        }

        private void vezneButton_Click(object sender, EventArgs e)
        {
            if (veznek.Text != "" && vezneS.Text != "")
            {
                try
                {
                    baglanti.Open();
                    SqlCommand vezne = new SqlCommand("select veznedar.veznedar_kullanici_adi, veznedar.veznedar_parola from veznedar where veznedar_kullanici_adi=@kadi and veznedar_parola=@ksifre", baglanti);
                    vezne.Parameters.AddWithValue("@kadi", SqlDbType.NVarChar).Value = veznek.Text;
                    vezne.Parameters.AddWithValue("@ksifre", SqlDbType.Int).Value = vezneS.Text;
                    SqlDataReader oku = vezne.ExecuteReader();
                    if (oku.Read())
                    {
                        MessageBox.Show("Giriş Başarılı");
                        frVezne yeni2 = new frVezne();
                        yeni2.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Böyle Bir Kayıt Bulunamadı");
                }
                catch
                {
                    MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");
                }
                baglanti.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frSifre yeni = new frSifre();
            yeni.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frIletisim yeni = new frIletisim();
            yeni.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frKaydol yeni1 = new frKaydol();
            yeni1.Show();
            //this.Hide();
        }
    }
}
