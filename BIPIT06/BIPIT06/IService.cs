using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BIPIT06
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [DataContract]
    public class Shippings
    {
        [DataMember(Name = "shipping_id", Order = 1)]
        public string ShippingID { get; set; }
        [DataMember(Name = "client_fullname", Order = 2)]
        public string ClientFullname { get; set; }
        [DataMember(Name = "service_title", Order = 3)]
        public string ServiceTitle { get; set; }
        [DataMember(Name = "service_cost", Order = 4)]
        public string ServiceCost { get; set; }
        [DataMember(Name = "shipping_date", Order = 5)]
        public string ShippingDate { get; set; }
    }
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Shippings[] GetData();
        [OperationContract]
        Dictionary<int, string> GetClients();
        [OperationContract]
        Dictionary<int, string> GetServices();
        [OperationContract]
        void NewRec(int client_id, int service_id, DateTime shipping_date);
        [OperationContract]
        bool isHostAlive();
        [OperationContract]
        void GetStatus(string name, string port, string loaclPath, string uri, string scheme);
    }
}
