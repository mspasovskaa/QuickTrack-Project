using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProektSept.Models
{
    public class BillsFees
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Month { get; set; }
        public int Price { get; set; }
    }
}