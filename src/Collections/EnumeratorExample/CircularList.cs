using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorExample;

internal class CircularList<T> : IEnumerable<T>
{
    private List<T> _items = [];

    public CircularList(IEnumerable<T> items)
    {
        _items = this._items.ToList();
    }

    public void Add(T item)
    {
        _items.Add(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        int currentIndex = 0;

        while(true)
        {
            yield return _items[currentIndex];
            currentIndex = (currentIndex + 1) % _items.Count;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
