using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace sistem_analiz_proje
{
    class sqlbaglantisi
    {
        //Data Source = MUHAMMET\SQLEXPRESS;Initial Catalog = DboGarajOtomasyon; Integrated Security = True
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=MUHAMMED\SQLEXPRESS;Initial Catalog=DboGarajOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
