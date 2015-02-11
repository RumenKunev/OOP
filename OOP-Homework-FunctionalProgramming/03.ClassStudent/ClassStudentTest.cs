using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ClassStudent
{
    class ClassStudentTest
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student> 
            {
                new Student("Ivan", "Ivanov", 22, 123414, "0887887887", "ivan@yahoo.com", new List<double> {4.5, 5, 6}, 1, "Alfa"),
                new Student("Petar", "Petrov", 25, 234513, "0887888888", "petar@abv.bg", new List<double> {3.5, 5.5, 4}, 2, "Beta"),
                new Student("Goro", "Georgiev", 19, 345214, "+3592877987", "goro@yahoo.com", new List<double> {4, 3.5, 5}, 3, "Beta"),
                new Student("Mladen", "Mladenov", 29, 456312, "0887222222", "Mlado@gmail.com", new List<double> {5, 6, 6}, 1, "Alfa"),
                new Student("Maria", "Ivanova", 20, 523413, "08874444444", "mara@yahoo.com", new List<double> {4.5, 5, 6}, 2, "Alfa"),
                new Student("Kamelia", "Ivanova", 21, 678014, "0887444333", "kami@abv.bg", new List<double> {3, 2, 2, 6}, 3, "Alfa")
            };

            var studentsFromGroup2 =
                from student in studentsList
                where student.GroupNumber == 2
                select student;

            //var studentsFromGroup2 = studentsByDescendingNamestudentsList.Where(student => student.GroupNumber == 2)
            //.OrderBy(student => student.FirstName);

            foreach (var student in studentsFromGroup2)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();

            var studentsByFirstLastName =
                from student in studentsList
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            //var studentsByFirstLastName =studentsList.Where(student => student.FirstName.CompareTo(student.LastName) < 0);

            foreach (var student in studentsByFirstLastName)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();

            var studentsAgeBetween18And24 = studentsList
                .Where(student => student.Age >= 18 && student.Age <= 24)
                .Select(student => new { 
                    FirstName = student.FirstName, 
                    LastName = student.LastName, 
                    Age = student.Age 
                });

            foreach (var student in studentsAgeBetween18And24)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();

            var studentsByDescendingName = studentsList.OrderByDescending(student => student.FirstName)
                .ThenByDescending(student => student.LastName);

            //var studentsByDescendingName =
            //    from student in studentsList
            //    orderby student.FirstName descending, student.LastName descending
            //    select student; 

            foreach (var student in studentsByDescendingName)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();

            var studentsByEmailDomain =
                from student in studentsList
                where student.Email.Contains("@abv.bg")
                select student;

            foreach (var student in studentsByEmailDomain)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();

            var studentsByPhone =
                from student in studentsList
                where student.Phone.StartsWith("02") ||
                    student.Phone.StartsWith("+3592") ||
                    student.Phone.StartsWith("+359 2")
                select student;

            foreach (var student in studentsByPhone)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();

            var studentsWithExcellence = studentsList.Where(student => student.Marks.Contains(6))
                .Select(student => new { 
                    FullName = student.FirstName + " " + student.LastName, Marks = string.Join(", ", student.Marks) });

            foreach (var student in studentsWithExcellence)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();

            var weakStudents = studentsList.Where(student => student.Marks.Where(mark => mark == 2).Count() == 2);
            //var weakStudents = studentsList.Where(student => student.Marks.Aggregate(0, (counter, value) => counter + (value == 2 ? 1 : 0)) == 2);

            foreach (var student in weakStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();

            var studentsEnrolled2014 = studentsList.Where(student => student.FacultyNumber.ToString().EndsWith("14"));

            foreach (var student in studentsEnrolled2014)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();

            var studentByGroup = studentsList.GroupBy(student => student.GroupName);

            foreach (var group in studentByGroup)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();

            //var groupedByGroupName = from st in studentsList
            //                        group st by st.GroupName into g
            //                        select new { GroupName = g.Key, students = g.ToList() };

            //Console.WriteLine("\nStudents grouped by GroupName: ");
            //foreach (var item in groupedByGroupName)
            //{
            //    Console.WriteLine(item.GroupName);
            //    Console.WriteLine("\t{0}", string.Join("\n\t", item.students));
            //}

            List<StudentSpecialty> studentSpecialty = new List<StudentSpecialty>()
            {
                new StudentSpecialty("Web Developer", 123414),
                new StudentSpecialty("Web Developer", 234513),
                new StudentSpecialty("QA Engeneer", 345212),
                new StudentSpecialty("PHP Developer", 678014),
                new StudentSpecialty("PHP Developer", 456312),
                new StudentSpecialty("Web Developer", 523413)
            };

            var studentJoinedToSpecialties =
                from student in studentsList
                join specialty in studentSpecialty
                on student.FacultyNumber equals specialty.FacultyNumber
                orderby student.FirstName
                select new { Name = student.FirstName + " " + student.LastName, 
                    FacultyNumber = student.FacultyNumber, 
                    Specialty = specialty.SpecialtyName };
            
            //var joinedResult =
            //    studentsList
            //    .Join(studentSpecialty,
            //    st => st.FacultyNumber,
            //    sp => sp.FacultyNumber,
            //    (st, sp) => new
            //    {
            //        Name = st.FirstName + " " + st.LastName,
            //        FacultyNumber = st.FacultyNumber,
            //        Specialty = sp.SpecialtyName
            //    });
            foreach (var student in studentJoinedToSpecialties)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();
        }
    }
}
