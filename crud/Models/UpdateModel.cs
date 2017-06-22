using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;


namespace crud.Models
{
    public class UpdateModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "name")]
        public string name { get; set; }
        [Required]
        public int age { get; set; }
        public int Update(string id, string name, string age)
        {
            int i;
            using (SqlConnection con = new SqlConnection("Data Source=DD-PC;Initial Catalog=DB_VINAYAK;User Id=sa;Password=123;"))
            {
                using (SqlCommand c = new SqlCommand("update Table2 set name='" + name + "',age='" + int.Parse(age) + "' where id='" + int.Parse(id)+"'", con))
                {
                    con.Open();
                    i= c.ExecuteNonQuery();
                    return i;
                }
            }
        }
    }
}