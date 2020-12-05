using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIPIT08
{
    public class ShippingView
    {
        public int ShippingId { get; set; }
        public int ClientId { get; set; }
        public string ClientFullname { get; set; }
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public int ServiceCost { get; set; }
        public DateTime ShippingDate { get; set; }
    }
}