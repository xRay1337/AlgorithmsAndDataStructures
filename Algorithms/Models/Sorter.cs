namespace Algorithms.Models
{
    static public class Sorter
    {
        #region HeapSort

        public static void HeapSort(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                MakeHeap(array, i);
                Swap(ref array[0], ref array[i]);
            }
        }

        private static void MakeHeap(int[] array, int arrayLength)
        {
            for (int i = arrayLength / 2; i >= 0; i--)
            {
                if (2 * i + 1 <= arrayLength && array[i] < array[2 * i + 1])
                {
                    Swap(ref array[i], ref array[2 * i + 1]);
                }

                if (2 * i + 2 <= arrayLength && array[i] < array[2 * i + 2])
                {
                    Swap(ref array[i], ref array[2 * i + 2]);
                }
            }
        }
        #endregion

        #region GnomeSort
        public static void GnomeSort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (i > 0 && array[i - 1].CompareTo(array[i]) > 0)
                {
                    Swap(ref array[i - 1], ref array[i]);
                    i--;
                }
            }
        }
        #endregion

        #region CountingSort
        public static void CountingSort(int[] array, int maxValue = 256)
        {
            int[] counterArray = new int[maxValue];

            for (int i = 0; i < array.Length; i++)
            {
                counterArray[array[i]]++;
            }

            for (int j = 0, k = 0; j < maxValue; j++)
            {
                if (counterArray[j] > 0)
                {
                    array[k] = j;
                    counterArray[j]--;
                    j--;
                    k++;
                }
            }
        }
        #endregion

        #region InsertionSort
        public static void InsertionSort<T>(T[] array) where T : IComparable<T>
        {
            T key;

            for (int i = 1, j; i < array.Length; i++)
            {
                key = array[i];

                for (j = i - 1; j >= 0 && array[j].CompareTo(key) > 0; j--)
                {
                    Swap(ref array[j], ref array[j + 1]);
                }
            }
        }
        #endregion

        #region SelectionSort
        public static void SelectionSort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0, j, minValueId = 0; i < array.Length; i++, minValueId = i)
            {
                for (j = i; j < array.Length; j++)
                {
                    if (array[minValueId].CompareTo(array[j]) > 0)
                    {
                        minValueId = j;
                    }
                }

                Swap(ref array[i], ref array[minValueId]);
            }
        }
        #endregion

        #region QuickSort
        public static void QuickSort<T>(T[] array) where T : IComparable<T>
            => QuickSort(array, 0, array.Length - 1);

        private static void QuickSort<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);

                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);
            }
        }

        private static int Partition<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            int position = left;

            for (int i = left; i < right; i++)
            {
                if (array[right].CompareTo(array[i]) > 0)
                {
                    Swap(ref array[i], ref array[position]);

                    position++;
                }
            }

            Swap(ref array[right], ref array[position]);

            return position;
        }
        #endregion

        #region BubbleSort
        public static void BubbleSort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 1; j < array.Length; j++)
                {
                    if (array[j - 1].CompareTo(array[j]) > 0)
                    {
                        Swap(ref array[j], ref array[j - 1]);
                    }
                }
            }
        }
        #endregion

        private static void Swap<T>(ref T value1, ref T value2)
            => (value1, value2) = (value2, value1);
    }
}