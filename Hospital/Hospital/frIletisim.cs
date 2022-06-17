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
    public partial class frIletisim : Form
    {
        public frIletisim()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");
        private void btGonder_Click(object sender, EventArgs e)
        {
            try
            {
                
                baglanti.Open();
                SqlCommand iletisim = new SqlCommand("insert into iletisim (iletisim_ad,iletisim_soyad,iletisim_bilgileri,talep_sikayet,iletisim_kontrol)values(@ad,@soyad,@bilgiler,@sikayet,@kontrol)", baglanti);
                iletisim.Parameters.AddWithValue("@ad", textBox1.Text);
                iletisim.Parameters.AddWithValue("@soyad", textBox2.Text);
                iletisim.Parameters.AddWithValue("@bilgiler", textBox3.Text);
                iletisim.Parameters.AddWithValue("@sikayet", textBox4.Text);
                iletisim.Parameters.AddWithValue("@kontrol", label6.Text);
                iletisim.ExecuteNonQuery();
                MessageBox.Show("mesaj gönderildi");
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }
    }
}
