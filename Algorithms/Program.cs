using Algorithms.Models;

int[] intArray = { 4, 1, 2, 7, 22, 5, 3, 3 };
string[] strArray = { "Оксана", "Александр", "София", "Виталий" };

var srcArray = intArray;

Console.WriteLine(ArrayToString(srcArray));

Sorter.SelectionSort(srcArray);

Console.WriteLine(ArrayToString(srcArray));

static string ArrayToString<T>(T[] array) => string.Join(", ", array);