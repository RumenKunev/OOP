using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    class Program
    {

        static void Main()
        {
            Student petar = new Student("Petar Petrov", 889988, "some details");
            Student ivan = new Student("Ivan Ivanov", 990099);

            List<Student> students = new List<Student>() { petar, ivan };

            Discipline oop = new Discipline("Object Oriented Programming", 16, students);
            Discipline hqc = new Discipline("High Quality Code", 20, students);

            List<Discipline> disciplines = new List<Discipline>() { oop, hqc };

            Teacher nakov = new Teacher("Svetlin Nakov", disciplines);
            Teacher karamfilov = new Teacher("Vladi Karamfilov", disciplines);

            List<Teacher> teachers = new List<Teacher>();
            teachers.Add(nakov);
            teachers.Add(karamfilov);

            Class morningGroup = new Class("11.01", teachers);

         }
    }
}
