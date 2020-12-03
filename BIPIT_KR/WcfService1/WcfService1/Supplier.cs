using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfService1
{
    [DataContract]
    public class Supplier
    {
        [DataMember]
        public int SupplierCode { get; set; }

        [DataMember]
        public string SupplierName { get; set; }
    }
}