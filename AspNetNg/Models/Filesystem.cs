using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetNg.Models
{
    public class Filesystem
    {
        [Key, Column("DirectoryID")]
        public Guid DirectoryID { get; set; }
        [JsonIgnore]
        [ForeignKey("ActionID")]
        public virtual ICollection<ActionDirectory> ActionDirectories { get; set; }
    }
}