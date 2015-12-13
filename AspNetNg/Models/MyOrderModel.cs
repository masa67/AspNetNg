using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetNg.Models
{
    public class MyOrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        [Required]
        public List<MyOrderDetailModel> Details { get; set; }
    }

    public class PostPayQRCodeFuelOrderModel : MyOrderModel {
        public PostPayQRCodeFuelOrderModel() : base() { }
    }
}