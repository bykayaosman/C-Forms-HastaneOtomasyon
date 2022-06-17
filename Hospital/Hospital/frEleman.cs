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
    public partial class frEleman : Form
    {
        public frEleman()
        {
            InitializeComponent();
        }

        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");

        void temizle()
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            maskedTextBox5.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            textBox8.Text = "";
        }


        private void frEleman_Load(object sender, EventArgs e)
        {
            if (kontrol.Text == "1")
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                kontrol.Text = "1";
                temizle();
                panel1.Enabled = true;
                panel2.Enabled = false;
                panel3.Enabled = false;
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand listele1 = new SqlCommand("select *from labeleman ", baglanti);
                da = new SqlDataAdapter(listele1);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz;");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                kontrol.Text = "2";
                temizle();
                panel1.Enabled = false;
                panel2.Enabled = true;
                panel3.Enabled = false;
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand listele2 = new SqlCommand("select *from sekreter ", baglanti);
                da = new SqlDataAdapter(listele2);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz;");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                kontrol.Text = "3";
                temizle();
                panel1.Enabled = false;
                panel2.Enabled = false;
                panel3.Enabled = true;
                
                baglanti.Open();
                SqlCommand listele3 = new SqlCommand("select * from veznedar ", baglanti);
                da = new SqlDataAdapter(listele3);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz;");
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
                string deger8 = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox3.Text = deger.ToString();
                maskedTextBox1.Text = deger1.ToString();
                textBox1.Text = deger2.ToString();
                textBox6.Text = deger3.ToString();
                textBox8.Text = deger4.ToString();
                maskedTextBox2.Text = deger5.ToString();
                textBox5.Text = deger6.ToString();
                maskedTextBox4.Text = deger7.ToString();
                maskedTextBox3.Text = deger8.ToString();
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz;");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox6.Text != "")
            {
                try
                {
                    if (kontrol.Text == "1")
                    {
                        
                        baglanti.Open();
                        SqlCommand ara = new SqlCommand("select * from labeleman where lab_eleman_tc like '%" + maskedTextBox6.Text.ToString() + "%'", baglanti);
                        da = new SqlDataAdapter(ara);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        baglanti.Close();
                    }
                    else if (kontrol.Text == "2")
                    {
                       
                        baglanti.Open();
                        SqlCommand ara = new SqlCommand("select * from sekreter where sekreter_tc like '%" + maskedTextBox6.Text.ToString() + "%'", baglanti);
                        da = new SqlDataAdapter(ara);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;
                        baglanti.Close();
                    }
                    else if (kontrol.Text == "3")
                    {
                        
                        baglanti.Open();
                        SqlCommand ara = new SqlCommand("select * from veznedar where veznedar_tc like '%" + maskedTextBox6.Text.ToString() + "%'", baglanti);
                        da = new SqlDataAdapter(ara);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView3.DataSource = dt;
                        baglanti.Close();
                    }
                    else
                        MessageBox.Show("Öncelikle bir bölüm seçiniz!");


                }
                catch
                {
                    MessageBox.Show("Hata!! lütfen daha sonra deneyiniz.");
                }
            }
            else
                MessageBox.Show("Lütfen bir arama parametresi giriniz.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox4.Text != "" && maskedTextBox5.Text != "" && textBox1.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox8.Text != "")
                {
                    if (kontrol.Text == "1")
                    {
                        
                        baglanti.Open();
                        SqlCommand a = new SqlCommand("update labeleman set lab_eleman_tc=@tc,lab_eleman_adi=@ad,lab_eleman_cinsiyeti=@cinsiyet,lab_eleman_dogum=@dogum,lab_eleman_cep=@cep,lab_eleman_eposta=@eposta,lab_eleman_parola=@parola,lab_kullanici_adi=@kad where lab_eleman_id=@id", baglanti);
                        a.Parameters.AddWithValue("@id", textBox3.Text);
                        a.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                        a.Parameters.AddWithValue("@ad", textBox1.Text);
                        a.Parameters.AddWithValue("@cinsiyet", textBox6.Text);
                        a.Parameters.AddWithValue("@dogum", textBox8.Text);
                        a.Parameters.AddWithValue("@cep", maskedTextBox2.Text);
                        a.Parameters.AddWithValue("@eposta", textBox5.Text);
                        a.Parameters.AddWithValue("@parola", maskedTextBox5.Text);
                        a.Parameters.AddWithValue("@kad", maskedTextBox3.Text);
                        a.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Lab Eleman bilgileri başarıyla güncellendi");
                    }
                    else if (kontrol.Text == "2")
                    {
                        
                        baglanti.Open(); SqlCommand a = new SqlCommand("update sekreter set sekreter_tc=@tc,sekreter_adi=@ad,sekreter_cinsiyeti=@cinsiyet,sekreter_dogum=@dogum,sekreter_cep=@cep,sekreter_eposta=@eposta,sekreter_parola=@parola,sekreter_kullanici_adi=@kad where sekreter_id=@id", baglanti);
                        a.Parameters.AddWithValue("@id", textBox3.Text);
                        a.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                        a.Parameters.AddWithValue("@ad", textBox1.Text);
                        a.Parameters.AddWithValue("@cinsiyet", textBox6.Text);
                        a.Parameters.AddWithValue("@dogum", textBox8.Text);
                        a.Parameters.AddWithValue("@cep", maskedTextBox2.Text);
                        a.Parameters.AddWithValue("@eposta", textBox5.Text);
                        a.Parameters.AddWithValue("@parola", maskedTextBox5.Text);
                        a.Parameters.AddWithValue("@kad", maskedTextBox3.Text);
                        a.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Sekreter bilgileri başarıyla güncellendi");

                    }
                    else if (kontrol.Text == "3")
                    {
                        
                        baglanti.Open(); SqlCommand a = new SqlCommand("update veznedar set veznedar_tc=@tc,veznedar_adi=@ad,veznedar_cinsiyeti=@cinsiyet,veznedar_dogum=@dogum,veznedar_cep=@cep,veznedar_eposta=@eposta,veznedar_parola=@parola,veznedar_kullanici_adi=@kad where veznedar_id=@id", baglanti);
                        a.Parameters.AddWithValue("@id", textBox3.Text);
                        a.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                        a.Parameters.AddWithValue("@ad", textBox1.Text);
                        a.Parameters.AddWithValue("@cinsiyet", textBox6.Text);
                        a.Parameters.AddWithValue("@dogum", textBox8.Text);
                        a.Parameters.AddWithValue("@cep", maskedTextBox2.Text);
                        a.Parameters.AddWithValue("@eposta", textBox5.Text);
                        a.Parameters.AddWithValue("@parola", maskedTextBox5.Text);
                        a.Parameters.AddWithValue("@kad", maskedTextBox3.Text);
                        a.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Veznedar bilgileri başarıyla güncellendi");
                    }

                }
                else
                    MessageBox.Show("Eleman Seçiniz");
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (maskedTextBox3.Text != "")
            {
                try
                {
                    if (kontrol.Text == "1")
                    {
                        
                        baglanti.Open();
                        SqlCommand sil = new SqlCommand("delete labeleman where lab_kullanici_adi=@kadi", baglanti);
                        sil.Parameters.AddWithValue("@kadi", maskedTextBox3.Text);
                        sil.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Lab elemanı başarıyla silindi");
                    }
                    if (kontrol.Text == "2")
                    {
                        
                        baglanti.Open();
                        SqlCommand sil = new SqlCommand("delete sekreter where sekreter_kullanici_adi=@kadi", baglanti);
                        sil.Parameters.AddWithValue("@kadi", maskedTextBox3.Text);
                        sil.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Sekreter başarıyla silindi");
                    }
                    if (kontrol.Text == "3")
                    {
                        
                        baglanti.Open();
                        SqlCommand sil = new SqlCommand("delete veznedar where veznedar_kullanici_adi=@kadi", baglanti);
                        sil.Parameters.AddWithValue("@kadi", maskedTextBox3.Text);
                        sil.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Veznedar başarıyla silindi");
                    }
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
            try
            {
                if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox5.Text != "" && textBox1.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox8.Text != "")
                {
                    if (kontrol.Text == "1")
                    {
                        
                        baglanti.Open();
                        SqlCommand a = new SqlCommand("insert into labeleman(lab_eleman_tc,lab_eleman_adi,lab_eleman_cinsiyeti,,lab_eleman_dogum,lab_eleman_cep,lab_eleman_eposta,lab_eleman_parola,lab_kullanici_adi)values(@tc,@ad,@cinsiyet,@dogum,@cep,@eposta,@parola,@kad)", baglanti);
                        a.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                        a.Parameters.AddWithValue("@ad", textBox1.Text);
                        a.Parameters.AddWithValue("@cinsiyet", textBox6.Text);
                        a.Parameters.AddWithValue("@dogum", textBox8.Text);
                        a.Parameters.AddWithValue("@cep", maskedTextBox2.Text);
                        a.Parameters.AddWithValue("@eposta", textBox5.Text);
                        a.Parameters.AddWithValue("@parola", maskedTextBox5.Text);
                        a.Parameters.AddWithValue("@kad", maskedTextBox3.Text);
                        a.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Lab Eleman başarıyla eklendi");
                    }
                    else if (kontrol.Text == "2")
                    {
                        
                        baglanti.Open();
                        SqlCommand a = new SqlCommand("insert into sekreter(sekreter_tc,sekreter_adi,sekreter_cinsiyeti,sekreter_dogum,sekreter_cep,sekreter_eposta,sekreter_parola,sekreter_kullanici_adi)values(@tc,@ad,@cinsiyet,@dogum,@cep,@eposta,@parola,@kad)", baglanti);
                        a.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                        a.Parameters.AddWithValue("@ad", textBox1.Text);
                        a.Parameters.AddWithValue("@cinsiyet", textBox6.Text);
                        a.Parameters.AddWithValue("@dogum", textBox8.Text);
                        a.Parameters.AddWithValue("@cep", maskedTextBox2.Text);
                        a.Parameters.AddWithValue("@eposta", textBox5.Text);
                        a.Parameters.AddWithValue("@parola", maskedTextBox5.Text);
                        a.Parameters.AddWithValue("@kad", maskedTextBox3.Text);
                        a.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Sekreter bilgileri başarıyla güncellendi");

                    }
                    else if (kontrol.Text == "3")
                    {
                        
                        baglanti.Open();
                        SqlCommand a = new SqlCommand("insert into veznedar(veznedar_tc,veznedar_adi,veznedar_cinsiyeti,veznedar_dogum,veznedar_cep,veznedar_eposta,veznedar_parola,veznedar_kullanici_id)values(@tc,@ad,@cinsiyet,@dogum,@cep,@eposta,@parola,@kad)", baglanti);
                        a.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                        a.Parameters.AddWithValue("@ad", textBox1.Text);
                        a.Parameters.AddWithValue("@cinsiyet", textBox6.Text);
                        a.Parameters.AddWithValue("@dogum", textBox8.Text);
                        a.Parameters.AddWithValue("@cep", maskedTextBox2.Text);
                        a.Parameters.AddWithValue("@eposta", textBox5.Text);
                        a.Parameters.AddWithValue("@parola", maskedTextBox5.Text);
                        a.Parameters.AddWithValue("@kad", maskedTextBox3.Text);
                        a.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Veznedar bilgileri başarıyla güncellendi");
                    }

                }
                else
                    MessageBox.Show("Eleman Seçiniz");
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz");
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                int deger = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                double deger1 = Convert.ToDouble(dataGridView2.CurrentRow.Cells[1].Value);
                string deger2 = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                string deger3 = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                string deger4 = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                string deger5 = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                string deger6 = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                string deger7 = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                string deger8 = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                textBox3.Text = deger.ToString();
                maskedTextBox1.Text = deger1.ToString();
                textBox1.Text = deger2.ToString();
                textBox6.Text = deger3.ToString();
                textBox8.Text = deger4.ToString();
                maskedTextBox2.Text = deger5.ToString();
                textBox5.Text = deger6.ToString();
                maskedTextBox4.Text = deger7.ToString();
                maskedTextBox3.Text = deger8.ToString();
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz;");
            }
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int deger = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                double deger1 = Convert.ToDouble(dataGridView3.CurrentRow.Cells[1].Value);
                string deger2 = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                string deger3 = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                string deger4 = dataGridView3.CurrentRow.Cells[4].Value.ToString();
                string deger5 = dataGridView3.CurrentRow.Cells[5].Value.ToString();
                string deger6 = dataGridView3.CurrentRow.Cells[6].Value.ToString();
                string deger7 = dataGridView3.CurrentRow.Cells[7].Value.ToString();
                string deger8 = dataGridView3.CurrentRow.Cells[8].Value.ToString();
                textBox3.Text = deger.ToString();
                maskedTextBox1.Text = deger1.ToString();
                textBox1.Text = deger2.ToString();
                textBox6.Text = deger3.ToString();
                textBox8.Text = deger4.ToString();
                maskedTextBox2.Text = deger5.ToString();
                textBox5.Text = deger6.ToString();
                maskedTextBox4.Text = deger7.ToString();
                maskedTextBox3.Text = deger8.ToString();
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz;");
            }
        }
    }
}
