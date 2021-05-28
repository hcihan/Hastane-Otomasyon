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
using System.Xml.Linq;
using System.Security.Cryptography;

namespace HastaneOtomasyon4
{
    public partial class hastagüncel : Form
    {
        public hastagüncel()
        {
            InitializeComponent();
        }
        public string tcno;
        sqlbağlan asd1 = new sqlbağlan();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update hastatablo set hastaad=@p1,hastasoyad=@p2,hastasifre=@p3, hastacinsiyet=@p4, hastadoğum=@p5, hastatelefon=@p6 where hastatc=@p7",asd1.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad1.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtşifre.Text);
            komut.Parameters.AddWithValue("@p4", cinsiyet.Text);
            komut.Parameters.AddWithValue("@p5", msktarih.Text);
            komut.Parameters.AddWithValue("@p6", msktelefon.Text);
            komut.Parameters.AddWithValue("@p7", msktc.Text);
            komut.ExecuteNonQuery();
            asd1.baglanti().Close();
            MessageBox.Show("Güncelleme İşlemi Yapılmıştır","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Hide();
        }
        private void hastagüncel_Load(object sender, EventArgs e)
        {
            msktc.Text = tcno;
            SqlCommand komut = new SqlCommand("Select * from hastatablo where hastatc=@p1",asd1.baglanti());
            komut.Parameters.AddWithValue("@p1",msktc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad1.Text = dr[1].ToString();
                txtsoyad.Text= dr[2].ToString();
                msktc.Text= dr[3].ToString();
                txtşifre.Text= dr[4].ToString();
                cinsiyet.Text= dr[5].ToString();
                msktarih.Text= dr[6].ToString();
                msktelefon.Text= dr[7].ToString();
            }
            asd1.baglanti().Close();
        }
    }
}
