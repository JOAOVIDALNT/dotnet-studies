using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01.Models
{
    public class FileReader
    {

        // Método que retorna 3 valores ao invés de apenas com usando Tuplas
        public (bool Success, string[] Lines, int LinesCount) FileRead(string path) 
        {
            try 
            {
                string[] lines = File.ReadAllLines(path);

                return (true, lines, lines.Count());

            }
            catch(Exception e) 
            {
                return (false, new String[0], 0);
            }
        }
    }
}