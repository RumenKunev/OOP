class Cat : Animal
{
    public Cat(string name, int age, Gender gender)
        : base(name, age, gender)
    {
    }

    public override void ProduceSound()
    {
        System.Console.WriteLine("Myauuuuuu!");
    }

    public override string ToString()
    {
        return string.Format("{0} {1} {2}", this.Name, this.Age, this.Gender);
    }
}
