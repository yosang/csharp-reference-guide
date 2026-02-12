# C# Notes and Reference Guide
- [About](#about)
- [Compiler](#compiler)
  - [Top-level statements and Main](#top-level-statements-and-main)
- [Syntax](#syntax)
  - [Types](#types)
    - [Conversion](#conversion)
    - [Value vs Reference](#value-vs-reference)
    - [var keyword](#var-keyword)
    - [target-typed new expressions](#target-typed-new-expressions)
  - [Strings](#strings)
  - [Arrays](#arrays)
    - [Indices and Ranges](#indices-and-ranges)
  - [Modifiers](#modifiers)
    - [Parameter modifiers](#parameter-modifiers)
  - [Null](#null)
  - [Switch](#switch)
  - [namespaces](#namespaces)
    - [visibility/access modifiers](#visibilityaccess-modifiers)

# About
This repo will serve as personal notes and quick reference guide for stuff that I pick up as I learn C#.

Goes nicely with [c-sharp-katas](https://github.com/yosang/c-sharp-katas) repo, for some hands-on problem solving with C#.

Its not meant to be a C# learn the basics, theres course material for that...

# Compiler
- The c# compiler compiles source code (a set of files with the `.cs` extension) into an assembly.
- An assembly is the unit of packaging and deployment in `.NET`.
- An assembly can either be an application (executable) or a library.
    - An executable has an entry point (`Main` or top-level statements), a library does not.
    - The purpose of a library is to be called upon (referenced) and used by other assemblies (applications or other libraries)
    - `.NET` itself is a set of libraries and a runtime environment (CLR, Common Language Runtime) at the same time.

## Top-level statements and Main
- A C# program can use top-level statements (a series of statements).
    - In this case the program itself serves as the main entry point for the application. (C# generates a Main method automatically)
- If a `Main` method is present, C# will use this as the entry point.
    - A project that has top-level statements will ignore the `Main` method, with a.

# Syntax
- C# syntax is inspired by C and C++ syntax.
- **Identifiers** are names we can choose for our classes, methods, variables etc.
    - System, variableName, Console, WriteLine...
    - Whole word of Unicode characters.
    - Can start with a letter or underscore.
    - Case sensitive.
    - By convention, identifiers for parameters or local variables should be written in camelCase while methods and classes in PascalCase.
- **Keywords** are reserved to the compiler, like `using` or `int`.
    - Cannot be used as identifiers.

## Types
- C# is a typed language, meaning we can either use predefined types or create custom ones.
    - Example of predefined types are `int`, `string` etc...
    - To create a custom type we define a class, fields, constructor, and add a method to use it. We can then use that class as a type and instantiate it with `new`. See example [custom-type](./custom-types/Program.cs)
    - A type contains data members and function members. 
        - The data members of UnitConverter is the field `ratio`.
        - The function member of UnitConverter are the constructor and the method `convert`.
    - Data is created when we instantiate a type.
    - The `new` operator creates an instance of a type.
- The `public` keyword exposes members to other classes.
    - If a member is not marked as public, it will be private and cannot be accessed from outside of the class.

### Conversion
- Types can be converted to other types, as long as the types are compatible.
- A conversion always creates new value from existing value when dealing with value types, different for reference types.
- Conversions can either be implicit (done by the compiler) or explicit, we write it out or cast it ourselves.
    - implicit conversion will only happen if the compiler can guarantee that no data will be lost during conversion

### Value vs Reference
- Value types such as numeric, char, bool types etc, are always copied during assignment. Meaning that if we define int x = 7, and int y = x, we can change x but y will still be 7 (copy).
- Reference types such as strings, arrays etc are different, when assigned, we copy the reference to the object itself, meaning that if we mutate the original, the copy will also be affected. 

### var keyword
- The var keyword can be used to instruct the compiler implicitly of a type
    - For example, `var i = 3` - i will implicitly become type `int`.

### target-typed new expressions
- If we already declared a type, we can write `new` without having to repeat the type name. This is target-typed new expression.

## Strings
- Strings are immutable reference type. 
- String interpolation means we can include expressions in the string `$"Some text here and {expression}"` 
- We can search with strings using indexes `str[2]`, for access only, we cant mutate a string.
    - indexOf and lastIndex of are useful, they take a `char` type.
- Every method of a string (because its immutable) returns a new string, leaving the original one untouched.
- To be able to mutate strings we have to access the individual `char` values.
    - [StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-10.0) creates a buffer of char values that can be converted to strings with the `ToString()` method.
    - StringBuilder has some nice methods we can use
        - `Append` - Adds a char at the end of the buffer, it accepts among the following types `char`, `string`, `int`, `double`, `bool`, `char[]`...
        - `Insert` - Inserts a char at a specific index
        -  `Replace` - Replaces a char
        - `ToString` - Converts the entire buffer to a string.
        - `ToString(int startIndex, int length)` to get a substring
        - `Remove(int startIndex, int length)` — deletes characters
        - `Clear()` - Clears everything from the buffer.

## Arrays
- We can declare arrays with fixed sizes, or implicitly `char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' }`, shorthand version: `char[] vowels = { 'a', 'e', 'i', 'o', 'u' }`
- From C#12, we can declare arrays with square brackets aswell `char[] vowels = ['a', 'e', 'i', 'o', 'u'];`
- This is called `collection expression`, and can be used when calling methods `sayTheVowels(['a', 'e', 'i', 'o', 'u']);`
    - Collection expressions works with other collections too `List<string> planets = ["Mercury", "Venus", "Earth", "Mars"]`

### Indices and Ranges
- We can refer to elements in an array using indices (relative to the end of an array).
    - `vowels[^1]` returns `'u'`
    - `vowels[^2]` returns `'o'`
    - The `Index` type allows us to create a variable that is of type index, useful for using that variable when refering to elements in an array.
        - `Index lastItem = ^1` and to use it we just `Console.WriteLine(myArr[lastItem]);`
- We can use ranges to `slice` parts of an array.
    - Example array `int[] myArr = [1, 2, 4, 5];`
    - `int[] sliced = myArr[2..];` - Slices the array from index 2 and to the end (exclusive)
    - `int[] sliced = myArr[1..2]` - Gets 2
    - `int[] sliced = myArr[..2];` - Gets 1 and 2
    - `int[] sliced = myArr[2..];` - Gets 4 and 5
    - Like indices, we also got a `Range` type
    - `Range firstTwoItems = 0..2;`
    - `int[] sliced = myArr[firstTwoItems];` - Gets us 1 and 2
- We can combine both indices and ranges aswell
    - `int[] sliced = myArr[^2..^1];` - Gets 4 - starting from -2 upto and not inclusive -1

## Modifiers

### Parameter modifiers
- To refresh my memory, **parameters** define the set of **arguments** that has to be provided when calling a method.
    - `fo(8)` - 8 is an arguments
    - `static void foo(int p) {...}` - p is a parameter 
- In C#, we can control how parameters are passed with `ref`, `in`, `out` and `params`.
    - `ref` - Passes an argument by reference, the default is that arguments are passed by value (a new variable copy is created).
    - The `ref` keyword is both required when calling and declaring the method. 
        ```c#
        int x = 10;
        
        // Here x is passed to f by value
        Foo(x);
        void Foo(int p) => p++; // p is 11, but x is still 10, because p is a copy
        
        // Here x is passed to foo by reference
        FooRef(ref x);
        void FooRef(ref int p) => p++; // x is now 11

        ```
    - `out` - Works just like ref, but it doesnt need to be assigned before going into the function. However it must be assigned before it comes `out` the function.
        - `int.TryParse("123", out int y);` - We now have a variable y that is of int type and can be used.
    - `in` - Works just like ref, but its readonly, it prevents the reference to be mutated from within a method.
        ```c#
        // Here x is used, but it cannot be modified
        Bar(x);
        void Bar(in int p)
        {
            // p++; // Wont work, throws an error
            WriteLine(p); 
        }
        ```
    - `params` - Allows any number of parameters to be passed
        ```c#
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
        ```
## Null
- `??` - **Null coalescing** - says, if the operand to the left is not null, give it to me, otherwise use the right operand.
- `??=` - **Null assignment** - says, if the operand to the left is null, assign the operand to the right to the left.
- `?.` - **Null conditional** - says, if the property we are trying to access is null, return null and dont throw any errors

## Switch
- classic switch
    ```c#
        int cityNumber = 1; // Stan
        string cityName = cityNumber switch
        {
            0 => "Stavanger",
            1 => "Bergen",
            _ => "Oslo"
        };

        System.Console.WriteLine(cityName); // Bergen
        System.Console.WriteLine(giveMeACity(0)); // Stavanger


        string giveMeACity(int c)
        {
            switch (c)
            {
                case 0:
                    return "Stavanger";
                    break;
                case 1:
                    return "Bergen";
                    break;
                default:
                    return "Oslo";
                    break;
            }
        }
        ;
    ```
- switch expressions
    ```c#
    int cityNumber = 1; // Stan
    string cityName = cityNumber switch
    {
        0 => "Stavanger",
        1 => "Bergen",
        _ => "Oslo"
    };

    System.Console.WriteLine(cityName); // Bergen
    ```
## namespaces
...

### visibility/access modifiers
...