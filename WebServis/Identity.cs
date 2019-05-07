using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace WebServis
{
    public class Identity : SoapHeader
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}