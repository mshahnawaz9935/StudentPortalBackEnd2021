using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentPortalBackEnd2021.Data
{
    public class StudentPortalBackEnd2021Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public StudentPortalBackEnd2021Context() : base("name=StudentPortalBackEnd2021Context")
        {
        }

        public System.Data.Entity.DbSet<StudentPortaAPI.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<StudentPortalAPI.Models.Education> Educations { get; set; }
    }
}
