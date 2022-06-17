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
    public partial class frYatanHasta : Form
    {
        public frYatanHasta()
        {
            InitializeComponent();
        }

        public static int id;
        public static int yatan;
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");

        void klinkgetir()
        {
            SqlCommand c = new SqlCommand("select * from klinikler where klinik_id < 14 or klinik_id > 18", baglanti);
            Query.combo(c, "klinik_id", "klinik_adi", comboBox5);

        }
        void a()
        {
            SqlCommand c = new SqlCommand("select * from ameliyat", baglanti);
            Query.combo(c, "ameliyat_id", "ameliyat_adi", comboBox1);

        }
        void b()
        {
            SqlCommand c = new SqlCommand("select * from serum", baglanti);
            Query.combo(c, "serum_id", "serum_adi", comboBox2);

        }
        void c()
        {
            SqlCommand c = new SqlCommand("select * from ilaclar", baglanti);
            Query.combo(c, "ilac_id", "ilac_adi", comboBox3);

        }
        void yatak()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            SqlCommand a = new SqlCommand("select * from klinikler where klinik_id=@id", baglanti);
            a.Parameters.AddWithValue("@id", maskedTextBox4.Text);
            SqlDataReader oku = a.ExecuteReader();
            while (oku.Read())
            {
                label20.Text = oku[2].ToString();
                label21.Text = oku[3].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("update klinikler set yatan_hasta=@h where klinik_id=@id", baglanti);
            ekle.Parameters.AddWithValue("@id", maskedTextBox4.Text);
            ekle.Parameters.AddWithValue("@h", Convert.ToInt32(label21.Text) - 1);
            ekle.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand yatak = new SqlCommand("update klinikler set yatak_kapasite=@kapasite where klinik_id=@id ", baglanti);
            yatak.Parameters.AddWithValue("@id", maskedTextBox4.Text);
            yatak.Parameters.AddWithValue("@kapasite", Convert.ToInt32(label20.Text) + 1);
            yatak.ExecuteNonQuery();
            baglanti.Close();

        }

        private void frYatanHasta_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand görüntüle = new SqlCommand("select hastalar.Hasta_id,hastalar.Hasta_tc,hastalar.Hasta_adi,hastalar.Hasta_soyadi,hastalar.Hasta_cinsiyeti,hastalar.Hasta_kan,hastalar.Hasta_dogumYeri,hastalar.Hasta_dogumTarihi,yatan.yatan_doktor_id,yatan.yatan_klinik_id from hastalar INNER JOIN yatan on hastalar.Hasta_id=yatan.yatan_hasta_id where yatan.yatan_doktor_id=@id ", baglanti);
                görüntüle.Parameters.AddWithValue("@id", frDoktor.dkidd);

                da = new SqlDataAdapter(görüntüle);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                klinkgetir();
                a();
                b();
                c();
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int deger = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                double deger1 = Convert.ToDouble(dataGridView1.CurrentRow.Cells[1].Value);
                string deger2 = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string deger3 = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string deger4 = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string deger5 = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                string deger6 = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                string deger7 = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                string deger8 = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                maskedTextBox2.Text = deger.ToString();
                maskedTextBox1.Text = deger1.ToString();
                textBox1.Text = deger2.ToString();
                textBox2.Text = deger3.ToString();
                textBox6.Text = deger4.ToString();
                textBox7.Text = deger5.ToString();
                textBox8.Text = deger6.ToString();
                maskedTextBox3.Text = deger7.ToString();
                maskedTextBox4.Text = deger8.ToString();
                id = Convert.ToInt32(maskedTextBox2.Text);
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox5.SelectedIndex != 0)
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand komutdoktor = new SqlCommand("SELECT klinikler.klinik_id,doktorlar.doktor_id,doktorlar.doktor_adi_soyadi FROM doktorlar INNER JOIN klinikler ON doktorlar.doktor_klinik_id=klinikler.klinik_id WHERE doktorlar.doktor_klinik_id=@kid", baglanti);
                    komutdoktor.Parameters.AddWithValue("@kid", comboBox5.SelectedValue.ToString());
                    Query.combo(komutdoktor, "doktor_id", "doktor_adi_soyadi", comboBox4);

                    baglanti.Close();
                }
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


                if (comboBox5.SelectedIndex != 0 && maskedTextBox2.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand nakil = new SqlCommand("update yatan set yatan_hasta_id=@id,yatan_doktor_id=@did,yatan_klinik_id=@kid ", baglanti);
                    nakil.Parameters.AddWithValue("@id", maskedTextBox2.Text);
                    nakil.Parameters.AddWithValue("did", comboBox4.SelectedValue);
                    nakil.Parameters.AddWithValue("@kid", comboBox5.SelectedValue);
                    nakil.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Hasta Başarıyla Nakledilmiştir");
                    this.Close();
                }
                else
                    MessageBox.Show("Eksik Alanları Doldurunuz");
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text != "" && comboBox1.SelectedIndex != 0)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand lab = new SqlCommand("insert into tedavi(ameliyat_id,tedavi_hasta_id)values(@ameliyat,@id)", baglanti);
                    lab.Parameters.AddWithValue("@id", maskedTextBox2.Text);
                    lab.Parameters.AddWithValue("@ameliyat", comboBox1.SelectedValue);
                    lab.ExecuteNonQuery();
                    baglanti.Close();
                    listBox1.Items.Add(comboBox1.Text);
                }
                catch
                {
                    MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyniz.");
                }
            }
            else
            {
                MessageBox.Show("Gerekli bilgileri giriniz.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            listBox1.Items.Clear();
            comboBox2.Text = "";
            listBox2.Items.Clear();
            comboBox3.Text = "";
            listBox3.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text != "" && comboBox2.SelectedIndex != 0)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand lab = new SqlCommand("insert into tedavi(serum_id,tedavi_hasta_id)values(@serum,@id)", baglanti);
                    lab.Parameters.AddWithValue("@id", maskedTextBox2.Text);
                    lab.Parameters.AddWithValue("@serum", comboBox2.SelectedValue);
                    lab.ExecuteNonQuery();
                    baglanti.Close();
                    listBox2.Items.Add(comboBox2.Text);
                }
                catch
                {
                    MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyniz.");
                }
            }
            else
            {
                MessageBox.Show("Gerekli bilgileri giriniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text != "" && comboBox3.SelectedIndex != 0)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand lab = new SqlCommand("insert into tedavi(tedavi_ilac_id,tedavi_hasta_id)values(@ilac,@id)", baglanti);
                    lab.Parameters.AddWithValue("@id", maskedTextBox2.Text);
                    lab.Parameters.AddWithValue("@ilac", comboBox3.SelectedValue);
                    lab.ExecuteNonQuery();
                    baglanti.Close();
                    listBox3.Items.Add(comboBox3.Text);
                }
                catch
                {
                    MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyniz.");
                }
            }
            else
            {
                MessageBox.Show("Gerekli bilgileri giriniz.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox2.Text != "")
                {
                    if (textBox3.Text != "")
                    {
                        yatak();
                        baglanti.Open();
                        SqlCommand taburcu2 = new SqlCommand("insert into tedavi(tedavi_hasta_id,yatis_gun)values(@id,@yatis)", baglanti);
                        taburcu2.Parameters.AddWithValue("@id", maskedTextBox2.Text);
                        taburcu2.Parameters.AddWithValue("@yatis", textBox3.Text);
                        taburcu2.ExecuteNonQuery();
                        baglanti.Close();
                        if (baglanti.State == ConnectionState.Open)
                            baglanti.Close();
                        baglanti.Open();
                        SqlCommand vezne = new SqlCommand("insert into vezne(hasta_id)values(@id) ", baglanti);
                        vezne.Parameters.AddWithValue("@id", maskedTextBox2.Text);
                        vezne.ExecuteNonQuery();
                        baglanti.Close();
                        baglanti.Open();
                        SqlCommand guncelle = new SqlCommand("update hastalar set kontrol = @kont where Hasta_id=@id", baglanti);
                        guncelle.Parameters.AddWithValue("@id", maskedTextBox2.Text);
                        guncelle.Parameters.AddWithValue("@kont", label18.Text);
                        guncelle.ExecuteNonQuery();
                        baglanti.Close();
                        if (baglanti.State == ConnectionState.Open)
                            baglanti.Close();
                        baglanti.Open();
                        SqlCommand taburcu = new SqlCommand("delete from yatan where yatan_hasta_id=@id", baglanti);
                        taburcu.Parameters.AddWithValue("@id", maskedTextBox2.Text);
                        taburcu.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Hasta Taburcu Edilmiştir. Hastayı Vezneye Yönlendiriniz");
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Hastanın kaç gün yattığını belirtiniz.");
                    }

                }
                else
                    MessageBox.Show("Lütfen hasta seçiniz");
            }
            catch
            {
                MessageBox.Show("Hata lüfen daha sonra deneyiniz");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text != "")
            {
                frYatanTest yeni = new frYatanTest();
                yeni.Show();
            }
            else
                MessageBox.Show("Hasta Seçiniz");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox2.Text != "")
                {
                    label17.Text = "1";
                    yatan = Convert.ToInt32(label17.Text);
                    frDoktorTahlilSonucları yeni = new frDoktorTahlilSonucları();
                    yeni.Show();
                }
                else
                    MessageBox.Show("Hasta Seçiniz");
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text != "")
            {
                frGecmisTedaviler yeni = new frGecmisTedaviler();
                yeni.Show();
            }
            else
                MessageBox.Show("Hasta Seçiniz");
        }
    }
}
