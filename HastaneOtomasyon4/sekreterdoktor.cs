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
    public partial class sekreterdoktor : Form
    {
        public sekreterdoktor()
        {
            InitializeComponent();
        }
        sqlbağlan sek = new sqlbağlan();
        private void sekreterdoktor_Load(object sender, EventArgs e)
        {
            //DOKTORLARI LİSTELEME
            DataTable dt2 = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter("select * from doktortablo", sek.baglanti());
            ds.Fill(dt2);
            dataGridView1.DataSource = dt2;
            sek.baglanti().Close();

           //branş
            SqlCommand da = new SqlCommand("select bransad from branstbl", sek.baglanti());
            SqlDataReader dt = da.ExecuteReader();
            while (dt.Read())
            {
                cmbbrans.Items.Add(dt[0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand doktor = new SqlCommand("insert into doktortablo (doktorad, doktorsoyad, doktorbrans, doktortc, doktorsifre)values (@d1,@d2,@d3,@d4,@d5)",sek.baglanti());
            doktor.Parameters.AddWithValue("@d1",txtad.Text);
            doktor.Parameters.AddWithValue("@d2", txtsoyad.Text);
            doktor.Parameters.AddWithValue("@d3", cmbbrans.Text);
            doktor.Parameters.AddWithValue("@d4", msktc.Text);
            doktor.Parameters.AddWithValue("@d5", txtşifre.Text);
            doktor.ExecuteNonQuery();
            sek.baglanti().Close();
            MessageBox.Show("Doktor Tanımlandı");

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbbrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msktc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtşifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand güncel = new SqlCommand("update doktortablo set doktorad=@d1, doktorsoyad=@d2, doktorbrans=@d3, doktorsifre=@d4 where doktortc=@d5", sek.baglanti());
            güncel.Parameters.AddWithValue("@d1", txtad.Text);
            güncel.Parameters.AddWithValue("@d2", txtsoyad.Text);
            güncel.Parameters.AddWithValue("@d3", cmbbrans.Text);
            güncel.Parameters.AddWithValue("@d4", txtşifre.Text);
            güncel.Parameters.AddWithValue("@d5", msktc.Text);
            güncel.ExecuteNonQuery();
            sek.baglanti().Close();
            MessageBox.Show("Güncelleme Tamamlandı");
        }
    }
}
