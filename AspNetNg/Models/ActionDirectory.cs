using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetNg.Models
{
    public class ActionDirectory
    {
        [Key]
        public Guid ActionID { get; set; }
        [ForeignKey("ActionID")]
        public virtual Action Action { get; set; }
        public Guid DirectoryID { get; set; }
        [ForeignKey("DirectoryID")]
        public virtual Filesystem Directory { get; set; }
        public Guid GrievanceStepID { get; set; }
        [ForeignKey("GrievanceStepID")]
        public virtual GrievanceStep GrievanceStep { get; set; }
    }
}