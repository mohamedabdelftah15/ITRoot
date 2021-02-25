using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITRoot_Task.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public string InvoiceNumber { get; set; }
        public string Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int? UserID { get; set; }
    }
}