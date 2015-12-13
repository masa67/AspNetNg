using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetNg.Models
{
    public class MyOrderDetailModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public decimal Amount { get; set; }
    }
}