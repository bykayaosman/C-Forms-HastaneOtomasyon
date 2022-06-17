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
    public partial class frYoneticiIletisim : Form
    {
        public frYoneticiIletisim()
        {
            InitializeComponent();
        }
        public static string tahlilid;
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand c = new SqlCommand("select * from iletisim where iletisim_id=@id", baglanti);
                c.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                SqlDataReader oku = c.ExecuteReader();
                while (oku.Read())
                {

                    textBox1.Text = oku[1].ToString();
                    textBox2.Text = oku[2].ToString();
                    textBox3.Text = oku[4].ToString();
                    textBox4.Text = oku[3].ToString();
                }
                baglanti.Close();
                panel1.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra Tekrar Deneyiniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient Kaynak = new SmtpClient();
                Kaynak.Credentials = new System.Net.NetworkCredential("odev061@gmail.com", "deneme_12");
                Kaynak.Host = "smtp.gmail.com";
                Kaynak.Port = 587;
                MailAddress Giden = new MailAddress("odev061@gmail.com", "HO İletişim");
                MailMessage Mesaj = new MailMessage();
                Mesaj.From = Giden;
                Mesaj.To.Add(textBox3.Text);
                Mesaj.Subject = textBox8.Text;
                Mesaj.Body = textBox6.Text;
                Mesaj.IsBodyHtml = true;
                Kaynak.EnableSsl = true;
                Kaynak.Send(Mesaj);
                MessageBox.Show("Geri Dönüş Başarıyla Yapılmıştır");
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand a = new SqlCommand("update iletisim set iletisim_kontrol=@a where iletisim_bigileri=@b", baglanti);
                a.Parameters.AddWithValue("@b", textBox3.Text);
                a.Parameters.AddWithValue("@a", Convert.ToInt32(label5.Text));
                a.ExecuteNonQuery();
                baglanti.Close();

                this.Close();
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra Tekrar Deneyiniz.");
            }
        }

        private void frYoneticiIletisim_Load(object sender, EventArgs e)
        {
            try
            {
               
                baglanti.Open();
                SqlCommand görüntüle = new SqlCommand("select * from iletisim", baglanti);
                da = new SqlDataAdapter(görüntüle);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! lütfen daha sonra tekrar deneyin");
            }
        }
    }
}
