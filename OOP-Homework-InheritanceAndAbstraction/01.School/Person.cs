using System;

public abstract class Person : IDetailable
{
    private string name;
    private string details;

    public Person(string name, string details = null)
    {
        this.Name = name;
        this.Details = details;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Not a valid name!");
            }
            this.name = value;
        }
    }

    public string Details { get; set; }
}
