using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime SellDate { get; set; }
    }
}