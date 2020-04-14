using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServers.Models
{
    public class WeChatOpenIdModel
    {
        public string OpenId { get; set; }
        public string UnionId { get; set; }
        public string UserName { get; set; }
    }
}
