using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01.Models
{
    public class Product
    {

        public Product(int id, string name, decimal price, DateTime sellDate)
        {
            Id = id;
            Name = name;
            Price = price;
            SellDate = sellDate;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime SellDate { get; set; }
    }
}