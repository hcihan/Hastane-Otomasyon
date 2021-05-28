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
    public partial class hastaüyelik : Form
    {
        public hastaüyelik()
        {
            InitializeComponent();
        }

        private void hastaüyelik_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hastagrs geri = new hastagrs();
            geri.Show();
            this.Hide();
        }
        sqlbağlan hstgrs = new sqlbağlan();
       
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into hastatablo(hastaad, hastasoyad, hastatc, hastasifre, hastacinsiyet,hastatelefon,hastadoğum)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)",hstgrs.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktc.Text);
            komut.Parameters.AddWithValue("@p4", txtşifre.Text);
            komut.Parameters.AddWithValue("@p5", cinsiyet.Text);
            komut.Parameters.AddWithValue("@p6", msktelefon.Text);
            komut.Parameters.AddWithValue("@p7", msktarih.Text);
            komut.ExecuteNonQuery();
            hstgrs.baglanti().Close();
            MessageBox.Show("Kaydınız Tamamlanmıştır", "Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
