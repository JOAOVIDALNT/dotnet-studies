using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _02.Models
{
    public class Product
    {
        public int Id { get; set; }

        // CASO RECEBA UM ARQUIVO JSON COM NOME DIFERENTE SE APLICA UM ATRIBUTO PARA NÃO FUGIR DA CONVENÇÃO DO SEU CÓDIGO EX:
        [JsonProperty("Product_Name")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime SellDate { get; set; }
    }
}