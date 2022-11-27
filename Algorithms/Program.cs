using Algorithms.Models;
                                                //0, 1, 2, 3, 4, 5, 6, 7
int[] intArray = { 4, 1, 2, 7, 22, 5, 3, 3 };   //1, 2, 3, 3, 4, 5, 7, 22
string[] strArray = { "Оксана", "Александр", "София", "Виталий" };

var srcArray = intArray;

Console.WriteLine(ArrayToString(srcArray));

Sorter.QuickSort(srcArray);

Console.WriteLine(ArrayToString(srcArray));

//int i = Searcher.BinarySearch(intArray, 4);

//for(int i = 0; i < 25; i++)
Console.WriteLine(Searcher.LinearSearch(intArray, -1));
Console.WriteLine(Searcher.LinearSearch(intArray, 0));
Console.WriteLine(Searcher.LinearSearch(intArray, 1));
Console.WriteLine(Searcher.LinearSearch(intArray, 2));
Console.WriteLine(Searcher.LinearSearch(intArray, 3));
Console.WriteLine(Searcher.LinearSearch(intArray, 4));
Console.WriteLine(Searcher.LinearSearch(intArray, 5));
Console.WriteLine(Searcher.LinearSearch(intArray, 7));
Console.WriteLine(Searcher.LinearSearch(intArray, 22));
Console.WriteLine(Searcher.LinearSearch(intArray, 23));
//Searcher.BinarySearch(intArray, i);
//Console.WriteLine(i); 

static string ArrayToString<T>(T[] array) => string.Join(", ", array);