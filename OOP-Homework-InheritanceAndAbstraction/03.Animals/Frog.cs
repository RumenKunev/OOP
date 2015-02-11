class Frog : Animal
{
    public Frog(string name, int age, Gender gender)
        : base(name, age, gender)
    {
    }

    public override void ProduceSound()
    {
        System.Console.WriteLine("Kwak, kwak!");
    }
}