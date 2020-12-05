using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BIPIT08
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public ShippingView[] GetShippings(DateTime? startDate = null, DateTime? endDate = null)
        {
            List<ShippingView> shippings = new List<ShippingView>();

            using (bipitpjEntities db = new bipitpjEntities())
            {
                var order = db.View_3;
                foreach (var item in order)
                {
                    ShippingView shipping = new ShippingView
                    {
                        ShippingId = item.shipping_id,
                        ClientId = item.client_id,
                        ClientFullname = item.client_fullname,
                        ServiceId = item.service_id,
                        ServiceTitle = item.service_title,
                        ServiceCost = item.service_cost,
                        ShippingDate = DateTime.Parse(item.shipping_date.ToString()),
                    };

                    if(startDate != null && endDate != null )
                    {
                        if(shipping.ShippingDate >= startDate && shipping.ShippingDate <= endDate)
                        {
                            shippings.Add(shipping);
                        }
                    }
                    else
                    {
                        shippings.Add(shipping);
                    }    
                }            
            }

            return shippings.ToArray();
        }

        public void DeleteShipping(int id)
        {
            using (bipitpjEntities db = new bipitpjEntities())
            {
                var shippings = db.Shippings;
                Shippings shippingDelete = db.Shippings.Where(x => x.shipping_id == id).FirstOrDefault();
                if (shippingDelete != null)
                {
                    db.Shippings.Remove(shippingDelete);
                    db.SaveChanges();
                }
            }
        }

        public void AddShipping(int clientId, int serviceId, DateTime shippingDate)
        {
            using (bipitpjEntities db = new bipitpjEntities())
            {
                    var shippings = db.Shippings;
                    Shippings shipping = new Shippings
                    {
                        client_id = clientId,
                        service_id = serviceId,
                        shipping_date = shippingDate,
                    };
                    shippings.Add(shipping);
                    db.SaveChanges();
            }
        }

        public Client[] getClients()
        {
            List<Client> clients = new List<Client>();
            using (bipitpjEntities db = new bipitpjEntities())
            {
                var clientRecords = db.Clients;
                foreach (var item in clientRecords)
                {
                    Client client = new Client
                    {
                        ClientId = item.client_id,
                        ClientFullname = item.client_fullname,
                    };

                    clients.Add(client);
                }
            }

            return clients.ToArray();
        }

        public Service[] getServices()
        {
            List<Service> services = new List<Service>();
            using (bipitpjEntities db = new bipitpjEntities())
            {
                var serviceRecords = db.Services;
                foreach (var item in serviceRecords)
                {
                    Service service = new Service
                    {
                        ServiceId = item.service_id,
                        ServiceTitle = item.service_title,
                    };

                    services.Add(service);
                }
            }

            return services.ToArray();
        }
    }
}
