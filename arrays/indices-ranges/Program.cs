using System;

int[] myArr = [1, 2, 4, 5];

// int[] sliced = myArr[2..]; // Slices the array from index 2 and to the end (exclusive)
// int[] sliced = myArr[1..2]; // Gets 2
// int[] sliced = myArr[..2]; // Gets 1 and 2
// int[] sliced = myArr[2..]; // Gets 4 and 5

Range firstTwoItems = 0..2;
int[] sliced = myArr[firstTwoItems]; // 1 and 2

foreach (int i in sliced)
{
    Console.WriteLine(i);
}

// int last = myArr[^1]; // Gets the last number
// int last = myArr[^2]; // Gets the seconbd last number
// Console.WriteLine(last);


// Using the Index type
// Index lastItem = ^1;

// Console.WriteLine(myArr[lastItem]);

