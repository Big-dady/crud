using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace crud.Models
{
    public class delete
    {
        public int Delete(int id)
        {
            int i;
            using (SqlConnection cn = new SqlConnection("Data Source=DD-PC;Initial Catalog=DB_VINAYAK;User Id=sa;Password=123;"))
            {


                using (SqlCommand cmd = new SqlCommand("Delete From Table2 Where id=" + id, cn))
                {
                    cn.Open();
                    i = cmd.ExecuteNonQuery();
                    return i;
                }
            }
        }
    }
}