using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetNg.Models
{
    public class RootObject
    {
        [Key]
        public int RootObjectId { get; set; }
        public string Name { get; set; }
    }

    [Table("AObjects")]
    public class AObject : RootObject
    {
        public string AField { get; set; }
        //Other fields
    }

    [Table("BObjects")]
    public class BObject : RootObject
    {
        //Other fields
        public string BField { get; set; }
    }
}