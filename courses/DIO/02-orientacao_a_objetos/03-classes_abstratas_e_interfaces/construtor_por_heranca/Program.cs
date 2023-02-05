using _02_heranca_e_polimorfismo.Models;


Student s1 = new Student(); // A CLASSE STUDENT POSSUI CONSTRUTOR SEM PARÂMETRO
s1.Name = "João";
s1.Age = 22;
s1.Grade = 8;
s1.Present();

Teacher t1 = new Teacher("Giulia"); // A CLASSE TEACHER NÃO POSSUI CONSTRUTOR SEM PARÂMETRO
// t1.Name = "Giulia";
t1.Age = 19;
t1.Salary = 2200M;
t1.Present();