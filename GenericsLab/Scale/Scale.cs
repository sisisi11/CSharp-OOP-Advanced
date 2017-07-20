﻿using System;
public class Scale<T>
    where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }

    public T GetHavier()
    {
        if (left.CompareTo(this.right) > 0)
        {
            return this.left;
        }
        else if (left.CompareTo(this.right) < 0)
        {
            return this.right;
        }
        return default(T);
    }
}