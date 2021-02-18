﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
        where T: IComparable
    {
        public EqualityScale(T left , T right)
        {
            Left = left;
            Right = right;
        }
        public T Left { get; set; }
        public T Right { get; set; }

        public bool AreEqual()
        {
            return Left.CompareTo(Right) == 0;
        }
    }
}