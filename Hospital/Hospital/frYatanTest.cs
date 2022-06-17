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
    public partial class frYatanTest : Form
    {
        public frYatanTest()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");

        void doktorBilgiler()
        {
            maskedTextBox2.Text = frDoktor.dkidd;
            frDoktor.dkidd = maskedTextBox2.Text;
            try
            {


                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand doktor = new SqlCommand("select * from doktorlar where doktor_id=@did ", baglanti);
                doktor.Parameters.AddWithValue("@did", maskedTextBox2.Text);
                SqlDataReader oku = doktor.ExecuteReader();
                while (oku.Read())
                {
                    maskedTextBox2.Text = oku[0].ToString();
                    maskedTextBox5.Text = oku[4].ToString();
                }
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyniz.");
            }
        }
        void hastaBilgiler()
        {


            try
            {
                if (maskedTextBox4.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand hasta = new SqlCommand("select * from hastalar where Hasta_id=@hid", baglanti);
                    hasta.Parameters.AddWithValue("@hid", maskedTextBox4.Text);
                    SqlDataReader oku = hasta.ExecuteReader();
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
                    }
                    baglanti.Close();
                }


            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyniz.");
            }
        }
        void testler()
        {
            try
            {


                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand testler = new SqlCommand("select * from testler ", baglanti);
                Query.combo(testler, "test_id", "test_adi", comboBox1);
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyniz.");
            }
        }
        void o()
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand tahlil = new SqlCommand("insert into tahliller(tahlil_doktor_id,tahlil_hasta_id,tahlil_klinik_id)values(@did,@hid,@kid)", baglanti);

                if (maskedTextBox4.Text != "")
                {
                    tahlil.Parameters.AddWithValue("@did", maskedTextBox2.Text);
                    tahlil.Parameters.AddWithValue("@hid", maskedTextBox4.Text);
                    tahlil.Parameters.AddWithValue("@kid", maskedTextBox5.Text);

                }


                tahlil.ExecuteNonQuery();
                baglanti.Close();



                baglanti.Open();
                SqlCommand tahlil2 = new SqlCommand("select *from tahliller", baglanti);
                SqlDataReader oku = tahlil2.ExecuteReader();
                while (oku.Read())
                {
                    maskedTextBox7.Text = oku[0].ToString();
                }
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyniz.");
            }
        }

        private void frYatanTest_Load(object sender, EventArgs e)
        {
            try
            {
                maskedTextBox4.Text = frYatanHasta.id.ToString();

                doktorBilgiler();
                hastaBilgiler();
                testler();
                o();
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand lab = new SqlCommand("insert into lab (lab_tahlil_id,lab_test_id)values(@tid,@tidd)", baglanti);
                lab.Parameters.AddWithValue("@tid", maskedTextBox7.Text);
                lab.Parameters.AddWithValue("@tidd", comboBox1.SelectedValue);
                lab.ExecuteNonQuery();
                baglanti.Close();
                listBox1.Items.Add(comboBox1.Text);
                baglanti.Open();
                SqlCommand tedavi = new SqlCommand("insert into tedavi(tedavi_test_id,tedavi_hasta_id)values(@test,@id) ", baglanti);
                tedavi.Parameters.AddWithValue("@test", comboBox1.SelectedValue);
                tedavi.Parameters.AddWithValue("@id", maskedTextBox4.Text);
                tedavi.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyniz.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            comboBox1.SelectedIndex = 0;
            this.Close();
        }
    }
}
