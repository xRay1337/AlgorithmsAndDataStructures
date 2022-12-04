namespace DataStructures.Interfaces
{
    internal interface IHeap<T> : IEnumerable<T> where T : IComparable<T>
    {
        public void AddItem(T item);

        public T FindRoot();

        public T ExtractRoot();
    }
}