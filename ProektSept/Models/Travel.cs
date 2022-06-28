using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProektSept.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public string Where { get; set; }
        public string Period { get; set; }
        public int Cost { get; set; }
    }
}