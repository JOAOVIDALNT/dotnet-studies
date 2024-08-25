using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _09_comentarios_e_boas_praticas.Models
{
    /// <summary>
    /// Represents a person - hit /// to create a summary
    /// </summary>
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }


        /// <summary>
        /// Person present herself, saying name and age
        /// </summary>
        public void Present() 
        {
            Console.WriteLine($"Hello, my name is {name} and I'm {age} year old");
        }

        /// <summary>
        /// sum 2 numbers
        /// </summary>
        /// <param name="x">first number to sum</param>
        /// <param name="y">second number to sum</param>
        public void testeComment(int x, int y)
        {
            Console.WriteLine($"{x} + {y}");
        }
        
        /// <summary>
        /// sum 2 numbers and return
        /// </summary>
        /// <param name="x">first number to sum</param>
        /// <param name="y"> second number to sum</param>
        /// <returns>return the sum of x and y</returns>
        public int testeComment2(int x, int y)
        {
            return x + y;
        }
    }
}