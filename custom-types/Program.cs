using System;

namespace MyCustomType
{
    public class App
    {
        public static void Main()
        {
            UnitConverter feetToInches = new UnitConverter(12);

            Console.WriteLine(feetToInches.Convert(30));
        }
    }
    public class UnitConverter
    {
        int ratio; // This a field/attribute

        public UnitConverter(int unitRatio) // This method serves as the contrusctor
        {
            ratio = unitRatio;
        }

        public int Convert(int unit) // Method that returns an int
        {
            return unit * ratio;
        }
    }
}