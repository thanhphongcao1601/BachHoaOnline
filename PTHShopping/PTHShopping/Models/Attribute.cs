using System;
using System.Collections.Generic;

#nullable disable

namespace PTHShopping.Models
{
    public partial class Attribute
    {
        public Attribute()
        {
            AttributesPrices = new HashSet<AttributesPrice>();
        }

        public string AttributesId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AttributesPrice> AttributesPrices { get; set; }
    }
}
