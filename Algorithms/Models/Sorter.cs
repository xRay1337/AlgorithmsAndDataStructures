namespace Algorithms.Models
{
    static public class Sorter
    {
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