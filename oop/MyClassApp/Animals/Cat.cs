namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string n) : base(n) { }

        public override string Eat()
        {
            return base.Eat() + " and does not leave a mess";
        }
    }
}