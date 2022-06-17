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
    public partial class frDoktorTahlilSonucları : Form
    {
        public frDoktorTahlilSonucları()
        {
            InitializeComponent();
        }

        public static string id;
        public static string hastaid;
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");

        private void frDoktorTahlilSonucları_Load(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = label10.Text;
                textBox4.Text = frDoktor.dkidd;
                klinkgetir();
                klinikgetir2();
                ilac();
                yatanhasta();
                if (frYatanHasta.yatan == 1)
                {
                    panel5.Visible = false;
                    panel4.Visible = false;
                    btAra.Enabled = false;
                    textBox1.Enabled = false;
                    btTemizle.Visible = true;
                    textBox1.Text = frYatanHasta.id.ToString();
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand listele = new SqlCommand("select lab.lab_id,lab.lab_tahlil_id,lab_test_id,testler.test_adi,lab_aciklama,tahliller.tahlil_doktor_id,tahliller.tahlil_hasta_id,tahliller.tahlil_klinik_id,lab.lab_tarih from lab INNER JOIN tahliller on tahliller.tahlil_id=lab_tahlil_id INNER JOIN testler on testler.test_id=lab.lab_test_id where tahliller.tahlil_hasta_id=@id and tahliller.tahlil_doktor_id=@idd and lab.kontrol=2", baglanti);
                    listele.Parameters.AddWithValue("@idd", textBox4.Text);
                    listele.Parameters.AddWithValue("@id", textBox1.Text);
                    //listele.Parameters.AddWithValue("@kont", label19.Text);
                    da = new SqlDataAdapter(listele);
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }
        void yatak()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            SqlCommand a = new SqlCommand("select * from klinikler where klinik_id=@id", baglanti);
            a.Parameters.AddWithValue("@id", textBox3.Text);
            SqlDataReader oku = a.ExecuteReader();
            while (oku.Read())
            {
                label23.Text = oku[2].ToString();
                label24.Text = oku[3].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("update klinikler set yatan_hasta=@h where klinik_id=@id", baglanti);
            ekle.Parameters.AddWithValue("@id", textBox3.Text);
            ekle.Parameters.AddWithValue("@h", Convert.ToInt32(label24.Text) + 1);
            ekle.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand yatak = new SqlCommand("update klinikler set yatak_kapasite=@kapasite where klinik_id=@id ", baglanti);
            yatak.Parameters.AddWithValue("@id", textBox3.Text);
            yatak.Parameters.AddWithValue("@kapasite", Convert.ToInt32(label23.Text) - 1);
            yatak.ExecuteNonQuery();
            baglanti.Close();
            if (Convert.ToInt32(label23.Text) <= 0)
            {
                MessageBox.Show("Klinikte boş yatak yoktur");
            }
        }
        void yatanhasta()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            SqlCommand yatan = new SqlCommand("select yatan_hasta_id from yatan", baglanti);
            SqlDataReader oku = yatan.ExecuteReader();
            while (oku.Read())
            {
                listBox2.Items.Add(oku[0].ToString());
            }

        }
        void klinkgetir()
        {
            SqlCommand c = new SqlCommand("select * from klinikler where klinik_id < 14 or klinik_id > 18", baglanti);
            Query.combo(c, "klinik_id", "klinik_adi", cbxKlinik);
        }
        void ilac()
        {
            SqlCommand a = new SqlCommand("select * from ilaclar", baglanti);
            Query.combo(a, "ilac_id", "ilac_adi", comboBox4);
        }
        void klinikgetir2()
        {
            SqlCommand c = new SqlCommand("select * from klinikler where klinik_id < 14 or klinik_id > 18", baglanti);
            Query.combo(c, "klinik_id", "klinik_adi", cbxKlinik2);
        }

        private void btAra_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand listele = new SqlCommand("select lab.lab_id,lab.lab_tahlil_id,lab_test_id,testler.test_adi,lab_aciklama,tahliller.tahlil_doktor_id,tahliller.tahlil_hasta_id,tahliller.tahlil_klinik_id,lab.lab_tarih from lab INNER JOIN tahliller on tahliller.tahlil_id=lab_tahlil_id INNER JOIN testler on testler.test_id=lab.lab_test_id where tahliller.tahlil_hasta_id=@id and tahliller.tahlil_doktor_id=@idd and lab.kontrol=2", baglanti);
                listele.Parameters.AddWithValue("@idd", textBox4.Text);
                listele.Parameters.AddWithValue("@id", textBox1.Text);
                //  listele.Parameters.AddWithValue("@kont", label19.Text);
                da = new SqlDataAdapter(listele);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                if (listBox2.Items.Contains(textBox1.Text))
                {
                    panel5.Visible = false;
                    panel4.Visible = false;
                    btAra.Enabled = false;
                    textBox1.Enabled = false;
                    btTemizle.Visible = true;
                }
                baglanti.Close();

                // label10.Text = Doktor.dkidd;
            }
            catch
            {
                MessageBox.Show("hata!! lütfen daha sonra tekrar deneyin");
            }
        }

        private void btGonder_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Reçete ve Tanı başarıyla kaydedilmiştir.");
                textBox2.Text = "";
                comboBox4.SelectedIndex = 0;
                listBox1.Items.Clear();

                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand vezne = new SqlCommand("insert into vezne(hasta_id)values(@id) ", baglanti);
                vezne.Parameters.AddWithValue("@id", textBox1.Text);
                vezne.ExecuteNonQuery();
                baglanti.Close();

            }
            catch
            {
                MessageBox.Show("Hata!! lütfen daha sonra tekrar deneyiniz");
            }
        }

        private void btTaniSil_Click(object sender, EventArgs e)
        {
            try
            {


                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand lab = new SqlCommand("update lab set kontrol=@kont where lab_id=@id ", baglanti);
                lab.Parameters.AddWithValue("@id", label18.Text);
                lab.Parameters.AddWithValue("@kont", label19.Text);
                lab.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! lütfen daha sonra tekrar deneyiniz");
            }
        }

        private void btPaylas_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && frDoktor.klinikid != "16" && frDoktor.klinikid != "17" && frDoktor.klinikid != "18")
                {
                    panel1.Enabled = true;
                    panel2.Enabled = false;
                    panel3.Enabled = false;
                    if (frDoktor.klinikid == "16" || frDoktor.klinikid == "17" || frDoktor.klinikid == "18")
                        MessageBox.Show("Acil doktorları paylaşım yapamaz. Nakil Sekmesini Kullanınız.");
                }
                else
                    MessageBox.Show("Bir Tahlil Seçiniz");
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }

        }

        private void cbxKlinik_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxKlinik.SelectedIndex != 0)
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand komutdoktor = new SqlCommand("SELECT klinikler.klinik_id,doktorlar.doktor_id,doktorlar.doktor_adi_soyadi FROM doktorlar INNER JOIN klinikler ON doktorlar.doktor_klinik_id=klinikler.klinik_id WHERE doktorlar.doktor_klinik_id=@kid", baglanti);
                    komutdoktor.Parameters.AddWithValue("@kid", cbxKlinik.SelectedValue.ToString());
                    Query.combo(komutdoktor, "doktor_id", "doktor_adi_soyadi", comboBox5);

                    baglanti.Close();
                }
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }

        }

        private void btKlinGonder_Click(object sender, EventArgs e)
        {
            try
            {

                baglanti.Open();
                SqlCommand a = new SqlCommand("select * from tahliller where tahlil_doktor_id=@id", baglanti);
                a.Parameters.AddWithValue("@id", Convert.ToInt32(comboBox5.SelectedValue));
                SqlDataReader oku = a.ExecuteReader();
                while (oku.Read())
                {
                    label17.Text = oku[0].ToString();
                }

                baglanti.Close();

                baglanti.Open();
                SqlCommand nakil = new SqlCommand("insert into lab(lab_tahlil_id,lab_test_id,lab_tarih,lab_aciklama)values(@tahlilid,@testid,@tarih,@aciklama)", baglanti);
                nakil.Parameters.AddWithValue("@tahlilid", label17.Text);
                nakil.Parameters.AddWithValue("@testid", label7.Text);
                nakil.Parameters.AddWithValue("@aciklama", label9.Text);
                nakil.Parameters.AddWithValue("@tarih", label12.Text);
                nakil.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Hasta Bilgileri Başarıyla Gönderilidi");

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
                int deger = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                int deger2 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
                string deger3 = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string deger4 = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                int deger5 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value);
                int deger6 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value);
                string deger7 = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                int deger8 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                label6.Text = deger.ToString();
                label7.Text = deger2.ToString();
                label8.Text = deger3.ToString();
                label9.Text = deger4.ToString();
                label10.Text = deger5.ToString();
                label11.Text = deger6.ToString();
                label12.Text = deger7.ToString();
                label18.Text = deger8.ToString();
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz!");
            }
        }

        private void btNakil_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    panel2.Enabled = true;
                    panel1.Enabled = false;
                    panel3.Enabled = false;

                }

                else
                    MessageBox.Show("Bir Tahlil Seçiniz");
            }


            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz");
            }
        }

        private void cbxKlinik2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxKlinik2.SelectedIndex != 0)
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand komutdoktor = new SqlCommand("SELECT klinikler.klinik_id,doktorlar.doktor_id,doktorlar.doktor_adi_soyadi FROM doktorlar INNER JOIN klinikler ON doktorlar.doktor_klinik_id=klinikler.klinik_id WHERE doktorlar.doktor_klinik_id=@kid", baglanti);
                    komutdoktor.Parameters.AddWithValue("@kid", cbxKlinik2.SelectedValue.ToString());
                    Query.combo(komutdoktor, "doktor_id", "doktor_adi_soyadi", comboBox1);

                    baglanti.Close();
                }
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void btDoktGonder_Click(object sender, EventArgs e)
        {
            try
            {
                if (frDoktor.klinikid == "16" || frDoktor.klinikid == "17" || frDoktor.klinikid == "18")
                {


                    baglanti.Open();
                    SqlCommand nakil = new SqlCommand("update tahliller set tahlil_doktor_id=@id", baglanti);
                    nakil.Parameters.AddWithValue("@id", Convert.ToInt32(comboBox1.SelectedValue));
                    nakil.ExecuteNonQuery();
                    baglanti.Close();


                    baglanti.Open();
                    SqlCommand sil = new SqlCommand("delete from acil where acil_hasta_id=@id ", baglanti);
                    sil.Parameters.AddWithValue("@id", textBox1.Text);
                    MessageBox.Show("Hasta Başarıyla Sevk Edildi");
                    sil.ExecuteNonQuery();
                    baglanti.Close();
                }
                else
                {
                    baglanti.Open();
                    SqlCommand nakil = new SqlCommand("update tahliller set tahlil_doktor_id=@id", baglanti);
                    nakil.Parameters.AddWithValue("@id", Convert.ToInt32(comboBox1.SelectedValue));
                    nakil.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Hasta Nakli Başarıyla Sağlandı");
                    baglanti.Close();                    
                }

            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyiniz");
            }
        }

        private void btDoktorSec_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox5.SelectedIndex != 0 && cbxKlinik.SelectedIndex != 0)
                {
                    btKlinGonder.Enabled = true;
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();

                    baglanti.Open();
                    SqlCommand nakil2 = new SqlCommand("insert into tahliller(tahlil_doktor_id,tahlil_hasta_id,tahlil_klinik_id)values(@doktorid,@hastaid,@klinikid)", baglanti);
                    nakil2.Parameters.AddWithValue("@hastaid", label10.Text);
                    nakil2.Parameters.AddWithValue("@klinikid", label11.Text);
                    nakil2.Parameters.AddWithValue("@doktorid", Convert.ToInt32(comboBox5.SelectedValue));
                    nakil2.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }

        private void btTaniRecete_Click(object sender, EventArgs e)
        {
            panel3.Enabled = true;
            panel1.Enabled = false;
            panel2.Enabled = false;
        }

        private void btReceteEkle_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (comboBox4.SelectedIndex != 0)
                {
                    try
                    {
                        if (baglanti.State == ConnectionState.Open)
                            baglanti.Close();
                        baglanti.Open();
                        SqlCommand recete = new SqlCommand("insert into receteler(recete_doktor_id,recete_hasta_id,recete_aciklama,recete_icerik)values(@did,@hid,@aciklama,@recete)", baglanti);
                        recete.Parameters.AddWithValue("@did", textBox4.Text);
                        recete.Parameters.AddWithValue("@hid", textBox1.Text);
                        recete.Parameters.AddWithValue("@aciklama", textBox2.Text);
                        recete.Parameters.AddWithValue("@recete", comboBox4.SelectedValue);
                        listBox1.Items.Add(comboBox4.Text);
                        btGonder.Enabled = true;
                        recete.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Hata!! lütfen daha sonra tekrar deneyiniz");
                    }
                }
                else
                {
                    MessageBox.Show("ilaç seçiniz");
                }
            }
            else
            {
                MessageBox.Show("Bir tanı koyunuz;");
            }
        }

        private void btYatisVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand ekle = new SqlCommand("insert into yatan(yatan_hasta_id,yatan_doktor_id,yatan_klinik_id)values(@hastaid,@doktorid,@klinikid)", baglanti);
                    ekle.Parameters.AddWithValue("@hastaid", textBox1.Text);
                    ekle.Parameters.AddWithValue("@doktorid", textBox4.Text);
                    ekle.Parameters.AddWithValue("@klinikid", textBox3.Text);
                    ekle.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand guncelle = new SqlCommand("update hastalar set kontrol = @kont where Hasta_id=@id", baglanti);
                    guncelle.Parameters.AddWithValue("@id", textBox1.Text);
                    guncelle.Parameters.AddWithValue("@kont", label22.Text);
                    guncelle.ExecuteNonQuery();
                    baglanti.Close();


                    MessageBox.Show("Hasta Başarıyla Hastaneye Yatırılmıştır. ");   
                    panel3.Enabled = false;
                    btPaylas.Enabled = false;
                    btNakil.Enabled = false;
                    this.Close();
                }
                else
                    MessageBox.Show("Önce Hasta Seçiniz");
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz");
            }
        }

        private void btTemizle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand lab = new SqlCommand("update lab set kontrol=@kont where lab_id=@id ", baglanti);
                lab.Parameters.AddWithValue("@id", label18.Text);
                lab.Parameters.AddWithValue("@kont", label19.Text);
                lab.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! lütfen daha sonra tekrar deneyiniz");
            }
        }
    }
}
