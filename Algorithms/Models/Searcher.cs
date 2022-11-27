namespace Algorithms.Models
{
    public static class Searcher
    {
        public static int InterpolationSearch(int[] array, int item)
        {
            int left = 0;
            int right = array.Length - 1;
            int pos;
            int index = -1;

            while (left <= right)
            {
                pos = left + ((item - array[left]) * (right - left) / (array[right] - array[left]));

                if (array[pos] > item)
                {
                    right = pos - 1;
                }
                else if (array[pos] < item)
                {
                    left = pos + 1;
                }
                else
                {
                    index = pos;
                    break;
                }
            }

            return index;
        }

        public static int BinarySearch<T>(T[] array, T item) where T : IComparable<T>
        {
            int left = 0;
            int right = array.Length - 1;
            int pos;
            int index = -1;

            while (left <= right)
            {
                pos = (right + left) / 2;

                if (array[pos].CompareTo(item) > 0)
                {
                    right = pos - 1;
                }
                else if (array[pos].CompareTo(item) < 0)
                {
                    left = pos + 1;
                }
                else
                {
                    index = pos;
                    break;
                }
            }

            return index;
        }

        public static int LinearSearch<T>(T[] array, T item) where T : IComparable<T>
        {
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTo(item) == 0)
                {
                    index = i;
                }
            }

            return index;
        }
    }
}