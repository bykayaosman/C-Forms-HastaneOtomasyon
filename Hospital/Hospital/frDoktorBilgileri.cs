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
    public partial class frDoktorBilgileri : Form
    {
        public frDoktorBilgileri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");


        private void frDoktorBilgileri_Load(object sender, EventArgs e)
        {
            try
            {
                maskedTextBox4.Text = frGiris.dsifre;
                maskedTextBox3.Text = frGiris.dkid;
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand doldur = new SqlCommand("select * from doktorlar where kullanici_adi= @kid", baglanti);
                doldur.Parameters.AddWithValue("@kid", SqlDbType.Int).Value = maskedTextBox3.Text;
                SqlDataReader oku = doldur.ExecuteReader();
                while (oku.Read())
                {
                    maskedTextBox1.Text = oku[5].ToString();
                    textBox1.Text = oku[3].ToString();
                    textBox6.Text = oku[11].ToString();
                    textBox7.Text = oku[6].ToString();
                    textBox8.Text = oku[7].ToString();
                    textBox9.Text = oku[10].ToString();
                    maskedTextBox2.Text = oku[8].ToString();
                    textBox5.Text = oku[9].ToString();
                    maskedTextBox3.Text = oku[1].ToString();
                    textBox2.Text = oku[12].ToString();
                    pictureBox2.ImageLocation = textBox2.Text;
                }
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen Daha Sonra Tekar Deneyiniz!! ");
            }
        }

        void form()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "GirisSayfasi")
                {
                    Application.OpenForms[i].Close();

                }
            }
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == "GirisSayfasi")
                {
                    Application.OpenForms[i].Show();
                }
            }
        }

        private void btGuncelle_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text != "" && textBox5.Text != "" && maskedTextBox2.Text != "" && textBox9.Text != "" && maskedTextBox5.Text != "" && maskedTextBox3.Text != "")
            {

                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand guncelle = new SqlCommand("update doktorlar set doktor_cep=@cep, doktor_eposta=@eposta,doktor_adres=@adres,sifre=@sifre,doktor_foto=@foto where kullanici_adi=@kid", baglanti);
                    guncelle.Parameters.AddWithValue("@kid", maskedTextBox3.Text);
                    guncelle.Parameters.AddWithValue("@cep", SqlDbType.NVarChar).Value = maskedTextBox2.Text.ToString();
                    guncelle.Parameters.AddWithValue("@eposta", SqlDbType.NVarChar).Value = textBox5.Text;
                    guncelle.Parameters.AddWithValue("@sifre", SqlDbType.Int).Value = maskedTextBox5.Text.ToString();
                    guncelle.Parameters.AddWithValue("@adres", SqlDbType.NVarChar).Value = textBox9.Text;
                    guncelle.Parameters.AddWithValue("@foto", SqlDbType.NVarChar).Value = textBox2.Text;
                    guncelle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kullanıcı Bilgileri Güncellendi,Lütfen Tekrar Giriş Yapınız.");
                    form();
                }
                catch
                {
                    MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyiniz");
                }
            }
            else
                MessageBox.Show("Alanlar Boş Bırakılamaz!");
        }

        private void btFotografSec_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                pictureBox2.ImageLocation = openFileDialog1.FileName;
                textBox2.Text = openFileDialog1.FileName;
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }
    }
}
