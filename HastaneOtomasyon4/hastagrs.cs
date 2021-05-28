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
    public partial class hastagrs : Form
    {
        public hastagrs()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hastaüyelik üye = new hastaüyelik();
            üye.Show();
            
        }
        sqlbağlan asd = new sqlbağlan();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand giris = new SqlCommand("select * from hastatablo where hastatc=@p1 and hastasifre=@p2",asd.baglanti());
            giris.Parameters.AddWithValue("@p1", hastatc.Text);
            giris.Parameters.AddWithValue("@p2", hastasifre.Text);
            SqlDataReader dr = giris.ExecuteReader();
            if (dr.Read())
            {
                hastadetay hasta = new hastadetay();
                hasta.tc = hastatc.Text;
                hasta.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen Tekrar Deneyiniz veya Üye Olunz.","Dikkat",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            asd.baglanti().Close();
        }
    }
}
