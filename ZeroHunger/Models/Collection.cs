using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public enum Status { Pending, Approved, Rejected }

    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Food { get; set; }
        public int Quantity { get; set; }
        public int Expiry { get; set; }
        public Status Status { get; set; }
    }
}