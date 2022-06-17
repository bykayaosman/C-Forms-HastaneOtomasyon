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
    public partial class frKaydol : Form
    {
        public frKaydol()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox4.Text != "" && textBox5.Text != "" && richTextBox2.Text != "")
            {
                try
                {

                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand komutKaydet = new SqlCommand("insert into hastalar(Hasta_tc,Hasta_adi,Hasta_soyadi,Hasta_cinsiyeti,Hasta_kan,Hasta_dogumYeri,Hasta_dogumTarihi,Hasta_babaAdi,Hasta_anneAdi,Hasta_cepTel,Hasta_ePosta,hasta_parola,Hasta_Adres) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)", baglanti);
                    komutKaydet.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
                    komutKaydet.Parameters.AddWithValue("@p2", textBox1.Text);
                    komutKaydet.Parameters.AddWithValue("@p3", textBox2.Text);
                    komutKaydet.Parameters.AddWithValue("@p4", comboBox1.Text);
                    komutKaydet.Parameters.AddWithValue("@p5", comboBox4.Text);
                    komutKaydet.Parameters.AddWithValue("@p6", comboBox2.Text);
                    komutKaydet.Parameters.AddWithValue("@p7", maskedTextBox3.Text);
                    komutKaydet.Parameters.AddWithValue("@p8", textBox3.Text);
                    komutKaydet.Parameters.AddWithValue("@p9", textBox4.Text);
                    komutKaydet.Parameters.AddWithValue("@p10", maskedTextBox2.Text);
                    komutKaydet.Parameters.AddWithValue("@p11", textBox5.Text);
                    komutKaydet.Parameters.AddWithValue("@p12", maskedTextBox4.Text);
                    komutKaydet.Parameters.AddWithValue("@p13", richTextBox2.Text);
                    komutKaydet.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt Başarıyla Eklendi.");

                }

                catch
                {
                    MessageBox.Show("Hata! Lütfen Daha Donra Tekrar Deneyin.");
                }

            }
            else
            {
                MessageBox.Show("Lütfen Bilgilerinizi Giriniz!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox1.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();

                    SqlCommand sorgula = new SqlCommand("select * from hastalar where Hasta_tc=@tc and Hasta_parola is null", baglanti);
                    sorgula.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                    SqlDataReader oku = sorgula.ExecuteReader();

                    if (oku.Read())
                    {
                        bul();
                        MessageBox.Show("Kaydınız bulunmuştur lütfen şifre giriniz.");
                        maskedTextBox1.Text = oku[1].ToString();
                        textBox1.Text = oku[2].ToString();
                        textBox2.Text = oku[3].ToString();
                        comboBox1.Text = oku[4].ToString();
                        comboBox4.Text = oku[5].ToString();
                        comboBox2.Text = oku[6].ToString();
                        maskedTextBox3.Text = oku[7].ToString();
                        textBox3.Text = oku[8].ToString();
                        textBox4.Text = oku[9].ToString();
                        maskedTextBox2.Text = oku[10].ToString();
                        textBox5.Text = oku[11].ToString();
                        richTextBox2.Text = oku[13].ToString();

                    }
                    else
                    {
                        MessageBox.Show("Kaydınız bulunamadı ya da daha önce şifre belirlediniz. Lütfen tam bilgilerinizi giriniz ya da Hasta Girişi Panelini Kullanınız.");
                    }
                }

                else
                {
                    MessageBox.Show("Lütfen kontrol için önce TC girişi yapın");
                }
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra deneyin.");
            }
        }


        void bul()
        {
            maskedTextBox1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            maskedTextBox2.Enabled = false;
            maskedTextBox3.Enabled = false;
            richTextBox2.Enabled = false;
            textBox5.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = true;


        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox4.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand guncelle = new SqlCommand("update hastalar set Hasta_parola=@parola where Hasta_tc=@tc", baglanti);
                    guncelle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@parola", maskedTextBox4.Text);
                    guncelle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Şifre başarıyla alınmıştır.");
                }
                else
                {
                    MessageBox.Show("Lütfen önce şifre giriniz");
                }
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra deneyin");
            }
        }
    }
}
