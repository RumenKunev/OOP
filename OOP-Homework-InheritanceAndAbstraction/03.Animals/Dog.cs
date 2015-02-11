class Dog : Animal
{
    public Dog(string name, int age, Gender gender)
        : base(name, age, gender)
    {
    }

    public override void ProduceSound()
    {
        System.Console.WriteLine("I bark at the moon! Ouuuuuu!");
    }
}