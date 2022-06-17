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
    public partial class frLaboratuvar : Form
    {
        public frLaboratuvar()
        {
            InitializeComponent();
        }


        public static string tahlilid;
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");



        private void frLaboratuvar_Load(object sender, EventArgs e)
        {
            try
            {                
                baglanti.Open();
                SqlCommand görüntüle = new SqlCommand("select lab.lab_id,lab.lab_tahlil_id,lab.lab_test_id,tahliller.tahlil_doktor_id,tahliller.tahlil_hasta_id,tahliller.tahlil_klinik_id from lab INNER JOIN tahliller on tahliller.tahlil_id=lab.lab_tahlil_id where kontrol=1 or kontrol is null", baglanti);

                da = new SqlDataAdapter(görüntüle);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("hata!! lütfen daha sonra tekrar deneyin");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                baglanti.Open();
                SqlCommand a = new SqlCommand("update lab set kontrol=2 where lab_tahlil_id=@idd", baglanti);
                a.Parameters.AddWithValue("@idd", textBox1.Text);
                a.ExecuteNonQuery();
                baglanti.Close();
                frLabSonuc yeni = new frLabSonuc();
                yeni.Show();
            }
            catch
            {
                MessageBox.Show("hata!! lütfen daha sonra tekrar deneyin");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult karar = new DialogResult();
            karar = MessageBox.Show("Çıkış istediğinize emin misiniz ? ", "Uyarı", MessageBoxButtons.YesNo);
            if (karar == DialogResult.Yes)
            {
                this.Hide();
                frGiris yeni = new frGiris();
                yeni.Show();
            }
            else if (karar == DialogResult.No)
            {
                MessageBox.Show("Oturum Kapatılmadı.");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int deger = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            textBox1.Text = deger.ToString();
            tahlilid = textBox1.Text;
        }
    }
}
