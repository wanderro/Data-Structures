using System;

namespace DataStructures;

// реализация очереди
public class Queue<T>
{
    private const int DEFAULT_COUNT_ELEMENTS = 3;

    private int _headIndex;
    private int _tailIndex;
    private int _nextIndex;

    private T[] _elements;

    public Queue()
    {
        _elements = new T[DEFAULT_COUNT_ELEMENTS];
    }

    public void Enqueue(T value)
    {
        if (_nextIndex - _headIndex >= _elements.Length)
        {
            ExtendQueue();
        }

        var currentIndex = _nextIndex % _elements.Length;
        _elements[currentIndex] = value;

        ++_nextIndex;
    }

    private void ExtendQueue()
    {
        var newArray = new T[_elements.Length * 2];

        for (int i = 0; i < _elements.Length; i++)
        {
            newArray[i] = _elements[(_headIndex + i) % _elements.Length];
        }

        _headIndex = 0;
        _nextIndex = _elements.Length;
        _elements = newArray;
    }

    public T Dequeue()
    {
        if (_headIndex == _nextIndex)
        {
            throw new IndexOutOfRangeException();
        }

        var result = _elements[_headIndex % _elements.Length];
        ++_headIndex;

        return result;
    }

    public T Peak()
    {
        if (_headIndex == _nextIndex)
        {
            throw new IndexOutOfRangeException();
        }

        return _elements[_headIndex % _elements.Length];
    }
}