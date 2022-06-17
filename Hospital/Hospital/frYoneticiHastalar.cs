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
    public partial class frYoneticiHastalar : Form
    {
        public frYoneticiHastalar()
        {
            InitializeComponent();
        }
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");


        private void frYoneticiHastalar_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand yonetici = new SqlCommand("select *from hastalar", baglanti);
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand c = new SqlCommand("select * from hastalar where Hasta_id=@id", baglanti);
                c.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                SqlDataReader oku = c.ExecuteReader();
                while (oku.Read())
                {
                    maskedTextBox1.Text = oku[1].ToString();
                    textBox1.Text = oku[2].ToString();
                    textBox2.Text = oku[3].ToString();
                    textBox6.Text = oku[4].ToString();
                    textBox7.Text = oku[5].ToString();
                    textBox8.Text = oku[6].ToString();
                    maskedTextBox3.Text = oku[7].ToString();
                    textBox3.Text = oku[8].ToString();
                    textBox4.Text = oku[9].ToString();
                    maskedTextBox2.Text = oku[10].ToString();
                    textBox5.Text = oku[0].ToString();
                    textBox9.Text = oku[13].ToString();

                }
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("hata!! lütfen daha sonra tekrar deneyin");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox5.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand guncelle = new SqlCommand("update hastalar set Hasta_tc=@tc,Hasta_adi=@ad,Hasta_soyadi=@soyad,Hasta_cinsiyeti=@cinsiyet,Hasta_kan=@kan,Hasta_dogumYeri=@dogumy,Hasta_dogumTarihi=@tarih,Hasta_babaAdi=@baba,Hasta_anneAdi=@anne,Hasta_cepTel=@cep,Hasta_Adres=@adres where Hasta_id=@id", baglanti);
                    guncelle.Parameters.AddWithValue("@id", textBox5.Text);
                    guncelle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@ad", textBox1.Text);
                    guncelle.Parameters.AddWithValue("@soyad", textBox2.Text);
                    guncelle.Parameters.AddWithValue("@cinsiyet", textBox6.Text);
                    guncelle.Parameters.AddWithValue("@kan", textBox7.Text);
                    guncelle.Parameters.AddWithValue("@dogumy", textBox8.Text);
                    guncelle.Parameters.AddWithValue("@tarih", maskedTextBox3.Text);
                    guncelle.Parameters.AddWithValue("@baba", textBox3.Text);
                    guncelle.Parameters.AddWithValue("@anne", textBox4.Text);
                    guncelle.Parameters.AddWithValue("@cep", maskedTextBox2.Text);
                    guncelle.Parameters.AddWithValue("@adres", textBox9.Text);
                    guncelle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Hasta Başarıyla Güncellendi");
                }
                else
                {
                    MessageBox.Show("Alanlar Boş Geçilemez");
                }
            }
            catch
            {
                MessageBox.Show("hata!! lütfen daha sonra tekrar deneyin");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Clear();
            maskedTextBox3.Clear();
            maskedTextBox2.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (maskedTextBox4.Text != "")
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand ara = new SqlCommand("select * from hastalar where Hasta_tc like '%" + maskedTextBox4.Text.ToString() + "%'", baglanti);
                    da = new SqlDataAdapter(ara);
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
                catch
                {
                    MessageBox.Show("Hata!! lütfen daha sonra deneyiniz.");
                }
            }
            else
                MessageBox.Show("Lütfen bir arama parametresi giriniz.");

        }
    }
}
