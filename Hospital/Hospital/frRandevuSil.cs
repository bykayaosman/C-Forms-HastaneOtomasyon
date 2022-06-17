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
    public partial class frRandevuSil : Form
    {
        public frRandevuSil()
        {
            InitializeComponent();
        }
        public static SqlDataAdapter da;

        public static SqlCommand komut;
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
                SqlCommand sil = new SqlCommand("delete from randevular where randevuid=@id", baglanti);
                sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                sil.ExecuteNonQuery();
                baglanti.Close();


                MessageBox.Show("Seçilen Randevu Başarıyla Silindi. ");
            }
            catch
            {
                MessageBox.Show("Hata!! Lüten daha sonra tekrar deneyin.");
            }
        }

        private void frRandevuSil_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                Randevularım.Text = frHasta.idx;

                SqlCommand görüntüle = new SqlCommand("Select randevular.randevuid,klinikler.klinik_adi,randevular.randevu_tarih,randevular.randevu_saat,hastalar.Hasta_tc,hastalar.Hasta_adi,hastalar.Hasta_soyadi from randevular INNER JOIN hastalar on randevular.randevu_hasta_id=hastalar.Hasta_id INNER JOIN klinikler ON randevular.randevu_klinik_id=klinikler.klinik_id where hastalar.Hasta_id=@id", baglanti);
                görüntüle.Parameters.AddWithValue("@id", Randevularım.Text);
                da = new SqlDataAdapter(görüntüle);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("HATA!! Lütfen daha sonra tekrar deneyiniz!!");

            }
        }
    }
}
