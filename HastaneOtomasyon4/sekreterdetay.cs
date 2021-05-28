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

namespace HastaneOtomasyon4
{
    public partial class sekreterdetay : Form
    {
        public sekreterdetay()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbağlan sek2 = new sqlbağlan();
        private void button7_Click(object sender, EventArgs e)
        {
            Form1 asd = new Form1();
            asd.Show();
            this.Hide();
        }

        private void btndoktor_Click(object sender, EventArgs e)
        {
            sekreterdoktor düzen = new sekreterdoktor();
            düzen.Show();
            
        }

        private void btnbrans_Click(object sender, EventArgs e)
        {
            sekreterbrans düzen = new sekreterbrans();
            düzen.Show();
        }

        private void btnrandevu_Click(object sender, EventArgs e)
        {
            sekreterrandevu giris = new sekreterrandevu();
            giris.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void sekreterdetay_Load(object sender, EventArgs e)
        {
            //AD-SOYAD YAZDIRMA
            lbltc.Text = tc;
            SqlCommand komut2 = new SqlCommand("select * from sekretertablo where sekretertc=@p1",sek2.baglanti());
            komut2.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader okur = komut2.ExecuteReader();
            while (okur.Read())
            {
                lblad.Text = okur[1].ToString() + " " + okur[4].ToString();
            }
            sek2.baglanti().Close();

            //BRANŞ LİSTESİ ÇEKME
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select bransad from branstbl",sek2.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            sek2.baglanti().Close();
            //DOKTOR LİSTESİ ÇEKME
            DataTable dt2 = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter("select (doktorad + ' ' + doktorsoyad) as 'Doktorlar',doktorbrans from doktortablo", sek2.baglanti());
            ds.Fill(dt2);
            dataGridView2.DataSource = dt2;
            sek2.baglanti().Close();
            //BRANŞ LİSTESİNİ COMBOBOXA EKLEME
            SqlCommand brans=new SqlCommand("select bransad from branstbl",sek2.baglanti());
            SqlDataReader oku = brans.ExecuteReader();
            while (oku.Read())
            {
                cmbbrans.Items.Add(oku[0]);
            }
            sek2.baglanti().Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand asd = new SqlCommand("insert into randevutablo (randevutarih, randevusaat, randevubrans, randevudoktor) values (@p1,@p2,@p3,@p4)", sek2.baglanti());
            asd.Parameters.AddWithValue("@p1", msktarih.Text);
            asd.Parameters.AddWithValue("@p2", msksaat.Text);
            asd.Parameters.AddWithValue("@p3", cmbbrans.Text);
            asd.Parameters.AddWithValue("@p4", cmbdr.Text);
            asd.ExecuteNonQuery();
            sek2.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdr.Items.Clear();
            cmbdr.Text = "";
            SqlCommand doktor = new SqlCommand("select doktorad,doktorsoyad from doktortablo where doktorbrans=@p1", sek2.baglanti());
            doktor.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dok = doktor.ExecuteReader();
            while (dok.Read())
            {
                cmbdr.Items.Add(dok[0] +" "+ dok[1]);
            }
            sek2.baglanti().Close();
        }

        private void btnoluştur_Click(object sender, EventArgs e)
        {
            SqlCommand duyur = new SqlCommand("insert into duyurutablo (duyuru) values (@p1)", sek2.baglanti());
            duyur.Parameters.AddWithValue("@p1", richTextBox1.Text);
            duyur.ExecuteNonQuery();
            sek2.baglanti().Close();
            MessageBox.Show("Duyuru Başarıyla Oluşturuldu");
        }
    }
}
