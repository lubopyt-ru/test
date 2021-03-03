using System;
using System.Collections.Generic;

namespace ASP.NET_Core_3._1_Test
{
    public partial class Customers
    {
        public Guid Id { get; set; }
        public string Fio { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime Registration { get; set; }
    }
}
