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
    public partial class frHastaBilgileri : Form
    {
        public frHastaBilgileri()
        {
            InitializeComponent();
        }
        public static string tc;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");
        void form ()
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


        private void frHastaBilgileri_Load(object sender, EventArgs e)
        {
            try
            {
                textBox5.Text = frGiris.kid;
                maskedTextBox4.Text = frGiris.ksifre;

                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();

                SqlCommand id = new SqlCommand("select * from hastalar where Hasta_ePosta=@eposta", baglanti);
                id.Parameters.AddWithValue("@eposta", SqlDbType.NVarChar).Value = textBox5.Text;
                SqlDataReader oku = id.ExecuteReader();
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
                    maskedTextBox2.Text = oku[10].ToString();
                    textBox5.Text = oku[11].ToString();
                    maskedTextBox4.Text = oku[12].ToString();
                    textBox9.Text = oku[13].ToString();
                }

            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen Daha Sonra Tekrar Deneyiniz.");
            }
            tc = maskedTextBox1.Text;

            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox5.Text != "" && textBox5.Text != "" && maskedTextBox2.Text != "" && textBox9.Text !="")
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    SqlCommand guncelle = new SqlCommand("Update hastalar set Hasta_cepTel=@tel, Hasta_ePosta=@eposta, Hasta_parola=@parola,Hasta_Adres=@adres where Hasta_tc=@tc ", baglanti);
                    guncelle.Parameters.AddWithValue("@tc", SqlDbType.NVarChar).Value = maskedTextBox1.Text.ToString();
                    guncelle.Parameters.AddWithValue("@tel", SqlDbType.NVarChar).Value = maskedTextBox2.Text.ToString();
                    guncelle.Parameters.AddWithValue("@eposta", SqlDbType.NVarChar).Value = textBox5.Text;
                    guncelle.Parameters.AddWithValue("@parola", SqlDbType.NVarChar).Value = maskedTextBox5.Text;
                    guncelle.Parameters.AddWithValue("@adres", SqlDbType.NVarChar).Value = textBox9.Text;
                    guncelle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kullanıcı Bilgileri Güncellendi,Lütfen Tekrar Giriş Yapınız.");
                    form();
               
                }
                catch
                {
                    MessageBox.Show("Hata!! Lütfen Daha Sonra Tekrar Deneyiniz");
                }
                baglanti.Close();
            }
            else
                MessageBox.Show("Alanlar Boş Bırakılamaz");
        }
        }
    }

