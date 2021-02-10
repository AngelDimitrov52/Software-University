﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(value);
                boxes.Add(box);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int indexOne = indexes[0];
            int indexTwo = indexes[1];

            var swapBox = SwapTwoElements(boxes, indexOne, indexTwo);

            foreach (var box in swapBox)
            {        
                Console.WriteLine(box);
            }
        }
        public static List<T> SwapTwoElements<T>(List<T> list, int indexOne, int indexTwo)
        {
            var temp = list[indexOne];
            list[indexOne] = list[indexTwo];
            list[indexTwo] = temp;
            return list;
        }
    }
}
