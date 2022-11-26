namespace Algorithms.Models
{
    public static class Searcher
    {
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

        public static int BinarySearch<T>(T[] array, T item) where T : IComparable<T>
        {
            int left = 0;
            int right = array.Length - 1;
            int mid;
            int index = -1;

            while (left <= right)
            {
                mid = (right + left) / 2;

                if (array[mid].CompareTo(item) == 0)
                {
                    index = mid;
                    break;
                }

                if (array[mid].CompareTo(item) > 0)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return index;
        }
    }
}