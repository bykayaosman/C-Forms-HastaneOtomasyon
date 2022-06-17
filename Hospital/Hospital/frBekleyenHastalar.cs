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
    public partial class frBekleyenHastalar : Form
    {
        public frBekleyenHastalar()
        {
            InitializeComponent();
        }
        public static int kontrolMuayene = 0;
        public static string hastaid;
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");

        private void btHastaSec_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand c = new SqlCommand("select * from bekleyenHasta where bekleyen_id=@id ", baglanti);
                c.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[1].Value.ToString());
                SqlDataReader oku = c.ExecuteReader();
                while (oku.Read())
                {
                    textBox1.Text = oku[1].ToString();
                    hastaid = textBox1.Text;
                }
                baglanti.Close();
                hastaid = textBox1.Text;
                textBox1.Text = hastaid;
                kontrolMuayene = 1;
                frMuayene yeni = new frMuayene();

                yeni.Show();
            }

            catch
            {
                MessageBox.Show("Hata!! Lütfen daha sonra tekrar deneyiniz.");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int deger = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                textBox1.Text = deger.ToString();
                hastaid = textBox1.Text;
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz");
            }
        }

        private void frBekleyenHastalar_Load(object sender, EventArgs e)
        {
            try
            {
                label1.Text = frGiris.dkid;
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand görüntüle = new SqlCommand("select bekleyenHasta.bekleyen_id,hastalar.Hasta_id,hastalar.Hasta_tc,hastalar.Hasta_adi,hastalar.Hasta_soyadi,klinikler.klinik_adi from bekleyenHasta INNER JOIN hastalar on bekleyenHasta.bekleyen_hasta_id=hasta_id INNER JOIN klinikler ON bekleyenHasta.bekleyen_klinikid=klinikler.klinik_id INNER JOIN doktorlar ON bekleyenHasta.bekleyen_doktorid=doktorlar.doktor_id where doktorlar.kullanici_adi=@dkid", baglanti);
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
    }
}
