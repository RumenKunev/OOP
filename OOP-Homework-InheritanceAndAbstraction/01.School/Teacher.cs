using System;
using System.Collections.Generic;

public class Teacher : Person
{
    IList<Discipline> disciplines = new List<Discipline>();

    public Teacher(string name, IList<Discipline> disciplines, string details = null)
        : base(name, details = null)
    {
        this.Disciplines = disciplines;
    }

    public IList<Discipline> Disciplines { get; set; }

    public override string ToString()
    {
        return this.Name + "->" + string.Join(", ", this.Disciplines) + this.Details;
    }
}