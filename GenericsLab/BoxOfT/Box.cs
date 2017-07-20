using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private IList<T> data;
    private T rem;

    public Box()
    {
        this.data = new List<T>();
    }

    public int Count => this.data.Count;

    public void Add(T item)
    {
        this.data.Add(item);
    }
    public T Remove()
    {
        this.rem = this.data.Last();
        this.data.RemoveAt(this.data.Count - 1);
        return this.rem;
    }
}