using System;
using System.Collections.Generic;

public class Class
{
    private string identifier;
    private IList<Teacher> teachers = new List<Teacher>();

    public Class(string id, IList<Teacher> teachers)
    {
        this.Identifier = id;
        this.Teachers = teachers;
    }

    public string Identifier
    {
        get
        {
            return this.identifier;
        }
        set 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException();
            }
            this.identifier = value;
        }
    }

    public IList<Teacher> Teachers { get; set; }
}

