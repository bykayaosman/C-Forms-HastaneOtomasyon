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
    public partial class frHastaLab : Form
    {
        public frHastaLab()
        {
            InitializeComponent();
        }

        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");


        private void frHastaLab_Load(object sender, EventArgs e)
        {
            try
            {
                label2.Text = frHasta.idx;
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                SqlCommand listele = new SqlCommand("select lab.lab_id,lab.lab_tahlil_id,lab_test_id,testler.test_adi,lab_aciklama,tahliller.tahlil_doktor_id,tahliller.tahlil_hasta_id,tahliller.tahlil_klinik_id,lab.lab_tarih from lab INNER JOIN tahliller on tahliller.tahlil_id=lab_tahlil_id INNER JOIN testler on testler.test_id=lab.lab_test_id where tahliller.tahlil_hasta_id=@id", baglanti);
                listele.Parameters.AddWithValue("@id", label2.Text);
                da = new SqlDataAdapter(listele);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata!! Daha Sonra Tekrar Deneyiniz");

            }
        }
    }
}
