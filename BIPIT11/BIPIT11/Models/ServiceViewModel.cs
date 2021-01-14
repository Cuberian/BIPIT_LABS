using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIPIT11.Models
{
    public class ServiceViewModel
    {
        public ServiceViewModel(int id, string title, int cost)
        {
            service_id = id;
            service_title = title;
            service_cost = cost;
        }

        public int service_id { get; set; }
        public string service_title { get; set; }
        public int service_cost { get; set; }
    }
}