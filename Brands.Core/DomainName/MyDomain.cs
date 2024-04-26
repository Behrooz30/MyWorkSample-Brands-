using System;
using System.Collections.Generic;
using System.Text;

namespace Brands.Core.DomainName
{
    public static class MyDomain
    {
        public static string Domain = Environment.GetEnvironmentVariable("APP_DOMAIN");
        public static string My_2nd_DomainName = "http://localhost:44360";      
        public static string My_3th_DomainName = "172.17.0.1:80";                      

    }
}
