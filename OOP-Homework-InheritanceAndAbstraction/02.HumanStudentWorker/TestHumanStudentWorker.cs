using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanStudentWorker
{
    class TestHumanStudentWorker
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student("Ivan", "Ivanov", "12345"),
                new Student("Petar", "Petrov", "23456"),
                new Student("Goro", "Georgiev", "34567"),
                new Student("Dochka", "Draganova", "45678")
            };

            var sortedStudents = students.OrderBy(student => student.FaultyNumber);

            List<Worker> workers = new List<Worker>()
            {
                new Worker("Petar", "Ivanov", 1000, 8),
                new Worker("Zhelyo", "Ginchev", 150, 7),
                new Worker("Chuck", "Norris", 200000, 1),
                new Worker("Rumen", "Kunev", 300, 8)
            };

            var sortedWorkers = workers.OrderByDescending(worker => worker.MoneyPerHour());

            List<Human> mergedLists = new List<Human>();
            mergedLists.AddRange(sortedStudents);
            mergedLists.AddRange(sortedWorkers);

            var sortedMergedLists = mergedLists.OrderBy(m => m.FirstName).ThenBy(m => m.LastName);
        }
    }
}
