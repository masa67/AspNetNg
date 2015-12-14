using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetNg.Models
{
    public class MyOrderModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        [Required]
        public List<MyOrderDetailModel> Details { get; set; }
    }

    public class PostPayQRCodeFuelOrderModel : MyOrderModel {
        public PostPayQRCodeFuelOrderModel() : base() { }
    }
}