using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentPortaAPI.Models
{
    public class Student
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string college { get; set; }
        public string result { get; set; }
        public string summary { get; set; }
    }
}