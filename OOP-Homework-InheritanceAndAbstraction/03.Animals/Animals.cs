public abstract class Animal : ISound
{    
    public Animal(string name, int age, Gender gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }

    public abstract void ProduceSound();

    public override string ToString()
    {
        return string.Format("{0} {1} {2}", this.Name, this.Age, this.Gender);
    }
}
