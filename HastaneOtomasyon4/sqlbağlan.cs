using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HastaneOtomasyon4
{
    class sqlbağlan
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source = DESKTOP-PR0I5AF\\SQLEXPRESS02; Initial Catalog = hastaneotomasyon; Integrated Security = True");
            baglan.Open();
            return baglan;
        }

    }
}
