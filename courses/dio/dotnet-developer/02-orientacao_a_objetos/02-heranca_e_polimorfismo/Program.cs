using _02_heranca_e_polimorfismo.Models;


Student s1 = new Student();
s1.Name = "João";
s1.Age = 22;
s1.Grade = 8;
s1.Present();

Teacher t1 = new Teacher();
t1.Name = "Giulia";
t1.Age = 19;
t1.Salary = 2200M;
t1.Present();