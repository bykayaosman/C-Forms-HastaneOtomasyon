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
    public partial class frRandevuAl : Form
    {
        public frRandevuAl()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");


        void klinik()
        {
            SqlCommand c = new SqlCommand("select * from klinikler where klinik_id < 14 or klinik_id > 18", baglanti);
            Query.combo(c, "klinik_id", "klinik_adi", comboBox1);
        }

        void randevu()
        {
            try
            {               
                baglanti.Open();
                if (comboBox1.SelectedIndex != 0 && comboBox2.SelectedIndex != 0)
                {
                    foreach (Control item in panel2.Controls)
                        if (item is Button) item.BackColor = Color.Green; //Butonların Renginİ yeşil yaptım.
                    randevualabilir = true;
                    panel2.Enabled = true;
                    SqlCommand randevu = new SqlCommand("Select *from randevular where randevu_klinik_id=@kid and randevu_doktor_id=@did and randevu_tarih=@tarih ", baglanti);
                    randevu.Parameters.AddWithValue("@kid", comboBox1.SelectedValue.ToString());
                    randevu.Parameters.AddWithValue("@did", comboBox2.SelectedValue.ToString());
                    randevu.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToShortDateString());
                    Query.veri_getir(randevu);
                    while (Query.dr.Read())
                    {
                        foreach (Control item in panel2.Controls)
                        {
                            if (item is Button && item.Text == Query.dr["randevu_saat"].ToString())
                            {
                                item.BackColor = Color.Red;

                                if (textBox1.Text == Query.dr["Hasta_id"].ToString())
                                {
                                    MessageBox.Show("Bu tarihte bir randevunuz var lütfen başka tarih seçiniz!");
                                    randevualabilir = false;
                                }
                            }
                        }
                    }
                }
                else
                    panel2.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Bu tarihte hazırda bekleyen bir randevunuz var!!");
                this.Close();
            }
        }
        void tc()
        {
            label6.Text = frGiris.kid;
          
            baglanti.Open();
            SqlCommand id = new SqlCommand("select * from hastalar where Hasta_ePosta=@eposta", baglanti);
            id.Parameters.AddWithValue("@eposta", SqlDbType.NVarChar).Value = label6.Text;
            SqlDataReader oku = id.ExecuteReader();
            while (oku.Read())
            {
                textBox1.Text = oku[0].ToString();
            }
            baglanti.Close();
        }
        bool randevualabilir = true;
        string saat = "";
        Button btn;




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {                
                baglanti.Open();
                if (comboBox1.SelectedIndex != 0 && comboBox2.SelectedIndex != 0 && btn.BackColor != Color.Red && randevualabilir == true)
                {
                    SqlCommand randevuekle = new SqlCommand("insert into randevular(randevu_hasta_id,randevu_tarih,randevu_saat,randevu_klinik_id,randevu_doktor_id)values(@id,@tarih,@saat,@kid,@did)", baglanti);
                    randevuekle.Parameters.AddWithValue("@id", textBox1.Text.ToString());
                    randevuekle.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToShortDateString());
                    randevuekle.Parameters.AddWithValue("@saat", saat);
                    randevuekle.Parameters.AddWithValue("@kid", comboBox1.SelectedValue.ToString());
                    randevuekle.Parameters.AddWithValue("@did", comboBox2.SelectedValue.ToString());
                    randevuekle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show(textBox1.Text + "TC'li kişiye" + dateTimePicker1.Value.ToShortDateString() + " " + saat + "'ine randevu alınmıştır");
                    comboBox1.SelectedIndex = comboBox2.SelectedIndex = 0;
                    randevu();
                }
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen Daha Sonra Tekar Deneyin.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btn = sender as Button;
            saat = btn.Text;    
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                randevu();
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex != 0)
                {
                    SqlCommand doktor = new SqlCommand("SELECT klinikler.klinik_id,doktorlar.doktor_id,doktorlar.doktor_adi_soyadi FROM doktorlar INNER JOIN klinikler ON doktorlar.doktor_klinik_id=klinikler.klinik_id WHERE doktorlar.doktor_klinik_id=@kid", baglanti);
                    doktor.Parameters.AddWithValue("@kid", comboBox1.SelectedValue.ToString());
                    Query.combo(doktor, "doktor_id", "doktor_adi_soyadi", comboBox2);
                }
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void frRandevuAl_Load(object sender, EventArgs e)
        {
            try
            {
                klinik();
                //textBox1.Text = Hasta_bilgiler.tc;
                tc();
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }
    }
}
