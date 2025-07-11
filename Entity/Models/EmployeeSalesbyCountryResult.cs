﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    public partial class EmployeeSalesbyCountryResult
    {
        [StringLength(15)]
        public string Country { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(10)]
        public string FirstName { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int OrderID { get; set; }
        [Column("SaleAmount", TypeName = "money")]
        public decimal? SaleAmount { get; set; }
    }
}
