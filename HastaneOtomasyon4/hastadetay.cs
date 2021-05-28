using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon4
{
    public partial class hastadetay : Form
    {
        public hastadetay()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            hastagrs geri = new hastagrs();
            geri.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            hastagüncel güncel = new hastagüncel();
            güncel.tcno = hastatc.Text;
            güncel.Show();

        }
        sqlbağlan asd = new sqlbağlan();
       public  string tc;
        private void hastadetay_Load(object sender, EventArgs e)
        {
            //AD-SOYAD YAZDIRMA
            hastatc.Text = tc;
            SqlCommand komut = new SqlCommand("select hastaad,hastasoyad from hastatablo where hastatc=@p1", asd.baglanti());
            komut.Parameters.AddWithValue("@p1", hastatc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                hastadsoyad.Text = dr[0] + " " + dr[1];
            }
            asd.baglanti().Close();
            //RANDEVU LİSTESİ
            DataTable ran = new DataTable();
            SqlDataAdapter ran1 = new SqlDataAdapter("select *from randevutablo where hastatc="+tc,asd.baglanti());
            ran1.Fill(ran);
            dataGridView1.DataSource = ran;

            //BRANŞ EKLEME
            SqlCommand giris = new SqlCommand("select bransad from branstbl", asd.baglanti());
            SqlDataReader oku = giris.ExecuteReader();
            while (oku.Read())
            {
                drbrans.Items.Add(oku[0]);
            }
            asd.baglanti().Close();
        }
        private void drbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            drad.Items.Clear();
            SqlCommand yeni = new SqlCommand("Select doktorad,doktorsoyad from doktortablo where doktorbrans=@p1", asd.baglanti());
            yeni.Parameters.AddWithValue("@p1", drbrans.Text);
            SqlDataReader oku1 = yeni.ExecuteReader();
            while (oku1.Read())
            {
                drad.Items.Add(oku1[0] +" "+ oku1[1]);
            }
            asd.baglanti().Close();
        }

        private void drad_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable da = new DataTable();
            SqlDataAdapter dt = new SqlDataAdapter("Select * from randevutablo where randevubrans='"+drbrans.Text+"' and randevudurum=0",asd.baglanti());
            dt.Fill(da);
            dataGridView2.DataSource = da;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand rand = new SqlCommand("update randevutablo set randevudurum=1, hastatc=@p2,sikayet=@p3 where randevuid=@p4",asd.baglanti());
            rand.Parameters.AddWithValue("@p2", hastatc.Text);
            rand.Parameters.AddWithValue("@p3", lblsikayet.Text);
            rand.Parameters.AddWithValue("@p4", textBox1.Text);
            rand.ExecuteNonQuery();
            asd.baglanti().Close();
            MessageBox.Show("Randevunuz Alınmıştır");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();

        }
    }
}
