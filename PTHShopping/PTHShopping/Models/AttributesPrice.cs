using System;
using System.Collections.Generic;

#nullable disable

namespace PTHShopping.Models
{
    public partial class AttributesPrice
    {
        public string AttributesPricesId { get; set; }
        public string AttributesId { get; set; }
        public string IdsanPham { get; set; }
        public double? Gia { get; set; }
        public bool? Active { get; set; }

        public virtual Attribute Attributes { get; set; }
    }
}
