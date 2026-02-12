namespace Animals
{
    public class Animal
    {
        public string Name { get; } // property called Name that can be read, but not modified outside the class.

        public Animal(string n)
        {
            Name = n;
        }

        public virtual string Eat()
        {
            return $"{Name} eats";
        }
    }
}