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
    public partial class frYoneticiBilgiler : Form
    {
        public frYoneticiBilgiler()
        {
            InitializeComponent();
        }
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand c = new SqlCommand("select * from yoneticiler where kullanici_id=@id", baglanti);
                c.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                SqlDataReader oku = c.ExecuteReader();
                while (oku.Read())
                {
                    textBox1.Text = oku[0].ToString();
                    textBox2.Text = oku[1].ToString();
                    textBox3.Text = oku[3].ToString();
                    textBox4.Text = oku[2].ToString();

                }
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("hata!! lütfen daha sonra tekrar deneyin");
            }
        }

        private void frYoneticiBilgiler_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand yonetici = new SqlCommand("select *from yoneticiler", baglanti);
                da = new SqlDataAdapter(yonetici);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("hata!! lütfen daha sonra tekrar deneyin");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && maskedTextBox1.Text != "")
                {

                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand gunceller = new SqlCommand("update yoneticiler set kullanici_kullanici_adi=@kad,kullanici_sifre=@sifre,kullanici_adisoyadi=@ad where kullanici_id=@id", baglanti);
                    gunceller.Parameters.AddWithValue("@id", textBox1.Text);
                    gunceller.Parameters.AddWithValue("@kad", textBox2.Text);
                    gunceller.Parameters.AddWithValue("@sifre", maskedTextBox1.Text);
                    gunceller.Parameters.AddWithValue("@ad", textBox3.Text);
                    gunceller.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kullanici Bilgileri Basariyla Güncellendi");

                }
                else
                {
                    MessageBox.Show("Alanlar Boş Bırakılamaz");
                }
            }
            catch
            {
                MessageBox.Show("hata!! lütfen daha sonra tekrar deneyin");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand ekle = new SqlCommand("insert into yoneticiler(kullanici_kullanici_adi,kullanici_sifre,kullanici_adisoyadi)values(@kad,@sifre,@ad)", baglanti);
                    ekle.Parameters.AddWithValue("@kad", textBox2.Text);
                    ekle.Parameters.AddWithValue("@sifre", maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@ad", textBox3.Text);
                    ekle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kullanici Basariyla Eklendi");
                }
                else
                {
                    MessageBox.Show("Alanlar Boş Bırakılamaz");
                }
            }
            catch
            {
                MessageBox.Show("hata!! lütfen daha sonra tekrar deneyin");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand sil = new SqlCommand("delete from yoneticiler where kullanici_id=@id", baglanti);
                    sil.Parameters.AddWithValue("@id", textBox1.Text);
                    sil.ExecuteNonQuery();
                    MessageBox.Show("Kullanici Başarıyla Silindi");
                }
                else
                {
                    MessageBox.Show("Önce bir kullanıcı seçiniz");
                }
            }
            catch
            {
                MessageBox.Show("hata!! lütfen daha sonra tekrar deneyin");
            }
        }
    }
}
