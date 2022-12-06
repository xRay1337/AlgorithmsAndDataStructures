using DataStructures.Enums;
using System.Collections;

namespace DataStructures.Collections
{
    public class Heap<T> : IEnumerable<T> where T : IComparable<T>
    {
        private ArrayList<T> _data;

        private int _modCount;

        private OrderBy _sort;

        public OrderBy Sort
        {
            get => _sort;
            set
            {
                if (_sort != value && Count > 1)
                {
                    _modCount++;
                    _sort = value;
                    var prevData = _data.Reverse().ToArray();
                    Clear();
                    AddRangeItems(prevData);
                }
                else
                {
                    _sort = value;
                }
            }
        }

        public int Count => _data.Count;

        public Heap(OrderBy sort = OrderBy.Desc)
        {
            _data = new();
            _modCount = 0;
            Sort = sort;
        }

        public Heap(T item, OrderBy sort = OrderBy.Desc) : this(sort)
            => _data.Add(item);

        public Heap(IEnumerable<T> rangeItems, OrderBy sort = OrderBy.Desc) : this(sort)
        {
            _data = new(rangeItems.Count());
            AddRangeItems(rangeItems);
        }

        public Heap(Heap<T> heap) : this(heap.ToArray(), heap.Sort) { }

        public void AddItem(T item)
        {
            _modCount++;

            _data.Add(item);

            for (int i = _data.Count - 1; i > 0;)
            {
                int parentId = (i - 1) / 2;

                if (Sort == OrderBy.Desc && _data[i].CompareTo(_data[parentId]) > 0 ||
                    Sort == OrderBy.Asc && _data[i].CompareTo(_data[parentId]) < 0)
                {
                    (_data[i], _data[parentId]) = (_data[parentId], _data[i]);
                }

                i = parentId;
            }
        }

        public void AddRangeItems(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public T FindRoot() => _data.First();

        public T ExtractRoot()
        {
            if (_data.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            _modCount++;

            var root = _data[0];
            _data[0] = _data[^1];
            _data.RemoveAt(_data.Count - 1);

            if (_data.Count > 1)
            {
                for (int i = 0, childId1, childId2, maxChildId = -1; i < _data.Count;)
                {
                    childId1 = 2 * i + 1;
                    childId2 = 2 * i + 2;

                    if (childId2 < _data.Count)
                    {
                        maxChildId = Sort == OrderBy.Desc && _data[childId1].CompareTo(_data[childId2]) > 0 ||
                                     Sort == OrderBy.Asc && _data[childId1].CompareTo(_data[childId2]) < 0 ? childId1 : childId2;
                    }
                    else if (childId1 < _data.Count)
                    {
                        maxChildId = childId1;
                    }

                    if (Sort == OrderBy.Desc && _data[maxChildId].CompareTo(_data[i]) > 0 ||
                        Sort == OrderBy.Asc && _data[maxChildId].CompareTo(_data[i]) < 0)
                    {
                        (_data[maxChildId], _data[i]) = (_data[i], _data[maxChildId]);
                        i = maxChildId;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return root;
        }

        public void Clear()
        {
            _modCount++;
            _data.Clear();
        }

        public bool Contains(T item) => _data.Contains(item);

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0, modNumber = _modCount; i < Count; i++)
            {
                if (modNumber != _modCount)
                {
                    throw new InvalidOperationException("Heap has been changed.");
                }

                yield return _data[i];
            }
        }

        public IEnumerator GetEnumerator() => GetEnumerator();

        public override string ToString() => string.Join(", ", _data);

        public override bool Equals(object? obj)
        {
            var o = obj as Heap<T>;

            if (o is null || o.Count != Count) return false;

            return _data.ToArray().Except((obj as Heap<T>)?.ToArray()).Count() == 0
            && (obj as Heap<T>)?.ToArray().Except(_data.ToArray()).Count() == 0;
        }

        public override int GetHashCode()
            => _data.Select(x => x.GetHashCode() * 47).Sum();
    }
}