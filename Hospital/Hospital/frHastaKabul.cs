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
    public partial class frHastaKabul : Form
    {
        public frHastaKabul()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");
        public static SqlDataReader dr;
        public int a;

        void temizle()
        {
            // && maskedTextBox3.Text != ""&& comboBox1.Text!="" && comboBox2.Text != "" && comboBox4.Text !=
            maskedTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
            richTextBox1.Clear();
            richTextBox2.Clear();
            textBox5.Clear();
            comboBox7.Text = "";
            comboBox8.Text = "";
            comboBox6.Text = "";
            textBox6.Clear();
            textBox7.Clear();
            comboBox3.Text = "";
            comboBox5.Text = "";
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;


        }
        void klinkgetir()
        {
            SqlCommand c = new SqlCommand("select * from klinikler where klinik_id < 14 or klinik_id > 18", baglanti);
           Query.combo(c, "klinik_id", "klinik_adi", comboBox3);
        }
        void doktorgetir()
        {
            SqlCommand acil = new SqlCommand("select * from doktorlar", baglanti);
            Query.combo(acil, "doktor_id", "doktor_adi_soyadi", comboBox6);
        }
        void acilKlinik()
        {
            SqlCommand acilklinik = new SqlCommand("select * from klinikler where klinik_id > '15' ", baglanti);
            Query.combo(acilklinik, "klinik_id", "klinik_adi", comboBox8);
        }
        void id()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            SqlCommand id = new SqlCommand("select hasta_id from hastalar", baglanti);
            SqlDataReader oku = id.ExecuteReader();
            while (oku.Read())
            {
                textBox6.Text = oku[0].ToString();
                textBox7.Text = oku[0].ToString();

            }
            baglanti.Close();
        }
        void idsorgulama()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            SqlCommand id = new SqlCommand("select hasta_id from hastalar where Hasta_tc=@tc ", baglanti);
            id.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            SqlDataReader oku = id.ExecuteReader();
            while (oku.Read())
            {
                textBox6.Text = oku[0].ToString();
                textBox7.Text = oku[0].ToString();

            }
            baglanti.Close();
        }


        private void frHastaKabul_Load(object sender, EventArgs e)
        {
            try
            {
                klinkgetir();
                // doktorgetir();
                acilKlinik();
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            if (maskedTextBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox4.Text != "")
            {


                try
                {

                    baglanti.Open();
                    SqlCommand komutKaydet = new SqlCommand("insert into hastalar(Hasta_tc,Hasta_adi,Hasta_soyadi,Hasta_cinsiyeti,Hasta_kan,Hasta_dogumYeri,Hasta_dogumTarihi,Hasta_babaAdi,Hasta_anneAdi,Hasta_cepTel,Hasta_ePosta,Hasta_Adres) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", baglanti);
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
                    komutKaydet.Parameters.AddWithValue("@p12", richTextBox2.Text);
                    komutKaydet.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt Başarıyla Eklendi.");


                    id();


                }

                catch
                {
                    MessageBox.Show("Hata! Lütfen Daha Donra Tekrar Deneyin.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Hasta Girişi Yapınız!!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            frGiris yeni = new frGiris();
            yeni.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();


            try
            {
                baglanti.Open();

                SqlCommand komutKaydetBekleyen = new SqlCommand("insert into bekleyenHasta(bekleyen_hasta_id,bekleyen_klinikid,bekleyen_doktorid)values(@p1,@p2,@p3)", baglanti);

                komutKaydetBekleyen.Parameters.AddWithValue("@p1", SqlDbType.VarChar).Value = Convert.ToInt32(textBox7.Text);
                komutKaydetBekleyen.Parameters.AddWithValue("@p2", SqlDbType.Int).Value = Convert.ToInt32(comboBox3.SelectedValue);
                komutKaydetBekleyen.Parameters.AddWithValue("@p3", SqlDbType.Int).Value = Convert.ToInt32(comboBox5.SelectedValue);
                komutKaydetBekleyen.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("Hasta Başarıyla Muayene Sırasına Alındı.");
                temizle();
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen Daha Sonra Tekrar Deneyiniz.");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.SelectedIndex != 0)
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand komutdoktor = new SqlCommand("SELECT klinikler.klinik_id,doktorlar.doktor_id,doktorlar.doktor_adi_soyadi FROM doktorlar INNER JOIN klinikler ON doktorlar.doktor_klinik_id=klinikler.klinik_id WHERE doktorlar.doktor_klinik_id=@kid", baglanti);
                    komutdoktor.Parameters.AddWithValue("@kid", comboBox3.SelectedValue.ToString());
                    Query.combo(komutdoktor, "doktor_id", "doktor_adi_soyadi", comboBox5);

                    baglanti.Close();


                }
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox4.Text != "")
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand acil = new SqlCommand("insert into acil(acil_hasta_id,acil_doktor_id,aciklama,derece,acil_klinik_id)values(@p1,@p2,@p3,@p4,@p5)", baglanti);
                    acil.Parameters.AddWithValue("@p1", SqlDbType.Int).Value = Convert.ToInt32(textBox6.Text);
                    acil.Parameters.AddWithValue("@p2", SqlDbType.Int).Value = Convert.ToInt32(comboBox6.SelectedValue);
                    acil.Parameters.AddWithValue("@p3", SqlDbType.NVarChar).Value = richTextBox1.Text;
                    acil.Parameters.AddWithValue("@p4", SqlDbType.NVarChar).Value = comboBox7.Text;
                    acil.Parameters.AddWithValue("@p5", SqlDbType.Int).Value = Convert.ToInt32(comboBox8.SelectedValue);
                    acil.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Acil Hasta Kaydı Başarıyla Yapıldı");
                    temizle();

                }
                catch
                {
                    MessageBox.Show("Hata!! Lütfen Daha Sonra Tekrar Deneyin ");
                }
            }
            else
                MessageBox.Show("Lütfen Hasta Girişi Yapınız");
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox8.SelectedIndex != 0)
                {

                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();

                    baglanti.Open();
                    SqlCommand acildoktor = new SqlCommand("SELECT klinikler.klinik_id,doktorlar.doktor_id,doktorlar.doktor_adi_soyadi FROM doktorlar INNER JOIN klinikler ON doktorlar.doktor_klinik_id=klinikler.klinik_id WHERE doktorlar.doktor_klinik_id=@kid and doktor_klinik_id > 15 ", baglanti);
                    acildoktor.Parameters.AddWithValue("@kid", comboBox8.SelectedValue.ToString());
                    Query.combo(acildoktor, "doktor_id", "doktor_adi_soyadi", comboBox6);

                    baglanti.Close();
                }
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox4.Text != "" || a == 5)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
            else
                MessageBox.Show("Önce Hasta Girişi Yapınız");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox4.Text != "" || a == 5)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }
            else
                MessageBox.Show("Önce Hasta Girişi Yapınız");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox1.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();

                    baglanti.Open();
                    SqlCommand sorgulama = new SqlCommand("select * from hastalar where Hasta_tc=@tc", baglanti);
                    sorgulama.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                    SqlDataReader oku = sorgulama.ExecuteReader();
                    if (oku.Read())
                    {

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
                        richTextBox2.Text = oku[12].ToString();
                        MessageBox.Show("Bu kritere uyan bir hasta bulundu.");
                        idsorgulama();
                        a = 5;

                    }
                    else
                        MessageBox.Show("Bu kriterde bir hasta bulunamadı. Lütfen kayıt yapınız.");
                    baglanti.Close();
                }
                else
                    MessageBox.Show("Önce Hasta TC'si giriniz.");

            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }
    }
}
