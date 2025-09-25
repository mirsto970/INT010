using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.CodeBase
{
    public class CommonParameters
    {
        public string Domain { get; init; }

        public string Company { get; set; }

        public string _4PSSQLConnection { get; set; }

        public string InvoUrl { get; set; }

        public string ImdokUrl { get; set; }

        public CommonParameters(IConfiguration config,string domain)
        {
            Company = config.GetValue<string>($"{domain}:Company");
            _4PSSQLConnection = config.GetValue<string>("4PS:4PSLiveConnectionString");
            Domain = domain;
        }

        public CommonParameters(IConfiguration config)
        {
           
            InvoUrl = config.GetValue<string>("4PS:InvoUrl");
            ImdokUrl = config.GetValue<string>("4PS:ImdokUrl");
           
        }
    }
}
