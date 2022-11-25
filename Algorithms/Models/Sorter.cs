namespace Algorithms.Models
{
    static public class Sorter
    {

        #region QuickSort
        public static void QuickSort(int[] array) => QuickSort(array, 0, array.Length - 1);

        private static void QuickSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(array, start, end);

                QuickSort(array, start, pivot - 1);
                QuickSort(array, pivot + 1, end);
            }
        }

        private static int Partition(int[] array, int start, int end)
        {
            int position = start;

            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end])
                {
                    Swap(ref array[i], ref array[position]);

                    position++;
                }
            }

            Swap(ref array[end], ref array[position]);

            return position;
        }
        #endregion

        #region BubbleSort
        public static int[] BubbleSort(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j < array.Length; j++)
                    if (array[j] < array[j - 1])
                        Swap(ref array[j], ref array[j - 1]);

            return array;
        }
        #endregion

        private static void Swap(ref int value1, ref int value2) => (value1, value2) = (value2, value1);
    }
}