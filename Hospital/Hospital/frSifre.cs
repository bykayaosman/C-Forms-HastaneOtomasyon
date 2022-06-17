using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital
{
    public partial class frSifre : Form
    {
        public frSifre()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");


        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            kontrol.Text = "3";
        }

        private void frSifre_Load(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(1000, 9999);
            yeniS.Text = sayi.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            kontrol.Text = "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            kontrol.Text = "2";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            kontrol.Text = "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            kontrol.Text = "6";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void vezneButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    if (kontrol.Text == "1")
                    {
                        if (baglanti.State == ConnectionState.Open)
                            baglanti.Close();
                        baglanti.Open();
                        SqlCommand a = new SqlCommand("select doktorlar.doktor_eposta from doktorlar where doktor_eposta=@q ", baglanti);
                        a.Parameters.AddWithValue("@q", textBox1.Text);
                        SqlDataReader oku = a.ExecuteReader();
                        if (oku.Read())
                        {
                            SmtpClient Kaynak = new SmtpClient();
                            Kaynak.Credentials = new System.Net.NetworkCredential("odev061@gmail.com", "deneme_12");
                            Kaynak.Host = "smtp.gmail.com";
                            Kaynak.Port = 587;
                            MailAddress Giden = new MailAddress("odev061@gmail.com", "HO Admin");
                            MailMessage Mesaj = new MailMessage();
                            Mesaj.From = Giden;
                            Mesaj.To.Add(textBox1.Text);
                            Mesaj.Subject = label1.Text;
                            Mesaj.Body = yeniS.Text;
                            Mesaj.IsBodyHtml = true;
                            Kaynak.EnableSsl = true;
                            Kaynak.Send(Mesaj);
                            kontrol2.Text = "2";
                            MessageBox.Show("Yeni Şifreniz Mailinize Gönderilmiştir");
                            baglanti.Close();


                        }
                        else
                            MessageBox.Show("Böyle bir e-posta sistemde kayıtlı değil");

                        if (kontrol2.Text == "2")
                        {
                            baglanti.Open();
                            SqlCommand q = new SqlCommand("update doktorlar set sifre=@a where doktor_eposta=@eposta ", baglanti);
                            q.Parameters.AddWithValue("@eposta", textBox1.Text);
                            q.Parameters.AddWithValue("@a", yeniS.Text);
                            q.ExecuteNonQuery();
                            baglanti.Close();
                            this.Close();
                        }
                    }

                    if (kontrol.Text == "2")
                    {
                        if (baglanti.State == ConnectionState.Open)
                            baglanti.Close();
                        baglanti.Open();
                        SqlCommand a = new SqlCommand("select hastalar.Hasta_ePosta from hastalar where Hasta_ePosta=@q ", baglanti);
                        a.Parameters.AddWithValue("@q", textBox1.Text);
                        SqlDataReader oku = a.ExecuteReader();
                        if (oku.Read())
                        {
                            SmtpClient Kaynak = new SmtpClient();
                            Kaynak.Credentials = new System.Net.NetworkCredential("odev061@gmail.com", "deneme_12");
                            Kaynak.Host = "smtp.gmail.com";
                            Kaynak.Port = 587;
                            MailAddress Giden = new MailAddress("odev061@gmail.com", "HO Admin");
                            MailMessage Mesaj = new MailMessage();
                            Mesaj.From = Giden;
                            Mesaj.To.Add(textBox1.Text);
                            Mesaj.Subject = label1.Text;
                            Mesaj.Body = yeniS.Text;
                            Mesaj.IsBodyHtml = true;
                            Kaynak.EnableSsl = true;
                            Kaynak.Send(Mesaj);
                            kontrol2.Text = "2";
                            MessageBox.Show("Yeni Şifreniz Mailinize Gönderilmiştir");
                            baglanti.Close();


                        }
                        else
                            MessageBox.Show("Böyle bir e-posta sistemde kayıtlı değil");

                        if (kontrol2.Text == "2")
                        {
                            baglanti.Open();
                            SqlCommand q = new SqlCommand("update doktorlar set Hasta_parola=@a where Hasta_ePosta=@eposta ", baglanti);
                            q.Parameters.AddWithValue("@eposta", textBox1.Text);
                            q.Parameters.AddWithValue("@a", yeniS.Text);
                            q.ExecuteNonQuery();
                            baglanti.Close();
                            this.Close();
                        }
                    }
                    if (kontrol.Text == "3")
                    {
                        if (baglanti.State == ConnectionState.Open)
                            baglanti.Close();
                        baglanti.Open();
                        SqlCommand a = new SqlCommand("select veznedar.veznedar_eposta where veznedar_eposta=@q ", baglanti);
                        a.Parameters.AddWithValue("@q", textBox1.Text);
                        SqlDataReader oku = a.ExecuteReader();
                        if (oku.Read())
                        {
                            SmtpClient Kaynak = new SmtpClient();
                            Kaynak.Credentials = new System.Net.NetworkCredential("odev061@gmail.com", "deneme_12");
                            Kaynak.Host = "smtp.gmail.com";
                            Kaynak.Port = 587;
                            MailAddress Giden = new MailAddress("odev061@gmail.com", "HO Admin");
                            MailMessage Mesaj = new MailMessage();
                            Mesaj.From = Giden;
                            Mesaj.To.Add(textBox1.Text);
                            Mesaj.Subject = label1.Text;
                            Mesaj.Body = yeniS.Text;
                            Mesaj.IsBodyHtml = true;
                            Kaynak.EnableSsl = true;
                            Kaynak.Send(Mesaj);
                            kontrol2.Text = "2";
                            MessageBox.Show("Yeni Şifreniz Mailinize Gönderilmiştir");
                            baglanti.Close();


                        }
                        else
                            MessageBox.Show("Böyle bir e-posta sistemde kayıtlı değil");

                        if (kontrol2.Text == "2")
                        {
                            baglanti.Open();
                            SqlCommand q = new SqlCommand("update veznedar set veznedar_parola=@a where veznedar_eposta=@eposta ", baglanti);
                            q.Parameters.AddWithValue("@eposta", textBox1.Text);
                            q.Parameters.AddWithValue("@a", yeniS.Text);
                            q.ExecuteNonQuery();
                            baglanti.Close();
                            this.Close();
                        }
                    }
                    if (kontrol.Text == "4")
                    {
                        if (baglanti.State == ConnectionState.Open)
                            baglanti.Close();
                        baglanti.Open();
                        SqlCommand a = new SqlCommand("select labeleman.lab_eleman_eposta where lab_eleman_eposta=@q ", baglanti);
                        a.Parameters.AddWithValue("@q", textBox1.Text);
                        SqlDataReader oku = a.ExecuteReader();
                        if (oku.Read())
                        {
                            SmtpClient Kaynak = new SmtpClient();
                            Kaynak.Credentials = new System.Net.NetworkCredential("odev061@gmail.com", "deneme_12");
                            Kaynak.Host = "smtp.gmail.com";
                            Kaynak.Port = 587;
                            MailAddress Giden = new MailAddress("odev061@gmail.com", "HO Admin");
                            MailMessage Mesaj = new MailMessage();
                            Mesaj.From = Giden;
                            Mesaj.To.Add(textBox1.Text);
                            Mesaj.Subject = label1.Text;
                            Mesaj.Body = yeniS.Text;
                            Mesaj.IsBodyHtml = true;
                            Kaynak.EnableSsl = true;
                            Kaynak.Send(Mesaj);
                            kontrol2.Text = "2";
                            MessageBox.Show("Yeni Şifreniz Mailinize Gönderilmiştir");
                            baglanti.Close();


                        }
                        else
                            MessageBox.Show("Böyle bir e-posta sistemde kayıtlı değil");

                        if (kontrol2.Text == "2")
                        {
                            baglanti.Open();
                            SqlCommand q = new SqlCommand("update labeleman set lab_eleman_parola=@a where lab_eleman_eposta=@eposta ", baglanti);
                            q.Parameters.AddWithValue("@eposta", textBox1.Text);
                            q.Parameters.AddWithValue("@a", yeniS.Text);
                            q.ExecuteNonQuery();
                            baglanti.Close();
                            this.Close();
                        }
                    }
                    if (kontrol.Text == "5")
                    {
                        if (baglanti.State == ConnectionState.Open)
                            baglanti.Close();
                        baglanti.Open();
                        SqlCommand a = new SqlCommand("select sekreter.sekreter_eposta where sekreter_eposta=@q ", baglanti);
                        a.Parameters.AddWithValue("@q", textBox1.Text);
                        SqlDataReader oku = a.ExecuteReader();
                        if (oku.Read())
                        {
                            SmtpClient Kaynak = new SmtpClient();
                            Kaynak.Credentials = new System.Net.NetworkCredential("odev061@gmail.com", "deneme_12");
                            Kaynak.Host = "smtp.gmail.com";
                            Kaynak.Port = 587;
                            MailAddress Giden = new MailAddress("odev061@gmail.com", "HO Admin");
                            MailMessage Mesaj = new MailMessage();
                            Mesaj.From = Giden;
                            Mesaj.To.Add(textBox1.Text);
                            Mesaj.Subject = label1.Text;
                            Mesaj.Body = yeniS.Text;
                            Mesaj.IsBodyHtml = true;
                            Kaynak.EnableSsl = true;
                            Kaynak.Send(Mesaj);
                            kontrol2.Text = "2";
                            MessageBox.Show("Yeni Şifreniz Mailinize Gönderilmiştir");
                            baglanti.Close();


                        }
                        else
                            MessageBox.Show("Böyle bir e-posta sistemde kayıtlı değil");

                        if (kontrol2.Text == "2")
                        {
                            baglanti.Open();
                            SqlCommand q = new SqlCommand("update sekreter set sekreter_parola=@a where sekreter_eposta=@eposta ", baglanti);
                            q.Parameters.AddWithValue("@eposta", textBox1.Text);
                            q.Parameters.AddWithValue("@a", yeniS.Text);
                            q.ExecuteNonQuery();
                            baglanti.Close();
                            this.Close();
                        }
                    }


                }
                else
                    MessageBox.Show("Lütfen bir e-posta giriniz.");
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz");
            }
        }
    }
}
