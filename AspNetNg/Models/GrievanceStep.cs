using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetNg.Models
{
    public class GrievanceStep
    {
        [Column("GrievanceStepId")]
        public Guid GrievanceStepID { get; set; }
        public Guid? GrievanceID { get; set; }
        [ForeignKey("GrievanceID")]
        public virtual Grievance Grievance { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
        [JsonIgnore]
        public virtual ICollection<ActionDirectory> ActionDirectories { get; set; }
    }
}