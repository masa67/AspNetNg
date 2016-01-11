using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetNg.Models
{
    public class TravelRequest
    {
        [Key]
        public int RequestID { get; set; }

        [ForeignKey("Resource")]
        public int? ResourceID { get; set; }

        public Resource Resource { get; set; }
    }

    public class Resource
    {
        [Key]
        public int ResourceID { get; set; }

        public string ResourceName { get; set; }

    }
}