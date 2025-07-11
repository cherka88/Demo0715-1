using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    public partial class CustOrdersDetailResult
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public int Discount { get; set; }
        public decimal ExtendedPrice { get; set; }
    }
}