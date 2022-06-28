using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProektSept.Models
{
    public class FoodDrinks
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}