using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class TestAnimals
    {
        static void Main(string[] args)
        {
            Dog[] dogs = new Dog[]
            {
                new Dog("Balkan", 4, Gender.Male),
                new Dog("Majlo", 3, Gender.Male),
                new Dog("Strashimirka", 7, Gender.Female)
            };

            Frog[] frogs = new Frog[]
            {
                new Frog("Kermit", 2, Gender.Male),
                new Frog("Zhabcho", 4, Gender.Male)
            };

            Kitten[] kittens = new Kitten[]
            {
                new Kitten("Kat", 6),
                new Kitten("Sweety", 0)
            };

            Tomcat[] tomcats = new Tomcat[]
            {
                new Tomcat("Lucky", 7),
                new Tomcat("Tom", 6)
            };

            var dogsAverageAge = dogs.Average(dog => dog.Age);
            Console.WriteLine(dogsAverageAge);

            List<Animal> animals = new List<Animal>
            {
                new Dog("Popi", 4, Gender.Male),
                new Cat("Maca", 3, Gender.Female),
                new Frog("Keri", 5, Gender.Female),
                new Kitten("Mici", 2),
                new Kitten("Maca", 3),
                new Tomcat("Tom", 4),
                new Tomcat("Misho", 3)
            };

            var animalsBygroups = animals.GroupBy(GetAnimalKind,
(g, a) => new { kind = g, averagAge = a.Average(animal => animal.Age) });

            foreach (var animalGroup in animalsBygroups)
            {
                Console.WriteLine("The average age of {0}s is {1:f2}.", animalGroup.kind, animalGroup.averagAge);
            }

        }

        public static string GetAnimalKind(Animal animal)
        {
            string kind = "";
            if (animal.GetType().BaseType.Name == "Animal")
            {
                kind = animal.GetType().Name;
            }
            else
            {
                kind = animal.GetType().BaseType.Name;
            }

            return kind;
        }
    }
}


