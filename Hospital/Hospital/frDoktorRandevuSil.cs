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
    public partial class frDoktorRandevuSil : Form
    {
        public frDoktorRandevuSil()
        {
            InitializeComponent();
        }
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");

        private void frDoktorRandevuSil_Load(object sender, EventArgs e)
        {
            label1.Text = frGiris.dkid;

            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand görüntüle = new SqlCommand("select randevular.randevuid,klinikler.klinik_adi,randevular.randevu_tarih,randevular.randevu_saat,hastalar.Hasta_tc,hastalar.Hasta_adi,hastalar.Hasta_soyadi from randevular INNER JOIN hastalar on randevular.randevu_hasta_id=hasta_id INNER JOIN klinikler ON randevular.randevu_klinik_id=klinikler.klinik_id INNER JOIN doktorlar ON randevular.randevu_doktor_id=doktorlar.doktor_id where doktorlar.kullanici_adi=@dkid", baglanti);
                görüntüle.Parameters.AddWithValue("@dkid", label1.Text);
                da = new SqlDataAdapter(görüntüle);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyiniz.");
            }
        }

        private void btRandevuSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand sil = new SqlCommand("update randevular set iptal=@ip where randevuid=@id", baglanti);

                sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                sil.Parameters.AddWithValue("@ip", label2.Text);
                sil.ExecuteNonQuery();
                baglanti.Close();


                MessageBox.Show("Seçilen Randevu Başarıyla Silindi. ");
            }
            catch
            {
                MessageBox.Show("Hata!! Lüten daha sonra tekrar deneyin.");
            }
        }
    }
}
