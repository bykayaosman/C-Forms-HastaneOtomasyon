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
    public partial class frLabSonuc : Form
    {
        public frLabSonuc()
        {
            InitializeComponent();
        }


        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");



        private void frLabSonuc_Load(object sender, EventArgs e)
        {
            textBox1.Text = frLaboratuvar.tahlilid;
            frLaboratuvar.tahlilid = textBox1.Text;
            try
            {
                baglanti.Open();
                SqlCommand testler = new SqlCommand("select lab.lab_test_id,lab.lab_tahlil_id,testler.test_id,testler.test_adi from lab INNER JOIN tahliller on tahliller.tahlil_id=lab.lab_tahlil_id INNER JOIN testler on testler.test_id = lab.lab_test_id where lab_tahlil_id=@id ", baglanti);
                testler.Parameters.AddWithValue("@id", textBox1.Text.ToString());
                da = new SqlDataAdapter(testler);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! lütfen daha sonra tekar deneyiniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                baglanti.Open();
                SqlCommand test = new SqlCommand("select * from testler where test_id=@id", baglanti);
                test.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[2].Value.ToString());
                SqlDataReader oku = test.ExecuteReader();
                while (oku.Read())
                {
                    textBox3.Text = oku[1].ToString();
                    textBox4.Text = oku[0].ToString();

                }
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! lütfen daha sonra tekar deneyiniz.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && dateTimePicker1.Value != null)
            {
                try
                {
                    
                    baglanti.Open();
                    SqlCommand lab = new SqlCommand("update lab set lab_tahlil_id=@id,lab_test_id=@testid,lab_tarih=@tarih,lab_aciklama=@sonuc,lab.kontrol=@kont where lab_test_id=@tid and lab.kontrol=2", baglanti);
                    lab.Parameters.AddWithValue("@id", textBox1.Text);
                    lab.Parameters.AddWithValue("@testid", textBox4.Text);
                    lab.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToShortDateString());
                    lab.Parameters.AddWithValue("@sonuc", textBox2.Text);
                    lab.Parameters.AddWithValue("@tid", textBox4.Text);
                    lab.Parameters.AddWithValue("@kont", label7.Text);
                    lab.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Sonuçlar doktora gönderilmiştir.");
                }
                catch
                {
                    MessageBox.Show("Hata!! lütfen daha sonra tekar deneyiniz.");
                }
            }
            else
                MessageBox.Show("Alanlar Boş Bıraklılamaz!");

        }
    }
}
