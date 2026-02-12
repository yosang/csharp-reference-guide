using static System.Console;

int x = 10;

// Here x is passed to f by value
// Foo(x);
void Foo(int p) => p++;

// Here x is passed to foo by reference
// FooRef(ref x);
void FooRef(ref int p) => p++; // x is now 11

int.TryParse("123", out int y);
// WriteLine(y);

// Here x is used, but it cannot be modified
// Bar(x);

void Bar(in int p)
{
    // p++; // Wont work, throws an error
    WriteLine(p);
}

FooBar(x, y);

void FooBar(params int[] p)
{
    foreach (int num in p)
    {
        WriteLine(num);
        // 10
        // 123
    }
}