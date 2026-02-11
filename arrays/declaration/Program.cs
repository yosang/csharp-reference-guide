// char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
// char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
// char[] vowels = ['a', 'e', 'i', 'o', 'u'];

class Program
{
    public static void Main()
    {
        sayTheVowels(['a', 'e', 'i', 'o', 'u']);
    }

    public static void sayTheVowels(char[] vowels)
    {
        foreach (char c in vowels)
        {
            System.Console.WriteLine(c);
        }
    }
}