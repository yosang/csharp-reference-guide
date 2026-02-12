namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string n) : base(n) { }

        public override string Eat()
        {
            // Inheritance is implemented here, the Name property is public 
            return $"{Name} eats and leaves food all over the floor";
        }
    }
}