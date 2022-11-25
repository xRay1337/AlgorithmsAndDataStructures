using Algorithms.Models;

int[] srcArray = { 1, 4, 2, 7, 22, 5, 3, 3 };

Console.WriteLine(ArrayToString(srcArray));

Sorter.QuickSort(srcArray);

Console.WriteLine(ArrayToString(srcArray));

static string ArrayToString(int[] array) => string.Join(", ", array);