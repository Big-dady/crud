using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace crud.Models
{
    public class SelectModel
    {
        public DataSet GetAllTable2()
        {
            SqlConnection con = new SqlConnection("Data Source=DD-PC;Initial Catalog=DB_VINAYAK;User Id=sa;Password=123;");
            SqlCommand c = new SqlCommand("select * from Table2",con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(c);
            da.Fill(ds);
            return ds;
        }
    }
}