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
    public partial class frYoneticiKlinikler : Form
    {
        public frYoneticiKlinikler()
        {
            InitializeComponent();
        }
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");

        void doktor()
        {
            SqlCommand acil = new SqlCommand("select * from doktorlar where doktor_klinik_id IS NULL", baglanti);
            acil.Parameters.AddWithValue("@id", textBox1.Text);
            Query.combo(acil, "doktor_id", "doktor_adi_soyadi", comboBox2);
        }
        void mdoktor()
        {
            if (textBox2.Text != "")
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand komutdoktor = new SqlCommand("SELECT klinikler.klinik_id,doktorlar.doktor_id,doktorlar.doktor_adi_soyadi FROM doktorlar INNER JOIN klinikler ON doktorlar.doktor_klinik_id=klinikler.klinik_id WHERE doktorlar.doktor_klinik_id=@kid", baglanti);
                komutdoktor.Parameters.AddWithValue("@kid", textBox1.Text.ToString());
                Query.combo(komutdoktor, "doktor_id", "doktor_adi_soyadi", comboBox1);

                baglanti.Close();


            }
        }


        private void frYoneticiKlinikler_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();

                SqlCommand doldur = new SqlCommand("select klinikler.klinik_id,klinikler.klinik_adi,klinikler.yatan_hasta,doktorlar.doktor_adi_soyadi from klinikler INNER JOIN doktorlar on doktor_klinik_id=klinik_id", baglanti);
                da = new SqlDataAdapter(doldur);
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (maskedTextBox6.Text != "")
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand ara = new SqlCommand("select * from klinikler where klinik_id like '%" + maskedTextBox6.Text.ToString() + "%'", baglanti);
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand c = new SqlCommand("select * from klinikler where klinik_id=@id", baglanti);
                c.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                SqlDataReader oku = c.ExecuteReader();
                while (oku.Read())
                {
                    textBox1.Text = oku[0].ToString();
                    textBox2.Text = oku[1].ToString();
          //          frYatanHasta.Series["Yatan Hasta"].Points.AddXY(oku[1].ToString(), oku[3]);


                }
                mdoktor();
                doktor();
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! lütfen daha sonra deneyiniz.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != 0)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand de = new SqlCommand("update doktorlar set doktor_klinik_id=@kid where doktor_id=@id", baglanti);
                    de.Parameters.AddWithValue("@id", comboBox2.SelectedValue.ToString());
                    de.Parameters.AddWithValue("@kid", textBox1.Text);
                    de.ExecuteNonQuery();
                    baglanti.Close();
                }
                catch
                {
                    MessageBox.Show("Hata!! Lütfen daha sonra deneyiniz.");
                }
            }

            else
            {
                MessageBox.Show("Lütfen bir doktor seçiniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand ce = new SqlCommand("insert into klinikler(klinik_adi,yatak_kapasite)values(@kadi,@kapasite)", baglanti);
                    ce.Parameters.AddWithValue("@kadi", textBox2.Text.ToString());
                    ce.Parameters.AddWithValue("@kapasite", textBox3.Text);
                    ce.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Klinik başarıyla eklendi");
                }
                catch
                {
                    MessageBox.Show("Hata!! Lütfen daha sonra deneyiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir değer giriniz.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand sil = new SqlCommand("delete from klinikler where klinik_id=@id ", baglanti);
                    sil.Parameters.AddWithValue("@id", textBox1.Text);
                    sil.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Klinik başarıyla silindi");
                }
                catch
                {
                    MessageBox.Show("Hata!! Lütfen daha sonra deneyiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir klinik seçiniz");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
    }
}

