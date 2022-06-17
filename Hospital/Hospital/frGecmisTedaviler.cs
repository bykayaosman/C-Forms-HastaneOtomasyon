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
    public partial class frGecmisTedaviler : Form
    {
        public frGecmisTedaviler()
        {
            InitializeComponent();
        }
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");


        void ameliyat()
        {

            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            // SqlCommand a = new SqlCommand("select tedavi.ameliyat_id,ameliyat.ameliyat_adi,tedavi.serum_id,serum.serum_adi,tedavi.tedavi_ilac_id,ilaclar.ilac_adi from tedavi inner join ameliyat on tedavi.ameliyat_id=ameliyat.ameliyat_id inner join serum on tedavi.serum_id=serum.serum_id inner join ilaclar on tedavi.tedavi_ilac_id=ilaclar.ilac_id where tedavi.tedavi_hasta_id=@id", baglanti);
            SqlCommand a = new SqlCommand("select tedavi.ameliyat_id,ameliyat.ameliyat_adi from tedavi inner join ameliyat on tedavi.ameliyat_id=ameliyat.ameliyat_id where tedavi.tedavi_hasta_id=@id", baglanti);
            a.Parameters.AddWithValue("@id", frYatanHasta.id);
            da = new SqlDataAdapter(a);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

        }
        void serum()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            // SqlCommand a = new SqlCommand("select tedavi.ameliyat_id,ameliyat.ameliyat_adi,tedavi.serum_id,serum.serum_adi,tedavi.tedavi_ilac_id,ilaclar.ilac_adi from tedavi inner join ameliyat on tedavi.ameliyat_id=ameliyat.ameliyat_id inner join serum on tedavi.serum_id=serum.serum_id inner join ilaclar on tedavi.tedavi_ilac_id=ilaclar.ilac_id where tedavi.tedavi_hasta_id=@id", baglanti);
            SqlCommand a = new SqlCommand("select tedavi.serum_id,serum.serum_adi from tedavi inner join serum on tedavi.serum_id=serum.serum_id where tedavi.tedavi_hasta_id=@id", baglanti);
            a.Parameters.AddWithValue("@id", frYatanHasta.id);
            da = new SqlDataAdapter(a);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            baglanti.Close();
        }
        void ilac()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            // SqlCommand a = new SqlCommand("select tedavi.ameliyat_id,ameliyat.ameliyat_adi,tedavi.serum_id,serum.serum_adi,tedavi.tedavi_ilac_id,ilaclar.ilac_adi from tedavi inner join ameliyat on tedavi.ameliyat_id=ameliyat.ameliyat_id inner join serum on tedavi.serum_id=serum.serum_id inner join ilaclar on tedavi.tedavi_ilac_id=ilaclar.ilac_id where tedavi.tedavi_hasta_id=@id", baglanti);
            SqlCommand a = new SqlCommand("select tedavi.tedavi_ilac_id,ilaclar.ilac_adi from tedavi  inner join ilaclar on tedavi.tedavi_ilac_id=ilaclar.ilac_id  where tedavi.tedavi_hasta_id=@id", baglanti);
            a.Parameters.AddWithValue("@id", frYatanHasta.id);
            da = new SqlDataAdapter(a);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            baglanti.Close();
        }

        void hasta()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();

            SqlCommand id = new SqlCommand("select * from hastalar where Hasta_id=@id", baglanti);
            id.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = maskedTextBox2.Text;
            SqlDataReader oku = id.ExecuteReader();
            while (oku.Read())
            {
                maskedTextBox1.Text = oku[1].ToString();
                textBox1.Text = oku[2].ToString();
                textBox2.Text = oku[3].ToString();
                textBox6.Text = oku[4].ToString();
                textBox7.Text = oku[5].ToString();
                textBox8.Text = oku[6].ToString();
                maskedTextBox3.Text = oku[7].ToString();
            }
            baglanti.Close();

        }
        void lab()
        {

            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            SqlCommand listele = new SqlCommand("select lab.lab_id,lab.lab_tahlil_id,lab_test_id,testler.test_adi,lab_aciklama,tahliller.tahlil_doktor_id,tahliller.tahlil_hasta_id,tahliller.tahlil_klinik_id,lab.lab_tarih from lab INNER JOIN tahliller on tahliller.tahlil_id=lab_tahlil_id INNER JOIN testler on testler.test_id=lab.lab_test_id where tahliller.tahlil_hasta_id=@id and tahliller.tahlil_doktor_id=@did", baglanti);
            listele.Parameters.AddWithValue("@id", maskedTextBox2.Text);
            listele.Parameters.AddWithValue("@did", maskedTextBox4.Text);
            da = new SqlDataAdapter(listele);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }


        private void frGecmisTedaviler_Load(object sender, EventArgs e)
        {
            try
            {
                maskedTextBox4.Text = frDoktor.dkidd;
                maskedTextBox5.Text = frDoktor.klinikid;
                maskedTextBox2.Text = frYatanHasta.id.ToString();
                hasta();
                lab();
                ameliyat();
                serum();
                ilac();
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }
    }
}
