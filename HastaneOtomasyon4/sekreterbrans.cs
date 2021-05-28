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
    public partial class sekreterbrans : Form
    {
        public sekreterbrans()
        {
            InitializeComponent();
        }
        sqlbağlan sek3 = new sqlbağlan();
        private void sekreterbrans_Load(object sender, EventArgs e)
        {
            //COMBOXA BRANŞ EKLEME
            SqlCommand brans = new SqlCommand("select bransad from branstbl", sek3.baglanti());
            SqlDataReader oku = brans.ExecuteReader();
            while (oku.Read())
            {
                cmbbrans.Items.Add(oku[0]);
            }
            sek3.baglanti().Close();
            //TABLOYA EKLEME
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select bransid,bransad from branstbl", sek3.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            sek3.baglanti().Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand ekle = new SqlCommand("insert into branstbl (bransad) values(@b1)", sek3.baglanti());
            ekle.Parameters.AddWithValue("@b1", cmbbrans.Text);
            ekle.ExecuteNonQuery();
            sek3.baglanti().Close();
            MessageBox.Show("Branş Başarıyla Eklendi");
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            cmbbrans.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand güncel = new SqlCommand("update branstbl set bransad=@c1 where bransid=@c2", sek3.baglanti());
            güncel.Parameters.AddWithValue("@c1", cmbbrans.Text);
            güncel.Parameters.AddWithValue("@c2", txtid.Text);
            güncel.ExecuteNonQuery();
            sek3.baglanti().Close();
            MessageBox.Show("Güncelleme Tamamlandı");
        }
    }
}
