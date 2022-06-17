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
    public partial class frAcilMuayene : Form
    {
        public frAcilMuayene()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");
        
        private void frAcilMuayene_Load(object sender, EventArgs e)
        {
            try
            {

                mtxHastaID.Text = frDoktorAcil.hastaid;
                doktorBilgiler();
                hastaBilgiler();
                testler();
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
            a.Parameters.AddWithValue("@id", mtxKlinikID.Text);
            SqlDataReader oku = a.ExecuteReader();
            while (oku.Read())
            {
                label20.Text = oku[2].ToString();
                label21.Text = oku[3].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("update klinikler set yatan_hasta=@h where klinik_id=@id", baglanti);
            ekle.Parameters.AddWithValue("@id", mtxKlinikID.Text);
            ekle.Parameters.AddWithValue("@h", Convert.ToInt32(label21.Text) + 1);
            ekle.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand yatak = new SqlCommand("update klinikler set yatak_kapasite=@kapasite where klinik_id=@id ", baglanti);
            yatak.Parameters.AddWithValue("@id", mtxKlinikID.Text);
            yatak.Parameters.AddWithValue("@kapasite", Convert.ToInt32(label20.Text) - 1);
            yatak.ExecuteNonQuery();
            baglanti.Close();
            if (Convert.ToInt32(label20.Text) <= 0)
            {
                MessageBox.Show("Klinikte boş yatak yoktur");
            }
        }
        void doktorBilgiler()
        {
            mtxDoktorID.Text = frDoktor.dkidd;
            frDoktor.dkidd = mtxDoktorID.Text;
            try
            {


                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand doktor = new SqlCommand("select * from doktorlar where doktor_id=@did ", baglanti);
                doktor.Parameters.AddWithValue("@did", mtxDoktorID.Text);
                SqlDataReader oku = doktor.ExecuteReader();
                while (oku.Read())
                {
                    mtxDoktorID.Text = oku[0].ToString();
                    mtxKlinikID.Text = oku[4].ToString();
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
                if (mtxHastaID.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand hasta = new SqlCommand("select * from hastalar where Hasta_id=@hid", baglanti);
                    hasta.Parameters.AddWithValue("@hid", mtxHastaID.Text);
                    SqlDataReader oku = hasta.ExecuteReader();
                    while (oku.Read())
                    {
                        mtxHastaTC.Text = oku[1].ToString();
                        mtxAdi.Text = oku[2].ToString();
                        txSoyadi.Text = oku[3].ToString();
                        txCinsiyet.Text = oku[4].ToString();
                        txKanGrubu.Text = oku[5].ToString();
                        txDogumYer.Text = oku[6].ToString();
                        mtxDogumTar.Text = oku[7].ToString();
                        txBabaAdi.Text = oku[8].ToString();
                        txAnneAdi.Text = oku[9].ToString();
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
                Query.combo(testler, "test_id", "test_adi", cbTest);
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyniz.");
            }
        }

        private void btTestEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand lab = new SqlCommand("insert into lab (lab_tahlil_id,lab_test_id)values(@tid,@tidd)", baglanti);
                lab.Parameters.AddWithValue("@tid", mtxTahlilID.Text);
                lab.Parameters.AddWithValue("@tidd", cbTest.SelectedValue);
                lab.ExecuteNonQuery();
                baglanti.Close();
                lbxTest.Items.Add(cbTest.Text);
                baglanti.Open();
                SqlCommand tedavi = new SqlCommand("insert into tedavi(tedavi_test_id,tedavi_hasta_id)values(@test,@id) ", baglanti);
                tedavi.Parameters.AddWithValue("@test", cbTest.SelectedValue);
                tedavi.Parameters.AddWithValue("@id", mtxHastaID.Text);
                tedavi.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyniz.");
            }
        }

        private void btBitti_Click(object sender, EventArgs e)
        {
            try
            {
                lbxTest.Items.Clear();
                cbTest.SelectedIndex = 0;
                if (mtxHastaID.Text != "")
                {
                    baglanti.Open();
                    SqlCommand temizle = new SqlCommand("delete from acil where acil_hasta_id=@id ", baglanti);
                    temizle.Parameters.AddWithValue("@id", mtxHastaID.Text);
                    temizle.ExecuteNonQuery();
                    baglanti.Close();
                }

            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyniz.");
            }
        }

        private void btTestIste_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand tahlil = new SqlCommand("insert into tahliller(tahlil_doktor_id,tahlil_hasta_id,tahlil_klinik_id)values(@did,@hid,@kid)", baglanti);

                if (mtxHastaID.Text != "")
                {
                    tahlil.Parameters.AddWithValue("@did", mtxDoktorID.Text);
                    tahlil.Parameters.AddWithValue("@hid", mtxHastaID.Text);
                    tahlil.Parameters.AddWithValue("@kid", mtxKlinikID.Text);

                }


                tahlil.ExecuteNonQuery();
                baglanti.Close();

                panel3.Enabled = true;
                panel4.Enabled = false;
                btTaniKoy.Enabled = false;

                baglanti.Open();
                SqlCommand tahlil2 = new SqlCommand("select *from tahliller", baglanti);
                SqlDataReader oku = tahlil2.ExecuteReader();
                while (oku.Read())
                {
                    mtxTahlilID.Text = oku[0].ToString();
                }
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyniz.");
            }
        }

        private void btTaniKoy_Click(object sender, EventArgs e)
        {
            panel3.Enabled = false;
            panel4.Enabled = true;
        }

        private void btGonder_Click(object sender, EventArgs e)
        {
            try
            {
                if (mtxHastaID.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand recete = new SqlCommand("insert into receteler(recete_doktor_id,recete_hasta_id,recete_aciklama,recete_icerik)values(@did,@hid,@aciklama,@recete)", baglanti);
                    recete.Parameters.AddWithValue("@did", mtxDoktorID.Text);
                    recete.Parameters.AddWithValue("@hid", mtxHastaID.Text);
                    recete.Parameters.AddWithValue("@aciklama", txTani.Text);
                    recete.Parameters.AddWithValue("@recete", txRecete.Text);
                    recete.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Reçete ve Tanı başarıyla kaydedilmiştir.");
                    baglanti.Open();
                    SqlCommand temizle = new SqlCommand("delete from acil where acil_hasta_id=@id ", baglanti);
                    temizle.Parameters.AddWithValue("@id", mtxHastaID.Text);
                    temizle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Hastayı Vezneye Yönlendirin");
                }



            }
            catch
            {
                MessageBox.Show("Hata!! lütfen daha sonra tekrar deneyiniz");
            }
        }

        private void btYatisVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (mtxHastaID.Text != "")
                {
                    yatak();
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();

                    baglanti.Open();
                    SqlCommand ekle = new SqlCommand("insert into yatan(yatan_hasta_id,yatan_doktor_id,yatan_klinik_id)values(@hastaid,@doktorid,@klinikid)", baglanti);
                    ekle.Parameters.AddWithValue("@hastaid", mtxHastaID.Text);
                    ekle.Parameters.AddWithValue("@doktorid", mtxDoktorID.Text);
                    ekle.Parameters.AddWithValue("@klinikid", mtxKlinikID.Text);
                    ekle.ExecuteNonQuery();
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand temizle = new SqlCommand("delete from acil where acil_hasta_id=@id ", baglanti);
                    temizle.Parameters.AddWithValue("@id", mtxHastaID.Text);
                    temizle.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand guncelle = new SqlCommand("update hastalar set kontrol = @kont where Hasta_id=@id", baglanti);
                    guncelle.Parameters.AddWithValue("@id", mtxHastaID.Text);
                    guncelle.Parameters.AddWithValue("@kont", label15.Text);
                    guncelle.ExecuteNonQuery();
                    baglanti.Close();



                    MessageBox.Show("Hasta Başarıyla Hastaneye Yatırılmıştır. ");
                }
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }
    }
}
