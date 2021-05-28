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
    public partial class doktordetay : Form
    {
        public doktordetay()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbağlan drdetay = new sqlbağlan();
        private void button3_Click(object sender, EventArgs e)
        {
            doktorgiris gir = new doktorgiris();
            gir.Show();
            this.Hide();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 asd = new Form1();
            asd.Show();
            this.Hide();
        }

        private void doktordetay_Load(object sender, EventArgs e)
        {
            doktortc.Text = tc;
            SqlCommand dr = new SqlCommand("select * from doktortablo where doktortc=@p1", drdetay.baglanti());
            dr.Parameters.AddWithValue("@p1", doktortc.Text);
            SqlDataReader dr1 = dr.ExecuteReader();
            while (dr1.Read())
            {
                doktorad.Text = dr1[1].ToString() + " " + dr1[2].ToString();
            }
            drdetay.baglanti().Close();

            DataTable ran = new DataTable();
            SqlDataAdapter ran1 = new SqlDataAdapter("select *from randevutablo where randevudoktor='"+doktorad.Text+"'",drdetay.baglanti());
            ran1.Fill(ran);
            dataGridView3.DataSource = ran;
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView3.SelectedCells[0].RowIndex;
            hastatc.Text = dataGridView3.Rows[secilen].Cells[6].Value.ToString();
            txtşikayet.Text = dataGridView3.Rows[secilen].Cells[7].Value.ToString();


        }
    }
}
