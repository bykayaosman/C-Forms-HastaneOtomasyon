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
    public partial class frYoneticiDoktor : Form
    {
        public frYoneticiDoktor()
        {
            InitializeComponent();
        }

        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");

        void klinik()
        {
            SqlCommand c = new SqlCommand("select * from klinikler where klinik_id < 14 or klinik_id > 18", baglanti);
            Query.combo(c, "klinik_id", "klinik_adi", comboBox1);
        }


        private void frYoneticiDoktor_Load(object sender, EventArgs e)
        {
            try
            {
                klinik();
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand listele = new SqlCommand("select * from doktorlar", baglanti);
                da = new SqlDataAdapter(listele);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand q = new SqlCommand("select * from doktorlar where doktor_id =@id", baglanti);
                q.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                SqlDataReader oku = q.ExecuteReader();
                while (oku.Read())
                {
                    maskedTextBox1.Text = oku[5].ToString();
                    textBox1.Text = oku[3].ToString();
                    textBox6.Text = oku[11].ToString();
                    textBox7.Text = oku[6].ToString();
                    textBox8.Text = oku[7].ToString();
                    textBox9.Text = oku[10].ToString();
                    maskedTextBox2.Text = oku[8].ToString();
                    textBox5.Text = oku[9].ToString();
                    maskedTextBox3.Text = oku[1].ToString();
                    maskedTextBox4.Text = oku[2].ToString();
                    textBox2.Text = oku[4].ToString();
                    textBox3.Text = oku[0].ToString();
                    textBox4.Text = oku[12].ToString();
                    pictureBox1.ImageLocation = textBox4.Text;
                }
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox4.Text != "" && maskedTextBox5.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && comboBox1.SelectedIndex != 0 && textBox4.Text != "")
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand a = new SqlCommand("UPDATE doktorlar SET kullanici_adi=@kadi,sifre=@sifre,doktor_adi_soyadi=@ad,doktor_klinik_id=@klinik,doktor_tc=@tc,doktor_kan=@kan,doktor_dtarih=@dtarih,doktor_cep=@cep,doktor_eposta=@eposta,doktor_adres=@adres,doktor_cinsiyeti=@cinsiyet,doktor_foto=@foto where doktor_id=@id", baglanti);
                    a.Parameters.AddWithValue("@kadi", SqlDbType.NVarChar).Value = maskedTextBox3.Text.ToString();
                    a.Parameters.AddWithValue("@sifre", SqlDbType.Int).Value = Convert.ToInt32(maskedTextBox5.Text);
                    a.Parameters.AddWithValue("@ad", SqlDbType.NVarChar).Value = textBox1.Text.ToString();
                    a.Parameters.AddWithValue("@klinik", SqlDbType.Int).Value = Convert.ToInt32(comboBox1.SelectedValue);
                    a.Parameters.AddWithValue("@tc", SqlDbType.NVarChar).Value = maskedTextBox1.Text.ToString();
                    a.Parameters.AddWithValue("@kan", textBox7.Text);
                    a.Parameters.AddWithValue("@dtarih", textBox8.Text);
                    a.Parameters.AddWithValue("@cep", maskedTextBox2.Text);
                    a.Parameters.AddWithValue("@eposta", textBox5.Text);
                    a.Parameters.AddWithValue("@adres", textBox9.Text);
                    a.Parameters.AddWithValue("@cinsiyet", textBox6.Text);
                    a.Parameters.AddWithValue("@id", textBox3.Text);
                    a.Parameters.AddWithValue("@foto", textBox4.Text);
                    a.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Doktor bilgileri başarıyla güncellendi");
                }
                catch
                {
                    MessageBox.Show("Hata!! lütfen daha sonra deneyiniz.");
                }
            }
            else
                MessageBox.Show("Alanlar Boş Bırakılamaz");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox3.Text != "")
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand sil = new SqlCommand("delete doktorlar where kullanici_adi=@kadi", baglanti);
                    sil.Parameters.AddWithValue("@kadi", maskedTextBox3.Text);
                    sil.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Doktor başarıyla silindi");
                }
                catch
                {
                    MessageBox.Show("Hata!! lütfen daha sonra deneyiniz.");
                }
            }


            else
                MessageBox.Show("Alanlar Boş Bırakılamaz");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            maskedTextBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox5.Text != "" && textBox1.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                try
                {                  
                    baglanti.Open();
                    SqlCommand a = new SqlCommand("insert into doktorlar(kullanici_adi,sifre,doktor_adi_soyadi,doktor_klinik_id,doktor_tc,doktor_kan,doktor_dtarih,doktor_cep,doktor_eposta,doktor_adres,doktor_cinsiyeti,doktor_foto)values(@kadi,@sifre,@ad,@klinik,@tc,@kan,@dtarih,@cep,@eposta,@adres,@cinsiyet,@foto)", baglanti);
                    a.Parameters.AddWithValue("@kadi", SqlDbType.NVarChar).Value = maskedTextBox3.Text.ToString();
                    a.Parameters.AddWithValue("@sifre", SqlDbType.Int).Value = Convert.ToInt32(maskedTextBox5.Text);
                    a.Parameters.AddWithValue("@ad", SqlDbType.NVarChar).Value = textBox1.Text.ToString();
                    a.Parameters.AddWithValue("@klinik", SqlDbType.Int).Value = Convert.ToInt32(comboBox1.SelectedValue);
                    a.Parameters.AddWithValue("@tc", SqlDbType.NVarChar).Value = maskedTextBox1.Text.ToString();
                    a.Parameters.AddWithValue("@kan", textBox7.Text);
                    a.Parameters.AddWithValue("@dtarih", textBox8.Text);
                    a.Parameters.AddWithValue("@cep", maskedTextBox2.Text);
                    a.Parameters.AddWithValue("@eposta", textBox5.Text);
                    a.Parameters.AddWithValue("@adres", textBox9.Text);
                    a.Parameters.AddWithValue("@cinsiyet", textBox6.Text);
                    a.Parameters.AddWithValue("@foto", textBox4.Text);
                    a.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Doktor başarıyla eklendi");
                }
                catch
                {
                    MessageBox.Show("Hata!! lütfen daha sonra deneyiniz.");
                }
            }
            else
                MessageBox.Show("Alanlar Boş Bırakılamaz");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (maskedTextBox6.Text != "")
            {
                try
                {
                    baglanti.Open();
                    SqlCommand ara = new SqlCommand("select * from doktorlar where doktor_tc like '%" + maskedTextBox4.Text.ToString() + "%'", baglanti);
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

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox4.Text = openFileDialog1.FileName;
        }
    }
}
