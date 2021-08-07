using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentPortalAPI.Models
{
    public class Experience
    {
        [Key]
        public Guid id { get; set; }
        public string title { get; set; }
        public string company { get; set; }
        public string location { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
        public string result { get; set; }
        public string description { get; set; }
        public bool currentjob { get; set; }
        public Guid studentid { get; set; }
    }
}