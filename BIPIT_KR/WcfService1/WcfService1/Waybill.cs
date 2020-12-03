using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfService1
{
    [DataContract]
    public class Waybill
    {

        [DataMember]
        public DateTime WaybillDate { get; set; }

        [DataMember]
        public int SupplierCode { get; set; }

        [DataMember]
        public int WaybillSum { get; set; }
    }
}