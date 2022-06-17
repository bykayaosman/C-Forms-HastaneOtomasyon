using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital
{
    public partial class frHastaRecete : Form
    {
        public frHastaRecete()
        {
            InitializeComponent();
        }
        private StringReader myReader;
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-66APTKT;Initial Catalog=HOSPITAL;Integrated Security=True");
        private void frHastaRecete_Load(object sender, EventArgs e)
        {

        }
    }
}
