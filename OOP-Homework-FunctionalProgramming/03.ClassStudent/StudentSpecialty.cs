using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ClassStudent
{
    public class StudentSpecialty
    {
        private string specialtyName;
        private int facultyNumber;

        public StudentSpecialty(string specialtyName, int facultyNumber)
        {
            this.SpecialtyName = specialtyName;
            this.FacultyNumber = facultyNumber;
        }

        public string SpecialtyName { get { return this.specialtyName; } set { this.specialtyName = value; } }
        public int FacultyNumber { get { return this.facultyNumber; } set { this.facultyNumber = value; } }
    }
}
