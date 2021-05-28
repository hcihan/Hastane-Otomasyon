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
    public partial class doktorgiris : Form
    {
        public doktorgiris()
        {
            InitializeComponent();
        }
        sqlbağlan asdf = new sqlbağlan();
       
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand doktor = new SqlCommand("select * from doktortablo where doktortc=@p1 and doktorsifre=@p2",asdf.baglanti());
            doktor.Parameters.AddWithValue("@p1", doktortc.Text);
            doktor.Parameters.AddWithValue("@p2", doktorsifr.Text);
            SqlDataReader dr = doktor.ExecuteReader();
            if (dr.Read())
            {
                doktordetay detay = new doktordetay();
                detay.tc = doktortc.Text;
                detay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kimlik veya Şifre");
            }
           
        }
    }
}
