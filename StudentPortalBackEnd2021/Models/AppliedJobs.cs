﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentPortalAPI.Models
{
    public class AppliedJobs
    {
        public Guid id { get; set; }
        public string studentid { get; set; }
        public string companyid { get; set; }
        public string jobid { get; set; }
        public string applydate { get; set; }
    }
}