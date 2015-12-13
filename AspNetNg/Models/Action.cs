using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetNg.Models
{
    public class Action
    {
        [Key]
        public Guid ActionId { get; set; }
    }
}