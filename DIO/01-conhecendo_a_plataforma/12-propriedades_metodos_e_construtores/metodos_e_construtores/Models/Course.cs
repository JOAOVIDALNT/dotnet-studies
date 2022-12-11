using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using validacoes_no_get_e_set.Models;

namespace metodos_e_construtores.Models
{
    public class Course
    {
        public string Name { get; set; }
        public List<Person> Students { get; set; }

        public void AddStudent(Person student)
        {
            Students.Add(student);
        }

        public int GetStudentsQuantity()
        {
            int quantity = Students.Count;
            return quantity;
        }

        public bool RemoveStudents(Person student) // retornando com booleanos apenas para exemplificar
        {
            return Students.Remove(student);
        }

        public void GetAllStudents()
        {
            foreach(Person student in Students)
            {
                Console.WriteLine(student.CompleteName);
            }
        }
    

    
}
}