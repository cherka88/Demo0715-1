using Entity.Models;
using System.Collections.Generic;

namespace Website.Models
{
    public class OrderViewModel
    {
        public string CustomerId { get; set; }
        public List<CustOrdersOrdersResult> Orders { get; set; }
        public List<CustOrdersDetailResult> OrderDetails { get; set; }
    }
}