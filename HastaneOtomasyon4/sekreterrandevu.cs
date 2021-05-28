using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneOtomasyon4
{
    public partial class sekreterrandevu : Form
    {
        public sekreterrandevu()
        {
            InitializeComponent();
        }
        sqlbağlan sek4 = new sqlbağlan();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sekreterrandevu_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from randevutablo", sek4.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            sek4.baglanti().Close();
        }
    }
}
