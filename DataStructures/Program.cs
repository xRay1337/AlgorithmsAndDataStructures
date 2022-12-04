using DataStructures.Collections;
using DataStructures.Enums;

int[] array = { 36, 20, 25, 19, 3, 7, 1, 2, 1 };

var heap = new Heap<int>(array);
heap.AddItem(37);
heap.AddItem(100);
heap.AddItem(1);
heap.AddItem(38);

int heapCount = heap.Count;

Console.WriteLine($"heapCount = {heapCount}. HeapBeforeLoop = {heap}");

Console.WriteLine();


for (int i = 0; i < heapCount; i++)
{
    Console.WriteLine($"ExtractedRoot = {heap.ExtractRoot()}");

    Console.WriteLine($"i = {i}. HeapNow = {heap}");

    Console.WriteLine();

    if (heap.Count <= heapCount / 2 && heap.Sort == OrderBy.Desc)
    {
        Console.WriteLine("-------Change sort-------");
        Console.WriteLine();
        heap.Sort = OrderBy.Asc;
    }
}


//Console.WriteLine(heap);

//Console.WriteLine(heap.ExtractRoot());

//Console.WriteLine(heap);

//Console.WriteLine(heap.ExtractRoot());

//Console.WriteLine(heap);

//Console.WriteLine(heap.ExtractRoot());

//Console.WriteLine(heap);
