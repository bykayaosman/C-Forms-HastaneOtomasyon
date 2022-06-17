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
    public partial class frVezne : Form
    {
        public frVezne()
        {
            InitializeComponent();
        }

        int muayene = 150;
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");


        void ameliyat()
        {

            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            SqlCommand a = new SqlCommand("select tedavi.ameliyat_id,ameliyat.ameliyat_adi,ameliyat.ameliyat_fiyat from tedavi inner join ameliyat on tedavi.ameliyat_id=ameliyat.ameliyat_id where tedavi.tedavi_hasta_id=@id and tedavi.kontrol is null ", baglanti);
            a.Parameters.AddWithValue("@id", textBox4.Text);
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
            SqlCommand a = new SqlCommand("select tedavi.serum_id,serum.serum_adi,serum.serum_fiyat from tedavi inner join serum on tedavi.serum_id=serum.serum_id where tedavi.tedavi_hasta_id=@id and tedavi.kontrol is null", baglanti);
            a.Parameters.AddWithValue("@id", textBox4.Text);
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
            SqlCommand a = new SqlCommand("select tedavi.tedavi_ilac_id,ilaclar.ilac_adi,ilaclar.ilac_fiyat from tedavi  inner join ilaclar on tedavi.tedavi_ilac_id=ilaclar.ilac_id  where tedavi.tedavi_hasta_id=@id and tedavi.kontrol is null", baglanti);
            a.Parameters.AddWithValue("@id", textBox4.Text);
            da = new SqlDataAdapter(a);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            baglanti.Close();
        }

        void lab()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            SqlCommand a = new SqlCommand("select lab.lab_test_id,testler.test_adi,testler.test_fiyat from lab inner join testler on lab.lab_test_id=testler.test_id inner join tahliller on tahliller.tahlil_id=lab.lab_tahlil_id where tahliller.tahlil_hasta_id=@id and lab.kontrol=3 ", baglanti);
            a.Parameters.AddWithValue("@id", textBox4.Text);
            da = new SqlDataAdapter(a);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        void yatistest()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            SqlCommand a = new SqlCommand("select tedavi.tedavi_test_id,testler.test_adi,testler.test_fiyat from tedavi  inner join testler on tedavi.tedavi_test_id=testler.test_id  where tedavi.tedavi_hasta_id=@id and tedavi.kontrol is null", baglanti);
            a.Parameters.AddWithValue("@id", textBox4.Text);
            da = new SqlDataAdapter(a);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            baglanti.Close();
        }
        void borc()
        {
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                    listBox1.Items.Add(row.Cells[2].Value.ToString());

            }
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow)
                    listBox1.Items.Add(row.Cells[2].Value.ToString());

            }
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (!row.IsNewRow)
                    listBox1.Items.Add(row.Cells[2].Value.ToString());

            }
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                if (!row.IsNewRow)
                    listBox1.Items.Add(row.Cells[2].Value.ToString());

            }

            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                if (!row.IsNewRow)
                    listBox1.Items.Add(row.Cells[2].Value.ToString());

            }

            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            SqlCommand yatis = new SqlCommand("select yatis_gun from tedavi where tedavi_hasta_id=@id", baglanti);
            yatis.Parameters.AddWithValue("@id", textBox4.Text);
            SqlDataReader oku = yatis.ExecuteReader();
            while(oku.Read())
            {
                label23.Text = oku[0].ToString();
            }
            baglanti.Close();

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand hasta = new SqlCommand("select * from hastalar where hasta_id=@id", baglanti);
                hasta.Parameters.AddWithValue("@id", SqlDbType.Int).Value = textBox4.Text;
                SqlDataReader oku = hasta.ExecuteReader();
                if (oku.Read())
                {
                    maskedTextBox1.Text = oku[1].ToString();
                    textBox1.Text = oku[2].ToString();
                    textBox2.Text = oku[3].ToString();
                    textBox6.Text = oku[4].ToString();
                    textBox7.Text = oku[5].ToString();
                    textBox8.Text = oku[6].ToString();
                    maskedTextBox3.Text = oku[7].ToString();


                    ameliyat();
                    serum();
                    ilac();
                    lab();
                    yatistest();
                    borc();
                }
                baglanti.Close();
                button2.Enabled = true;

            }
            else
                MessageBox.Show("ID Giriniz");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int toplam2 = 0;
                int toplam = 0;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    toplam += Convert.ToInt32(listBox1.Items[i]);
                }
                if (label23.Text == "")
                {
                    toplam2 = toplam + muayene;
                    textBox3.Text = toplam2.ToString();

                }
                else
                {
                    int toplam3 = Convert.ToInt32(label23.Text);
                    toplam2 = toplam + muayene + (150 * toplam3);
                    textBox3.Text = toplam2.ToString();
                }

                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand borc = new SqlCommand("update vezne set borc=@b where hasta_id=@id ", baglanti);
                borc.Parameters.AddWithValue("@id", textBox4.Text);
                borc.Parameters.AddWithValue("@b", Convert.ToInt32(textBox3.Text));
                borc.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand güncelle = new SqlCommand("update tedavi set kontrol=@kont where tedavi_hasta_id=@id ", baglanti);
                güncelle.Parameters.AddWithValue("@id", textBox4.Text);
                güncelle.Parameters.AddWithValue("@kont", Convert.ToInt32(label17.Text));
                güncelle.ExecuteNonQuery();
                baglanti.Close();

                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand güncelle2 = new SqlCommand("update lab set kontrol=@kont from lab inner join tahliller on tahliller.tahlil_id = lab.lab_tahlil_id where tahliller.tahlil_hasta_id=@id ", baglanti);
                güncelle2.Parameters.AddWithValue("@id", textBox4.Text);
                güncelle2.Parameters.AddWithValue("@kont", label18.Text);
                güncelle2.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                SqlCommand sil = new SqlCommand("delete from vezne where hasta_id=@id", baglanti);
                sil.Parameters.AddWithValue("@id", textBox4.Text);
                sil.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Hastanın Borcu Ödenmiştir");
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }
    }
}
