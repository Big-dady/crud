using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    public class InsertModel
    {[Required]
        [Display(Name="name")]
        public string name{get; set;}
       [Required]
    public int age { get; set; }
        
       public int Insert(string name, int age)
       {
           
           using (SqlConnection cn = new SqlConnection("Data Source=DD-PC;Initial Catalog=DB_VINAYAK;User Id=sa;Password=123;"))
           {
               using (SqlCommand cmd = new SqlCommand("Insert Into Table2  (name,age)Values('" + name + "','" + age + "')", cn))
               {
                   cn.Open();
                   return cmd.ExecuteNonQuery();
               }
           }
       }

    }
}