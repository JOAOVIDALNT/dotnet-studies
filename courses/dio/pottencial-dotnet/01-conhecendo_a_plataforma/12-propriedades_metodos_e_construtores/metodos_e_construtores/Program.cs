using metodos_e_construtores.Models;
using validacoes_no_get_e_set.Models;


Person p1 = new Person("João", "Vidal");


Person p2 = new Person("Giulia", "Tomé");

Course course = new Course();

course.Name = "English Course";
course.Students = new List<Person>();

Console.WriteLine($"Students at {course.Name}");
course.AddStudent(p1);
course.AddStudent(p2);
course.GetAllStudents();
Console.WriteLine($"Current Students: {course.GetStudentsQuantity()}");














// Person p1 = new Person();
// p1.Age = 22;
// p1.Name = "João";


// p1.Present();