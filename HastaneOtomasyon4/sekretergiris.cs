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
    public partial class sekretergiris : Form
    {
        public sekretergiris()
        {
            InitializeComponent();
        }
        sqlbağlan sekr=new sqlbağlan();
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from sekretertablo where sekretertc=@p1 and sekretersifre=@p2", sekr.baglanti());
            komut.Parameters.AddWithValue("@p1", sekretertc.Text);
            komut.Parameters.AddWithValue("@p2", sekretersifre.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                sekreterdetay gir = new sekreterdetay();
                gir.tc = sekretertc.Text;
                gir.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen Tekrar Deneyiniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sekr.baglanti().Close();
        }
    }
}
