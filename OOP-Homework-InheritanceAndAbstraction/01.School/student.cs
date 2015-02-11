using System;

public class Student : Person
{
    private int classNumber;

    public Student(string name, int classnumber, string details = null)
        : base(name, details)
    {
        this.ClassNumber = classnumber;
    }

    public int ClassNumber
    {
        get
        {
            return this.classNumber;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentNullException();
            }
            this.classNumber = value;
        }
    }

    public override string ToString()
    {
        return base.Name + " -> Nr." + this.ClassNumber + this.Details;
    }

}

