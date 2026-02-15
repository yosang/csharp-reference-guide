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
    - [using directive](#using-directive)
- [Object Oriented Programming](#object-oriented-programming)
- [class](#class)
  - [visibility/access modifiers](#visibilityaccess-modifiers)

# About
This repo will serve as personal notes and quick reference guide for stuff that I pick up as I learn C#.

Goes nicely with [c-sharp-katas](https://github.com/yosang/c-sharp-katas) repo, for some hands-on problem solving with C#.

Its not meant to be a C# learn the basics...

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
    - A project that has top-level statements will ignore the `Main` method, with a warning.

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
- Accessing `char` is read-only.
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
    - Like indices, we also got a `Range` type
    - `Range firstTwoItems = 0..2;`
    - `int[] sliced = myArr[firstTwoItems];` - Gets us 1 and 2
- We can combine both indices and ranges aswell
    - `int[] sliced = myArr[^2..^1];` - Gets 4 - starting from -2 upto and not inclusive -1

## Modifiers

### Parameter modifiers
- To refresh my memory, **parameters** define the set of **arguments** that has to be provided when calling a method.
    - `foo(8)` - 8 is an arguments
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
        int cityNumber = 1; // Bergen
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
    int cityNumber = 1; // Bergen
    string cityName = cityNumber switch
    {
        0 => "Stavanger",
        1 => "Bergen",
        _ => "Oslo"
    };

    System.Console.WriteLine(cityName); // Bergen
    ```
## namespaces
- Namespaces are domains where type names must be unique.
- Types are organized into hierarchical name spaces.
- The `WriteLine` method is a method of then namespace `System.Console`.
- We can create namespaces with the `namespace` keyword.
- The dots in a namespace represents the hierarchy.
    ```c#
    namespace Outer
    {
        namespace Inner
        {
            class Animal {}
            class Person {}
        }
    }
    ```
- To refer to a class, we must use its namespace `Outer.Inner.Animal` to access its methods.
- Types not defined in any namespace belong to the `global namespace`.
- `File-scoped` namespaces is when everything in a file belongs a single namespace.
    ```c#
    namespace MyNameSpace; // Everything below belongs to this namespace

    class Animal {} // Belongs to MyNameSpace
    class Person {}
    ```
- File-scoped namespaces cannot be combined with top-level statements in the same file (compiler error).

### using directive
- Imports a namespace and allows us to access everything from it once imported.
- With `using MyNameSpace` on top of a file we can use the `Animal` class without writing out `MyNameSpace.Animal` every time.
- 

# Object Oriented Programming
Classes are commonly used for `OOP` as they provide `Abstraction`, `Polymorphism`, `Inheritance` and `Encapsulation`.

This is the heart of `C#`.

- **Abstraction**: Hides unnecessary implementation details from outside of the class.
- **Polymorphism**: Instances of a class can have the same methods, but with different behavior.
- **Inheritance**: Allows an instance of a class to inherit attributes and methods from an existing class.
- **Encapsulation**: Bundles methods and fields into a single unit (class). Allowing modifiers to define the access to each and one of those.

# class
- A `class` consists of attributes and modifiers and class members.
    - attributes allow us to add metadata to classes, fields and methods.
    - modifiers allow us to control the access of classes: `public`, `internal`, `static`...
    - class members are such as `fields`, `methods`, `constructors`...
- A `field` is a variable.
    - a field can have a `readonly` modifier to prevent it from being modified after construction.
- A `method` performs an action in a series of statements.
    - a method can receive data from the caller by specifying `parameters` and send back data to the caller using a `return` type.
    - a method can specify a `void` return type, meaning it wont send anything back to the caller.
    - a method can also access its outside world by using `ref` and `out` parameters.
- A `constructor` is simply a `method`, but named after the class name.
    - The constructor is used to run initialization code on new instances of a class.
    - When designing the constructor we dont give it a return type, because its purpose is to run code on initiation.
    ```c#
    Animal myPet = new Animal("Ella");

    myPet.Bark(); // Woof

    public class Animal
    {
        public string name; // Field

        public Animal(string n) // The constructor, takes a string
        {
            name = n; // Assigns n to name.
        }

        public void Bark()
        {
            Console.WriteLine("Woof");
        }
    }
    ```
    - If we dont design a constructor on a class, the class will automatically implement a `parameterless-constructor`.
    - if the baseclass has a parameterless constructor, the compiler inserts `: base()` automatically for subclasses.
        - otherwise we must explicitly call `: base(..)`


## visibility/access modifiers
- The `public` modifier exposes class members to other classes.
    - by default: 
        - top-level types = `internal` (Access is limited to the current project/assembly where it is defined)
        - members (fields, methods…) = `private`
- The `static` allows us to use fields, methods only as part of a class itself and not an instance of it.
    - If a class is marked `static`, it cannot be instantiated, meaning we cant create instances of it, all the members of this class must also be marked `static`. 
    - See [example:](./class-modifiers/Program.cs)
- The `virtual` modifier allows subclasses of a class to modify a method. This enables `polymorphism`.
    - When overriding on a subclass, we must use the `override` modifier on it.
    - See [example](./oop/inheritance/Program.cs)
- The `required` modifier can reduce the need for a class constructor, but this means every class instance will require this field to be assigned.
    - Constructors can still exist (and can be marked [SetsRequiredMembers] to satisfy the requirement)
    - Introduced in C# 11. Useful with object initializers:` new Person { Name = "Alice" };` where Name is required.

# interfaces
...

# delegates
...

# events
...
# attributes
...
