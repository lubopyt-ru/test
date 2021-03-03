using System;
using System.Collections.Generic;

namespace ASP.NET_Core_3._1_Test
{
    public partial class Purchases
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalСost { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }

    }
}
