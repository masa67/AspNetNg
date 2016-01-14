using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetNg.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }

        public ICollection<Group> groups { get; set; }
    }

    public class Group
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }

        public ICollection<User> users { get; set; }
    }
}