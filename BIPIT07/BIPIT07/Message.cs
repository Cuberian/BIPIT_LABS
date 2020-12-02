using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BIPIT07
{
    [DataContract]
    public class Message
    {
        [DataMember(Name = "UserId", Order = 1)]
        public int UserId { get; set; }

        [DataMember(Name = "UserName", Order = 2)]
        public string UserName { get; set; }

        [DataMember(Name = "Text", Order = 3)]
        public string Text { get; set; }

        [DataMember(Name = "SendTime", Order = 4)]
        public DateTime SendTime { get; set; }

    }
}
