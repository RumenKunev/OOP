using System;
using System.Collections.Generic;

public class Discipline
{
    private string name;
    private int numberOfLectures;
    IList<Student> students = new List<Student>();

    public Discipline(string name, int numberOfLectures, List<Student> students)
    {
        this.Name = name;
        this.NumberOfLectures = numberOfLectures;
        this.Students = students;
    }

    public string Name { get; set; }
    public int NumberOfLectures { get; set; }
    public IList<Student> Students { get; set; }

    public override string ToString()
    {
        return this.Name;
    }
}


