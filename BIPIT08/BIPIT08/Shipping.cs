using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIPIT08
{
    public class Shipping
    {
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime ShippingDate { get; set; }
    }
}