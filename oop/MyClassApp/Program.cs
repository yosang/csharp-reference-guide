using System;
using Animals;

namespace Program
{
    public class App
    {
        public static void Main()
        {
            // An array of animal types
            Animal[] animals =
            {
              new Animal("Birdie"),
              new Dog("Ella"),
              new Cat("Yoda")
            };

            foreach (Animal a in animals)
            {
                Console.WriteLine(a.Eat());
            }

            // Animal wildAnimal = new Animal("Birdie");
            // Console.WriteLine(wildAnimal.Eat());

            // Dog myPet = new Dog("Ella");
            // Console.WriteLine(myPet.Eat());

            // Cat neighboursPet = new Cat("Yoda");
            // Console.WriteLine(neighboursPet.Eat());
        }
    }
}