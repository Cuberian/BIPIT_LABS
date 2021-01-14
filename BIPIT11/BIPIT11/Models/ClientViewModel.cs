using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIPIT11.Models
{
    public class ClientViewModel
    {
        public ClientViewModel(int id, string fullname, string email)
        {
            client_id = id;
            client_fullname = fullname;
            client_email = email;
        }
        public int client_id { get; set; }
        public string client_fullname { get; set; }
        public string client_email { get; set; }
    }
}