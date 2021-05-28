using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hastagrs gir = new hastagrs();
            gir.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doktorgiris gir = new doktorgiris();
            gir.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sekretergiris gir = new sekretergiris();
            gir.Show();
            this.Hide();
        }
    }
}
